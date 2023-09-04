using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {

        /// <summary>
        /// STRING DE CONEXAO COM O BANCO DE DADOS QUE RECEBEM OS SEGUINTES PARÂMETROS
        /// DATA SOURCE = nome do servidor;
        /// INITIAL CATALOG = Nome do banco de dados;
        /// AUTENTIFICAÇÃO:
        ///     - WINDOWS =  Integrated Secutiry = True;
        ///     - SQLSERVER = User Id = sa; pwd = Senha;
        /// </summary>
        private string StringConexao = "Data Source = note12-s14; Initial Catalog = Filmes_Tarde; User Id = sa; pwd = Senai@134";

        /// <summary>
        /// Atualiza um registro
        /// </summary>
        /// <param name="corpoGenero">objeto com as informacoes a serem atualizadas</param>
        public void AtualizarIdCorpo(GeneroDomain corpoGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @NomeInserir WHERE IdGenero = @Id";

                using (SqlCommand comando = new SqlCommand(queryUpdate, con))
                {
                    comando.Parameters.AddWithValue("@NomeInserir", corpoGenero.Nome);
                    comando.Parameters.AddWithValue("@Id", corpoGenero.IdGenero);

                    con.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int Id, GeneroDomain urlGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "UPDATE Genero SET Nome = @NomeInserir WHERE IdGenero = @IdGenero";

                using (SqlCommand comando = new SqlCommand(queryUpdateUrl, con))
                {
                    comando.Parameters.AddWithValue("@NomeInserir", urlGenero.Nome);
                    comando.Parameters.AddWithValue("@IdGenero", Id);

                    con.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public GeneroDomain BuscarPorId(int Id)
        {
            GeneroDomain generoBuscar = new GeneroDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdBuscar";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(queryById, con))
                {
                    cmd.Parameters.AddWithValue("@IdBuscar", Id);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        generoBuscar.IdGenero = Convert.ToInt32(reader[0]);

                        generoBuscar.Nome = reader["Nome"].ToString();

                        return generoBuscar;
                    }

                    else
                    {
                        return null;
                    }
                }
            }
            
        }


        /// <summary>
        /// cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto com as informacoes que serao cadastradas</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //declara a query que será executada
                string queryInsert = "insert into Genero (Nome) values (@Nome)";

                //abre a conexao com o banco de dados, ele poderia estar dentro do using abaixo, não tem problema,pois só estamos declarando ela

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                                                // valor da variavel @Nome sera o nome do objeto novoGenero
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    con.Open();
                    //Executa a query, nota-se que não usamos o "reader", pois não iremos ler nada
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int Id)
        {
            using (SqlConnection connect = new SqlConnection(StringConexao))
            {
                string queryDelete = "delete from Genero where IdGenero = @IdGenero";

             
                using (SqlCommand cmd = new SqlCommand(queryDelete, connect))
                {
                   cmd.Parameters.AddWithValue ("@IdGenero", Id);

                   connect.Open();

                   cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os objetos do tipo "Gênero"
        /// </summary>
        /// <returns>Lista de objetos do tipo gênero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria/instancia uma lista de gêneros, onde será armazenados os dados
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();


            //Declara a SQLConnection passando a string de conexao como parâmetro
            using (SqlConnection connect = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string selectAll = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexão com o banco de dados
                connect.Open();

                //Declara o SQLDataReader para percorrer/ler a tabela no banco de dados
                SqlDataReader reader;


                //Declara o SQL command passando a variavel q guarda a query a ser executada(SelectALL que é a variavel q guarda o resultado do comando a ser executado), junto da conexao(connect, que conecta ao banco de dados)
                using (SqlCommand command = new SqlCommand(selectAll, connect))
                {
                    //executa a query e armazena os dados no reader que eu ja declarei anteriormente
                    reader = command.ExecuteReader();


                    //Enquanto houver registro para serem lidos no reader
                    //O laço se repetirá
                    while (reader.Read())
                    {
                        //instancia um objeto do tipo GeneroDomain
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero, o valor da 
                            //primeira coluna da tabela
                            IdGenero = Convert.ToInt32(reader[0]),

                            //Atribui a propriedade Nome, o valor da
                            //coluna nome
                            Nome = reader[nameof(GeneroDomain.Nome)].ToString()
                        };


                        //Adiciona o objeto criado dentro da lista 
                        ListaGeneros.Add(genero);
                    }
                }
            }

            //retorna a lista de gêneros com os objetos já atribuidos 
            return ListaGeneros;
        }
    }
}
