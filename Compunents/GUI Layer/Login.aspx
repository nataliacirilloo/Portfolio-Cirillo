<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GUI_Layer.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Compunents</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
        /* Ocultar elementos de autocompletado del navegador */
        input::-ms-reveal,
        input::-ms-clear {
            display: none;
        }

        input[type="password"]::-webkit-credentials-auto-fill-button,
        input[type="password"]::-webkit-inner-spin-button,
        input[type="password"]::-webkit-calendar-picker-indicator {
            display: none !important;
        }

        /* Estilos generales de la página */
        body {
            background-color: #f8f9fa;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
        }

        .login-container {
            min-height: 100vh;
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 20px;
        }

        .login-card {
            background: white;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
            border-top: 5px solid #150165;
            width: 100%;
            max-width: 700px;
            overflow: hidden;
        }

        /* Encabezado del formulario */
        .login-header {
            background: #150165;
            color: white;
            text-align: center;
            padding: 40px 30px;
        }

            .login-header h2 {
                font-size: 2.2rem;
                font-weight: 700;
                margin: 0 0 10px 0;
            }

            .login-header p {
                font-size: 1.1rem;
                margin: 0;
                opacity: 0.9;
            }

        /* Cuerpo del formulario */
        .login-body {
            padding: 50px 40px;
        }

        .form-label {
            font-weight: 600;
            color: #374151;
            margin-bottom: 8px;
            font-size: 1rem;
            display: flex;
            align-items: center;
            gap: 8px;
        }

            .form-label i {
                color: #150165;
                font-size: 1.1rem;
            }

        .form-control {
            border: 2px solid #e5e7eb;
            border-radius: 12px;
            padding: 16px 20px;
            font-size: 1.1rem;
            transition: all 0.3s ease;
            background-color: #f9fafb;
            width: 100%;
        }

            .form-control:focus {
                border-color: #2563eb;
                box-shadow: 0 0 0 3px rgba(37, 99, 235, 0.1);
                background-color: white;
                outline: none;
            }

            .form-control::placeholder {
                color: #9ca3af;
            }

        /* Contenedor para campo de contraseña con botón de mostrar/ocultar */
        .password-container {
            position: relative;
        }

        .password-toggle {
            position: absolute;
            right: 20px;
            top: 50%;
            transform: translateY(-50%);
            background: none;
            border: none;
            color: #6b7280;
            cursor: pointer;
            font-size: 1.1rem;
            padding: 8px;
            border-radius: 6px;
            transition: all 0.2s ease;
        }

            .password-toggle:hover {
                color: #2563eb;
                background-color: rgba(37, 99, 235, 0.1);
            }

        /* Estilos de botones */
        .btn-custom {
            padding: 16px 24px;
            font-size: 1.1rem;
            font-weight: 600;
            border: none;
            border-radius: 12px;
            transition: all 0.3s ease;
            text-decoration: none;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            width: 100%;
        }

        .btn-primary-custom {
            background: #150165;
            color: white;
            box-shadow: 0 4px 15px rgba(37, 99, 235, 0.3);
        }

            .btn-primary-custom:hover {
                transform: translateY(-2px);
                box-shadow: 0 8px 25px rgba(37, 99, 235, 0.4);
                color: white;
            }

        .btn-success-custom {
            background: linear-gradient(135deg, #10b981 0%, #059669 100%);
            color: white;
            box-shadow: 0 4px 15px rgba(16, 185, 129, 0.3);
        }

            .btn-success-custom:hover {
                transform: translateY(-2px);
                box-shadow: 0 8px 25px rgba(16, 185, 129, 0.4);
                color: white;
            }

        /* Enlace de recuperación de contraseña */
        .forgot-link {
            color: #2563eb;
            text-decoration: none;
            font-weight: 500;
            font-size: 1rem;
            transition: all 0.2s ease;
        }

            .forgot-link:hover {
                color: #1d4ed8;
                text-decoration: underline;
            }

        /* Mensajes de error */
        .text-error {
            color: #ef4444;
            font-size: 0.9rem;
            margin-top: 5px;
            font-weight: 500;
        }

        .alert-custom {
            background: linear-gradient(135deg, #fef2f2 0%, #fdf2f8 100%);
            border: 1px solid #fecaca;
            color: #991b1b;
            border-radius: 12px;
            padding: 15px;
            margin-bottom: 25px;
            font-weight: 500;
        }

        .form-group {
            margin-bottom: 25px;
        }

        .button-group {
            margin-bottom: 25px;
        }

        /* Responsive design */
        @media (max-width: 768px) {
            .login-container {
                padding: 15px;
            }

            .login-card {
                max-width: 100%;
                border-radius: 15px;
            }

            .login-header {
                padding: 30px 20px;
            }

                .login-header h2 {
                    font-size: 1.8rem;
                }

            .login-body {
                padding: 30px 25px;
            }

            .form-control {
                padding: 14px 16px;
                font-size: 1rem;
            }

            .btn-custom {
                padding: 14px 20px;
                font-size: 1rem;
            }
        }
    </style>
    <script type="text/javascript">
        // Función para mostrar/ocultar contraseña
        function showPassword() {
            var passwordInput = document.getElementById('<%= txtcontrasela.ClientID %>');
            var toggleBtn = document.getElementById('togglePassword');

            if (passwordInput.type === 'password') {
                passwordInput.type = 'text';
                toggleBtn.innerHTML = '<i class="fas fa-eye-slash"></i>';
            } else {
                passwordInput.type = 'password';
                toggleBtn.innerHTML = '<i class="fas fa-eye"></i>';
            }
        }

        // Función para mostrar errores
        function showError() {
            var errorLabel = document.getElementById('<%= Resultado.ClientID %>');
            var pnlError = document.getElementById('<%= pnlError.ClientID %>');

            if (errorLabel && errorLabel.textContent.trim() !== '') {
                pnlError.classList.remove('d-none');
            } else {
                pnlError.classList.add('d-none');
            }
        }

        // Inicializar al cargar la página
        window.onload = function () {
            showError();
        };
    </script>
</head>
<body>
    <div class="login-container">
        <form id="form1" runat="server">
            <div class="login-card">
                <!-- Encabezado con logo y título -->
                <div class="login-header">
                        <img src="Content/LogoCompunents.jpg" alt="Logo Compunents" style="max-height: 80px; margin-bottom: 20px;" />
                    <h2>
                        Iniciar Sesión
                    </h2>
                </div>

                <!-- Formulario de login -->
                <div class="login-body">
                    <!-- Panel de errores -->
                    <asp:Panel ID="pnlError" runat="server" CssClass="alert-custom d-none">
                        <i class="fas fa-exclamation-triangle me-2"></i>
                        <asp:Label ID="Resultado" runat="server"></asp:Label>
                    </asp:Panel>

                    <!-- Campo de usuario -->
                    <div class="form-group">
                        <label for="txtusername" class="form-label">
                            <i class="fas fa-user"></i>
                            Usuario
                        </label>
                        <asp:TextBox ID="txtusername" runat="server"
                            CssClass="form-control"
                            placeholder="Ingrese su nombre de usuario" />
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server"
                            ControlToValidate="txtusername"
                            ErrorMessage="El usuario es obligatorio"
                            Display="Dynamic"
                            CssClass="text-error"
                            ValidationGroup="LoginGroup" />
                    </div>

                    <!-- Campo de contraseña con botón de mostrar/ocultar -->
                    <div class="form-group">
                        <label for="txtcontrasela" class="form-label">
                            <i class="fas fa-lock"></i>
                            Contraseña
                        </label>
                        <div class="password-container">
                            <asp:TextBox ID="txtcontrasela" runat="server"
                                TextMode="Password"
                                CssClass="form-control"
                                placeholder="Ingrese su contraseña" />
                            <button type="button" id="togglePassword" class="password-toggle"
                                onclick="showPassword(); return false;">
                                <i class="fas fa-eye"></i>
                            </button>
                        </div>
                        <asp:RequiredFieldValidator ID="rfvcontrasena" runat="server"
                            ControlToValidate="txtcontrasela"
                            ErrorMessage="La contraseña es obligatoria"
                            Display="Dynamic"
                            CssClass="text-error"
                            ValidationGroup="LoginGroup" />
                    </div>

                    <!-- Botones de acción -->
                    <div class="row g-3 button-group">
                        <div class="col-md-6">
                            <asp:Button ID="btnLogin" runat="server"
                                Text="Ingresar"
                                CssClass="btn-custom btn-primary-custom"
                                OnClick="btnLogin_Click"
                                ValidationGroup="LoginGroup" />
                        </div>
                        <div class="col-md-6">
                            <asp:HyperLink ID="lnkRegistrarse" runat="server"
                                NavigateUrl="~/RegistroCliente.aspx"
                                Text="Registrarse"
                                CssClass="btn-custom btn-success-custom" />
                        </div>
                    <div class="forgot-wrap mt-3 text-center">
                        <asp:HyperLink ID="lnkOlvidoContrasena" runat="server"
                            NavigateUrl="~/RecuperarContrasena.aspx"
                            Text="¿Olvidaste tu contraseña?"
                            CssClass="forgot-link" />
                    </div>
                    </div>
                    <!-- Resumen de validaciones -->
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                        HeaderText="Por favor, corrija los siguientes errores:"
                        ValidationGroup="LoginGroup"
                        CssClass="alert-custom mt-4"
                        DisplayMode="BulletList" />
                </div>
            </div>
        </form>
    </div>

    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
