using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]//Precisa estar logado para acessar a rota
    public class FilmeController : ControllerBase
    {

        private IFilmeRepository _FilmeRepository { get; set; }

        public FilmeController()
        {
            _FilmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Endpoint que acessa método listar os filmes
        /// </summary>
        /// <returns>Ele retorna uma lista de gêneros e um status code</returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> ListaFilmes = _FilmeRepository.ListarTodos();

                return Ok(ListaFilmes);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o método cadastrar
        /// </summary>
        /// <param name="novoFilme">Objeto recebido na requisição</param>
        /// <returns>Retorna o status code created</returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _FilmeRepository.Cadastrar(novoFilme);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        /// <summary>
        /// Endpoint que acessa o método deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _FilmeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método listar pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                FilmeDomain filmeBuscado = _FilmeRepository.BuscaPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("O filme buscado não foi encontrado !");
                }
                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método atualizar pelo corpo
        /// </summary>
        /// <param name="Filme"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        public IActionResult PutBody(FilmeDomain Filme)
        {
            try
            {
                FilmeDomain filmeBuscado = _FilmeRepository.BuscaPorId(Filme.IdFilme);
                if (filmeBuscado != null)
                {
                    try
                    {
                        _FilmeRepository.AtualizarPorId(Filme);
                        return StatusCode(204);
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);   
                    }
                }
                return NotFound("Filme não encontrado !");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método atualizar por URL
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="urlGenero"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public IActionResult PutUrl(int Id, FilmeDomain urlGenero)
        {
            try
            {
                _FilmeRepository.AtualizarPorUrl(Id, urlGenero);

                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }

        }
    }
}
