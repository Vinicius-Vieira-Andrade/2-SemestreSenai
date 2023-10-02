using APIHealthClinic.Context;
using APIHealthClinic.Domain;
using APIHealthClinic.Interface;

namespace APIHealthClinic.Repository
{
    public class MedicoRepository : IMedicoRepository
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
            }

            ctx.Medico.Update(medicoBuscado!);
            ctx.SaveChanges();
        }

        public Medico BuscarId(Guid id)
        {
            Medico medicoBuscado = ctx.Medico.Find(id)!;
            if (medicoBuscado != null)
            { 
                return ctx.Medico
                .Select(m => new Medico
                 {
                     IdMedico = m.IdMedico,
                     CRM = m.CRM,

                     Especialidade = new Especialidade()
                     {
                         IdEspecialidade = m.IdEspecialidade,
                         Titulo = m.Especialidade.Titulo
                     },

                     Usuario = new Usuario()
                     {
                         IdUsuario = m.IdUsuario,
                         Nome = m.Usuario.Nome,
                         Email = m.Usuario.Email,
                         IdTipoUsuario = m.Usuario.IdTipoUsuario

                     },

                     Clinica = new Clinica()
                     {
                         IdClinica= m.IdClinica,
                         NomeFantasia = m.Clinica.NomeFantasia
                     }


                     
                 }
            ).FirstOrDefault(m => m.IdMedico == id)!;

            }

            return medicoBuscado;
        }

        public void CadastrarMedico(Medico medico)
        {
            ctx.Medico.Add(medico);
            ctx.SaveChanges();
        }

        public List<Consulta> ListarConsulta(string Nome)
        {
            return ctx.Consulta.Where(c => c.Medico.Usuario.Nome == Nome).ToList();
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
