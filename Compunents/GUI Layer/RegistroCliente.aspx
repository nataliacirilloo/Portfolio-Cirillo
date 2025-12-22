<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="GUI_Layer.RegistroCliente" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro - Compunents</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
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
            padding: 8px 10px;
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
</head>
<body>
    <div class="login-container">
        <form id="form1" runat="server">
            <div class="login-card">
                <!-- Encabezado del formulario con logo y título -->
                <div class="login-header">
                   <img src="Content/LogoCompunents.jpg" alt="Logo Compunents" style="max-height: 80px; margin-bottom: 20px;" />
                    <h2>
                        Registro de Cliente
                    </h2>
                </div>

                <!-- Cuerpo del formulario de registro -->
                <div class="login-body">
                    <!-- Panel para mostrar mensajes de error -->
                    <asp:Panel ID="pnlError" runat="server" CssClass="alert-custom d-none">
                        <i class="fas fa-exclamation-triangle me-2"></i>
                        <asp:Label ID="lblResultado" runat="server"></asp:Label>
                    </asp:Panel>

                    <!-- Fila con campos de nombre y apellido -->
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtNombre" class="form-label">
                                    <i class="fas fa-user"></i>
                                    Nombre
                                </label>
                                <asp:TextBox ID="txtNombre" runat="server"
                                    CssClass="form-control"
                                    placeholder="Ingrese su nombre" />
                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                                    ControlToValidate="txtNombre"
                                    ErrorMessage="El nombre es obligatorio"
                                    Display="Dynamic"
                                    CssClass="text-error"
                                    ValidationGroup="RegistroGroup" />
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label for="txtApellido" class="form-label">
                                    <i class="fas fa-user"></i>
                                    Apellido
                                </label>
                                <asp:TextBox ID="txtApellido" runat="server"
                                    CssClass="form-control"
                                    placeholder="Ingrese su apellido" />
                                <asp:RequiredFieldValidator ID="rfvApellido" runat="server"
                                    ControlToValidate="txtApellido"
                                    ErrorMessage="El apellido es obligatorio"
                                    Display="Dynamic"
                                    CssClass="text-error"
                                    ValidationGroup="RegistroGroup" />
                            </div>
                        </div>
                    </div>

                    <!-- Campo de DNI con validación de solo números -->
                    <div class="form-group">
                        <label for="txtDni" class="form-label">
                            <i class="fas fa-id-card"></i>
                            DNI
                        </label>
                        <asp:TextBox ID="txtDni" runat="server"
                            CssClass="form-control"
                            placeholder="Ingrese su DNI" />
                        <asp:RequiredFieldValidator ID="rfvDni" runat="server"
                            ControlToValidate="txtDni"
                            ErrorMessage="El DNI es obligatorio"
                            Display="Dynamic"
                            CssClass="text-error"
                            ValidationGroup="RegistroGroup" />
                        <asp:RegularExpressionValidator ID="revDni" runat="server"
                            ControlToValidate="txtDni"
                            ErrorMessage="El DNI debe contener solo números"
                            ValidationExpression="^\d+$"
                            Display="Dynamic"
                            CssClass="text-error"
                            ValidationGroup="RegistroGroup" />
                    </div>

                    <!-- Campo de email con validación de formato -->
                    <div class="form-group">
                        <label for="txtMail" class="form-label">
                            <i class="fas fa-envelope"></i>
                            Email
                        </label>
                        <asp:TextBox ID="txtMail" runat="server"
                            CssClass="form-control"
                            placeholder="Ingrese su email" />
                        <asp:RequiredFieldValidator ID="rfvMail" runat="server"
                            ControlToValidate="txtMail"
                            ErrorMessage="El email es obligatorio"
                            Display="Dynamic"
                            CssClass="text-error"
                            ValidationGroup="RegistroGroup" />
                        <asp:RegularExpressionValidator ID="revMail" runat="server"
                            ControlToValidate="txtMail"
                            ErrorMessage="Formato de email inválido"
                            ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                            Display="Dynamic"
                            CssClass="text-error"
                            ValidationGroup="RegistroGroup" />
                    </div>

                    <!-- Campo de nombre de usuario -->
                    <div class="form-group">
                        <label for="txtUserName" class="form-label">
                            <i class="fas fa-user-circle"></i>
                            Nombre de Usuario
                        </label>
                        <asp:TextBox ID="txtUserName" runat="server"
                            CssClass="form-control"
                            placeholder="Ingrese su nombre de usuario" />
                        <asp:RequiredFieldValidator ID="rfvUserName" runat="server"
                            ControlToValidate="txtUserName"
                            ErrorMessage="El nombre de usuario es obligatorio"
                            Display="Dynamic"
                            CssClass="text-error"
                            ValidationGroup="RegistroGroup" />
                    </div>

                    <!-- Campo de contraseña -->
                    <div class="form-group">
                        <label for="txtPassword" class="form-label">
                            <i class="fas fa-key"></i>
                            Contraseña
                        </label>
                        <asp:TextBox ID="txtPassword" runat="server"
                            CssClass="form-control"
                            placeholder="Ingrese su contraseña" />
                        <asp:RequiredFieldValidator ID="rfvContraseña" runat="server"
                            ControlToValidate="txtPassword"
                            ErrorMessage="La contraseña es obligatoria"
                            Display="Dynamic"
                            CssClass="text-error"
                            ValidationGroup="RegistroGroup" />
                    </div>

                    <!-- Botones de acción -->
                    <div class="row g-3 button-group">
                        <div class="col-md-6">
                            <asp:Button ID="btnRegistrar" runat="server"
                                Text="Registrar"
                                CssClass="btn-custom btn-success-custom"
                                OnClick="btnRegistrar_Click"
                                ValidationGroup="RegistroGroup" />
                        </div>
                        <div class="col-md-6">
                            <asp:HyperLink ID="lnkVolver" runat="server"
                                NavigateUrl="~/Login.aspx"
                                Text="Volver al Login"
                                CssClass="btn-custom btn-primary-custom" />
                        </div>
                    </div>

                    <!-- Resumen de validaciones -->
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                        HeaderText="Por favor, corrija los siguientes errores:"
                        ValidationGroup="RegistroGroup"
                        CssClass="alert-custom mt-4"
                        DisplayMode="BulletList" />
                </div>
            </div>
        </form>
    </div>

    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
