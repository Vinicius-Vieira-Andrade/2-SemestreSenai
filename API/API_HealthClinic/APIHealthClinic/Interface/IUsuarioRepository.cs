using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IUsuarioRepository
    {
        Usuario BuscarEmailSenha(string email, string senha);

        void CadastrarUsuario(Usuario usuario);
    }
}
