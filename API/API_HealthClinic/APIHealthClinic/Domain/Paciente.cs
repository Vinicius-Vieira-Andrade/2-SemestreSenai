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


        public int Telefone { get; set; }

        public int RG { get; set; }

        public int Idade { get; set; }
    }
}
