using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MPCliente
    {
        Acceso acceso = new Acceso();

        public List<Cliente> ListarCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("ListarCliente", null);
            foreach (DataRow dr in dt.Rows)
            {
                Cliente cliente = new Cliente();
                cliente.IdCliente = Convert.ToInt32(dr["idCliente"]);
                cliente.Documento = dr["documento"].ToString();
                cliente.NombreCompletp = dr["nombreCompleto"].ToString();
                cliente.Correo = dr["correo"].ToString();
                cliente.Telefono = dr["telefono"].ToString();
                cliente.Estado= dr["estado"].ToString();
                clientes.Add(cliente);

            }
            return clientes;
        }

        public int AltaCliente(Cliente cliente)
        {
            int fa = 0;

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@idCliente", cliente.IdCliente),
                new SqlParameter("@documento", cliente.Documento),
                new SqlParameter("@nombreCompleto", cliente.NombreCompletp),
                new SqlParameter("@correo", cliente.Correo),
                new SqlParameter("@telefono", cliente.Telefono),
                new SqlParameter("@estado", cliente.Estado),
            };
            fa = acceso.Escribir("AddCliente", sp);
            return fa;
        }

        public int ModificarCliente(Cliente cliente)
        {
            int fa = 0;

            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@idCliente", cliente.IdCliente),
                new SqlParameter("@documento", cliente.Documento),
                new SqlParameter("@nombreCompleto", cliente.NombreCompletp),
                new SqlParameter("@correo", cliente.Correo),
                new SqlParameter("@telefono", cliente.Telefono),
                new SqlParameter("@estado", cliente.Estado),
            };
            fa = acceso.Escribir("ModificarCliente", sp);
            return fa;
        }

        public int EliminarCliente(Cliente Cliente)
        {
            int fa = 0;

            SqlParameter[] parameters = new SqlParameter[1]
            {
                new SqlParameter("idCliente",Cliente.IdCliente)
            };
            fa = acceso.Escribir("EliminarCliente", parameters);
            return fa;
        }

            public Cliente ObtenerCliente(string nroDocumento)
            {
            Cliente cliente = new Cliente();
            SqlParameter[] sp = new SqlParameter[]
                {
                new SqlParameter("@documento", nroDocumento)
                };
                DataTable dt = acceso.Leer("ObtenerClientePorDNI", sp);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];  
                    cliente = new Cliente
                    {
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        NombreCompletp = dr["nombreCompleto"].ToString()
                    };
                }
                return cliente;
            }
        }
    }
