using APIHealthClinic.Context;
using APIHealthClinic.Domain;
using APIHealthClinic.Interface;

namespace APIHealthClinic.Repository
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext ctx;

        public ClinicaRepository()
        {
            ctx = new HealthContext();
        }

        public void CadastrarClinica(Clinica clinica)
        {
            ctx.Clinica.Add(clinica);
            ctx.SaveChanges();
        }

        public void RemoverClinica(Guid id)
        {
            Clinica clinicaBuscada = ctx.Clinica.FirstOrDefault(c => c.IdClinica == id)!;

            if (clinicaBuscada != null)
            {
                ctx.Clinica.Remove(clinicaBuscada);
            }

            ctx.SaveChanges();
        }
    }
}
