using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEvent_.Domains
{
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
    {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();



        [Required(ErrorMessage = "A descricao do evento é obrigatória!!!")]
        [Column(TypeName = "text")]
        public string? Descricao { get; set; }


        [Required(ErrorMessage = "A informação sobre exibição é obrigatória!!!")]
        [Column(TypeName = "bit")]
        public bool Exibe { get; set; }




        //ref.tabela Usuario = fk
        [Required(ErrorMessage = "O usuário é obrigatório!!!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }



        //ref.tabela Evento = fk
        [Required(ErrorMessage = "O Evento é obrigatório!!!")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }




    }
}
