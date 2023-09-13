using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;
using webapi.inlock.tarde.Repositories;

namespace webapi.inlock.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception)
            {
                throw new Exception("Erro ao listar!");

            }
        }



        [HttpGet("ListarComJogos")]
        public IActionResult GetWithJuegos()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar!");
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _estudioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar!");
            }
        }

        [HttpPost]
        public IActionResult Post(Estudio estudio)
        {
            try
            {
                _estudioRepository.Cadastrar(estudio);

                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar o estúdio");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                return Ok(_estudioRepository.BuscaPorId(id));
                
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar pelo id");
            }
        }



        [HttpPut("{id}")]
        public IActionResult Put(Guid id,Estudio estudio)
        {
            try
            {
                _estudioRepository.Atualizar(id, estudio);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao atualizar estúdio");
            }
        }
    }
}
