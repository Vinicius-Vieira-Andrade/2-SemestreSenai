using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlock_CodeFirst.Domains
{
    [Table("Estudio")]
    public class Estudio
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string? Nome { get; set; }

        //referência lista de jogos
        public List<Jogo>? Jogos { get; set; }


    }
}
