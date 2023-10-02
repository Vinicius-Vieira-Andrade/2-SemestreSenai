using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIHealthClinic.Domain
{
    [Table(nameof(Paciente))]
    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();


        [Required(ErrorMessage = "O usuario é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]  
        public Usuario? Usuario { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string? Telefone { get; set; }

        [Column(TypeName = "varchar(9)")]
        public string? RG { get; set; }

        [Column(TypeName = "varchar(3)")]
        public string? Idade { get; set; }
    }
}
