using APIHealthClinic.Context;
using APIHealthClinic.Domain;
using APIHealthClinic.Interface;

namespace APIHealthClinic.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext ctx;

        public PacienteRepository()
        {
            ctx = new HealthContext();
        }


        public void AtualizarPaciente(Guid id, Paciente paciente)
        {
            Paciente pacienteBuscado = ctx.Paciente.Find(id)!;

            if (pacienteBuscado != null)
            {
                pacienteBuscado.RG = paciente.RG;

                pacienteBuscado.Telefone = paciente.Telefone;

                pacienteBuscado.Idade = paciente.Idade;
            }

            ctx.Paciente.Update(pacienteBuscado!);
            ctx.SaveChanges();
        }

        public Paciente BuscarId(Guid id)
        {
            Paciente pacienteBuscado = ctx.Paciente.Select(u => new Paciente
            {

                Idade = u.Idade,
                Telefone = u.Telefone,

                Usuario = new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Usuario.Nome
                }
            }
            ).FirstOrDefault(u => u.IdPaciente == id)!;

            return pacienteBuscado;
        }

        public void CadastrarPaciente(Paciente paciente)
        {
            ctx.Paciente.Add(paciente);
            ctx.SaveChanges();
        }

        public List<Consulta> ListarConsulta(Guid id)
        {
            return ctx.Consulta.Where(c => c.IdPaciente == id).ToList();
        }

        public List<Paciente> ListarPaciente()
        {
            return ctx.Paciente.ToList();
        }

        public void Remover(Guid id)
        {
            Paciente pacienteBuscado = ctx.Paciente.Find(id)!;

            if (pacienteBuscado != null)
            {
                ctx.Paciente.Remove(pacienteBuscado);
            }

            ctx.SaveChanges();
        }
    }
}
