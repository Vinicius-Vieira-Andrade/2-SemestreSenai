using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = note12-s14; Initial Catalog = Filmes_Tarde; User Id = sa; pwd = Senai@134";

        public UsuarioDomain Login(string Email, string Senha)
        {
            UsuarioDomain loginUser = new UsuarioDomain();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string? queryLogin = "SELECT Usuario.IdUsuario, Usuario.Email, Usuario.Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                SqlDataReader ler;

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    ler = cmd.ExecuteReader();


                    if (ler.Read())
                    {
                        loginUser.IdUsuario = Convert.ToInt32(ler[0]);
                        loginUser.Email = ler[nameof(UsuarioDomain.Email)].ToString();
                        loginUser.Permissao = ler[nameof(UsuarioDomain.Permissao)].ToString();

                        return loginUser;
                    }

                    else
                    {
                        return null;
                    }

                }
            }
        }
    }
}
