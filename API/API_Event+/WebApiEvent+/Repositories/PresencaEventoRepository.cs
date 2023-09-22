using WebApiEvent_.Contexts;
using WebApiEvent_.Domains;
using WebApiEvent_.Interfaces;

namespace WebApiEvent_.Repositories
{
    public class PresencaEventoRepository : IPresencaEvento
    {

        private readonly EventContext ctx;

        public PresencaEventoRepository()
        {
            ctx = new EventContext();
        }
         
        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento presencaBuscar = ctx.PresencaoEvento.Find(id)!;

            if (presencaBuscar != null)
            {
                presencaBuscar.Situacao = presencaEvento.Situacao;
                presencaBuscar.IdEvento = presencaEvento.IdEvento;
            }
            ctx.Update(presencaBuscar);
            ctx.SaveChanges();
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            PresencaEvento presencaBuscar = ctx.PresencaoEvento.Find(id)!;

            if (presencaBuscar != null)
            {
                return ctx.PresencaoEvento.FirstOrDefault(u => u.IdPresencaEvento == id)!;
            }

            return null;
        }

        public void Deletar(Guid id)
        {
            PresencaEvento presencaBuscar = ctx.PresencaoEvento.Find(id)!;

            if (presencaBuscar != null)
            {
                ctx.PresencaoEvento.Remove(presencaBuscar);
            }

            ctx.SaveChanges();
        }

        public void Inscrever(PresencaEvento inscricao)
        {
            try
            {
                ctx.PresencaoEvento.Add(inscricao);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao inscrever presencas");
            }
        }

        public List<PresencaEvento> Listar()
        {
            try
            {
                return ctx.PresencaoEvento.ToList();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar presenças");
            }
        }

        public List<PresencaEvento> ListarMinhas(Guid idUsuario)
        {
            return ctx.PresencaoEvento.Where(x => x.IdUsuario == idUsuario).ToList();
        }
    }
}
