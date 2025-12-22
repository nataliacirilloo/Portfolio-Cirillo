<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="GUI_Layer.Inicio" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard - Compunents</title>
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
            max-width: 1200px;
            margin: 0 auto;
        }

        /* Tarjeta de bienvenida */
        .welcome-card {
            background: white;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
            border-top: 5px solid #150165;
            padding: 40px;
            margin-bottom: 30px;
            text-align: center;
        }

        .welcome-card h2 {
            color: #150165;
            font-size: 2.5rem;
            font-weight: 700;
            margin-bottom: 15px;
        }

        .welcome-card p {
            color: #6b7280;
            font-size: 1.2rem;
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Barra de navegación superior -->
        <uc:TopBar ID="TopBarControl" runat="server" />

        <div class="main-content">
            <!-- Tarjeta de bienvenida con alertas de corrupción -->
            <div class="welcome-card">
                <h2>Bienvenido!</h2>
                <!-- Área para mostrar alertas de corrupción de datos -->
                <asp:Literal ID="litAlertaCorrupcion" runat="server" />
            </div>
        </div>
    </form>

    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
