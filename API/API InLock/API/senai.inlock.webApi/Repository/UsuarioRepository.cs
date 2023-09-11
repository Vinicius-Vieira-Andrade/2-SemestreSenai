using senai.inlock.webApi.Domain;
using senai.inlock.webApi.Interface;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string StringConexao = "Data Source = NOTE12-S14; Initial Catalog = inlock_games_tarde; User Id = sa; pwd = Senai@134";

        public UsuarioDomain Login(string Email, string Senha)
        {
            UsuarioDomain loginUser = new UsuarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "select Usuario.IdUsuario, Usuario.IdTipoUsuario, Usuario.Email from Usuario where Email = @Email AND Senha = @Senha";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        loginUser.IdUsuario = Convert.ToInt32(rdr[0]);
                        loginUser.IdTipoUsuario = Convert.ToInt32(rdr[1]);
                        loginUser.Email = rdr[nameof(UsuarioDomain.Email)].ToString();

                        return loginUser;
                    }
                    return null;
                }
            }
        }
    }
}
