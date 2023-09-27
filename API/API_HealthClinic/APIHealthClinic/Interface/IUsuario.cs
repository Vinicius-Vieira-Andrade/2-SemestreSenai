using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IUsuario
    {
        void Logar(string email, string senha);

        void CadastrarUsuario(Usuario usuario);
    }
}
