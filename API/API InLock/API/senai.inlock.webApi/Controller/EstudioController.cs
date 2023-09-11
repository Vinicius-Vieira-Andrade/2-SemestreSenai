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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _EstudioReposiory { get; set; }


        public EstudioController()
        {
            _EstudioReposiory = new EstudioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> ListaEstudios = _EstudioReposiory.ListaEstudios();
                return Ok(ListaEstudios);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                _EstudioReposiory.Cadastrar(novoEstudio);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(
                    erro.Message);
            }
        }
    }
}
