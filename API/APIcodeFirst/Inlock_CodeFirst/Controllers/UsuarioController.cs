using Inlock_CodeFirst.Domains;
using Inlock_CodeFirst.Interfaces;
using Inlock_CodeFirst.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inlock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuario _usuarioRepository;

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

                return Ok(usuario);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        public IActionResult GetByEmailAndPassword()
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
