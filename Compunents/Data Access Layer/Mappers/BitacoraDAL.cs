using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Mappers
{
    public class BitacoraDAL
    {
        DataAccess dt = new DataAccess();
        UsuarioDAL usuarioDAL = new UsuarioDAL();

        /// <summary>
        /// Registra un evento de login en la bitácora con criticidad según el rol del usuario
        /// </summary>
        public void BitacoraLogin(int idUsuario)
        {
            string rolUsuario = usuarioDAL.ObtenerRolUsuario(idUsuario)?.Trim().ToLower();

            string evento;
            int criticidad;

            switch (rolUsuario)
            {
                case "admin":
                    evento = "Logueo de Webmaster";
                    criticidad = 1;
                    break;
                case "empleado":
                    evento = "Logueo de Empleado";
                    criticidad = 2;
                    break;
                case "cliente":
                    evento = "Logueo de Cliente";
                    criticidad = 3;
                    break;
                default:
                    evento = "Logueo básico";
                    criticidad = 4;
                    break;
            }

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@Id_User", idUsuario),
        new SqlParameter("@Evento", evento),
        new SqlParameter("@Fecha", DateTime.Now),
        new SqlParameter("@Modulo", "Login"),
        new SqlParameter("@Criticidad", criticidad)
            };

            dt.Verificar("SP_InsertarBitacoraEvento", parametros);
        }

        /// <summary>
        /// Registra un evento personalizado en la bitácora del sistema
        /// </summary>
        public void RegistrarEvento(string evento, int idUsuario, string modulo, int criticidad)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Id_User", idUsuario),
                new SqlParameter("@Evento", evento),
                new SqlParameter("@Fecha", DateTime.Now),
                new SqlParameter("@Modulo", modulo),
                new SqlParameter("@Criticidad", criticidad)
            };
            dt.Verificar("SP_InsertarBitacoraEvento", parametros);
        }

        /// <summary>
        /// Obtiene todos los eventos registrados en la bitácora del sistema
        /// </summary>
        public List<Entity_Layer.Bitacora> ConsultarBitacora()
        {
            DataTable dtBitacora = new DataTable();
            dtBitacora = dt.Leer("SP_ConsultarBitacoras", null);
            List<Entity_Layer.Bitacora> bitacoraList = new List<Entity_Layer.Bitacora>();
            foreach (DataRow row in dtBitacora.Rows)
            {
                Entity_Layer.Bitacora bitacora = new Entity_Layer.Bitacora
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Id_user = Convert.ToInt32(row["Id_user"]),
                    Modulo = row["Modulo"].ToString(),
                    Evento = row["Evento"].ToString(),
                    Criticidad = Convert.ToInt32(row["Criticidad"]),
                    Fecha = Convert.ToDateTime(row["Fecha"])
                };
                bitacoraList.Add(bitacora);
            }
            return bitacoraList;
        }

    }
}
