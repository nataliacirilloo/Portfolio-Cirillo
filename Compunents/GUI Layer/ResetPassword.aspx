<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="GUI_Layer.ResetPassword" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Restablecer contraseña - Compunents</title>
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
        .password-container{ position:relative; }
        .password-toggle{ position:absolute; right:12px; top:50%; transform:translateY(-50%); border:0; background:transparent; cursor:pointer; color:#6b7280; padding:6px; border-radius:8px; }
        .password-toggle:hover{ color:#2563eb; background:rgba(37,99,235,.08); }
        .btn-primary{ background:var(--primary); border:0; height:48px; border-radius:14px; font-weight:700; box-shadow:0 8px 24px rgba(21,1,101,.25); }
        .btn-primary:hover{ filter:brightness(1.02); }
        .msg{ border-radius:12px; padding:12px 14px; margin-bottom:14px; display:flex; gap:10px; align-items:flex-start; }
        .msg.info{ background:#ecfeff; border:1px solid #a5f3fc; color:#0e7490; }
        .msg.error{ background:#fef2f2; border:1px solid #fecaca; color:#991b1b; }
        .text-error{ color:#ef4444; font-size:.9rem; margin-top:6px; font-weight:500; }
        .hint{ color:#6b7280; font-size:.9rem; margin-top:6px; }
        .small-link{ display:inline-block; margin-top:14px; text-decoration:none; color:var(--primary); font-weight:600; }
        .small-link:hover{ text-decoration:underline; }
        .disabled-mask{ opacity:.6; pointer-events:none; filter:grayscale(10%); }
    </style>
    <script type="text/javascript">
        function togglePwd(idTxt, idBtn) {
            var inp = document.getElementById(idTxt);
            var btn = document.getElementById(idBtn);
            if (!inp || !btn) return;
            if (inp.type === 'password') {
                inp.type = 'text';
                btn.innerHTML = '<i class="fas fa-eye-slash"></i>';
            } else {
                inp.type = 'password';
                btn.innerHTML = '<i class="fas fa-eye"></i>';
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <div class="page-wrap">
            <div id="card" runat="server" class="card">
                <div class="card-header">
                    <img src="Content/LogoCompunents.jpg" alt="Logo Compunents" />
                    <h2>Restablecer contraseña</h2>
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

                    <!-- Nueva contraseña -->
                    <div class="mb-2">
                        <label class="form-label" for="txtNueva">
                            <i class="fas fa-key"></i> Nueva contraseña
                        </label>
                        <div class="password-container">
                            <asp:TextBox ID="txtNueva" runat="server" TextMode="Password" CssClass="form-control" />
                            <button type="button" id="btnToggleNueva" class="password-toggle"
                                    onclick="togglePwd('<%= txtNueva.ClientID %>','btnToggleNueva')">
                                <i class="fas fa-eye"></i>
                            </button>
                        </div>
                        <asp:RequiredFieldValidator ID="rfvNueva" runat="server"
                            ControlToValidate="txtNueva"
                            ErrorMessage="La contraseña es obligatoria"
                            Display="Dynamic" CssClass="text-error" />
                        <!-- 8-64, al menos 1 mayúscula, 1 minúscula, 1 dígito -->
                        <asp:RegularExpressionValidator ID="revNueva" runat="server"
                            ControlToValidate="txtNueva"
                            ErrorMessage="Debe tener 8 a 64 caracteres, con mayúscula, minúscula y número."
                            Display="Dynamic" CssClass="text-error"
                            ValidationExpression="^(?=.{8,64}$)(?=.*[A-Z])(?=.*[a-z])(?=.*\d).*$" />
                        <div class="hint">Mínimo 8 caracteres. Incluí mayúscula, minúscula y número.</div>
                    </div>

                    <!-- Confirmación -->
                    <div class="mb-2">
                        <label class="form-label" for="txtConfirmar">
                            <i class="fas fa-lock"></i> Confirmar contraseña
                        </label>
                        <div class="password-container">
                            <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" CssClass="form-control" />
                            <button type="button" id="btnToggleConfirmar" class="password-toggle"
                                    onclick="togglePwd('<%= txtConfirmar.ClientID %>','btnToggleConfirmar')">
                                <i class="fas fa-eye"></i>
                            </button>
                        </div>
                        <asp:RequiredFieldValidator ID="rfvConfirmar" runat="server"
                            ControlToValidate="txtConfirmar"
                            ErrorMessage="Confirmá la contraseña"
                            Display="Dynamic" CssClass="text-error" />
                        <asp:CompareValidator ID="cmpPwd" runat="server"
                            ControlToValidate="txtConfirmar" ControlToCompare="txtNueva"
                            ErrorMessage="Las contraseñas no coinciden"
                            Display="Dynamic" CssClass="text-error" />
                    </div>

                    <!-- Botón -->
                    <div class="d-grid mt-3">
                        <asp:Button ID="btnGuardar" runat="server"
                            Text="Restablecer contraseña"
                            CssClass="btn btn-primary"
                            OnClick="btnGuardar_Click" />
                    </div>

                    <div class="text-center">
                        <asp:HyperLink ID="lnkLogin" runat="server"
                            NavigateUrl="~/Login.aspx"
                            Text="Volver a iniciar sesión"
                            CssClass="small-link" />
                    </div>

                    <!-- token a salvo del viewstate -->
                    <asp:HiddenField ID="hidToken" runat="server" />
                </div>
            </div>
        </div>
    </form>

    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
