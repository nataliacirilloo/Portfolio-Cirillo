using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace DAL
{
    public class Acceso
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=iLunaticTP;Integrated Security=True");
        public void abrir()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        public void cerrar()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public DataTable Leer(string sp, SqlParameter[] param)
        {
            abrir();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandText = sp;
            da.SelectCommand.Connection = conn;
            if (param != null)
            {
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.Parameters.AddRange(param);

            }

            da.Fill(dt);
            cerrar();
            return dt;
        }

        public int Escribir(string sp, SqlParameter[] parametro)
        {
            int sepudo = 0;
            abrir();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction ts = conn.BeginTransaction();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Transaction = ts;
            if (parametro != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parametro);
            }

            try
            {
                sepudo = cmd.ExecuteNonQuery();
                ts.Commit();
            }
            catch (SqlException ex)
            {
                ts.Rollback();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cerrar();
            }
            return sepudo;
        }

        public int obtenerValorInt(string sp, SqlParameter[] parametros)
        {
            int resultado = 0;

            abrir();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            cmd.Connection = conn;
            if (parametros != null)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parametros);
            }
            try
            {
                resultado = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);

            }
            finally
            {
                cerrar();
            }
            return resultado;
        }
    }
}
