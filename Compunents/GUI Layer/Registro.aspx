<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="GUI_Layer.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Usuario</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            padding: 40px;
        }

        .form-container {
            background-color: #fff;
            padding: 30px;
            border-radius: 10px;
            max-width: 400px;
            margin: auto;
            box-shadow: 0px 0px 10px rgba(0,0,0,0.1);
        }

            .form-container h2 {
                text-align: center;
                margin-bottom: 20px;
            }

            .form-container label {
                display: block;
                margin-top: 10px;
                font-weight: bold;
            }

            .form-container input[type="text"],
            .form-container input[type="email"],
            .form-container input[type="password"],
            .form-container select {
                width: 100%;
                padding: 8px;
                margin-top: 5px;
                border-radius: 4px;
                border: 1px solid #ccc;
            }

            .form-container input[type="submit"] {
                margin-top: 20px;
                width: 100%;
                background-color: #3498db;
                color: white;
                padding: 10px;
                border: none;
                border-radius: 4px;
                cursor: pointer;
                font-size: 16px;
            }

                .form-container input[type="submit"]:hover {
                    background-color: #2980b9;
                }

        .message {
            text-align: center;
            margin-top: 15px;
            color: green;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Contenedor del formulario de registro -->
        <div class="form-container">
            <h2>Registro de Usuario</h2>

            <!-- Campo de nombre -->
            <label for="txtNombre">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" />

            <!-- Campo de apellido -->
            <label for="txtApellido">Apellido</label>
            <asp:TextBox ID="txtApellido" runat="server" />

            <!-- Campo de DNI -->
            <label for="txtDni">DNI</label>
            <asp:TextBox ID="txtDni" runat="server" />

            <!-- Campo de email -->
            <label for="txtMail">Email</label>
            <asp:TextBox ID="txtMail" runat="server" TextMode="Email" />

            <!-- Campo de nombre de usuario -->
            <label for="txtUserName">Nombre de Usuario</label>
            <asp:TextBox ID="txtUserName" runat="server" />

            <!-- Campo de contraseña -->
            <label for="txtClave">Contraseña</label>
            <asp:TextBox ID="txtClave" runat="server" TextMode="Password" />

            <!-- Dropdown de perfil -->
            <label for="ddlPerfil">Perfil</label>
            <asp:DropDownList ID="ddlPerfil" runat="server" />

            <!-- Botón de registro -->
            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />

            <!-- Área para mostrar mensajes de resultado -->
            <asp:Label ID="lblResultado" runat="server" CssClass="message" />
        </div>
    </form>
</body>
</html>
