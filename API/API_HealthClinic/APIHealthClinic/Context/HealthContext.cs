using APIHealthClinic.Domain;
using Microsoft.EntityFrameworkCore;

namespace APIHealthClinic.Context
{
    public class HealthContext : DbContext
    {
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Feedback> Feedback { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //User Id = sa; pwd = "Senha" - para quem usa autenticação do SqlServer
            //Caso usemos autenticação do Windows só colocar Integrated Security = True;
            optionsBuilder.UseSqlServer("Server = NOTE12-S14; Database = API_Tarde_HealthClinic; User Id = sa; pwd = Senai@134; TrustServerCertificate = True;");
            base.OnConfiguring(optionsBuilder);
        }

        internal Clinica Find(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
