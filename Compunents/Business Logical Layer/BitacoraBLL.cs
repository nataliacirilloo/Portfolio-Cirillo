using Data_Access_Layer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logical_Layer
{
    public class BitacoraBLL
    {
        BitacoraDAL mapper = new BitacoraDAL();
        
        /// <summary>
        /// Obtiene todos los registros de la bitácora del sistema
        /// </summary>
        /// <returns>Lista de eventos registrados en la bitácora</returns>
        public List<Entity_Layer.Bitacora> ConsultarBitacora()
        {
            return mapper.ConsultarBitacora();
        }

        /// <summary>
        /// Registra el evento de login de un usuario en la bitácora
        /// </summary>
        /// <param name="idUsuario">ID del usuario que realizó el login</param>
        public void BitacoraLogin(int idUsuario)
        {
            mapper.BitacoraLogin(idUsuario);
        }

        /// <summary>
        /// Registra un evento personalizado en la bitácora del sistema
        /// </summary>
        /// <param name="evento">Descripción del evento ocurrido</param>
        /// <param name="idUsuario">ID del usuario relacionado al evento</param>
        /// <param name="modulo">Módulo del sistema donde ocurrió el evento</param>
        /// <param name="criticidad">Nivel de criticidad del evento (1-5)</param>
        public void RegistrarEvento(string evento, int idUsuario, string modulo, int criticidad)
        {
            mapper.RegistrarEvento(evento, idUsuario, modulo, criticidad);
        }

    }
}
