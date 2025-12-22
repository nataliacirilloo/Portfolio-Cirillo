using Business_Logical_Layer;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace GUI_Layer
{
    public partial class RecuperarContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Limpia mensajes en cada carga
            pnlInfo.Visible = false;
            pnlError.Visible = false;
        }

        UsuarioBLL usuarioBLL = new UsuarioBLL();

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsValid) return;

                // Honeypot: si viene con texto, es bot
                if (!string.IsNullOrWhiteSpace(txtCompany.Text))
                {
                    // Simular éxito silencioso (no revelar a bots)
                    MostrarInfo("Si el correo existe, te enviaremos un enlace para restablecer tu contraseña.");
                    return;
                }

                var email = (txtEmail.Text ?? string.Empty).Trim().ToLowerInvariant();

                // 1) Verificar si el usuario existe
                if (!usuarioBLL.VerificarUsuarioExiste(email))
                {
                    // Respuesta neutra para no filtrar existencia de cuentas
                    MostrarInfo("Si el correo existe, te enviaremos un enlace para restablecer tu contraseña.");
                    return;
                }

                // 2) Generar token y guardarlo (BD)
                var token = GenerarToken();
                usuarioBLL.GuardarTokenRecuperacion(email, token, DateTime.UtcNow.AddHours(2));

                // 3) Construir URL de reseteo
                var baseUrl = ConfigurationManager.AppSettings["ResetPasswordUrlBase"] ?? "~/ResetPassword.aspx";
                var relative = AgregarQueryString(baseUrl, "t", token);
                relative = AgregarQueryString(relative, "e", email);
                var resetUrl = ToAbsoluteUrl(relative);

                // 4) Enviar correo
                EnviarCorreoRecuperacion(email, resetUrl);

                // 5) Mensaje al usuario
                MostrarInfo("Si el correo existe, te enviamos un enlace para restablecer tu contraseña. Revisá tu bandeja de entrada y spam.");
            }
            catch (Exception ex)
            {
                // Logueá ex según tu logger
                MostrarError(ex.Message);
            }
        }

        private void MostrarInfo(string mensaje)
        {
            lblInfo.Text = mensaje;
            pnlInfo.Visible = true;
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text = mensaje;
            pnlError.Visible = true;
        }


        private string GenerarToken()
        {
            return Guid.NewGuid().ToString("N");
        }

        private string AgregarQueryString(string baseUrl, string key, string value)
        {
            if (string.IsNullOrWhiteSpace(baseUrl)) baseUrl = "~/ResetPassword.aspx";
            var sep = baseUrl.Contains("?") ? "&" : "?";
            return $"{baseUrl}{sep}{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}";
        }

        private string ToAbsoluteUrl(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out var abs)) return abs.ToString();

            var resolved = VirtualPathUtility.ToAbsolute(url);

            var req = HttpContext.Current?.Request;
            if (req == null) return resolved;

            var root = req.Url.GetLeftPart(UriPartial.Authority) + req.ApplicationPath.TrimEnd('/');
            return root + resolved;
        }


        private void EnviarCorreoRecuperacion(string destinatario, string resetUrl)
        {
            using (var smtp = new SmtpClient())
            {
                var fromAddress = ConfigurationManager.AppSettings["Mail.From"] ?? "no-reply@tudominio.com";
                var display = ConfigurationManager.AppSettings["Mail.FromDisplay"] ?? "Compunents";
                var from = new MailAddress(fromAddress, display);

                var mail = new MailMessage
                {
                    From = from,
                    Subject = "Restablecer contraseña",
                    IsBodyHtml = true,
                    Body = $@"
                        <p>Hola,</p>
                        <p>Recibimos una solicitud para restablecer tu contraseña.</p>
                        <p>Hacé clic en el siguiente enlace para continuar:</p>
                        <p><a href=""{resetUrl}"">{resetUrl}</a></p>
                        <p>Si no fuiste vos, ignorá este correo.</p>
                        <p>Este enlace expirará en 2 horas.</p>
                        <p>Saludos,<br/>Compunents</p>"
                };
                mail.To.Add(new MailAddress(destinatario));
                smtp.Send(mail);
            }
        }
    }
}
