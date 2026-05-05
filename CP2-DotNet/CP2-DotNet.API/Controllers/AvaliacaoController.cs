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
            Description = "Retorna todas as avaliações de um filme específico cadastradas"
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

        [HttpPost("{id}")]
        [SwaggerOperation(
            Summary = "Adiciona uma nova avaliação de filme no Banco"
        )]
        public IActionResult AddAvaliacao(int id, AvaliacaoEntity model)
        {
            try
            {
                var filmeExiste = _context.Filme.Where(x => x.Id == id).Count() > 0;
                if (!filmeExiste)
                {
                    return NotFound();
                }
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
                if (avaliacao is null)
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
                return Ok(model);
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
