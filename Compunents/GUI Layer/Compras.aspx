<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="GUI_Layer.Compras" %>

<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>
<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Compras - Compunents</title>
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
     .badge {
    position: absolute;
    top: 10px;
    left: 10px;
    z-index: 10;
    background-color: #10b981;
    color: white;
    padding: 5px 10px;
    border-radius: 5px;
    font-size: 0.8rem;
    font-weight: bold;
}

    .badge-success {
        background-color: #10b981;
    }

    .badge-warning {
        background-color: #f59e0b;
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

        .filters-section {
            background: white;
            border-radius: 15px;
            padding: 25px;
            margin-bottom: 30px;
            box-shadow: 0 5px 20px rgba(0, 0, 0, 0.08);
        }

        .filters-grid {
            display: grid;
            grid-template-columns: 1fr 200px 200px 150px;
            gap: 20px;
            align-items: end;
        }

        .form-group {
            margin-bottom: 0;
        }

        .form-label {
            font-weight: 600;
            color: #374151;
            margin-bottom: 8px;
            font-size: 0.95rem;
            display: block;
        }

        .form-control {
            border: 2px solid #e5e7eb;
            border-radius: 10px;
            padding: 12px 15px;
            font-size: 1rem;
            transition: all 0.3s ease;
            background-color: #f9fafb;
            width: 100%;
        }

            .form-control:focus {
                border-color: #150165;
                box-shadow: 0 0 0 3px rgba(21, 1, 101, 0.1);
                background-color: white;
                outline: none;
            }

        .btn-search {
            background: linear-gradient(135deg, #150165 0%, #1d4ed8 100%);
            color: white;
            border: none;
            padding: 12px 20px;
            border-radius: 10px;
            font-weight: 600;
            transition: all 0.3s ease;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
        }

            .btn-search:hover {
                transform: translateY(-2px);
                box-shadow: 0 8px 25px rgba(21, 1, 101, 0.4);
            }

        .products-grid {
            display: grid;
            grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
            gap: 25px;
            margin-bottom: 30px;
        }

        .product-card {
            background: white;
            border-radius: 15px;
            overflow: hidden;
            box-shadow: 0 5px 20px rgba(0, 0, 0, 0.08);
            transition: all 0.3s ease;
            border: 1px solid #e5e7eb;
            height: 480px;
            display: flex;
            flex-direction: column;
        }

            .product-card:hover {
                transform: translateY(-5px);
                box-shadow: 0 15px 40px rgba(0, 0, 0, 0.15);
            }

        .product-image {
            width: 100%;
            height: 200px;
            background: linear-gradient(135deg, #f3f4f6 0%, #e5e7eb 100%);
            display: flex;
            align-items: center;
            justify-content: center;
            overflow: hidden;
            position: relative;
            flex-shrink: 0;
        }

            .product-image img {
                width: 100%;
                height: 100%;
                object-fit: contain;
                object-position: center;
                transition: transform 0.3s ease;
            }

        .product-card:hover .product-image img {
            transform: scale(1.02);
        }

        .product-image .no-image {
            color: #9ca3af;
            font-size: 3rem;
        }

        .product-info {
            padding: 20px;
            display: flex;
            flex-direction: column;
            flex-grow: 1;
            justify-content: space-between;
        }

        .product-details {
            flex-grow: 1;
        }

        .product-name {
            font-size: 1.2rem;
            font-weight: 700;
            color: #150165;
            margin-bottom: 8px;
            height: 1.5em;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
        }

        .product-description {
            color: #6b7280;
            font-size: 0.95rem;
            margin-bottom: 15px;
            line-height: 1.4;
            height: 2.8em;
            overflow: hidden;
            display: -webkit-box;
            -webkit-line-clamp: 2;
            -webkit-box-orient: vertical;
        }

        .product-price {
            font-size: 1.5rem;
            font-weight: 700;
            color: #059669;
            margin-bottom: 10px;
        }

        .product-stock {
            font-size: 0.9rem;
            color: #6b7280;
            margin-bottom: 15px;
        }

        .product-actions {
            display: flex;
            gap: 10px;
            margin-top: auto;
        }

        .btn-add-cart {
            background: linear-gradient(135deg, #10b981 0%, #059669 100%);
            color: white;
            border: none;
            padding: 10px 15px;
            border-radius: 8px;
            font-weight: 600;
            flex: 1;
            transition: all 0.3s ease;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
        }

            .btn-add-cart:hover {
                transform: translateY(-2px);
                box-shadow: 0 8px 25px rgba(16, 185, 129, 0.4);
            }

        .quantity-input {
            width: 60px;
            border: 2px solid #e5e7eb;
            border-radius: 8px;
            padding: 8px;
            text-align: center;
            font-weight: 600;
        }

        /* Widget de Carrito Flotante */
        .cart-widget {
            position: fixed;
            top: 50%;
            right: -350px;
            transform: translateY(-50%);
            width: 350px;
            max-height: 80vh;
            background: white;
            border-radius: 20px 0 0 20px;
            box-shadow: -10px 0 30px rgba(0, 0, 0, 0.2);
            z-index: 1000;
            transition: all 0.4s cubic-bezier(0.4, 0, 0.2, 1);
            border-left: 5px solid #150165;
        }

            .cart-widget.open {
                right: 0;
            }

        .cart-toggle {
            position: absolute;
            left: -60px;
            top: 50%;
            transform: translateY(-50%);
            width: 60px;
            height: 60px;
            background: linear-gradient(135deg, #150165 0%, #1d4ed8 100%);
            border: none;
            border-radius: 15px 0 0 15px;
            color: white;
            font-size: 1.5rem;
            cursor: pointer;
            transition: all 0.3s ease;
            display: flex;
            align-items: center;
            justify-content: center;
            box-shadow: -5px 0 15px rgba(21, 1, 101, 0.3);
        }

            .cart-toggle:hover {
                background: linear-gradient(135deg, #1d4ed8 0%, #2563eb 100%);
                transform: translateY(-50%) translateX(-5px);
            }

        .cart-badge {
            position: absolute;
            top: -8px;
            left: -8px;
            background: #ef4444;
            color: white;
            border-radius: 50%;
            width: 24px;
            height: 24px;
            font-size: 0.8rem;
            font-weight: 700;
            display: flex;
            align-items: center;
            justify-content: center;
            animation: pulse 2s infinite;
        }

        @keyframes pulse {
            0%, 100% {
                transform: scale(1);
            }

            50% {
                transform: scale(1.1);
            }
        }

        .cart-header {
            padding: 20px;
            border-bottom: 2px solid #f3f4f6;
            background: linear-gradient(135deg, #150165 0%, #1d4ed8 100%);
            color: white;
            border-radius: 15px 0 0 0;
        }

            .cart-header h3 {
                margin: 0;
                font-size: 1.3rem;
                font-weight: 700;
                display: flex;
                align-items: center;
                gap: 10px;
            }

        .cart-content {
            max-height: 400px;
            overflow-y: auto;
            padding: 0;
        }

        .cart-item {
            padding: 15px 20px;
            border-bottom: 1px solid #f3f4f6;
            transition: all 0.3s ease;
        }

            .cart-item:hover {
                background-color: #f9fafb;
            }

            .cart-item:last-child {
                border-bottom: none;
            }

        .cart-item-info {
            display: flex;
            gap: 12px;
            margin-bottom: 10px;
        }

        .cart-item-image {
            width: 50px;
            height: 50px;
            background: #f3f4f6;
            border-radius: 8px;
            display: flex;
            align-items: center;
            justify-content: center;
            flex-shrink: 0;
        }

            .cart-item-image img {
                width: 100%;
                height: 100%;
                object-fit: cover;
                border-radius: 8px;
            }

            .cart-item-image i {
                color: #9ca3af;
                font-size: 1.2rem;
            }

        .cart-item-details {
            flex-grow: 1;
        }

        .cart-item-name {
            font-weight: 600;
            color: #150165;
            font-size: 0.95rem;
            margin-bottom: 4px;
            line-height: 1.2;
        }

        .cart-item-price {
            color: #059669;
            font-weight: 700;
            font-size: 0.9rem;
        }

        .cart-item-controls {
            display: flex;
            align-items: center;
            justify-content: space-between;
            gap: 10px;
        }

        .quantity-controls {
            display: flex;
            align-items: center;
            gap: 8px;
        }

        .quantity-btn {
            width: 28px;
            height: 28px;
            border: 2px solid #e5e7eb;
            background: white;
            border-radius: 6px;
            display: flex;
            align-items: center;
            justify-content: center;
            cursor: pointer;
            transition: all 0.2s ease;
            font-weight: 600;
            color: #374151;
        }

            .quantity-btn:hover {
                border-color: #150165;
                color: #150165;
            }

        .quantity-display {
            min-width: 30px;
            text-align: center;
            font-weight: 600;
            color: #374151;
        }

        .remove-btn {
            background: none;
            border: none;
            color: #ef4444;
            cursor: pointer;
            padding: 4px;
            border-radius: 4px;
            transition: all 0.2s ease;
        }

            .remove-btn:hover {
                background-color: #fef2f2;
                color: #dc2626;
            }

        .cart-footer {
            padding: 20px;
            border-top: 2px solid #f3f4f6;
            background: #f9fafb;
        }

        .cart-total {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 15px;
            font-size: 1.2rem;
            font-weight: 700;
        }

        .cart-total-label {
            color: #374151;
        }

        .cart-total-amount {
            color: #059669;
        }

        .cart-actions {
            display: flex;
            gap: 10px;
        }

        .btn-cart-action {
            flex: 1;
            padding: 12px;
            border: none;
            border-radius: 10px;
            font-weight: 600;
            cursor: pointer;
            transition: all 0.3s ease;
            text-decoration: none;
            display: flex;
            align-items: center;
            justify-content: center;
            gap: 8px;
        }

        .disabled-link {
            background: #e5e7eb !important; /* fondo gris claro */
            color: #9ca3af !important; /* texto gris */
            border: none !important;
            opacity: 1 !important;
            pointer-events: none;
            cursor: not-allowed;
            box-shadow: none !important;
        }

        .btn-view-cart {
            background: linear-gradient(135deg, #6b7280 0%, #4b5563 100%);
            color: white;
        }

            .btn-view-cart:hover {
                transform: translateY(-2px);
                box-shadow: 0 8px 25px rgba(107, 114, 128, 0.4);
                color: white;
            }

        .btn-checkout {
            background: linear-gradient(135deg, #150165 0%, #1d4ed8 100%);
            color: white;
        }

            .btn-checkout:hover {
                transform: translateY(-2px);
                box-shadow: 0 8px 25px rgba(21, 1, 101, 0.4);
                color: white;
            }

        .cart-empty {
            padding: 40px 20px;
            text-align: center;
            color: #6b7280;
        }

            .cart-empty i {
                font-size: 3rem;
                margin-bottom: 15px;
                color: #d1d5db;
            }

            .cart-empty h4 {
                margin-bottom: 8px;
                color: #374151;
            }

        .empty-state {
            text-align: center;
            padding: 60px 20px;
            color: #6b7280;
        }

            .empty-state i {
                font-size: 4rem;
                margin-bottom: 20px;
                color: #d1d5db;
            }

        .toast-notification {
            position: fixed;
            top: 20px;
            right: 20px;
            background: white;
            border-left: 4px solid #10b981;
            border-radius: 8px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.15);
            padding: 15px 20px;
            display: flex;
            align-items: center;
            gap: 12px;
            z-index: 2000;
            transform: translateX(120%);
            transition: transform 0.3s ease;
        }

            .toast-notification.show {
                transform: translateX(0);
            }

        .toast-icon {
            background: #ecfdf5;
            width: 40px;
            height: 40px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            color: #10b981;
            font-size: 1.2rem;
        }

        .toast-content {
            flex-grow: 1;
        }

        .toast-title {
            font-weight: 700;
            color: #111827;
            margin-bottom: 4px;
        }

        .toast-message {
            color: #6b7280;
            font-size: 0.9rem;
        }

        .toast-close {
            background: none;
            border: none;
            color: #9ca3af;
            cursor: pointer;
            font-size: 1.1rem;
            padding: 4px;
            transition: color 0.2s ease;
        }

            .toast-close:hover {
                color: #4b5563;
            }

        @media (max-width: 768px) {
            .main-content {
                padding: 20px;
            }

            .filters-grid {
                grid-template-columns: 1fr;
                gap: 15px;
            }

            .products-grid {
                grid-template-columns: 1fr;
            }

            .product-card {
                height: auto;
            }

            .cart-widget {
                width: 100%;
                right: -100%;
                border-radius: 0;
                max-height: 100vh;
            }

            .cart-toggle {
                left: -50px;
                width: 50px;
                height: 50px;
                border-radius: 10px 0 0 10px;
            }

            .toast-notification {
                width: calc(100% - 40px);
                max-width: 400px;
            }
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
                <h1><i class="fas fa-shopping-cart"></i>Catálogo de Productos</h1>
            </div>

            <!-- Filtros de búsqueda -->
            <asp:Panel ID="pnlFiltros" runat="server" CssClass="filters-section" DefaultButton="btnBuscar">
                <div class="filters-grid">
                    <div class="form-group">
                        <label class="form-label">Buscar productos</label>
                        <asp:TextBox ID="txtBuscar" runat="server"
                            CssClass="form-control"
                            placeholder="Nombre del producto..."
                            onkeypress="return handleEnterKey(event);" />
                    </div>
                    <div class="form-group">
                        <label class="form-label">Categoría</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">Todas las categorías</asp:ListItem>
                            <asp:ListItem Value="Hardware">Hardware</asp:ListItem>
                            <asp:ListItem Value="Software">Software</asp:ListItem>
                            <asp:ListItem Value="Accesorio">Accesorios</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Precio máximo</label>
                        <asp:TextBox ID="txtPrecioMax" runat="server"
                            CssClass="form-control"
                            placeholder="$0.00"
                            TextMode="Number"
                            onkeypress="return handleEnterKey(event);" />
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnBuscar" runat="server"
                            Text="Buscar"
                            CssClass="btn-search"
                            OnClick="btnBuscar_Click" />
                    </div>
                </div>
            </asp:Panel>

            <!-- Grid de productos -->
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                  <asp:Repeater ID="rptProductos" runat="server" 
    OnItemCommand="rptProductos_ItemCommand"
    OnItemDataBound="rptProductos_ItemDataBound">

                        <HeaderTemplate>
                            <div class="products-grid">
                        </HeaderTemplate>
               <ItemTemplate>
    <div class="product-card">
        <div class="product-image">
            <asp:Image ID="imgProducto" runat="server"
                ImageUrl='<%# Eval("UrlImagen", "{0}") ?? "https://via.placeholder.com/200" %>'
                AlternateText='<%# Eval("Nombre") %>' />

            <!-- 👇 Este panel se controla en ItemDataBound -->
            <asp:Panel ID="pnlMasVendido" runat="server" Visible="false" CssClass="badge badge-success">
                MÁS VENDIDO
            </asp:Panel>
        </div>
        <div class="product-info">
            <div class="product-details">
                <div class="product-name"><%# Eval("Nombre") %></div>
                <div class="product-description"><%# Eval("Descripcion") %></div>
                <div class="product-price">$<%# Eval("Precio", "{0:N2}") %></div>
                <div class="product-stock">Stock disponible: <%# Eval("Stock") %> unidades</div>
            </div>
            <div class="product-actions">
                <asp:TextBox ID="txtCantidad" runat="server"
                    CssClass="quantity-input"
                    Text="1"
                    TextMode="Number"
                    min="1"
                    max='<%# Eval("Stock") %>'
                    Enabled='<%# Convert.ToInt32(Eval("Stock")) > 0 %>' />

                <asp:LinkButton ID="btnAgregarCarrito" runat="server"
                    CssClass='<%# Convert.ToInt32(Eval("Stock")) > 0 ? "btn-add-cart" : "btn-add-cart disabled-link" %>'
                    Enabled='<%# Convert.ToInt32(Eval("Stock")) > 0 %>'
                    CommandName="AgregarCarrito"
                    CommandArgument='<%# Eval("Id") %>'>
                        <i class="fas fa-shopping-cart"></i>
                        <%# Convert.ToInt32(Eval("Stock")) > 0 ? "Agregar" : "Sin stock" %>
                </asp:LinkButton>
            </div>
        </div>
    </div>
</ItemTemplate>

                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <!-- Mensaje cuando no hay productos -->
                    <asp:Panel ID="pnlEmpty" runat="server" Visible="false" CssClass="empty-state"></asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- Widget de Carrito Flotante -->
        <div class="cart-widget" id="cartWidget">
            <asp:UpdatePanel ID="updPanelWidget" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- Botón para abrir/cerrar el carrito -->
                    <button type="button" class="cart-toggle" onclick="toggleCart(); return false;">
                        <i class="fas fa-shopping-cart"></i>
                        <span class="cart-badge" id="cartBadge" runat="server">0</span>
                    </button>
                    <!-- Encabezado del carrito -->
                    <div class="cart-header">
                        <h3><i class="fas fa-shopping-bag"></i>Mi Carrito</h3>
                    </div>
                    <!-- Contenido del carrito -->
                    <div class="cart-content" id="cartContent">
                        <!-- Lista de productos en el carrito -->
                        <asp:Panel ID="pnlWidgetItems" runat="server" Visible="false">
                            <asp:Repeater ID="rptWidgetCarrito" runat="server" OnItemCommand="rptWidgetCarrito_ItemCommand">
                                <ItemTemplate>
                                    <div class="cart-item">
                                        <div class="cart-item-info">
                                            <div class="cart-item-image">
                                                <asp:Image ID="imgWidgetProducto" runat="server" ImageUrl='<%# Eval("UrlImagen") ?? "https://via.placeholder.com/50" %>' alt='<%# Eval("Nombre") %>' />
                                            </div>
                                            <div class="cart-item-details">
                                                <div class="cart-item-name"><%# Eval("Nombre") %></div>
                                                <div class="cart-item-price"><%# Eval("PrecioUnitario", "{0:C}") %> c/u</div>
                                            </div>
                                        </div>
                                        <div class="cart-item-controls">
                                            <div class="quantity-controls">
                                                <asp:Button ID="btnRestar" runat="server" Text="-" CssClass="quantity-btn" CommandName="Restar" CommandArgument='<%# Eval("IdItem") %>' />
                                                <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>' CssClass="quantity-display" />
                                                <asp:Button ID="btnSumar" runat="server" Text="+" CssClass="quantity-btn" CommandName="Sumar" CommandArgument='<%# Eval("IdItem") %>' />
                                            </div>
                                            <asp:LinkButton ID="btnEliminar" runat="server" CssClass="remove-btn" ToolTip="Eliminar producto" CommandName="Eliminar" CommandArgument='<%# Eval("IdItem") %>'>
                                                        <i class="fas fa-trash"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </asp:Panel>

                        <!-- Mensaje cuando el carrito está vacío -->
                        <asp:Panel ID="pnlWidgetVacio" runat="server" CssClass="cart-empty" Visible="true">
                            <i class="fas fa-shopping-cart"></i>
                            <h4>Tu carrito está vacío</h4>
                        </asp:Panel>
                    </div>

                    <!-- Pie del carrito con total y botones de acción -->
                    <asp:Panel ID="pnlWidgetFooter" runat="server" CssClass="cart-footer" Visible="false">
                        <div class="cart-total">
                            <span class="cart-total-label">Total:</span>
                            <asp:Label ID="lblWidgetTotal" runat="server" Text="$0.00" CssClass="cart-total-amount" />
                        </div>
                        <div class="cart-actions">
                            <asp:HyperLink ID="lnkVerCarrito" runat="server" NavigateUrl="~/MiCarrito.aspx" CssClass="btn-cart-action btn-view-cart">
                                        <i class="fas fa-eye"></i> Ver Carrito
                            </asp:HyperLink>
                            <asp:HyperLink ID="lnkComprar" runat="server" NavigateUrl="~/Checkout.aspx" CssClass="btn-cart-action btn-checkout">
                                        Comprar
                            </asp:HyperLink>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="rptProductos" EventName="ItemCommand" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

        <!-- Notificación Toast -->
        <div class="toast-notification" id="toastNotification">
            <div class="toast-icon">
                <i class="fas fa-check"></i>
            </div>
            <div class="toast-content">
                <div class="toast-title">Compunents</div>
                <div class="toast-message" id="toastMessage">Producto agregado al carrito</div>
            </div>
            <button type="button" class="toast-close" onclick="hideToast()">
                <i class="fas fa-times"></i>
            </button>
        </div>
    </form>

    <script type="text/javascript">
        let isCartOpen = false;
        function toggleCart() {
            const cartWidget = document.getElementById('cartWidget');
            isCartOpen = !isCartOpen;
            if (cartWidget) {
                cartWidget.classList.toggle('open', isCartOpen);
            }
            return false;
        }

        function showToast(message) {
            if (!message || message.trim() === "") return;
            const toast = document.getElementById('toastNotification');
            const toastMessage = document.getElementById('toastMessage');
            if (toast && toastMessage) {
                toastMessage.textContent = message;
                toast.classList.add('show');
                setTimeout(() => { toast.classList.remove('show'); }, 3000);
            }
        }

        function hideToast() {
            var toast = document.getElementById('toastNotification');
            if (toast) {
                toast.classList.remove('show');
            }
        }
    </script>

</body>
</html>
