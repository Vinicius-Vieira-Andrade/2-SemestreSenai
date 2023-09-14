using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlock_CodeFirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "O Email é obrigatório!")]
        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }


       
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [Column(TypeName = "varchar(200)")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 60 caracteres!")]
        public string? Senha { get; set; }

        //ref.tabela TipoUsuario
        [Required(ErrorMessage = "O tipo usuario é obrigatório")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }
        
    }
}
