using CP2_DotNet.API.Data;
using CP2_DotNet.API.Models;
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
                return Ok(filmes);
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
                return Ok(filme);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("catalogo/{Genero}")]
        [SwaggerOperation(
            Summary = "Procura todos os filmes pelo Gênero",
            Description = "Retorna todos os filmes cadastrados com o gênero especificado"
        )]
        public IActionResult GetAvaliacaoByFilme(string Genero)
        {
            try
            {

                var filmes = _context.Filme.Where(f => f.Genero == Genero).ToList();
                if (!filmes.Any())
                {
                    return NoContent();
                }
                return Ok(filmes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Adiciona um novo filme no Banco"
        )]
        public IActionResult AddFilme(FilmeEntity model)
        {
            try
            {
                _context.Filme.Add(model);
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
            Summary = "Edita um filme existente no Banco"
        )]
        public IActionResult EditFilme(int id, FilmeEntity model)
        {
            try
            {
                var filme = _context.Filme.FirstOrDefault(x => x.Id == id);
                if (filme is null)
                {
                    return NotFound();
                }
               
                filme.Titulo = model.Titulo;
                filme.Genero = model.Genero;
                filme.AnoLancamento = model.AnoLancamento;
                filme.DuracaoMin = model.DuracaoMin;

                _context.Filme.Update(filme);
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
            Summary = "Exclui um filme existente no Banco"
        )]
        public IActionResult DeleteFilme(int id)
        {
            try
            {
                var filme = _context.Filme.FirstOrDefault(x => x.Id == id);
                if (filme is null)
                {
                    return NotFound();
                }

                _context.Filme.Remove(filme);
                _context.SaveChanges();
                return Ok(filme);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
