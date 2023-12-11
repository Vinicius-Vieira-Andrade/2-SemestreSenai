using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        //acesso aos métodos do repositório
        ComentariosEventoRepository comentario = new ComentariosEventoRepository();

        //armazena dados da API externa (IA - Azure)
        private readonly ContentModeratorClient? _contentModeratorClient;

        /// <summary>
        /// construtor que recebe os dados necessários para o acesso ao serviço externo
        /// </summary>
        /// <param name="contentModerator">objeto do tipo ContentModeratorClient</param>
        public ComentariosEventoController(ContentModeratorClient contentModerator)
        {
            _contentModeratorClient= contentModerator;
        }



        [HttpPost("Cadastra IA")]
        public async Task<IActionResult> PostIA(ComentariosEvento novoComentario)
        {
            try
            {
                //se a descrição do comentário não for passado no objeto 
                if (string.IsNullOrEmpty(novoComentario.Descricao))
                {
                    return BadRequest("O texto a ser moderado não pode ser vazio!");
                }

                //converte a string(descrição do comentário) em um MemoryStream
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(novoComentario.Descricao));

                //realiza a moderação do conteúdo
                var moderationResult = await _contentModeratorClient.TextModeration.ScreenTextAsync("text/plain", stream, "por", false, false, null, true);


                //moderationResult.Terms != null ? novoComentario.Exibe = false : novoComentario.Exibe = true;
                    //se existir termos ofensivos, não mostrar(exibe = false)
                    if (moderationResult.Terms != null)
                {
                    novoComentario.Exibe = false;
                    comentario.Cadastrar(novoComentario);
                }
                else
                {
                    novoComentario.Exibe = true;
                    comentario.Cadastrar(novoComentario);
                }
                return StatusCode(201, novoComentario);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(comentario.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetIA()
        {
            try
            {
                return Ok(comentario.ListarSomenteExibe());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }



        [HttpGet("BuscaPorIdUsuario")]
        public IActionResult GetById(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(comentario.BuscarPorId(idUsuario, idEvento));
            }
            catch (Exception e) {
            
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(ComentariosEvento comentarioNovo)
        {
            try
            {
                comentario.Cadastrar(comentarioNovo);
                return StatusCode(201, comentarioNovo);
            }
            catch (Exception e) { 
            
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                comentario.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
