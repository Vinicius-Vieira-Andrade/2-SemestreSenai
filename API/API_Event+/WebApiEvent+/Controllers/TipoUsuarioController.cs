using Microsoft.AspNetCore.Authorization;
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

    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao acessar a rota cadastrar");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar o método listar");
            }
        }


        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método deletar");
            }
        }


        [HttpPut]
        public IActionResult Put(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar metódo atualizar");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetID(Guid id)
        {
            try
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método buscar por id");
            }
        }
    }
}
