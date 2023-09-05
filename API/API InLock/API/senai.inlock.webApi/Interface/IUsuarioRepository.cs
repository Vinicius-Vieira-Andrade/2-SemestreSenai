using senai.inlock.webApi.Domain;

namespace senai.inlock.webApi.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string Email, string Senha);
    }
}
