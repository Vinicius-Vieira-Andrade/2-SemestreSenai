using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        ComentariosEventoRepository comentario = new ComentariosEventoRepository();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(comentario.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        [HttpGet("BuscaPorIdUsuario")]
        public IActionResult GetById(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorId(idUsuario, idEvento));
            }
            catch (Exception e) {
            
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(ComentariosEvento comentarioNovo)
        {
            try
            {
                comentario.Cadastrar(comentarioNovo);
                return StatusCode(201, comentarioNovo);
            }
            catch (Exception e) { 
            
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                comentario.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
