using WebApiEvent_.Domains;

namespace WebApiEvent_.Interfaces
{
    public interface IPresencaEvento
    {
        void Deletar(Guid id);

        List<PresencaEvento> Listar();

        PresencaEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, PresencaEvento presencaEvento);

        List<PresencaEvento> ListarMinhas(Guid idUsuario);

        void Inscrever(PresencaEvento inscricao);
    }
}
