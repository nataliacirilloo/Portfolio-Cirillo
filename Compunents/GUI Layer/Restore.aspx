<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Restore.aspx.cs" Inherits="GUI_Layer.Restore" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Restaurar Backup - Compunents</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/TopBar.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <style>
        body { background-color: #f8f9fa; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin: 0; padding: 0; }
        .main-content { padding: 30px; max-width: 1400px; margin: 0 auto; }
        .page-header { background: white; border-radius: 20px; box-shadow: 0 10px 30px rgba(0,0,0,0.1); border-top: 5px solid #150165; padding: 30px; margin-bottom: 30px; }
        .page-header h1 { color: #150165; font-size: 2.2rem; font-weight: 700; margin: 0; display: flex; align-items: center; gap: 15px; }
        .content-card { background: white; border-radius: 20px; box-shadow: 0 10px 30px rgba(0,0,0,0.1); padding: 30px; margin-bottom: 30px; overflow-x: auto; }
        .table-custom { width: 100%; border-collapse: collapse; }
        .table-custom th, .table-custom td { padding: 14px 20px; text-align: left; border-bottom: 1px solid #dee2e6; vertical-align: middle; white-space: nowrap; font-size: 0.95rem; }
        .table-custom th { background-color: #150165; color: white; font-weight: 700; text-transform: uppercase; letter-spacing: 0.5px; }
        .table-custom tbody tr:nth-child(even) { background-color: #f9f9fb; }
        .table-custom tbody tr:hover { background-color: #f1f5f9 !important; }
        .thead-custom th { background-color: #150165 !important; }
        .p-3 { padding: 1rem !important; font-weight: 600; }
        .text-center-aligned { text-align: center; }
        .btn-restore { background: linear-gradient(135deg, #10b981 0%, #059669 100%); color: white; border: none; padding: 8px 16px; border-radius: 8px; font-weight: 600; transition: all 0.3s ease; cursor: pointer; gap: 8px; display: inline-flex; align-items: center; }
        .btn-restore:hover { transform: translateY(-2px); box-shadow: 0 6px 20px rgba(16, 185, 129, 0.4); }
        .feedback-container { margin-bottom: 20px; }
        .feedback-message { padding: 15px; border-radius: 10px; font-weight: 500; }
        .feedback-success { background-color: #d1fae5; color: #065f46; border: 1px solid #6ee7b7; }
        .feedback-error { background-color: #fee2e2; color: #991b1b; border: 1px solid #fca5a5; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Barra de navegación superior -->
        <uc:TopBar ID="TopBarControl" runat="server" />
        <div class="main-content">
            <!-- Encabezado de la página -->
            <div class="page-header">
                <h1><i class="fas fa-window-restore"></i> Restaurar Copia de Seguridad</h1>
            </div>
            <!-- Tabla de archivos de backup disponibles -->
            <div class="content-card">
                <!-- Área para mostrar mensajes de resultado -->
                <div class="feedback-container">
                    <asp:Label ID="lblResultado" runat="server" Visible="false" CssClass="feedback-message"></asp:Label>
                </div>
                <asp:GridView ID="GridViewBackups" runat="server"
                    CssClass="table table-hover table-custom"
                    AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="10"
                    OnPageIndexChanging="GridViewBackups_PageIndexChanging"
                    OnRowCommand="GridViewBackups_RowCommand"
                    HeaderStyle-CssClass="thead-custom">
                    <Columns>
                        <asp:BoundField DataField="FileName" HeaderText="Nombre del Archivo" />
                        <asp:BoundField DataField="CreationDate" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" />
                        <asp:BoundField DataField="FileSize" HeaderText="Tamaño" ItemStyle-CssClass="text-center-aligned" HeaderStyle-CssClass="text-center-aligned" />
                        <asp:TemplateField HeaderText="Acciones" ItemStyle-CssClass="text-center-aligned">
                            <ItemTemplate>
                                <!-- Botón para restaurar backup -->
                                <asp:Button ID="btnRestaurar" runat="server" 
                                    Text="Restaurar" 
                                    CssClass="btn-restore" 
                                    CommandName="Restaurar" 
                                    CommandArgument='<%# Eval("FileName") %>'
                                    OnClientClick="return confirm('¿Estás seguro de que querés restaurar este backup?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
