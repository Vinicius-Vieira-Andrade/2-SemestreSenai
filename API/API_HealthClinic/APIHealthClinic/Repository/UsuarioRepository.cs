using APIHealthClinic.Context;
using APIHealthClinic.Domain;
using APIHealthClinic.Interface;
using APIHealthClinic.Utils;

namespace APIHealthClinic.Repository
{
    public class UsuarioRepository : IUsuario
    {
        private readonly HealthContext ctx;

        public UsuarioRepository()
        {
            ctx = new HealthContext();
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar novo usuario!");
            }
        }

        Usuario IUsuario.Logar(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario.Select(u => new Usuario
                {
                    IdTipoUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    Senha = u.Senha,

                    TipoUsuario = new TipoUsuario
                    {
                        IdTipoUsuario = u.IdTipoUsuario,
                        TituloTipoUsuario = u.TipoUsuario.TituloTipoUsuario
                    }




                }).FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.ComparaHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao buscar usuario");
            }
        }
    }
}
