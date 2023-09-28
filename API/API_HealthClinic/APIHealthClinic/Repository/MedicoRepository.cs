using APIHealthClinic.Context;
using APIHealthClinic.Domain;
using APIHealthClinic.Interface;

namespace APIHealthClinic.Repository
{
    public class MedicoRepository : IMedico
    {

        private readonly HealthContext ctx;

        public MedicoRepository()
        {
            ctx = new HealthContext();
        }

        public void AtualizarMedico(Guid id, Medico medico)
        {
            Medico medicoBuscado = ctx.Medico.Find(id)!;

            if (medicoBuscado != null)
            {
                medicoBuscado.CRM = medico.CRM;
                medicoBuscado.IdClinica = medico.IdClinica;
                medicoBuscado.Usuario!.Nome = medico.Usuario!.Nome;
            }

            ctx.Medico.Update(medicoBuscado!);
            ctx.SaveChanges();
        }

        public List<Medico> BuscarEspecialidade(Especialidade especialidade)
        {
             List<Medico> medicosBuscado = ctx.Medico.Where(e => e.Especialidade.Titulo == especialidade.Titulo).ToList();

            return medicosBuscado;
        }

        public Medico BuscarId(Guid id)
        {
            Medico medicoBuscado = ctx.Medico.Select(m => new Medico
            {
                IdMedico = m.IdMedico,
                CRM = m.CRM,

                Especialidade = new Especialidade()
                {
                    IdEspecialidade = m.IdEspecialidade,
                    Titulo = m.Especialidade.Titulo
                },

                Clinica = new Clinica()
                {
                    IdClinica = m.IdClinica,
                    CNPJ = m.Clinica.CNPJ,
                    Endereco = m.Clinica.Endereco,
                    NomeFantasia = m.Clinica.NomeFantasia,
                    RazaoSocial = m.Clinica.RazaoSocial
                },

                Usuario = new Usuario()
                {
                    IdUsuario = m.IdUsuario,
                    Nome = m.Usuario.Nome
                }
            }
            ).FirstOrDefault(m => m.IdMedico == id)!;

            return medicoBuscado;
        }

        public void CadastrarMedico(Medico medico)
        {
            ctx.Medico.Add(medico);
            ctx.SaveChanges();
        }

        public List<Consulta> ListarConsulta(Guid id)
        {
            return ctx.Consulta.Where(c => c.IdMedico == id).ToList();
        }

        public List<Medico> ListarMedicos()
        {
            return ctx.Medico.ToList();
        }

        public void Remover(Guid id)
        {
            Medico medicoBuscado = ctx.Medico.Find(id)!;

            if (medicoBuscado != null)
            {
                ctx.Medico.Remove(medicoBuscado);
            }

            ctx.SaveChanges();
        }
    }
}
