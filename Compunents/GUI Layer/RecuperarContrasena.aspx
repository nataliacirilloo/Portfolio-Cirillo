<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContrasena.aspx.cs" Inherits="GUI_Layer.RecuperarContrasena" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recuperar contraseña - Compunents</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
        :root{ --primary:#150165; --ring:rgba(37,99,235,.12); --bg:#f3f4f6; }
        body{ background:var(--bg); font-family:'Segoe UI',Tahoma,Geneva,Verdana,sans-serif; margin:0; }
        .page-wrap{ min-height:100vh; display:flex; align-items:center; justify-content:center; padding:24px; }
        .card{ width:100%; max-width:420px; background:#fff; border-radius:24px; box-shadow:0 20px 50px rgba(0,0,0,.10); overflow:hidden; }
        .card-header{ background:var(--primary); color:#fff; text-align:center; padding:32px 24px 24px; }
        .card-header img{ max-height:54px; margin-bottom:14px; }
        .card-header h2{ margin:0; font-size:24px; font-weight:800; }
        .card-body{ padding:24px; }
        .form-label{ font-weight:600; color:#1f2937; display:flex; gap:8px; align-items:center; margin-bottom:6px; }
        .form-label i{ color:var(--primary); }
        .form-control{ height:48px; border:2px solid #e5e7eb; border-radius:12px; background:#f9fafb; padding:12px 14px; }
        .form-control:focus{ background:#fff; border-color:#2563eb; box-shadow:0 0 0 4px var(--ring); }
        .btn-primary{ background:var(--primary); border:0; height:48px; border-radius:14px; font-weight:700; box-shadow:0 8px 24px rgba(21,1,101,.25); }
        .btn-primary:hover{ filter:brightness(1.02); }
        .msg{ border-radius:12px; padding:12px 14px; margin-bottom:14px; display:flex; gap:10px; align-items:flex-start; }
        .msg.info{ background:#ecfeff; border:1px solid #a5f3fc; color:#0e7490; }
        .msg.error{ background:#fef2f2; border:1px solid #fecaca; color:#991b1b; }
        .small-link{ display:inline-block; margin-top:14px; text-decoration:none; color:var(--primary); font-weight:600; }
        .small-link:hover{ text-decoration:underline; }
        .text-error{ color:#ef4444; font-size:.9rem; margin-top:6px; font-weight:500; }
        /* Honeypot */
        .hp{ position:absolute; left:-10000px; top:auto; width:1px; height:1px; overflow:hidden; }
    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <div class="page-wrap">
            <div class="card">
                <div class="card-header">
                    <img src="Content/LogoCompunents.jpg" alt="Logo Compunents" />
                    <h2>Recuperar contraseña</h2>
                </div>
                <div class="card-body">

                    <!-- Mensajes -->
                    <asp:Panel ID="pnlInfo" runat="server" CssClass="msg info" Visible="false">
                        <i class="fas fa-circle-info mt-1"></i>
                        <asp:Label ID="lblInfo" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pnlError" runat="server" CssClass="msg error" Visible="false">
                        <i class="fas fa-triangle-exclamation mt-1"></i>
                        <asp:Label ID="lblError" runat="server" />
                    </asp:Panel>

                    <!-- Email -->
                    <div class="mb-2">
                        <label for="txtEmail" class="form-label">
                            <i class="fas fa-envelope"></i> Correo electrónico
                        </label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="tu@correo.com" />
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server"
                            ControlToValidate="txtEmail"
                            ErrorMessage="El correo es obligatorio"
                            Display="Dynamic" CssClass="text-error" />
                        <asp:RegularExpressionValidator ID="revEmail" runat="server"
                            ControlToValidate="txtEmail"
                            ErrorMessage="Formato de correo inválido"
                            Display="Dynamic" CssClass="text-error"
                            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" />
                    </div>

                    <!-- Honeypot anti-bot -->
                    <div class="hp" aria-hidden="true">
                        <label for="txtCompany">Company</label>
                        <asp:TextBox ID="txtCompany" runat="server" />
                    </div>

                    <!-- Botón -->
                    <div class="d-grid mt-3">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar enlace de recuperación"
                            CssClass="btn btn-primary"
                            OnClick="btnEnviar_Click" />
                    </div>

                    <!-- Volver al login -->
                    <div class="text-center">
                        <asp:HyperLink ID="lnkVolverLogin" runat="server"
                            NavigateUrl="~/Login.aspx"
                            Text="Volver al inicio de sesión"
                            CssClass="small-link" />
                    </div>

                </div>
            </div>
        </div>
    </form>

    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
