using WebApiEvent_.Contexts;
using WebApiEvent_.Domains;
using WebApiEvent_.Interfaces;

namespace WebApiEvent_.Repositories
{
    public class TipoEventoRepository : ITipoEvento
    {

        private readonly EventContext ctx;

        public TipoEventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoEventoBuscado = ctx.TipoEvento.FirstOrDefault(u => u.IdTipoEvento == id)!;

            if (tipoEventoBuscado != null)
            {
                tipoEventoBuscado.Titulo = tipoEvento.Titulo;
            }

            ctx.TipoEvento.Update(tipoEvento);
            ctx.SaveChanges();

        }

        public TipoEvento BuscarId(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id);

                if (tipoEventoBuscado != null)
                {
                    return ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == id)!;
                }

                return null;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao buscar por id");
            }
        }

        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                ctx.TipoEvento.Add(tipoEvento);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar tipo evento");
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = ctx.TipoEvento.Find(id)!;

                if (tipoEventoBuscado != null)
                {
                    ctx.TipoEvento.Remove(tipoEventoBuscado);
                }

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar tipo de evento");
            }
        }

        public List<TipoEvento> Listar()
        {
            return ctx.TipoEvento.ToList();
        }
    }
}
