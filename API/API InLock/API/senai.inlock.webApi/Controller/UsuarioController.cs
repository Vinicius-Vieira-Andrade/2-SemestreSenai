using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using senai.inlock.webApi.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository;


        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult LoginPost (UsuarioDomain user)
        {
            try
            {
                UsuarioDomain loginUser = _UsuarioRepository.Login(user.Email, user.Senha);

                if (loginUser == null)
                {
                    return NotFound("Usuario não encontrado!!");
                }

                //Caso encontre o usuario buscado(loginUser), prossegue para a criação do token

                //1º Definir as claims(informacoes) que serão fornecidos no token(payload)

                var claims = new[]
                {
                    //formato da claim(tipo, valor)
                    new Claim(JwtRegisteredClaimNames.Jti, loginUser.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, loginUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, loginUser.IdTipoUsuario.ToString())

                };


                //2º Definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));


                //3º Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


                //4º Gerar o token 
                var token = new JwtSecurityToken
                (
                    //Emissor do token
                    issuer: "webapi.jogos.inlock",

                    //Destinatário
                    audience: "webapi.jogos.inlock",

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
