using CP2_DotNet.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CP2_DotNet.API.Controllers
{
    [Route("api/avaliacao")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public AvaliacaoController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        [SwaggerOperation(
            Summary = "Lista todas as avaliações",
            Description = "Método responsável por retornar todas as avaliações cadastradas"
        )]
        public IActionResult GetAllAvaliacao() {
            try
            {
                var avaliacoes = _context.Avaliacao.ToList();
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
