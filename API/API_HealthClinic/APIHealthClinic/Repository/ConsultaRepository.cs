using APIHealthClinic.Context;
using APIHealthClinic.Domain;
using APIHealthClinic.Interface;

namespace APIHealthClinic.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly HealthContext ctx;

        public ConsultaRepository()
        {
            ctx = new HealthContext();
        }
        public void AgendarConsulta(Consulta consulta)
        {
            ctx.Consulta.Add(consulta);
            ctx.SaveChanges();
        }

        public void AtualizarConsulta(Guid id, Consulta consulta)
        {
            Consulta consultaBuscar = ctx.Consulta.Find(id)!;

            if (consultaBuscar != null)
            {
                consultaBuscar.Data = consulta.Data;
                consultaBuscar.IdPaciente = consulta.IdPaciente;
                consultaBuscar.IdFeedback = consulta.IdFeedback;
                consultaBuscar.IdMedico = consulta.IdMedico;
                consultaBuscar.Prontuario = consulta.Prontuario;
            }

            ctx.Consulta.Update(consultaBuscar!);
            ctx.SaveChanges();
        }

        public void BuscarConsultaId(Guid id)
        {
            Consulta buscarConsulta = ctx.Consulta.Select(c => new Consulta
            {
                IdConsulta = c.IdConsulta,
                Data = c.Data,
                Prontuario = c.Prontuario,

                Medico = new Medico()
                {
                    IdMedico = c.IdMedico
                },

                Feedback = new Feedback()
                {
                    IdFeedback = c.IdFeedback,
                    Descricao = c.Feedback.Descricao,
                    ExibeFeedback = c.Feedback.ExibeFeedback,
                },

                Paciente = new Paciente()
                {
                    IdPaciente = c.IdPaciente,
                    RG = c.Paciente.RG,
                    Telefone = c.Paciente.Telefone,
                    Idade = c.Paciente.Idade,
                }
            }
            ).FirstOrDefault(m => m.IdConsulta == id)!;


        }

        public void CancelarConsulta(Guid id)
        {
            Consulta buscarConsulta = ctx.Consulta.Find(id)!;

            if (buscarConsulta != null)
            {
                ctx.Consulta.Remove(buscarConsulta);
            }

            ctx.SaveChanges();
        }

        public List<Consulta> ListarConsultas()
        {
            return ctx.Consulta.ToList();
        }
    }
}
