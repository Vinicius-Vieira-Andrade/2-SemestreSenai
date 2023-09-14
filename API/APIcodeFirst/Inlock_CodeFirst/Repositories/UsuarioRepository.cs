using Inlock_CodeFirst.Contexts;
using Inlock_CodeFirst.Domains;
using Inlock_CodeFirst.Interfaces;
using Inlock_CodeFirst.Utils;

namespace Inlock_CodeFirst.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        /// <summary>
        /// Injeção de dependencias, uma das, o usuario tem acesso a infos do banco, mas somente para leitura
        /// </summary>
        private readonly InlockContext AcessaBanco;
        public UsuarioRepository()
        {
            AcessaBanco = new InlockContext();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
               usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                AcessaBanco.Usuario.Add(usuario);
                AcessaBanco.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario Login(string Email, string Senha)
        {
            try
            {
                var usuarioBuscado = AcessaBanco.Usuario.FirstOrDefault(u => u.Email == Email);

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.ComparaHash(Senha, usuarioBuscado.Senha!);

                     if (confere )
                    {
                        return usuarioBuscado;
                    }
                }

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
