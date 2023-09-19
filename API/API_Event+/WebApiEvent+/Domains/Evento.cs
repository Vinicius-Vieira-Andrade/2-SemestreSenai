using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEvent_.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();



        [Required(ErrorMessage = "O nome do evento é obrigatório!!!")]
        [Column(TypeName = "varchar(100)")]
        public string? Nome { get; set; }



        [Required(ErrorMessage = "A data do evento é obrigatório!!!")]
        [Column(TypeName = "date")]
        public DateTime DataEvento { get; set; }



        [Required(ErrorMessage = "A descrição do evento é obrigatório!!!")]
        [Column(TypeName = "varchar(250)")]
        public string? Descricao { get; set; }




        //ref.tabela TipoEvento = fk
        [Required(ErrorMessage = "O tipo de evento é obrigatório!!!")]
        public Guid IdTipoEvento { get; set; }


        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }




        //ref.tabela Instituicao = fk
        [Required(ErrorMessage = "A instituição é obrigatória!!!")]
        public Guid IdInstituicao { get; set; }


        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
