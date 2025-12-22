<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiCarrito.aspx.cs" Inherits="GUI_Layer.MiCarrito" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mi Carrito - Compunents</title>
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
            color: #150165;
            font-size: 2.2rem;
            font-weight: 700;
            margin: 0;
            display: flex;
            align-items: center;
            gap: 15px;
        }

        .cart-container {
            background: white;
            border-radius: 15px;
            box-shadow: 0 5px 20px rgba(0, 0, 0, 0.08);
            padding: 25px;
            border: 1px solid #e5e7eb;
        }

        .summary-box {
            background-color: #f9fafb;
            border: 1px solid #e5e7eb;
            border-radius: 15px;
            padding: 25px;
        }

        .summary-box h3 {
            font-size: 1.3rem;
            font-weight: 700;
            color: #150165;
            border-bottom: 2px solid #e5e7eb;
            padding-bottom: 15px;
            margin-bottom: 20px;
        }
        
        .product-table {
            width: 100%;
            border-collapse: separate;
            border-spacing: 0 15px;
        }

        .product-table th {
            text-align: left;
            color: #6b7280;
            font-weight: 600;
            padding-bottom: 10px;
            font-size: 0.9rem;
            text-transform: uppercase;
        }

        .product-table td {
            padding: 15px;
            vertical-align: middle;
            background: #f9fafb;
            border-top: 1px solid #e5e7eb;
            border-bottom: 1px solid #e5e7eb;
        }
        
        .product-table tr td:first-child {
            border-left: 1px solid #e5e7eb;
            border-top-left-radius: 10px;
            border-bottom-left-radius: 10px;
        }
        
        .product-table tr td:last-child {
            border-right: 1px solid #e5e7eb;
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        .product-info-cell {
            display: flex;
            align-items: center;
            gap: 15px;
        }

        .product-info-cell img {
            width: 70px;
            height: 70px;
            object-fit: cover;
            border-radius: 8px;
            background: #e5e7eb;
        }

        .product-info-cell .product-name {
            font-weight: 600;
            color: #111827;
        }
        
        .quantity-controls {
            display: flex;
            align-items: center;
            gap: 8px;
        }
        
        .quantity-btn {
            width: 30px; height: 30px; border: 2px solid #e5e7eb;
            background: white; border-radius: 6px; cursor: pointer;
            transition: all 0.2s ease; font-weight: 600;
        }
        .quantity-btn:hover { border-color: #150165; color: #150165; }

        .quantity-input {
            width: 50px; text-align: center; font-weight: 600;
            border: 2px solid #e5e7eb; border-radius: 8px; padding: 5px;
        }

        .remove-btn {
            background: none; border: none; color: #ef4444; font-size: 1.2rem;
            cursor: pointer; transition: color 0.2s ease;
        }
        .remove-btn:hover { color: #dc2626; }
        
        .form-check { margin-bottom: 15px; }
        .form-check-label { font-weight: 500; }
        .form-control { border: 2px solid #e5e7eb; border-radius: 10px; padding: 12px 15px; }
        .form-control:focus { border-color: #150165; box-shadow: 0 0 0 3px rgba(21, 1, 101, 0.1); outline: none; }
        .form-label { font-weight: 600; color: #374151; margin-bottom: 8px; }

        .summary-line {
            display: flex;
            justify-content: space-between;
            margin-bottom: 15px;
            font-size: 1rem;
        }

        .summary-line.total {
            font-size: 1.4rem;
            font-weight: 700;
            color: #150165;
            border-top: 2px solid #e5e7eb;
            padding-top: 15px;
        }
        
        .btn-proceed-to-payment {
            background: linear-gradient(135deg, #150165 0%, #1d4ed8 100%);
            color: white; border: none; padding: 15px 20px;
            border-radius: 10px; font-weight: 600; transition: all 0.3s ease;
            width: 100%; font-size: 1.1rem; text-align: center;
            display: flex; align-items: center; justify-content: center; gap: 10px;
        }
        .btn-proceed-to-payment:hover {
            transform: translateY(-2px);
            box-shadow: 0 8px 25px rgba(21, 1, 101, 0.4);
            color: white;
            text-decoration: none;
        }
        
        .empty-cart-message {
            text-align: center;
            padding: 60px 20px;
            color: #6b7280;
        }
        .empty-cart-message i {
            font-size: 4rem;
            margin-bottom: 20px;
            color: #d1d5db;
        }
        .btn-continue-shopping {
            background: transparent;
            border: 2px solid #6b7280;
            color: #374151;
            padding: 15px 20px;
            border-radius: 10px;
            font-weight: 600;
            transition: all 0.3s ease;
            width: 100%;
            font-size: 1.1rem;
            text-align: center;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 10px;
            text-decoration: none;
        }

        .btn-continue-shopping:hover {
            background: #374151;
            color: white;
            border-color: #374151;
            text-decoration: none;
        }

        .summary-actions-container {
            display: flex;
            flex-direction: column;
            gap: 10px;
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
                <h1><i class="fas fa-shopping-bag"></i> Mi Carrito</h1>
            </div>

            <div class="row">
                <!-- Sección principal del carrito -->
                <div class="col-lg-8 mb-4">
                    <div class="cart-container">
                        <asp:UpdatePanel ID="updPanelCarrito" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <!-- Panel que se muestra cuando hay productos en el carrito -->
                                <asp:Panel ID="pnlCarritoConItems" runat="server" Visible="false">
                                    <asp:Repeater ID="rptCarrito" runat="server" OnItemCommand="rptCarrito_ItemCommand">
                                        <HeaderTemplate>
                                            <table class="product-table">
                                                <thead>
                                                    <tr>
                                                        <th style="width: 45%;">Producto</th>
                                                        <th style="width: 15%;">Precio</th>
                                                        <th style="width: 20%;">Cantidad</th>
                                                        <th style="width: 15%;">Subtotal</th>
                                                        <th style="width: 5%;"></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <div class="product-info-cell">
                                                        <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# Eval("UrlImagen") ?? "https://via.placeholder.com/70" %>' AlternateText='<%# Eval("Nombre") %>' Width="70px" Height="70px" style="object-fit: cover; border-radius: 8px;" />
                                                        <asp:Label ID="lblNombreProducto" runat="server" Text='<%# Eval("Nombre") %>' CssClass="product-name" />
                                                    </div>
                                                </td>
                                                <td><strong><asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("PrecioUnitario", "{0:C}") %>' /></strong></td>
                                                <td>
                                                    <div class="quantity-controls">
                                                        <asp:Button ID="btnRestar" runat="server" Text="-" CssClass="quantity-btn" CommandName="Restar" CommandArgument='<%# Eval("IdItem") %>' />
                                                        <asp:Label ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>' CssClass="quantity-input"/>
                                                        <asp:Button ID="btnSumar" runat="server" Text="+" CssClass="quantity-btn" CommandName="Sumar" CommandArgument='<%# Eval("IdItem") %>' />
                                                        <asp:LinkButton ID="btnActualizar" runat="server" CommandName="ActualizarCantidad" CommandArgument='<%# Eval("IdItem") %>' CssClass="quantity-btn" ToolTip="Actualizar"><i class="fas fa-sync-alt"></i></asp:LinkButton>
                                                    </div>
                                                </td>
                                                <td><strong><asp:Label ID="lblSubtotal" runat="server" Text='<%# Eval("Subtotal", "{0:C}") %>' /></strong></td>
                                                <td>
                                                    <asp:LinkButton ID="btnEliminar" runat="server" CssClass="remove-btn" ToolTip="Eliminar producto" CommandName="Eliminar" CommandArgument='<%# Eval("IdItem") %>'>
                                                        <i class="fas fa-trash-alt"></i>
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                                </tbody>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </asp:Panel>
                                <!-- Panel que se muestra cuando el carrito está vacío -->
                                <asp:Panel ID="pnlCarritoVacio" runat="server" Visible="false" CssClass="empty-cart-message">
                                    <i class="fas fa-cart-arrow-down"></i>
                                    <h3>Tu carrito está vacío</h3>
                                    <p><a href="Compras.aspx">Explora nuestro catálogo</a> para agregar productos.</p>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <!-- Panel lateral con opciones de envío y resumen -->
                <div class="col-lg-4">
                     <asp:UpdatePanel ID="updPanelResumen" runat="server" UpdateMode="Conditional">
                         <ContentTemplate>
                            <div class="summary-box">
                                <!-- Opciones de envío -->
                                <h3>Opciones de Envío</h3>
                                <div class="form-check">
                                    <asp:RadioButton ID="rbRetiroLocal" runat="server" GroupName="shippingOptions" Checked="true" AutoPostBack="true" OnCheckedChanged="shippingOption_CheckedChanged" />
                                    <label class="form-check-label" for="<%= rbRetiroLocal.ClientID %>">Retiro por el local</label>
                                </div>
                                <div class="form-check">
                                     <asp:RadioButton ID="rbEnvioDomicilio" runat="server" GroupName="shippingOptions" AutoPostBack="true" OnCheckedChanged="shippingOption_CheckedChanged" />
                                     <label class="form-check-label" for="<%= rbEnvioDomicilio.ClientID %>">Envío a domicilio</label>
                                </div>
                                <!-- Dropdown de localidades (se muestra solo si se selecciona envío a domicilio) -->
                                <asp:Panel ID="pnlLocalidades" runat="server" Visible="false" CssClass="mb-3">
                                    <label for="<%= ddlLocalidades.ClientID %>" class="form-label">Seleccione una localidad</label>
                                    <asp:DropDownList ID="ddlLocalidades" runat="server" 
                                        CssClass="form-control"
                                        AutoPostBack="true"
                                        OnSelectedIndexChanged="shippingOption_CheckedChanged">
                                    </asp:DropDownList>
                                </asp:Panel>
                                <!-- Resumen de compra -->
                                <h3 class="mt-4">Resumen de Compra</h3>
                                <div class="summary-line">
                                    <span>Subtotal:</span>
                                    <asp:Label ID="lblSubtotalResumen" runat="server" Text="$0.00"></asp:Label>
                                </div>
                                <div class="summary-line">
                                    <span>Costo de Envío:</span>
                                    <asp:Label ID="lblCostoEnvio" runat="server" Text="$0.00"></asp:Label>
                                </div>
                                <hr />
                                <div class="summary-line total">
                                    <span>TOTAL:</span>
                                    <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
                                </div>
                                <!-- Botones de acción -->
                                <div class="summary-actions-container">
                                    <asp:Button ID="btnProceedToPayment" runat="server" Text="Proceder al Pago" OnClick="btnProceedToPayment_Click" CssClass="btn-proceed-to-payment" />
                    
                                    <asp:HyperLink ID="lnkSeguirComprando" runat="server" 
                                        NavigateUrl="~/Compras.aspx" 
                                        CssClass="btn-continue-shopping"> 
                                        <i class="fas fa-shopping-cart"></i> Seguir Comprando
                                    </asp:HyperLink>
                                </div>                            
                            </div>
                        </ContentTemplate>
                         <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="rptCarrito" EventName="ItemCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
    
    <script type="text/javascript">
        function pageLoad(sender, args) {
            const deliveryOption = document.getElementById('<%= rbEnvioDomicilio.ClientID %>');
            const pickupOption = document.getElementById('<%= rbRetiroLocal.ClientID %>');
            if (deliveryOption && pickupOption) {
                deliveryOption.addEventListener('change', togglePostalCode);
                pickupOption.addEventListener('change', togglePostalCode);
                togglePostalCode(); 
            }
        }
        function togglePostalCode() {
            const deliveryOption = document.getElementById('<%= rbEnvioDomicilio.ClientID %>');
            const postalCodeSection = document.getElementById('postalCodeSection');
            if (deliveryOption && postalCodeSection) {
                postalCodeSection.style.display = deliveryOption.checked ? 'block' : 'none';
            }
        }
    </script>
</body>
</html>