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
    }
}
