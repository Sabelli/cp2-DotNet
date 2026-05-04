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
            Summary = "Lista todas os filmes",
            Description = "Método responsável por retornar todos os filmes cadastrados"
        )]
        public IActionResult GetAllFilme()
        {
            try
            {
                var avaliacoes = _context.Filme.ToList();
                if (!avaliacoes.Any())
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
    }
}
