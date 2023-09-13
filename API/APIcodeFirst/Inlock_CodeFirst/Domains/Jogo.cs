using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlock_CodeFirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O Nome do jogo é obrigatório!")]
        [Column(TypeName = "Varchar(100)")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A descrição do jogo é obrigatória")]
        [Column(TypeName = "text")]
        public string? Descricao { get; set; }

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "A Data de lançamento do jogo é obrigatória")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "Decimal(4,2)")]
        [Required(ErrorMessage = "O valor do jogo é obrigatório!")]
        public decimal Preço { get; set; }


        //ref.tabela estúdio - FK
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]

        public Estudio? Estudio { get; set; }
    }
}
