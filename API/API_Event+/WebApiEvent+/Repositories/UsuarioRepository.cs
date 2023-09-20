using WebApiEvent_.Contexts;
using WebApiEvent_.Domains;
using WebApiEvent_.Interfaces;
using WebApiEvent_.Utils;

namespace WebApiEvent_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext ctx;

        public UsuarioRepository()
        {
            ctx = new EventContext();
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
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
                        IdTipoUsuario = u.IdUsuario,
                        Titulo = u.TipoUsuario.Titulo
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

        public Usuario BuscarPorId(Guid id)
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
                        IdTipoUsuario = u.IdUsuario,
                        Titulo = u.TipoUsuario.Titulo
                    }
                }).FirstOrDefault(u => u.IdUsuario == id)!;

                return usuarioBuscado;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar usuário");
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Cadastrar o usuário");
            }
        }
    }
}
