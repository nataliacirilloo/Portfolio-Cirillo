<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdenConfirmada.aspx.cs" Inherits="GUI_Layer.OrdenConfirmada" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>¡Compra Confirmada! - Compunents</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/TopBar.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
        .main-content {
            padding: 40px;
            max-width: 800px; 
            margin: 0 auto;
        }
        .confirmation-card {
            background: white;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
            padding: 40px 50px;
            text-align: center;
            border-top: 5px solid #10b981; 
            display: flex;
            flex-direction: column;
            align-items: center;
        }
        .confirmation-icon {
            font-size: 5rem;
            color: #10b981;
            margin-bottom: 20px;
        }
        .confirmation-title {
            font-size: 2.5rem;
            font-weight: 700;
            color: #150165;
            margin-bottom: 15px;
        }
        .confirmation-text {
            font-size: 1.1rem;
            color: #6b7280;
            max-width: 500px;
            margin-bottom: 30px;
        }
        .order-number-box {
            background-color: #eefbf5;
            border: 2px dashed #10b981;
            border-radius: 10px;
            padding: 15px 25px;
            margin-bottom: 30px;
        }
        .order-number-box .label {
            font-weight: 600;
            color: #374151;
            display: block;
            margin-bottom: 5px;
        }
        .order-number-box .number {
            font-size: 2rem;
            font-weight: 700;
            color: #059669;
            letter-spacing: 2px;
        }
        .confirmation-actions {
            display: flex;
            gap: 15px;
            margin-top: 20px;
        }
        .btn-action {
            padding: 12px 25px;
            border-radius: 10px;
            font-weight: 600;
            text-decoration: none;
            transition: all 0.3s ease;
            display: inline-flex;
            align-items: center;
            gap: 8px;
        }
        .btn-primary-action {
            background: linear-gradient(135deg, #150165 0%, #1d4ed8 100%);
            color: white;
        }
        .btn-primary-action:hover {
             transform: translateY(-2px);
             box-shadow: 0 8px 25px rgba(21, 1, 101, 0.4);
             color: white;
        }
        .btn-secondary-action {
            background: transparent;
            border: 2px solid #6b7280;
            color: #374151;
        }
        .btn-secondary-action:hover {
            background: #374151;
            color: white;
        }
    </style>
</head>
    <body>
        <form id="form1" runat="server">
            <uc:TopBar ID="TopBarControl" runat="server" />
            <div class="main-content">
                <div class="confirmation-card">
                    <div class="confirmation-icon">
                        <i class="fas fa-check-circle"></i>
                    </div>
                    <h1 class="confirmation-title">¡Gracias por tu compra!</h1>
                    <!-- Texto de confirmacion -->
                    <p class="confirmation-text">
                        Tu pedido ha sido procesado con éxito. Hemos enviado un resumen de la compra a tu correo electrónico.
                    </p>
                    <div class="order-number-box">
                        <span class="label">Tu número de pedido es:</span>
                        <asp:Label ID="lblNumeroPedido" runat="server" Text="000000" CssClass="number"></asp:Label>
                    </div>
                    <!-- Botones de accion -->
                    <div class="confirmation-actions">
                        <asp:HyperLink ID="lnkMisCompras" runat="server" NavigateUrl="~/MisCompras.aspx" CssClass="btn-action btn-primary-action">
                            <i class="fas fa-history"></i> Ver mis Pedidos
                        </asp:HyperLink>
                        <asp:HyperLink ID="lnkSeguirComprando" runat="server" NavigateUrl="~/Compras.aspx" CssClass="btn-action btn-secondary-action">
                            <i class="fas fa-shopping-cart"></i> Seguir Comprando
                        </asp:HyperLink>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>