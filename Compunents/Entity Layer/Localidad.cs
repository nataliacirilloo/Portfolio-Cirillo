public class Localidad
{
    private int idLocalidad;
    private string nombre;
    private decimal costoEnvio;
    private decimal montoMinimoEnvio;

    public int IdLocalidad { get => idLocalidad; set => idLocalidad = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public decimal CostoEnvio { get => costoEnvio; set => costoEnvio = value; }
    public decimal MontoMinimoEnvio { get => montoMinimoEnvio; set => montoMinimoEnvio = value; }
}
