using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIHealthClinic.Domain
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O email é obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Tipo de usuario é obrigatório!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
