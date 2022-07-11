namespace ApiParcial.Comandos.Usuarios;

public class comandoCreateUsuario
{

    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool? Activo { get; set; }
}