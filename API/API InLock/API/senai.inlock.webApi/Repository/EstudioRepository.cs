using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class EstudioRepository : IEstudioRepository
    {
        private string StringConexao = "Data Source = NOTE12-S14; Initial Catalog = inlock_games_tarde; User Id = sa; pwd = Senai@134";


        //EXTRA DESAFIO (Em andamento)
        public List<EstudioDomain> BuscarEstudios()
        {
            List<EstudioDomain> ListaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAllEstudios = "SELECT Estudio.IdEstudio, Estudio.Nome FROM Estudio";


                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryAllEstudios, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain mostraEstudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudios"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        JogoDomain mostraJogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            
                        };
                    }



                }
            }
        }

        public void Cadastrar(EstudioDomain novoEstudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryAdd = "Insert into Estudio values (@Nome)";


                using (SqlCommand cmd = new SqlCommand(queryAdd, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }




        public List<EstudioDomain> ListaEstudios()
        {
            List<EstudioDomain> ListaEstudio = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string? queryLista = "Select Estudio.IdEstudio, Estudio.Nome From Estudio";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLista, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        ListaEstudio.Add(estudio);
                    }
                }
            }
            return ListaEstudio;
        }
    }
}
