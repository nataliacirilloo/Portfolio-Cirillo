using Business_Logical_Layer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace GUI_Layer
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        UsuarioBLL usuarioBLL = new UsuarioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            OcultarMensajes();

            // 1) Leer token desde querystring
            var token = (Request.QueryString["t"] ?? string.Empty).Trim();
            var email = (Request.QueryString["e"] ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(token))
            {
                MostrarError("Token inválido.");
                DeshabilitarForm();
                return;
            }

            // Guardarlo para el postback (si tenés un HiddenField en el .aspx)
            if (hidToken != null) hidToken.Value = token; 

            if (!usuarioBLL.VerificarToken(token, email))
            {
                MostrarError("El enlace no es válido o está vencido.");
                DeshabilitarForm();
                return;
            }

            MostrarInfo("Ingresá tu nueva contraseña.");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            OcultarMensajes();

            if (!Page.IsValid)
                return;

            var token = hidToken != null && !string.IsNullOrWhiteSpace(hidToken.Value)
                        ? hidToken.Value
                        : (Request.QueryString["t"] ?? string.Empty).Trim();
            var email = (Request.QueryString["e"] ?? string.Empty).Trim();

            if (string.IsNullOrWhiteSpace(token))
            {
                MostrarError("Sesión inválida. Volvé a solicitar el enlace.");
                return;
            }

            var pwd1 = txtNueva.Text ?? "";
            var pwd2 = txtConfirmar.Text ?? "";
            if (!pwd1.Equals(pwd2))
            {
                MostrarError("Las contraseñas no coinciden.");
                return;
            }

            try
            {
                var ok = usuarioBLL.RestablecerContraseña(email, pwd1);

                if (ok)
                {
                    MostrarInfo("Tu contraseña fue restablecida correctamente. Ya podés iniciar sesión.");
                    DeshabilitarForm();
                }
                else
                {
                    MostrarError("No se pudo restablecer la contraseña. El enlace puede estar vencido.");
                }
            }
            catch (Exception)
            {
                MostrarError("Ocurrió un error al actualizar la contraseña. Intentá nuevamente.");
            }
        }

        private void OcultarMensajes()
        {
            if (pnlInfo != null) pnlInfo.Visible = false;
            if (pnlError != null) pnlError.Visible = false;
        }
        private void MostrarInfo(string m)
        {
            if (lblInfo != null) lblInfo.Text = m;
            if (pnlInfo != null) pnlInfo.Visible = true;
        }
        private void MostrarError(string m)
        {
            if (lblError != null) lblError.Text = m;
            if (pnlError != null) pnlError.Visible = true;
        }
        private void DeshabilitarForm()
        {
            if (txtNueva != null) txtNueva.Enabled = false;
            if (txtConfirmar != null) txtConfirmar.Enabled = false;
            if (btnGuardar != null) btnGuardar.Enabled = false;
        }

       
    }
}
