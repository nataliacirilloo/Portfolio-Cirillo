namespace Entity_Layer
{
    /// <summary>
    /// Representa un usuario del sistema con sus datos personales, credenciales y perfil de acceso
    /// </summary>
    public class Usuario
    {
        private int id_usuario;
        public int Id_Usuario { get => id_usuario; set => id_usuario = value; }

        private string nombre;
        public string Nombre { get => nombre; set => nombre = value; }

        private string apellido;
        public string Apellido { get => apellido; set => apellido = value; }

        private string rol;
        public string Rol { get => rol; set => rol = value; }

        private int dni;
        public int Dni { get => dni; set => dni = value; }

        private string mail;
        public string Mail { get => mail; set => mail = value; }

        private string username;
        public string UserName { get => username; set => username = value; }

        private string contraseña;
        public string Contraseña { get => contraseña; set => contraseña = value; }

        public int Id_Perfil { get; set; }
        public string Nombre_Perfil { get; set; }

        private int intentosFallidos;
        public int IntentosFallidos { get => intentosFallidos; set => intentosFallidos = value; }

        private bool bloqueado;
        public bool Bloqueado { get => bloqueado; set => bloqueado = value; }
    }
}
