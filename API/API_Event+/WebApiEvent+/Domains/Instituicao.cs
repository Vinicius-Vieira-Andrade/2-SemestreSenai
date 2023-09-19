using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEvent_.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();



        [Column(TypeName = "char(14)")]
        [Required(ErrorMessage = "CNPJ é obrigatório!!!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }



        [Column(TypeName = "varchar(200)")]
        [Required(ErrorMessage = "O Endereço é obrigatório!!!")]
        public string? Endereco { get; set; }



        [Column(TypeName = "varchar(55)")]
        [Required(ErrorMessage = "O nome fantasia é obrigatório!!!")]
        public string? NomeFantasia { get; set; }
    }
}
