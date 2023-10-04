using APIHealthClinic.Domain;
using APIHealthClinic.Interface;
using APIHealthClinic.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIHealthClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository;

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult GetConsultas()
        {
            try
            {

                return Ok(_consultaRepository.ListarConsultas());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpPost]
        public IActionResult AgendaConsulta(Consulta consulta)
        {
            try
            {
                _consultaRepository.AgendarConsulta(consulta);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaConsulta(Guid id)
        {
            try
            {
                _consultaRepository.CancelarConsulta(id);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaConsulta(Guid id, Consulta consulta)
        {
            try
            {
                _consultaRepository.AtualizarConsulta(id, consulta);
                return StatusCode(201);
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
                return Ok(_consultaRepository.BuscarConsultaId(id));
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost("AdicionaComentario")]
        public IActionResult FazComent(Guid id, Feedback feedback)
        {
            try
            {
                _consultaRepository.FazerComentario(id, feedback);
                return Ok();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
