using Business_Logical_Layer;
using Data_Access_Layer.Mappers;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace Business_Logical_Layer
{
    public class BackupBLL
    {
        BackupDAL backupDAL = new BackupDAL();

        /// <summary>
        /// Verifica si hay corrupción en los datos de productos y localidades
        /// </summary>
        /// <returns>Tupla que indica si hay productos o localidades corruptas</returns>
        public (bool productosCorruptos, bool localidadesCorruptas) VerificarCorrupcion()
        {
            return backupDAL.VerificarCorrupcion();
        }

        // ====== MODELO SNAPSHOT PARA XML ======
        // Usa directamente tus entidades de Entity_Layer.
        // XmlSerializer requiere clases públicas y ctor por defecto (tus entidades ya lo cumplen).
        [XmlRoot("Backup")]
        public class BackupSnapshot
        {
            [XmlElement("Fecha")]
            public DateTime Fecha { get; set; }

            [XmlArray("Productos")]
            [XmlArrayItem("Producto")]
            public List<Producto> Productos { get; set; }

            [XmlArray("Localidades")]
            [XmlArrayItem("Localidad")]
            public List<Localidad> Localidades { get; set; }
        }

        /// <summary>
        /// Crea un backup de productos y localidades en formato XML
        /// </summary>
        /// <param name="idUsuario">ID del usuario que realiza el backup</param>
        public static void HacerBackup(int idUsuario)
        {
            // Obtener datos
            var productoBLL = new ProductoBLL();
            List<Producto> productos = productoBLL.ObtenerProductosActivos();

            var localidadBLL = new LocalidadBLL();
            List<Localidad> localidades = localidadBLL.ObtenerLocalidades();

            // Armar snapshot
            var backup = new BackupSnapshot
            {
                Fecha = DateTime.Now,
                Productos = productos,
                Localidades = localidades
            };

            // Rutas / archivo
            string nombreArchivo = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.xml";
            string carpeta = HttpContext.Current.Server.MapPath("~/Backups/");
            string ruta = Path.Combine(carpeta, nombreArchivo);

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);

            // Serializar a XML (UTF-8 sin BOM, identado)
            var serializer = new XmlSerializer(typeof(BackupSnapshot));
            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false),
                NewLineOnAttributes = false
            };

            using (var fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var writer = XmlWriter.Create(fs, settings))
            {
                serializer.Serialize(writer, backup);
            }

            var bitacoraBLL = new BitacoraBLL();
            bitacoraBLL.RegistrarEvento($"Backup XML creado: {nombreArchivo}", idUsuario, "Backup", 1);
        }

        /// <summary>
        /// Restaura datos desde un archivo de backup XML
        /// </summary>
        /// <param name="idUsuario">ID del usuario que realiza la restauración</param>
        /// <param name="file">Nombre del archivo de backup a restaurar</param>
        public static void RestaurarBackup(int idUsuario, string file)
        {
            string carpeta = HttpContext.Current.Server.MapPath("~/Backups/");

            // Validaciones de nombre/extension para evitar traversal y extensiones no válidas
            if (string.IsNullOrWhiteSpace(file))
                throw new ArgumentException("Nombre de archivo inválido.");

            if (!file.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("El archivo debe tener extensión .xml.");

            // Asegura que no haya path traversal
            string nombreLimpio = Path.GetFileName(file);
            if (!string.Equals(nombreLimpio, file, StringComparison.Ordinal))
                throw new ArgumentException("Nombre de archivo inválido.");

            string archivoSeleccionado = Path.Combine(carpeta, nombreLimpio);

            if (!File.Exists(archivoSeleccionado))
                throw new FileNotFoundException($"El archivo '{file}' no existe.");

            // Deserializar XML
            BackupSnapshot data;
            var serializer = new XmlSerializer(typeof(BackupSnapshot));
            using (var fs = new FileStream(archivoSeleccionado, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                object obj = serializer.Deserialize(fs);
                data = obj as BackupSnapshot;
            }

            if (data == null)
                throw new InvalidOperationException("El archivo de backup no tiene el formato esperado.");

            // Restaurar productos
            var productoBLL = new ProductoBLL();
            if (data.Productos != null)
            {
                foreach (var p in data.Productos)
                {
                    // Actualiza o inserta según tu lógica interna en ActualizarProducto.
                    productoBLL.ActualizarProducto(p);
                }
            }

            // Restaurar localidades
            var localidadBLL = new LocalidadBLL();
            if (data.Localidades != null)
            {
                foreach (var l in data.Localidades)
                {
                    localidadBLL.ActualizarLocalidad(l);
                }
            }

            var bitacoraBLL = new BitacoraBLL();
            bitacoraBLL.RegistrarEvento(
                $"Backup XML restaurado desde archivo: {Path.GetFileName(archivoSeleccionado)}",
                idUsuario,
                "Backup",
                1
            );
        }

        /// <summary>
        /// Simula corrupción de datos eliminando productos y localidades
        /// </summary>
        /// <param name="idUsuario">ID del usuario que ejecuta la simulación</param>
        public static void SimularCorrupcion(int idUsuario)
        {
            var productoBLL = new ProductoBLL();
            productoBLL.Corromper();

            var localidadBLL = new LocalidadBLL();
            localidadBLL.Corromper();

            var bitacoraBLL = new BitacoraBLL();
            bitacoraBLL.RegistrarEvento("Simulación de corrupción: se eliminaron productos y localidades.", idUsuario, "Backup", 1);
        }
    }
}
