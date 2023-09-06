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
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryCreate = "Insert into Jogo (Nome, IdEstudio, Descricao, DataLancamento, Valor) values (@Nome, @IdEstudio, @Descricao, @Data, @Valor)";

                using (SqlCommand cmd = new SqlCommand(queryCreate, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@Data", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain ListaIdJogos(int id)
        {
            throw new NotImplementedException();
        }

        public List<JogoDomain> ListaJogos()
        {
            List<JogoDomain> ListaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryRead = "select Jogo.IdJogo, Jogo.Nome, Jogo.Descricao, Jogo.DataLancamento, Jogo.Valor, Estudio.Nome, Jogo.IdEstudio from Jogo inner join Estudio on Jogo.IdEstudio = Estudio.IdEstudio";

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

                            IdEstudio = Convert.ToInt32(rdr[6]),

                            Nome = rdr[nameof(JogoDomain.Nome)].ToString(),

                            Descricao = rdr[nameof(JogoDomain.Descricao)].ToString(),

                            DataLancamento = Convert.ToDateTime(rdr[3]),

                            Valor = rdr[nameof(JogoDomain.Valor)].ToString()

                        };

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            IdEstudio = Convert.ToInt32(rdr[6]), 

                            Nome = rdr[nameof(EstudioDomain.Nome)].ToString()
                        };

                        jogo.Estudio = estudio;

                        ListaJogo.Add(jogo);

                    }
                }
            }
            return ListaJogo;
        }





    }
}
