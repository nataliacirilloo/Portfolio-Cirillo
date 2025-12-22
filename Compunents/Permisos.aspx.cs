using Business_Logical_Layer;
using Microsoft.Ajax.Utilities;
using Services_Layer.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI_Layer
{
    /// <summary>
    /// Página de administración para gestión de permisos, perfiles y familias de usuarios
    /// </summary>
	public partial class Permisos : System.Web.UI.Page
	{
        PerfilFamiliasBLL BLL = new PerfilFamiliasBLL();
        UsuarioBLL usuario = new UsuarioBLL();

        /// <summary>
        /// Carga inicial de datos al abrir la página
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPermisos();
                CargarPerfiles();
                CargarFamilias();
                CargarUsuarios();
            }
        }

        /// <summary>
        /// Carga la lista de permisos disponibles en el sistema
        /// </summary>
        private void CargarPermisos()
        {
            rptPermisos.DataSource = BLL.ObtenerPermisos();
            rptPermisos.DataBind();
        }

        /// <summary>
        /// Carga las familias con sus permisos asignados
        /// </summary>
        private void CargarFamilias()
        {
            var familias = BLL.ObtenerFamilia();
            var permisosDisponibles = BLL.ObtenerPermisos();

            var familiasConPermisos = familias.Select(f => {
                f.PermisosDisponibles = permisosDisponibles;
                f.PermisosEnUso = BLL.ObtenerPermisosPorFamilia(f.Id_Familia);
                return f;
            }).ToList();

            if (familiasConPermisos != null && familiasConPermisos.Count > 0)
            {
                rptFamilias.DataSource = familiasConPermisos;
                rptFamilias.DataBind();
            }
            else
            {
                rptFamilias.DataSource = null;
                rptFamilias.DataBind();
            }
        }

        /// <summary>
        /// Configura los controles de cada perfil al cargar los datos
        /// </summary>
        protected void rptPerfiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int idperfil = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Id_Perfil"));

                var familias = BLL.ObtenerFamilia();
                var idfamiliasAsignadas = BLL.ObtenerFamiliaPefil(idperfil);
                
                DropDownList ddl = (DropDownList)e.Item.FindControl("dllFamiliasPerfil");
                if (ddl != null)
                {
                    ddl.DataSource = familias;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Id_Familia";
                    ddl.DataBind();

                    if(idfamiliasAsignadas.Rows.Count > 0)
                    {
                        ddl.SelectedValue = idfamiliasAsignadas.Rows[0]["Id_Familia"].ToString();
                    }
                    else
                    {
                        ddl.Items.Insert(0, new ListItem("-- Seleccione Familia --", ""));
                    }
                }
            }
        }

        /// <summary>
        /// Carga la lista de perfiles disponibles
        /// </summary>
        private void CargarPerfiles()
        {
            var perfiles = BLL.ObtenerPerfiles();
            rptPerfiles.DataSource = perfiles;
            rptPerfiles.DataBind();
        }

        /// <summary>
        /// Carga la lista de usuarios del sistema
        /// </summary>
        private void CargarUsuarios()
        {
            var usuarios = usuario.GetUsuarios();
            rptUsuarios.DataSource = usuarios;
            rptUsuarios.DataBind();
        }

        /// <summary>
        /// Crea un nuevo perfil en el sistema
        /// </summary>
        protected void btnAgregarPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                var perfil = new Perfil { Nombre = txtNuevoPerfil.Text.Trim() };
                BLL.AgregarPerfil(perfil);
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "mostrarMensaje('success','¡Perfil creado exitosamente!');", true);
                txtNuevoPerfil.Text = "";
                CargarPerfiles();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "mostrarMensaje('error','Error al agregar el perfil');", true);
            }
        }

        /// <summary>
        /// Maneja las acciones de los controles de perfiles
        /// </summary>
        protected void rptPerfiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AsignarFamilia")
            {
                int idPerfil = Convert.ToInt32(e.CommandArgument);
                DropDownList ddlFamilias = (DropDownList)e.Item.FindControl("dllFamiliasPerfil");
                if (ddlFamilias != null && !string.IsNullOrEmpty(ddlFamilias.SelectedValue))
                {
                    int idFamiliaSeleccionada = int.Parse(ddlFamilias.SelectedValue);

                    try
                    {
                        var res = BLL.AgregarFamiliaPerfil(idPerfil, idFamiliaSeleccionada);

                        if (res != 0)
                        {
                            var mensajeSeguro = HttpUtility.JavaScriptStringEncode("Se asigno correctamente la familia al perfil");
                        }
                        else
                        {
                            var mensajeSeguro = HttpUtility.JavaScriptStringEncode("error al asignar, ya posse familia el perfil");
                        }
                    }
                    catch (Exception ex)
                    {
                        var mensajeSeguro = HttpUtility.JavaScriptStringEncode("Error con la asignacion, contactar administracion");
                    }
                }
            }
        }

        /// <summary>
        /// Configura los controles de cada familia al cargar los datos
        /// </summary>
        protected void rptFamilias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
            {
                var familia = (Familia)e.Item.DataItem;

                var cbl = (CheckBoxList)e.Item.FindControl("cblPermisosFamilia");
                cbl.DataSource = familia.PermisosDisponibles;
                cbl.DataTextField = "Nombre";
                cbl.DataValueField = "Id_Permiso";
                cbl.DataBind();

                var permisosEnUsoIds = familia.PermisosEnUso.Select(p => p.Id_Permiso).ToList();
                foreach (ListItem item in cbl.Items)
                {
                    if (permisosEnUsoIds.Contains(int.Parse(item.Value)))
                        item.Selected = true;
                }
            }
        }

        /// <summary>
        /// Crea una nueva familia en el sistema
        /// </summary>
        protected void btnAgregarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                var familia = new Familia { Nombre = txtNuevaFamilia.Text.Trim() };
                BLL.AgregarFamilia(familia);
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "mostrarMensaje('success','¡Familia creada exitosamente!');", true);
                txtNuevaFamilia.Text = "";
                CargarFamilias();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "mostrarMensaje('error','Error al agregar la familia');", true);
            }
        }

        /// <summary>
        /// Maneja las acciones de los controles de familias
        /// </summary>
        protected void rptFamilias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AsignarPermisos")
            {
                int idFamilia = Convert.ToInt32(e.CommandArgument);
                var chkList = (CheckBoxList)e.Item.FindControl("cblPermisosFamilia");
                List<int> idsPermisos = new List<int>();
                foreach (ListItem item in chkList.Items)
                    if (item.Selected)
                        idsPermisos.Add(int.Parse(item.Value));
                try
                {
                    var res = BLL.AgregarPermisosFamilia(idFamilia, idsPermisos);

                    if (res > 0)
                    {
                        var mensajeSeguro = HttpUtility.JavaScriptStringEncode("Se asignaron correctamente.");
                    }
                    else
                    {
                        var mensajeerror = HttpUtility.JavaScriptStringEncode("Permisos ya existentes en el sistema.");
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "mostrarMensaje('error','Error al asignar permisos');", true);
                }
            }
            if(e.CommandName == "EliminarPermisos")
            {
                int idFamilia = Convert.ToInt32(e.CommandArgument);
                var accion = BLL.EliminarPermisosFamilia(idFamilia);
                if(accion > 0)
                {
                    var mensaje = HttpUtility.JavaScriptStringEncode("Los permisos se eliminaron con exito.");
                }
                else if(accion == -1)
                {
                    var mensajeerror = HttpUtility.JavaScriptStringEncode("Permisos no se pueden elimina.");
                }
            }
        }

        /// <summary>
        /// Maneja las acciones de los controles de usuarios
        /// </summary>
        protected void rptUsuarios_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AsignarPerfil")
            {
                int idusuario = Convert.ToInt32(e.CommandArgument);
                DropDownList ddlPerfiles = (DropDownList)e.Item.FindControl("ddlPerfiles");
                if (ddlPerfiles != null && !string.IsNullOrEmpty(ddlPerfiles.SelectedValue))
                {
                    int idPerfilSeleccionado = int.Parse(ddlPerfiles.SelectedValue);

                    try
                    {
                        var res = BLL.AsignarPerfilUsuario(idusuario, idPerfilSeleccionado);

                        if (res != 0)
                        {
                            var mensajeSeguro = HttpUtility.JavaScriptStringEncode("Se asigno correctamente el perfil al usuario");
                        }
                    }
                    catch (Exception ex)
                    {
                        var mensajeSeguro = HttpUtility.JavaScriptStringEncode("Error con la asignacion, contactar administracion");
                    }
                }
            }
        }

        /// <summary>
        /// Configura los controles de cada usuario al cargar los datos
        /// </summary>
        protected void rptUsuarios_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var Perfiles = BLL.ObtenerPerfiles();
                int idusuario = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Id_Usuario"));

                var PerfilsAsignado = BLL.ObtenerPerfilAsignado(idusuario);
                DropDownList ddl = (DropDownList)e.Item.FindControl("ddlPerfiles");
                if (ddl != null)
                {
                    ddl.DataSource = Perfiles;
                    ddl.DataTextField = "Nombre";
                    ddl.DataValueField = "Id_Perfil";
                    ddl.DataBind();

                    if (PerfilsAsignado.Rows.Count > 0)
                    {
                        ddl.SelectedValue = PerfilsAsignado.Rows[0]["Id_Perfil"].ToString();
                    }
                    else
                    {
                        ddl.Items.Insert(0, new ListItem("-- Seleccione Perfil --", ""));
                    }
                }
            }
        }
    }
}