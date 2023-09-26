using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIHealthClinic.Domain
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "O endereço é obrigatório!")]
        [Column(TypeName = "Varchar(300)")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [Column(TypeName = "INT")]
        [MinLength(14, ErrorMessage = "O CNPJ aceita no minimo 14 caracteres!")]
        [MaxLength(14, ErrorMessage = "O CNPJ aceita no máximo 14 caracteres!")]
        public int CNPJ { get; set; }

        [Required(ErrorMessage = "A razão social é obrigatória!")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? RazaoSocial { get; set; }


        [Required(ErrorMessage = "O nome fantasia é obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        public string? NomeFantasia { get; set; }

    }
}
