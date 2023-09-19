using Microsoft.EntityFrameworkCore;
using WebApiEvent_.Domains;

namespace WebApiEvent_.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencaEvento> PresencaoEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //User Id = sa; pwd = "Senha" - para quem usa autenticação do SqlServer
            //Caso usemos autenticação do Windows só colocar Integrated Security = True;
            optionsBuilder.UseSqlServer("Server = NOTE12-S14; Database = API_Event+; User Id = sa; pwd = Senai@134; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);

        }
    }
}
