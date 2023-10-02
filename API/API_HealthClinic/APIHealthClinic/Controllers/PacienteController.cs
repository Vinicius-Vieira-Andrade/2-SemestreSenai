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
    public class PacienteController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository;

        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }


        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Paciente paciente)
        {
            try
            {
                _pacienteRepository.AtualizarPaciente(id, paciente);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (Guid id)
        {
            try
            {
                _pacienteRepository.Remover(id);
                return NoContent();
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
                Paciente paciente = _pacienteRepository.BuscarId(id);
                return StatusCode(201, paciente);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult CadastraPaciente(Paciente paciente)
        {
            try
            {
                _pacienteRepository.CadastrarPaciente(paciente);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        [HttpGet]
        public IActionResult GetPaciente()
        {
            try
            {
                return Ok(_pacienteRepository.ListarPaciente());
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpGet("(BuscaConsulta)")]
        public IActionResult GetConsultas(string Nome)
        {
            try
            {
                _pacienteRepository.ListarConsulta(Nome);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    }
}
