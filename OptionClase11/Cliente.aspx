<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="OptionClase11.Cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario de Cotización</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>FORMULARIO DE COTIZACION</h2>
            <hr />
            
            <b>¿DÓNDE VA DE VACACIONES?</b>
            <br />
            <asp:RadioButtonList ID="rblDestino" runat="server">
                <asp:ListItem>Mar del Plata</asp:ListItem>
                <asp:ListItem>Bariloche</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator 
                ID="rfvDestino" 
                runat="server" 
                ControlToValidate="rblDestino" 
                ErrorMessage="Debe seleccionar un destino." 
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            
            <br /><br />
            
            <b>¿CUÁL ES LA CATEGORÍA?</b>
            <br />
            <asp:RadioButtonList ID="rblEstrella" runat="server">
                <asp:ListItem>TRES</asp:ListItem>
                <asp:ListItem>CUATRO</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator 
                ID="rfvEstrella" 
                runat="server" 
                ControlToValidate="rblEstrella" 
                ErrorMessage="Debe seleccionar una categoría." 
                ForeColor="Red">
            </asp:RequiredFieldValidator>
            
            <br /><br />
            
            <b>CANTIDAD DE PERSONAS</b>
            <br />
            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvCantidad" 
                runat="server" 
                ControlToValidate="txtCantidad" 
                ErrorMessage="Debe cargar la cantidad de personas." 
                ForeColor="Red">
            </asp:RequiredFieldValidator>

            <br /><br />

            <b>CANTIDAD DE DÍAS</b>
            <br />
            <asp:TextBox ID="txtDias" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="rfvDias" 
                runat="server" 
                ControlToValidate="txtDias" 
                ErrorMessage="Debe cargar la cantidad de días." 
                ForeColor="Red">
            </asp:RequiredFieldValidator>

            <br /><br />

            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
        </div>
    </form>
</body>
</html>
