using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Interfaces
{
    public interface IFilmeRepository
    {



        void Cadastrar(FilmeDomain novoFilme);

        List<FilmeDomain> ListarTodos();

        FilmeDomain BuscaPorId(int id);

        void AtualizarPorId(FilmeDomain Filme);

        void Deletar(int id);

        void AtualizarPorUrl(int id, FilmeDomain urlGenero);
    }
}
