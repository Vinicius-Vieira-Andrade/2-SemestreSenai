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
    public class InstituicaoController : ControllerBase
    {
        private Iinstituicao _instituicao;

        public InstituicaoController()
        {
            _instituicao = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_instituicao.Listar());
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método listar");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                return Ok(_instituicao.BuscarId(id));
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessa método ");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _instituicao.Deletar(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método deletar");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Instituicao ins)
        {
            try
            {
                _instituicao.Atualizar(id, ins);
                return NoContent();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método atualizar");
            }
        }

        [HttpPost]
        public IActionResult Post(Instituicao ins)
        {
            try
            {
                _instituicao.Cadastrar(ins);
                return StatusCode(201);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao acessar método cadastrar");
            }
        }
    }
}
