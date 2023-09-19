using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEvent_.Domains
{
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O título do tipo de usuario é obrigatório!!!")]
        [Column(TypeName = "varchar(100)")]
        public string? Titulo { get; set; }
    }
}
