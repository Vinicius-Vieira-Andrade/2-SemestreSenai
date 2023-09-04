using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

        private IUsuarioRepository _UsuarioRepository { get; set; }


        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult GetLogin(UsuarioDomain usuario)
        {
            try
            {
                UsuarioDomain loginUser = _UsuarioRepository.Login(usuario.Email, usuario.Senha);

                if (loginUser == null)
                {
                    return NotFound("Usuario não encontrado");

                }



                //Caso encontre o usuario buscado(loginUser), prossegue para a criação do token

                //1º Definir as claims(informacoes) que serão fornecidos no token(payload)

                var claims = new[]
                {
                    //formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, loginUser.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, loginUser.Email),
                    new Claim(ClaimTypes.Role, loginUser.Permissao),



                    //existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim Personalizada", "Valor Personalizado")

                };


                //2º Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));


                //3º Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                //4º Gerar o token 
                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "webapi.filmes.tarde",

                    //Destinatário
                    audience: "webapi.filmes.tarde",

                    //Dados definidos nas claims(PayLoad)
                    claims: claims,

                    //Tempo de expiração
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds
                );

                //5º Retornar o token criado
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
