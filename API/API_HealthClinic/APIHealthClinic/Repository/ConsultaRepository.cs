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

        public Consulta BuscarConsultaId(Guid id)
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
                    IdPaciente = c.IdPaciente
                }
            }
            ).FirstOrDefault(m => m.IdConsulta == id)!;
            return buscarConsulta;
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

        public void FazerComentario(Guid id ,Feedback comentario)
        {
            Consulta consultaBuscada = ctx.Consulta.FirstOrDefault(c => c.IdConsulta == id)!;
            if (consultaBuscada != null)
            {
                ctx.Feedback.Add(comentario);

                consultaBuscada.IdFeedback = comentario.IdFeedback;
                ctx.Update(consultaBuscada);
            }
            ctx.SaveChanges();
        }

        public List<Consulta> ListarConsultas()
        {
            return ctx.Consulta.ToList();
        }
    }
}
