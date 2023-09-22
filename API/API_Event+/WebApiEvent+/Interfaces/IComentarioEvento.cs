using WebApiEvent_.Domains;

namespace WebApiEvent_.Interfaces
{
    public interface IComentarioEvento
    {
        void Cadastrar(ComentarioEvento comentario);

        void Deletar(Guid id);
        List<ComentarioEvento> Listar();

        ComentarioEvento BuscaId(Guid id);
    }
}
