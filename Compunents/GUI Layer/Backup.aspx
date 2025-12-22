<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Backup.aspx.cs" Inherits="GUI_Layer.Backup" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Backups - Compunents</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/TopBar.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
        /* Estilos generales de la página */
        body {
            background-color: #f8f9fa;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
        }

        .main-content {
            padding: 30px;
            max-width: 1400px;
            margin: 0 auto;
        }

        .page-header {
            background: white;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
            border-top: 5px solid #150165;
            padding: 30px;
            margin-bottom: 30px;
        }

        .page-header h1 {
            color: #150165;
            font-size: 2.2rem;
            font-weight: 700;
            margin: 0;
            display: flex;
            align-items: center;
            gap: 15px;
        }

        .content-card {
            background: white;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
            padding: 40px;
            margin-bottom: 30px;
            text-align: center;
        }
        
        .content-card p {
            font-size: 1.1rem;
            color: #4b5563;
            max-width: 600px;
            margin: 0 auto 30px auto;
        }

        .btn-action {
            color: white;
            border: none;
            padding: 15px 35px;
            border-radius: 12px;
            font-size: 1.1rem;
            font-weight: 600;
            transition: all 0.3s ease;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            gap: 10px;
            text-decoration: none;
            cursor: pointer;
        }

        .btn-action.btn-backup {
            background: linear-gradient(135deg, #150165 0%, #1d4ed8 100%);
        }

        .btn-action.btn-backup:hover {
            transform: translateY(-3px);
            box-shadow: 0 8px 25px rgba(21, 1, 101, 0.4);
        }

        /* Contenedor para mensajes de feedback */
        .feedback-container {
            margin-top: 35px;
            min-height: 50px;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .feedback-message {
            padding: 15px 25px;
            border-radius: 10px;
            font-weight: 500;
            display: inline-block;
        }

        .feedback-success {
            background-color: #d1fae5;
            color: #065f46;
            border: 1px solid #6ee7b7;
        }

        .feedback-error {
            background-color: #fee2e2;
            color: #991b1b;
            border: 1px solid #fca5a5;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Barra de navegación superior -->
        <uc:TopBar ID="TopBarControl" runat="server" />

        <div class="main-content">
            <!-- Encabezado de la página -->
            <div class="page-header">
                <h1>
                    <i class="fas fa-database"></i>
                    Gestión de Backups
                </h1>
            </div>

            <!-- Contenido principal con botones de acción -->
            <div class="content-card">
                <h2>Copia de Seguridad de la Base de Datos</h2>
                <p>
                    Haga clic en el botón para generar una copia de seguridad completa de la base de datos del sistema.
                    El archivo se guardará en una ubicación predefinida en el servidor.
                </p>
                
                <!-- Botón para realizar backup -->
                <asp:Button ID="btnRealizarBackup" runat="server" 
                    Text="Realizar Backup Ahora" 
                    CssClass="btn-action btn-backup" 
                    OnClick="btnRealizarBackup_Click" />

                <!-- Botón para simular corrupción (solo para pruebas) -->
                 <asp:Button ID="btnCorromperDB" runat="server" 
                    Text="Corromper DB" 
                    CssClass="btn-action btn-backup" 
                    OnClick="btnCorromperDB_Click" />

                <!-- Área para mostrar mensajes de resultado -->
                <div class="feedback-container">
                    <asp:Label ID="lblResultado" runat="server" Visible="false" CssClass="feedback-message"></asp:Label>
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>