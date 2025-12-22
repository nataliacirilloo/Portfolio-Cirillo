using Services_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DataAccess
    {
        private readonly SqlConnection conector = Singleton.ObtenerInstancia(
            @"Data Source=.;Initial Catalog=Compunents;Integrated Security=True;TrustServerCertificate=True"
            );

        SqlCommand cmd = new SqlCommand();

        public void Conectar()
        {
            conector.Open();
        }

        public void Desconectar()
        {
            conector.Close();
        }

        public DataTable Leer(string st, SqlParameter[] parametros = null)
        {

            DataTable tabla = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter(st, conector);


            adaptador.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (parametros != null)
            {
                adaptador.SelectCommand.Parameters.AddRange(parametros);
            }

            adaptador.Fill(tabla);
            return tabla;
        }

        public bool Verificar(string Procedure, SqlParameter[] param = null)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand(Procedure, conector);
            cmd.CommandType = CommandType.StoredProcedure;
            if (param != null) cmd.Parameters.AddRange(param);

            object resultado = cmd.ExecuteNonQuery();

            Desconectar();

            return resultado != null && Convert.ToBoolean(resultado);

        }

        public bool ObtenerEstadoBloqueo(string username)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
            new SqlParameter("@UserName", username)
            };

            DataTable resultado = Leer("VerificarEstadoBloqueo", parametros);

            if (resultado.Rows.Count > 0)
            {
                return Convert.ToBoolean(resultado.Rows[0]["Bloqueo"]);
            }

            return false;
        }


        public int Escribir(string sp, SqlParameter[] parametros)
        {
            Conectar();
            int i = 0;
            SqlCommand cmd = new SqlCommand();
            SqlTransaction ts = conector.BeginTransaction();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = conector;
            cmd.Transaction = ts;
            if (parametros != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parametros);
            }
            try
            {
                i = cmd.ExecuteNonQuery();
                ts.Commit();
            }
            catch (Exception ex)
            {
                ts.Rollback();
                throw ex;
            }
            finally
            {
                Desconectar();
            }
            return i;
        }

        SqlTransaction TR;

        void AceptarTX()
        {
            TR.Commit();
        }

        void CancelarTX()
        {
            TR.Rollback();
        }

        internal void AsignarID(string storeProc, object Entity)
        {
            Conectar();
            cmd = new SqlCommand(storeProc, conector);
            cmd.CommandType = CommandType.StoredProcedure;

            PropertyInfo Propntity = Entity.GetType().GetProperties()[0];
            Propntity.SetValue(Entity, cmd.ExecuteScalar());

            Desconectar();
        }

        public object ObetenerDatos(string storeProc, SqlParameter[] parametros = null)
        {
            Conectar();

            SqlCommand cmd = new SqlCommand(storeProc, conector);
            cmd.CommandType = CommandType.StoredProcedure;

            if (parametros != null) cmd.Parameters.AddRange(parametros);

            object Resultado = cmd.ExecuteScalar();

            Desconectar();

            return Resultado;
        }

    }

}

