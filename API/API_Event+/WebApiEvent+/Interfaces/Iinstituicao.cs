using WebApiEvent_.Domains;

namespace WebApiEvent_.Interfaces
{
    public interface Iinstituicao
    {
        void Cadastrar(Instituicao instituicao);

        void Deletar(Guid id);

        void Atualizar(Guid id, Instituicao instituicao);

        List<Instituicao> Listar();

        Instituicao BuscarId(Guid id);
    }
}
