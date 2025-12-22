<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="GUI_Layer.Reportes" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Reportes</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" charset="utf-8"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/TopBar.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
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
        .page-wrap { max-width: 1200px; margin: 0 auto; padding: 16px; }
        .actions { display:flex; gap:8px; margin: 12px 0 16px; }
        .feedback-message { padding:10px 12px; border-radius:6px; margin-bottom:12px; display:none; }
        .feedback-success { display:block; background:#e7f7ec; color:#0f5132; border:1px solid #badbcc; }
        .feedback-error { display:block; background:#fde2e1; color:#842029; border:1px solid #f5c2c7; }
        .grid { width:100%; border-collapse:collapse; }
        .grid th, .grid td { padding:8px 10px; border-bottom:1px solid #e5e7eb; text-align:left; }
        .grid th { background:#f3f4f6; font-weight:600; }
        .grid tr:hover { background:#fafafa; }
        .pill { padding:2px 8px; border-radius:999px; background:#eef2ff; }
        .right { text-align:right; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc:TopBar ID="TopBarControl" runat="server" />
        <div class="page-wrap">
            <div class="page-header">
                <h1>
                    <i class="fas fa-history"></i>
                    Reporte mensual de ventas
                </h1>
            </div>

            <asp:Label ID="lblResultado" runat="server" Visible="false"></asp:Label>

            <div class="actions">
                <asp:Button ID="btnRefrescar" runat="server" Text="Refrescar" OnClick="btnRefrescar_Click" />
                <asp:Button ID="btnExportar" runat="server" Text="Exportar XML" OnClick="btnExportar_Click" />
            </div>

            <asp:GridView ID="gvReporte"
                          runat="server"
                          CssClass="grid"
                          AutoGenerateColumns="False"
                          AllowSorting="true"
                          OnSorting="gvReporte_Sorting">
                <Columns>
                    <asp:BoundField DataField="Id_Producto" HeaderText="ID Producto" SortExpression="Id_Producto" />
                    <asp:BoundField DataField="NombreProducto" HeaderText="Producto" SortExpression="NombreProducto" />
                    <asp:BoundField DataField="Id_Pedido" HeaderText="# Pedidos" SortExpression="Id_Pedido" />
                    <asp:BoundField DataField="TotalItems" HeaderText="Unidades" SortExpression="TotalItems" />
                    <asp:BoundField DataField="SubtotalItem" HeaderText="Recaudación" DataFormatString="{0:C}" HtmlEncode="false" SortExpression="SubtotalItem" />
                    <asp:BoundField DataField="TotalCalculado" HeaderText="% del Mes" DataFormatString="{0:N2} %" HtmlEncode="false" SortExpression="TotalCalculado" />
                </Columns>
                <EmptyDataTemplate>
                    No hay datos para el período.
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

