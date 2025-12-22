<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="GUI_Layer.Bitacora" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <title>Bitácora - Compunents</title>
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

        .filters-section {
            background: white;
            border-radius: 15px;
            padding: 25px;
            margin-bottom: 30px;
            box-shadow: 0 5px 20px rgba(0, 0, 0, 0.08);
        }

        .filters-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
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

        .filters-actions {
            display: flex;
            gap: 10px;
        }

        .btn-action {
            width: 100%;
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
            text-decoration: none;
        }

        .btn-action.btn-search {
            background: linear-gradient(135deg, #150165 0%, #1d4ed8 100%);
        }

        .btn-action.btn-search:hover {
            transform: translateY(-2px);
            box-shadow: 0 8px 25px rgba(21, 1, 101, 0.4);
        }

        .btn-action.btn-clear {
            background: linear-gradient(135deg, #6b7280 0%, #4b5563 100%);
        }

        .btn-action.btn-clear:hover {
            transform: translateY(-2px);
            box-shadow: 0 8px 25px rgba(107, 114, 128, 0.3);
        }

        .content-card {
            background: white;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
            padding: 30px;
            margin-bottom: 30px;
            overflow-x: auto;
        }

        .table-custom {
            width: 100%;
            border-collapse: collapse;
        }

        .table-custom th, .table-custom td {
            padding: 14px 20px;
            text-align: center;
            border-bottom: 1px solid #dee2e6;
            vertical-align: middle;
            white-space: nowrap;
            font-size: 0.95rem;
        }

        .table-custom th {
            background-color: #150165;
            color: white;
            font-weight: 700;
            text-transform: uppercase;
            letter-spacing: 0.5px;
        }

        .table-custom tbody tr:nth-child(even) {
            background-color: #f9f9fb;
        }

        .table-custom tbody tr:hover {
            background-color: #f1f5f9 !important;
            box-shadow: none;
            cursor: default;
        }

        .table-hover > tbody > tr:hover > * {
            background-color: inherit !important;
        }


        .thead-custom th {
            background-color: #150165 !important;
        }

        .p-3 {
            padding: 1rem !important;
            font-weight: 600;
        }

        .badge {
            display: inline-block;
            padding: 0.35em 0.65em;
            font-size: 0.85em;
            font-weight: 600;
            color: #fff;
            border-radius: 0.5rem;
            text-align: center;
        }

        .badge-low {
            background-color: #10b981;
        }

        .badge-medium {
            background-color: #f59e0b;
        }

        .badge-high {
            background-color: #ef4444;
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
                    <i class="fas fa-history"></i>
                    Registros de la Bitácora
                </h1>
            </div>

            <!-- Panel de filtros de búsqueda -->
            <asp:Panel ID="pnlFiltros" runat="server" CssClass="filters-section" DefaultButton="btnFiltrar">
                <div class="filters-grid">
                    <!-- Filtro por ID de usuario -->
                    <div class="form-group">
                        <label class="form-label">Usuario ID</label>
                        <asp:TextBox ID="txtUsuarioID" runat="server" CssClass="form-control" placeholder="ID del usuario..." TextMode="Number" />
                    </div>

                    <!-- Filtro por módulo -->
                    <div class="form-group">
                        <label class="form-label">Módulo</label>
                        <asp:DropDownList ID="ddlModulo" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">Todos</asp:ListItem>
                            <asp:ListItem Value="Login">Login</asp:ListItem>
                            <asp:ListItem Value="Seguridad">Seguridad</asp:ListItem>
                            <asp:ListItem Value="Ventas">Ventas</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtro por evento -->
                    <div class="form-group">
                        <label class="form-label">Evento</label>
                        <asp:DropDownList ID="ddlEvento" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">Todos</asp:ListItem>
                            <asp:ListItem Value="Login">Login</asp:ListItem>
                            <asp:ListItem Value="Logout">Logout</asp:ListItem>
                            <asp:ListItem Value="Permiso Denegado">Permiso Denegado</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtro por criticidad -->
                    <div class="form-group">
                        <label class="form-label">Criticidad</label>
                        <asp:DropDownList ID="ddlCriticidad" runat="server" CssClass="form-control">
                            <asp:ListItem Value="">Todas</asp:ListItem>
                            <asp:ListItem Value="1">Alta (1)</asp:ListItem>
                            <asp:ListItem Value="2">Media (2)</asp:ListItem>
                            <asp:ListItem Value="3">Baja (3)</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <!-- Filtro por fecha desde -->
                    <div class="form-group">
                        <label class="form-label">Fecha Desde</label>
                        <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="form-control" TextMode="Date" />
                    </div>

                    <!-- Filtro por fecha hasta -->
                    <div class="form-group">
                        <label class="form-label">Fecha Hasta</label>
                        <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control" TextMode="Date" />
                    </div>

                    <!-- Botones de acción de filtros -->
                    <div class="form-group filters-actions">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn-action btn-search" OnClick="btnFiltrar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-action btn-clear" OnClick="btnLimpiar_Click" CausesValidation="false" />
                    </div>
                </div>
            </asp:Panel>

            <!-- Tabla de registros de bitácora -->
            <div class="content-card">
                <asp:GridView ID="GridViewBitacora" runat="server"
                    CssClass="table table-hover table-custom"
                    AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="15" OnPageIndexChanging="GridViewBitacora_PageIndexChanging"
                    OnRowDataBound="GridViewBitacora_RowDataBound"
                    HeaderStyle-CssClass="thead-custom">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" />
                        <asp:BoundField DataField="id_user" HeaderText="ID Usuario" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha y Hora" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" />
                        <asp:BoundField DataField="Modulo" HeaderText="Módulo" />
                        <asp:BoundField DataField="Evento" HeaderText="Evento" />
                        <asp:BoundField DataField="Criticidad" HeaderText="Criticidad" HtmlEncode="false" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="alert alert-info text-center" role="alert">
                            No se encontraron registros con los filtros aplicados.
                        </div>
                    </EmptyDataTemplate>
                    <PagerStyle CssClass="p-3" HorizontalAlign="Center" />
                </asp:GridView>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
