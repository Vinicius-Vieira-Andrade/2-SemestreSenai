using WebApiEvent_.Domains;

namespace WebApiEvent_.Interfaces
{
    public interface ITipoEvento
    {
        void Cadastrar(TipoEvento tipoEvento);

        void Deletar(Guid id);

        void Atualizar(Guid id, TipoEvento tipoEvento);

        List<TipoEvento> Listar();

        TipoEvento BuscarId(Guid id);
    }
}
