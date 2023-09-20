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
    public class TipoEventoController : ControllerBase
    {
        private ITipoEvento _TipoEventoRepository { get; set; }

        public TipoEventoController()
        {
            _TipoEventoRepository = new TipoEventoRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_TipoEventoRepository.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método de listar");
            }
        }



        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                return Ok(_TipoEventoRepository.BuscarId(id));
            }
            catch (Exception)
            {
                throw new Exception("Erro ao acessar o método de listar por id");
            }
        }


        [HttpPut]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _TipoEventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método de atualizar");
            }
        }


    }
}
