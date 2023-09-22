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
    public class PresencaEventoController : ControllerBase
    {
        private readonly IPresencaEvento _PresencaEvento;

        public PresencaEventoController()
        {
            _PresencaEvento = new PresencaEventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_PresencaEvento.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método listar");
            }
        }

        [HttpPost]
        public IActionResult Post(PresencaEvento presenca)
        {
            try
            {
                _PresencaEvento.Inscrever(presenca);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método cadastrar");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _PresencaEvento.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método deletar");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, PresencaEvento presencaEvento)
        {
            try
            {
                _PresencaEvento.Atualizar(id, presencaEvento);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método atualizar");
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                _PresencaEvento.BuscarPorId(id);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método listar por id");
            }
        }

        /// <summary>
        /// endpoint listar presencas
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpGet("{id}")]
        public IActionResult GetMy(Guid idUsuario)
        {
            try
            {
                _PresencaEvento.ListarMinhas(idUsuario);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método listar presenças");
            }
        }





    }
}
