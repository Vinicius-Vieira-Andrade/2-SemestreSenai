using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IUsuario
    {
        Usuario Logar(string email, string senha);

        void CadastrarUsuario(Usuario usuario);
    }
}
