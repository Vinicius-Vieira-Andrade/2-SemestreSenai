using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIHealthClinic.Domain
{
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Titulo é obrigatório")]
        public string? Titulo { get; set; }
    }
}
