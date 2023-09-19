using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiEvent_.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();



        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "O nome é obrigatório!!!")]
        public string? Nome { get; set; }



        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "O Email é obrigatório!!!")]
        public string? Email { get; set; }



        [Column(TypeName = "char(60)")]
        [Required(ErrorMessage = "A senha é obrigatória!!!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }






        //ref.tabela TipoUsuario = FK
        [Required(ErrorMessage = "O tipo de usuario é obrigatório!!!")]
        public Guid IdTipoUsuario { get; set; }


        [ForeignKey(nameof(IdTipoUsuario))] //usa a prop de cima
        public TipoUsuario? TipoUsuario { get; set; }


    }
}
