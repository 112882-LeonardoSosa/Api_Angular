using ApiParcial.Resultados;

public class ResultadoPersona : ResultadoBase
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string DNI { get; set; }
    public string Direccion { get; set; }
}