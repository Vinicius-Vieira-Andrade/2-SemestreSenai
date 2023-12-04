using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
    {
        private IPresencasEventoRepository _presencasEventoRepository { get; set; }

        public PresencaEventoController()
        {
            _presencasEventoRepository = new PresencaRepository();
        }

        [HttpGet]
        public IActionResult get ()
        {
            try
            {
                return Ok(_presencasEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(PresencasEvento presencas)
        {
            try
            {
                _presencasEventoRepository.Inscrever(presencas);

                return StatusCode(201);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ListarMinhasPresencas/{id}")]
        public IActionResult GetMyPresences(Guid id)
        {
            try
            {
                return Ok(_presencasEventoRepository.ListarMinhas(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
