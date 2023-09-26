using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIHealthClinic.Domain
{
    [Table(nameof(Feedback))]
    public class Feedback
    {
        [Key]
        public Guid IdFeedback { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(300)")]
        [Required(ErrorMessage = "O comentário é obrigatório!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        public bool ExibeFeedback { get; set; }
    }
}
