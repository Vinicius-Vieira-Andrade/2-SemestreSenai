using System.Data.SqlClient;
using webapi.filmes.tarde.Controllers;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {


        private string StringConexao = "Data Source = note12-s14; Initial Catalog = Filmes_Tarde; User Id = sa; pwd = Senai@134";

        public void AtualizarPorId(FilmeDomain Filme)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateBody = "UPDATE Filme SET Titulo = @TituloInserir WHERE IdFilme = @IdBuscar";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@IdBuscar", Filme.IdFilme);
                    cmd.Parameters.AddWithValue("@TituloInserir", Filme.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarPorUrl(int Id, FilmeDomain urlGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "UPDATE Filme SET Titulo = @TituloInserir WHERE IdFilme = @IdBuscar";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@TituloInserir", urlGenero.Titulo);
                    cmd.Parameters.AddWithValue("@IdBuscar", Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FilmeDomain BuscaPorId(int id)
        {

            FilmeDomain filmeBuscar = new FilmeDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryBuscaId = "select Filme.IdFilme, Filme.Titulo, Genero.IdGenero, Genero.Nome from Filme left join Genero on Filme.IdGenero = Genero.IdGenero where IdFilme = @IdBuscar";

                con.Open();

                SqlDataReader ler;

                using (SqlCommand cmd = new SqlCommand(queryBuscaId, con))
                {
                    cmd.Parameters.AddWithValue("@IdBuscar", id);

                    ler = cmd.ExecuteReader();

                    if (ler.Read())
                    {
                        filmeBuscar.IdFilme = Convert.ToInt32(ler[0]);

                        filmeBuscar.Titulo = ler["Titulo"].ToString();

                        GeneroDomain generoo = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(ler[2]),
                            Nome = ler["Nome"].ToString()
                        };
                        filmeBuscar.Genero = generoo;

                        return filmeBuscar;
                    }


                    else
                    {
                        return null;
                    }

                }
            }
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryCadastro = "Insert into Filme (IdGenero, Titulo) values (@IdGuarda, @TituloInserido)";

                using (SqlCommand cmd = new SqlCommand(queryCadastro, con))
                {
                    cmd.Parameters.AddWithValue("@IdGuarda", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@TituloInserido", novoFilme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "delete from Filme where IdFilme = @IdVariavel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdVariavel", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string listaTudo = "SELECT Filme.IdFilme, Genero.IdGenero, Filme.Titulo, Genero.Nome FROM Filme left join Genero on Genero.IdGenero = Filme.IdGenero";

                con.Open();

                SqlDataReader ler;

                using (SqlCommand cmd = new SqlCommand(listaTudo, con))
                {
                    ler = cmd.ExecuteReader();

                    while (ler.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(ler[0]),

                            IdGenero = Convert.ToInt32(ler[1]),

                            Titulo = ler["Titulo"].ToString(),
                        };

                        GeneroDomain generoo = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(ler[1]),
                            Nome = ler["Nome"].ToString()
                        };

                        filme.Genero = generoo;

                        ListaFilmes.Add(filme);
                    }
                }
            }
            return ListaFilmes;
        }

    }
}
