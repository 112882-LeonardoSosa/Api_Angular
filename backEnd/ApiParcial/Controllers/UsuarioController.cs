using Microsoft.AspNetCore.Mvc;
using ApiParcial.Models;
using ApiParcial.Comandos;
using Microsoft.EntityFrameworkCore;
using ApiParcial.Resultados.ResutaldoLogin;
using ApiParcial.Comandos.Usuarios;

namespace DataFirst.Controllers;

[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly prog3Context _context;
    public UsuarioController(prog3Context context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("Api/Usuario/Login")]
    public async Task<ActionResult<ResultadoLogin>> Login([FromBody] ComandoLogin comando)
    {
        try
        {   
            var result = new ResultadoLogin();
            var usuario = await _context.Usuarios.Where(u => u.Email.Equals(comando.Email) 
            && u.Password.Equals(comando.Password)).FirstOrDefaultAsync();
            if (usuario != null)
            {
                result.NombreDeUsuario = usuario.Email;
                result.StatusCode="200";
                return Ok(result);
            }
            else
            {
                result.setError("Usuario No encontrado en la base de datos");
                result.StatusCode="500";
                return Ok(result);
            }
        }
        catch (Exception ex)
        {
            
            return BadRequest("Error al Obtener Usuario");
        }
    }



    [HttpPost]
    [Route("Api/Usuario/Create")]
    public async Task<ActionResult<bool>> CreateUsuario([FromBody] comandoCreateUsuario comando)
    {
        try
        {   
            var usuario = new Usuario
            {   
                Id = comando.Id,
                Email = comando.Email,
                Password = comando.Password,
                Activo = true
                
            };
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return Ok(true);
        }
        catch (Exception ex)
        {
            
            return BadRequest("Error al Crear Usuario");
        }
    }

}