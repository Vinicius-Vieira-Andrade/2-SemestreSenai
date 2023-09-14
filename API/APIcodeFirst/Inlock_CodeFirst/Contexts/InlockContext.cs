using Inlock_CodeFirst.Domains;
using Microsoft.EntityFrameworkCore;

namespace Inlock_CodeFirst.Contexts
{
    public class InlockContext : DbContext
    {
        /// <summary>
        /// Definição das entidades no banco de dados
        /// </summary>
        public DbSet<TipoUsuario> TipoUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Estudio> Estudio { get; set; }

        public DbSet<Jogo> Jogo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //User Id = sa; pwd = "Senha" - para quem usa autenticação do SqlServer
            //Caso usemos autenticação do Windows só colocar Integrated Security = True;
            optionsBuilder.UseSqlServer("Server = NOTE12-S14; Database = InLock_Tarde; User Id = sa; pwd = Senai@134; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
            
        }
    }
}
