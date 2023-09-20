using System.ComponentModel.DataAnnotations;

namespace WebApiEvent_.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório!")]
        public string? Email { get; set; }



        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }
    }
}
