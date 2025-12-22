using System;

/// <summary>
/// Representa un producto del catálogo con toda su información comercial y de inventario
/// </summary>
public class Producto
{
    private int id;
    private string nombre;
    private string descripcion;
    private decimal precio;
    private int stock;
    private string urlImagen;
    private string categoria;
    private int estado;
    private DateTime fechaAlta;
    private DateTime? fechaBaja;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Descripcion
    {
        get { return descripcion; }
        set { descripcion = value; }
    }

    public decimal Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    public int Stock
    {
        get { return stock; }
        set { stock = value; }
    }

    public string UrlImagen
    {
        get { return urlImagen; }
        set { urlImagen = value; }
    }

    public string Categoria
    {
        get { return categoria; }
        set { categoria = value; }
    }

    public int Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    public DateTime FechaAlta
    {
        get { return fechaAlta; }
        set { fechaAlta = value; }
    }

    private DateTime? _fechaModificacion;

    public DateTime? FechaModificacion
    {
        get { return _fechaModificacion; }
        set { _fechaModificacion = value; }
    }

}
