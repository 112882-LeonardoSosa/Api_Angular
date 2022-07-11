using Microsoft.AspNetCore.Mvc;
using ApiParcial.Models;
using ApiParcial.Resultados.ResutaldoLogin;
using ApiParcial.Comandos.Usuarios;
using Microsoft.EntityFrameworkCore;
using ApiParcial.Resultados;
using ApiParcial.Comandos;

namespace DataFirst.Controllers;

[ApiController]
public class PersonaController : ControllerBase
{
    private readonly prog3Context _context;
    public PersonaController(prog3Context context)
    {
        _context = context;
    }


    [HttpGet]
    [Route("Api/Persona/GetTodos")]
    public async Task<ActionResult<ResultadoPersona>> GetTodosActivos()
    {
        try
        {   
            var result = new ResultadoPersona();
            var personas = await _context.Personas.ToListAsync();
            if (personas != null)
            {   
                foreach (var per in personas)
                {
                    var resultAux = new ResultadoPersona{
                        Nombre = per.Nombre,
                        Apellido = per.Apellido,
                        Id = per.Id,
                        DNI = per.Dni,
                        Direccion = per.Direccion
                        
                    };
                    //result.listaPersonas.Add(resultAux);
                    result.StatusCode="200";
                }           
                return Ok(result);
            }
            else
            {              
                return Ok(result);
            }
        }
        catch (Exception ex)
        {
            
            return BadRequest("Error al Obtener Personas");
        }
    }

   [HttpPost]
    [Route("Api/Persona/Create")]
    public async Task<ActionResult<bool>> CreatePersona([FromBody] comandoCreatePersona comando)
    {
        try
        {   
            var persona = new Persona
            {   
                Id = comando.Id,
                Nombre = comando.Nombre,
                Apellido = comando.Apellido,
                Dni = comando.Dni,
                Direccion = comando.Direccion
                
            };
            await _context.AddAsync(persona);
            await _context.SaveChangesAsync();
            return Ok(true);
        }
        catch (Exception ex)
        {
            
            return BadRequest("Error al Crear Persona");
        }
    }
  
}