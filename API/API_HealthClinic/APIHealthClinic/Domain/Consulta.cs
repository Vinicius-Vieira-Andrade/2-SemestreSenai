using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIHealthClinic.Domain
{
    [Table(nameof(Consulta))]
    public class Consulta
    {
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O id do paciente é obrigatório!")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        public Guid IdFeedback { get; set; }

        [ForeignKey(nameof(IdFeedback))]
        public Feedback? Feedback { get; set; }

        [Required(ErrorMessage = "O id do médico é obrigatório!")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }

        [Required(ErrorMessage = "O prontuario é obrigatório!")]
        [Column(TypeName = "TEXT")]
        public string? Prontuario { get; set; }

        [Required(ErrorMessage = "A data é obrigatória!")]
        [Column(TypeName = "DATE")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O horário é obrigatório!")]
        [Column(TypeName = "TIME")]
        public TimeSpan Horario { get; set; } = new TimeSpan(1);
    }
}
