<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopBar.ascx.cs" Inherits="GUI_Layer.Controls.TopBar" %>

<!-- Top Bar -->
<div class="top-bar">
    <div class="role-section">
        <img src="Content/LogoCompunents.jpg" alt="Logo Compunents" class="logo" />
        <div class="role-label">
            <i class="fas fa-user-shield"></i>
            Rol: <asp:Label ID="LblRol" runat="server" />
        </div>
    </div>
    <asp:Button ID="btnLogout" runat="server" Text="Cerrar sesión" CssClass="logout-button" OnClick="btnLogout_Click" UseSubmitBehavior="false" />
</div>

<!-- Panel Cliente -->
<asp:Panel ID="PanelCliente" runat="server" Visible="false">
    <div class="nav-bar">
        <div class="nav-container">
            <a href="Inicio.aspx"><i class="fas fa-home"></i>Inicio</a>
            <a href="Compras.aspx"><i class="fas fa-shopping-cart"></i>Compras</a>
            <a href="MisCompras.aspx"><i class="fas fa-history"></i>Mis Compras</a>
            <a href="SobreNosotros.aspx"><i class="fas fa-info"></i>Sobre Nosotros</a>
        </div>
    </div>
</asp:Panel>

<!-- Panel Empleado -->
<asp:Panel ID="PanelEmpleado" runat="server" Visible="false">
    <div class="nav-bar">
        <div class="nav-container">
            <a href="Inicio.aspx"><i class="fas fa-home"></i>Inicio</a>
            <a href="Clientes.aspx"><i class="fas fa-users"></i>Clientes</a>
            <a href="Productos.aspx"><i class="fas fa-box"></i>Productos</a>
            <a href="Ventas.aspx"><i class="fas fa-shopping-bag"></i>Ventas</a>
            <a href="Reportes.aspx"><i class="fas fa-chart-bar"></i>Reportes</a>
            <a href="SobreNosotros.aspx"><i class="fas fa-info"></i>Sobre Nosotros</a>
        </div>
    </div>
</asp:Panel>

<!-- Panel Admin -->
<asp:Panel ID="PanelAdmin" runat="server" Visible="false">
    <div class="nav-bar">
        <div class="nav-container">
            <a href="Inicio.aspx"><i class="fas fa-home"></i>Inicio</a>
            <a href="Backup.aspx"><i class="fas fa-database"></i>Backup</a>
            <a href="Restore.aspx"><i class="fas fa-undo"></i>Restore</a>
            <a href="Bitacora.aspx"><i class="fas fa-file-alt"></i>Bitacora</a>
            <a href="SobreNosotros.aspx"><i class="fas fa-info"></i>Sobre Nosotros</a>
            <a href="Reportes.aspx"><i class="fas fa-clipboard"></i>Reportes</a>
        </div>
    </div>
</asp:Panel>

<script type="text/javascript">
    // Marcar página activa en la navegación
    document.addEventListener('DOMContentLoaded', function () {
        var currentPage = window.location.pathname.split('/').pop();
        var navLinks = document.querySelectorAll('.nav-bar a');

        navLinks.forEach(function (link) {
            var linkPage = link.getAttribute('href');
            if (linkPage === currentPage) {
                link.classList.add('active');
            }
        });
    });
</script>
