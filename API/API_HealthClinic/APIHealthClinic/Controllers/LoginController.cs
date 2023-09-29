using APIHealthClinic.Domain;
using APIHealthClinic.Interface;
using APIHealthClinic.Repository;
using APIHealthClinic.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace APIHealthClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult BuscarEmailSenha(LoginViewModel user)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarEmailSenha(user.Email!, user.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha invalidos!");
                }


                var claims = new[]
                {
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome!),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdTipoUsuario.ToString())
                };



                var Key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("aaaaaaaaaaaaa-maior-autenticacao-tarde-healthclinic-key-webapi"));


                var creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    issuer: "webapi-healthclinic",

                    audience: "webapi-healthclinic",

                    claims: claims,

                    expires: DateTime.Now.AddMinutes(3),

                    signingCredentials: creds

                );



                return Ok(new

                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
