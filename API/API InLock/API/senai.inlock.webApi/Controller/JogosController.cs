using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repository;


namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método Listar jogos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<JogoDomain> ListaJogo = _jogoRepository.ListaJogos(); 

                return Ok(ListaJogo);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método Cadastrar jogos
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                _jogoRepository.CadastraJogos(novoJogo);
                
                return StatusCode(204);
            }
            catch (Exception erro)
            {

               return BadRequest(erro.Message);
            }
        }
    }
}
