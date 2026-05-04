using CP2_DotNet.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2_DotNet.API.Controllers
{
    [Route("api/filme")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FilmeController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Lista todos os filmes",
            Description = "Método responsável por retornar todos os filmes cadastrados"
        )]
        public IActionResult GetAllFilme()
        {
            try
            {
                var filmes = _context.Filme.ToList();
                if (!filmes.Any())
                {
                    return NoContent();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Procura um filme pelo ID",
            Description = "Método para buscar um filme, e suas informações, pelo ID"
        )]
        public IActionResult GetFilmeById(int id)
        {
            try
            {
                var filme = _context.Filme.FirstOrDefault(x => x.Id == id);
                if (filme is null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
