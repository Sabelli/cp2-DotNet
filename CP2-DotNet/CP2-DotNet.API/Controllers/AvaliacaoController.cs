using CP2_DotNet.API.Data;
using CP2_DotNet.API.Models;
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
                return Ok(avaliacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Procura uma avaliação pelo ID",
            Description = "Método para buscar uma avaliação, e suas informações, pelo ID"
        )]
        public IActionResult GetAvaliacaoById(int id)
        {
            try
            {
                var avaliacao = _context.Avaliacao.FirstOrDefault(x => x.Id == id);
                if (avaliacao is null)
                {
                    return NotFound();
                }
                return Ok(avaliacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("filme/{FilmeId}")]
        [SwaggerOperation(
            Summary = "Procura todas as avaliações pelo ID do Filme",
            Description = "Retorna todas as avaliações cadastradas de um filme específico"
        )]
        public IActionResult GetAvaliacaoByFilme(int FilmeId)
        {
            try
            {

                var avaliacoes = _context.Avaliacao.Where(a => a.FilmeId == FilmeId).ToList();
                if (!avaliacoes.Any())
                {
                    return NoContent();
                }
                return Ok(avaliacoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{FilmeId}")]
        [SwaggerOperation(
            Summary = "Adiciona uma nova avaliação de filme no Banco",
            Description = "Através do ID de um Filme (FK), cria uma avaliação nova no banco"
        )]
        public IActionResult AddAvaliacao(int FilmeId, AvaliacaoEntity model)
        {
            try
            {
                var filmeExiste = _context.Filme.FirstOrDefault(x => x.Id == FilmeId) != null;
                if (!filmeExiste)
                {
                    return NotFound();
                }
                model.FilmeId = FilmeId;
                _context.Avaliacao.Add(model);
                _context.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Edita uma avaliação existente no Banco"
        )]
        public IActionResult EditAvaliacao(int id, AvaliacaoEntity model)
        {
            try
            {
                var avaliacao = _context.Avaliacao.FirstOrDefault(x => x.Id == id);
                var filmeExiste = _context.Filme.FirstOrDefault(x => x.Id == model.FilmeId) != null;
                if (avaliacao is null || !filmeExiste)
                {
                    return NotFound();
                }
                avaliacao.Autor = model.Autor;
                avaliacao.Nota = model.Nota;
                avaliacao.Comentario = model.Comentario;
                avaliacao.DataAvaliacao = model.DataAvaliacao;
                avaliacao.FilmeId = model.FilmeId;

                _context.Avaliacao.Update(avaliacao);
                _context.SaveChanges();
                return Ok(avaliacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Exclui uma avaliação existente no Banco"
        )]
        public IActionResult DeleteAvaliacao(int id)
        {
            try
            {
                var avaliacao = _context.Avaliacao.FirstOrDefault(x => x.Id == id);
                if (avaliacao is null)
                {
                    return NotFound();
                }

                _context.Avaliacao.Remove(avaliacao);
                _context.SaveChanges();
                return Ok(avaliacao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
