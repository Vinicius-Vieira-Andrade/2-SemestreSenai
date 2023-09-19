using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEvent_.Domains
{
    [Table(nameof(PresencaEvento))]
    public class PresencaEvento
    {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();



        [Required(ErrorMessage = "A situação é obrigatória!!!")]
        [Column(TypeName = "bit")]
        public bool Situacao { get; set; }



        //ref.tabela Usuario = fk
        [Required(ErrorMessage = "Usuario obrigatório!!!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }



        //ref.tabela Evento = fk
        [Required(ErrorMessage = "Evento obrigatório!!!")]
        public Guid IdEvento { get; set; }


        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }
    }
}
