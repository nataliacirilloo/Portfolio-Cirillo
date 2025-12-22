<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="GUI_Layer.MisCompras" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mis Compras - Compunents</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/TopBar.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
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
            margin: 0;
            font-size: 2rem;
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .order-card {
            background: white;
            border-radius: 15px;
            margin-bottom: 20px;
            box-shadow: 0 4px 15px rgba(0,0,0,0.07);
            border: 1px solid #e5e7eb;
        }

.order-header {
    padding: 20px 25px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    cursor: pointer;
    gap: 20px;
    flex-wrap: wrap;
}

.order-header-info,
.order-header-status,
.order-header-total {
    flex: 1 1 0;
    min-width: 0;
}

.order-header-status {
    display: flex;
    justify-content: center;
}

.order-header-total {
    text-align: right;
}


        .order-header-info span {
            display: block;
        }

        .order-id {
            font-weight: 700;
            font-size: 1.1rem;
            color: #150165;
        }

        .order-date {
            font-size: 0.9rem;
            color: #6b7280;
        }

        .order-header-status .status-badge {
            padding: 5px 12px;
            border-radius: 20px;
            font-weight: 600;
            font-size: 0.85rem;
            color: white;
        }

        .status-confirmado { background-color: #059669; }
        .status-enviado { background-color: #3b82f6; }
        .status-cancelado { background-color: #ef4444; }

        .order-header-total {
            text-align: right;
        }

        .order-total-amount {
            font-size: 1.5rem;
            font-weight: 700;
            color: #111827;
        }

        .order-details {
            padding: 25px;
            border-top: 1px solid #e5e7eb;
            background-color: #f9fafb;
        }

        .order-product-item {
            display: flex;
            align-items: center;
            gap: 15px;
            padding: 10px 0;
            border-bottom: 1px solid #e5e7eb;
        }

        .order-product-item:last-child {
            border-bottom: none;
        }

        .text-center a {
            color: #150165;
            font-weight: 600;
        }

        .text-center a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Barra de navegación superior -->
        <uc:TopBar ID="TopBarControl" runat="server" />

        <div class="main-content">
            <!-- Encabezado de la página -->
            <div class="page-header">
                <h1><i class="fas fa-history"></i> Mis Compras</h1>
            </div>

            <!-- Panel que se muestra cuando hay pedidos -->
            <asp:Panel ID="pnlConPedidos" runat="server">
                <div id="accordionPedidos">
                    <asp:Repeater ID="rptPedidos" runat="server" OnItemDataBound="rptPedidos_ItemDataBound">
                        <ItemTemplate>
                            <div class="order-card">
                                <!-- Encabezado del pedido con información básica -->
                                <div class="order-header" data-toggle="collapse" href='<%# "#collapse" + Eval("IdPedido") %>' aria-expanded="false" aria-controls='<%# "collapse" + Eval("IdPedido") %>'>
                                    <div class="order-header-info">
                                        <span class="order-id">Pedido #<%# Eval("IdPedido", "{0:D6}") %></span>
                                        <span class="order-date">Fecha: <%# Eval("FechaPedido", "{0:dd/MM/yyyy}") %></span>
                                    </div>
                                    <div class="order-header-status">
                                        <span class='status-badge status-<%# Eval("Estado").ToString().ToLower() %>'>
                                            <%# Eval("Estado") %>
                                        </span>
                                    </div>
                                    <div class="order-header-total">
                                        <span class="order-total-amount"><%# Eval("Total", "{0:C}") %></span>
                                        <span><%# Eval("MetodoPago") %></span>
                                    </div>
                                </div>
                                <!-- Detalles del pedido (se expande al hacer clic) -->
                                <div id='<%# "collapse" + Eval("IdPedido") %>' class="collapse order-details" data-parent="#accordionPedidos">
                                    <h5>Detalle del Pedido</h5>
                                    <asp:Repeater ID="rptDetallePedido" runat="server">
                                        <ItemTemplate>
                                            <div class="order-product-item">
                                                <asp:Image runat="server" ImageUrl='<%# Eval("UrlImagen") ?? "https://via.placeholder.com/60" %>' Width="60px" Height="60px" style="border-radius: 8px;" />
                                                <div style="flex-grow: 1;">
                                                    <div style="font-weight: 600;"><%# Eval("NombreProducto") %></div>
                                                    <span><%# Eval("Cantidad") %> x <%# Eval("PrecioUnitario", "{0:C}") %></span>
                                                </div>
                                                <strong style="font-size: 1.1rem;"><%# (Convert.ToInt32(Eval("Cantidad")) * Convert.ToDecimal(Eval("PrecioUnitario"))).ToString("C") %></strong>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </asp:Panel>

            <!-- Panel que se muestra cuando no hay pedidos -->
            <asp:Panel ID="pnlSinPedidos" runat="server" CssClass="text-center p-5 bg-light rounded" Visible="false">
                <h4>Aún no has realizado ninguna compra.</h4>
                <p>¡<a href="Compras.aspx">Explora nuestro catálogo</a> y encuentra los mejores componentes!</p>
            </asp:Panel>
        </div>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.2/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
