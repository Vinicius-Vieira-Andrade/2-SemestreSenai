using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIHealthClinic.Domain
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();



        [Required(ErrorMessage = "O id do usuario é obrigatório!!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }




        [Required(ErrorMessage = "O id da especialidade é obrigatória!!")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }




        [Required(ErrorMessage = "O id da clinica é obrigatória!!")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }



        [Required(ErrorMessage = "O número do CRM é obrigatório!")]
        [Column(TypeName = "CHAR(13)")]
        public string? CRM { get; set; }
    }
}
