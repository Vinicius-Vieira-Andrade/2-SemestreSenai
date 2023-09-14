using Inlock_CodeFirst.Domains;

namespace Inlock_CodeFirst.Interfaces
{
    public interface IUsuario
    {
        Usuario Login(string Email, string Senha);

        void Cadastrar (Usuario usuario);

    }
}
