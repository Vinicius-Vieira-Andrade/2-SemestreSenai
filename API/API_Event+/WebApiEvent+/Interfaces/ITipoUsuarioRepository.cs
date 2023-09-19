using WebApiEvent_.Domains;

namespace WebApiEvent_.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipousuario);

        void Deletar(Guid id);

        List<TipoUsuario> Listar();

        TipoUsuario BuscarPorId();

        void Atualizar(Guid id, TipoUsuario tipoUsuario);
    }

}
