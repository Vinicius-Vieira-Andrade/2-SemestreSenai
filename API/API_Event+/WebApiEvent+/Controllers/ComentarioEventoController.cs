using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEvent_.Domains;
using WebApiEvent_.Interfaces;
using WebApiEvent_.Repositories;

namespace WebApiEvent_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEvento _comentarioEvento;

        public ComentarioEventoController()
        {
            _comentarioEvento = new ComentarioEventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentarioEvento.Listar());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message); 
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                return Ok(_comentarioEvento.BuscaId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(ComentarioEvento comentario)
        {
            try
            {
                _comentarioEvento.Cadastrar(comentario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEvento.Deletar(id);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
            
        }
    }
}
