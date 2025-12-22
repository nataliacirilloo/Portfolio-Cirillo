<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="GUI_Layer.Checkout" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Finalizar Compra - Compunents</title>
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
        .checkout-container {
            display: grid;
            grid-template-columns: 2fr 3fr;
            gap: 30px;
        }
        .order-summary, .payment-options {
            background: white;
            border-radius: 15px;
            padding: 25px;
            box-shadow: 0 5px 20px rgba(0,0,0,0.08);
        }
        .payment-tabs {
            display: flex;
            border-bottom: 2px solid #e5e7eb;
            margin-bottom: 20px;
        }
        .payment-tabs .tab {
            padding: 10px 20px;
            cursor: pointer;
            color: #6b7280;
            font-weight: 600;
        }
        .payment-tabs .tab.active {
            color: #150165;
            border-bottom: 3px solid #150165;
        }
        .payment-panel {
            display: none;
        }
        .payment-panel.active {
            display: block;
        }
        .cbu-box {
            background: #f3f4f6;
            border: 1px dashed #d1d5db;
            padding: 15px;
            border-radius: 10px;
            text-align: center;
            margin-bottom: 15px;
        }
        .cbu-box span {
            font-family: 'Courier New', Courier, monospace;
            font-size: 1.2rem;
            font-weight: 700;
            letter-spacing: 2px;
        }
       .summary-actions-container {
            display: flex;
            flex-direction: column;
            gap: 10px;
        }
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
                <h1><i class="fas fa-credit-card"></i> Finalizar Compra</h1>
            </div>
            
            <div class="checkout-container">
                <!-- Panel de resumen del pedido -->
                <div class="order-summary">
                    <h3>Resumen de tu Pedido</h3>
                    <asp:Repeater ID="rptResumenCarrito" runat="server">
                    </asp:Repeater>
                    <hr />
                    <div class="summary-line">
                        <span>Subtotal:</span>
                        <asp:Label ID="lblSubtotal" runat="server" />
                    </div>
                    <div class="summary-line">
                        <span>Envío:</span>
                        <asp:Label ID="lblEnvio" runat="server" />
                    </div>
                    <div class="summary-line total">
                        <span>TOTAL:</span>
                        <asp:Label ID="lblTotal" runat="server" />
                    </div>
                </div>

                <!-- Panel de opciones de pago -->
                <div class="payment-options">
                    <h3>Elige tu Método de Pago</h3>
                    <!-- Pestañas de métodos de pago -->
                    <div class="payment-tabs">
                        <div class="tab active" onclick="showPanel('tarjeta')"><i class="fas fa-credit-card"></i> Tarjeta</div>
                        <div class="tab" onclick="showPanel('transferencia')"><i class="fas fa-university"></i> Transferencia</div>
                    </div>

                    <!-- Panel de pago con tarjeta -->
                    <div id="panel-tarjeta" class="payment-panel active">
                        <div class="form-group mb-3">
                            <label class="form-label">Número de Tarjeta</label>
                            <asp:TextBox ID="txtNumeroTarjeta" runat="server" CssClass="form-control" placeholder="0000-0000-0000-0000"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label class="form-label">Nombre del Titular</label>
                            <asp:TextBox ID="txtNombreTitular" runat="server" CssClass="form-control" placeholder="Como aparece en la tarjeta"></asp:TextBox>
                        </div>
                        <div class="row">
                            <div class="col-md-6 form-group mb-3">
                                <label class="form-label">Fecha de Vencimiento (MM/AA)</label>
                                <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="form-control" placeholder="MM/AA"></asp:TextBox>
                            </div>
                            <div class="col-md-6 form-group mb-3">
                                <label class="form-label">Código de Seguridad (CVV)</label>
                                <asp:TextBox ID="txtCodigoSeguridad" runat="server" CssClass="form-control" placeholder="123"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Button ID="btnConfirmarConTarjeta" runat="server" Text="Confirmar y Pagar" CssClass="btn-proceed-to-payment" OnClick="btnConfirmarConTarjeta_Click" />
                    </div>
                    
                    <!-- Panel de pago por transferencia -->
                    <div id="panel-transferencia" class="payment-panel">
                        <p>Para completar tu compra, por favor realiza una transferencia a la siguiente cuenta:</p>
                        <div class="cbu-box">
                            <label>CBU:</label>
                            <span>0000123456789012345678</span>
                        </div>
                        <p>Una vez realizada, presiona el botón para confirmar. Tu pedido quedará pendiente de verificación.</p>
                        <asp:Button ID="btnConfirmarTransferencia" runat="server" Text="He Realizado la Transferencia" CssClass="btn-proceed-to-payment" OnClick="btnConfirmarTransferencia_Click" />
                    </div>
                    
                    <!-- Área para mostrar errores de pago -->
                    <asp:Label ID="lblErrorPago" runat="server" CssClass="text-danger mt-3" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
    </form>
    
    <script type="text/javascript">
        function showPanel(panelId) {
            document.querySelectorAll('.payment-panel').forEach(p => p.classList.remove('active'));
            document.getElementById('panel-' + panelId).classList.add('active');
            
            document.querySelectorAll('.payment-tabs .tab').forEach(t => t.classList.remove('active'));
            event.currentTarget.classList.add('active');
        }
    </script>
</body>
</html>