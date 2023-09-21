using WebApiEvent_.Domains;

namespace WebApiEvent_.Interfaces
{
    public interface IEvento
    {
        void Cadastrar(Evento evento);

        void Deletar(Guid id);

        void Atualizar(Guid id, Evento evento);

        List<Evento> Listar();

        Evento BuscarId(Guid id);
    }
}
