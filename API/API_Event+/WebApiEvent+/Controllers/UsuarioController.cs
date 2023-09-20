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
    
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar rota de cadastrar usuario");
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método buscar por id");
            }
        }

        [HttpGet]
        public IActionResult GetByEmailSenha(string email, string senha)
        {
            try
            {
                
                return Ok(_usuarioRepository.BuscarPorEmailESenha(email, senha));
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método buscar pelo email e senha");
            }
        }
    }
}
