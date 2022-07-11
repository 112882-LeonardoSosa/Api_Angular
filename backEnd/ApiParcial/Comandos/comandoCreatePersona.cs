namespace ApiParcial.Comandos;

public class comandoCreatePersona
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Apellido { get; set; } = null!;
    public string Dni { get; set; } = null!;
    public string Direccion { get; set; } = null!;
}