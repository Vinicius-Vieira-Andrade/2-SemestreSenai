using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato
    /// dominio/api/nomeController
    /// Exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de API
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que o tipo de resposta da API é JSON
    /// </summary>
    [Produces("application/json")]
    [Authorize]//Precisa estar logado para acessar a rota
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        //metodo construtor, quando bater no GeneroController, este é o primeiro a ser executado
        public GeneroController()
        {
            //instancia do objeto _generorepository, para que haja referencia aos metodos do repository
            _generoRepository = new GeneroRepository();
        }


        /// <summary>
        /// Endpoint que acessa o método de listar os gêneros
        /// </summary>
        /// <returns>Ele retorna uma lista de gêneros e um status code</returns>

        [HttpGet]
        [Authorize]//Precisa estar logado para acessar a rota
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista para receber os generos
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                //Retorna o "status code 200 = ok" e a lista de gêneros no formato json
                return Ok(ListaGeneros);
            }
            catch (Exception erro)
            {   //Retorna um "status code 400 = BadRequest" e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endepoint que acessa o método de listar gênero por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Retorna um gênero específico requisitado junto de um status code</returns>
        [HttpGet("{Id}")]
        public IActionResult GetId(int Id)
        {
            try
            {
                GeneroDomain generoBuscar = _generoRepository.BuscarPorId(Id);

                if (generoBuscar == null)
                {
                    return NotFound("O Gênero buscado não foi encontrado!");
                }

                return Ok(generoBuscar);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }



        /// <summary>
        /// Endpoint que acessa o método de cadastrar gênero
        /// </summary>
        /// <param name="cadGenero">Objeto recebido na requisição</param>
        /// <returns>Retorna um status code(created/criado)</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(GeneroDomain cadGenero)
        {
            try
            {
                //Faz a chamada para o método cadastrar
                _generoRepository.Cadastrar(cadGenero);

                //Retorna status code (Criado)
                return StatusCode(204);
            }
            catch (Exception error)
            {
                //Retorna um "status code 400 = BadRequest" e a mensagem de erro
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método deletar pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                //chama o método atualizar
                _generoRepository.Deletar(id);

                //retorna status code
                return StatusCode(204);
            }
            catch (Exception wrong)
            {

                return BadRequest(wrong.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método atualizar gênero pelo corpo
        /// </summary>
        /// <param name="corpoGenero"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(GeneroDomain corpoGenero)
        {
            try
            {
               GeneroDomain generoBuscado = _generoRepository.BuscarPorId(corpoGenero.IdGenero);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdCorpo(corpoGenero);
                        return StatusCode(204);
                    }
                    catch (Exception erro)
                    {

                        return BadRequest (erro.Message);
                    }
                }
                return NotFound("Genero não encontrado !!");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Endpoint que acessa o método de atualizar pelo url
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="urlGenero"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult PutUrl(int Id, GeneroDomain urlGenero)
        {
            try
            {
                _generoRepository.AtualizarIdUrl(Id, urlGenero);

                return StatusCode(200);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}


