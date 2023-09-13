using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlock_CodeFirst.Domains
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "O Email é obrigatório!")]
        [Column(TypeName = "varchar(100)")]
        [EmailAddress(ErrorMessage = "Endereço de Email inválido")]
        public string? Email { get; set; }


       
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [Column(TypeName = "varchar(100)")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 20 caracteres!")]
        public string? Senha { get; set; }



    }
}
