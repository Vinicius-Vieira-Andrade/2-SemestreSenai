using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "O Email não pode ser nulo e deverá ser unico")]
        public string? Email { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa de no minimo 3 e no maximo 20 caracteres !!!")]
        [Required(ErrorMessage = "A senha não pode ser nula")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "A permissão não pode ser nula")]
        public string? Permissao { get; set; }
    }
}
