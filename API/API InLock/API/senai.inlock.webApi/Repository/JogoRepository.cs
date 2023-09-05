using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = note12-s14; Initial Catalog = inlock_games_tarde; User Id = sa; pwd = Senai@134";
        public void CadastraJogos(JogoDomain novoJogo)
        {
            throw new NotImplementedException();
        }

        public JogoDomain ListaIdJogos(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListaJogos()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryRead = "select Jogo.IdJogo, Jogo.Nome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor, Estudio.Nome from Jogo inner join Estudio on Jogo.IdEstudio = Estudio.IdEstudio";

                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryRead, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogo = new JogoDomain()
                        {

                        IdJogo = Convert.ToInt32(rdr[0]),

                        Nome = ler

                        }


                    }
                }
            }
        }
    }
}
