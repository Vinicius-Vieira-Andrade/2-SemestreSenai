namespace senai.inlock.webApi.Domain
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public int IdTipoUsuario { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }
    }
}
