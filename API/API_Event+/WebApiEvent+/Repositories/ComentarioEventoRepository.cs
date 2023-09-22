using WebApiEvent_.Contexts;
using WebApiEvent_.Domains;
using WebApiEvent_.Interfaces;

namespace WebApiEvent_.Repositories
{
    public class ComentarioEventoRepository : IComentarioEvento
    {
        private readonly EventContext ctx;

        public ComentarioEventoRepository()
        {
            ctx = new EventContext();
        }

        public ComentarioEvento BuscaId(Guid id)
        {
            try
            {
                ComentarioEvento comentatrioBuscado = ctx.ComentarioEvento.Find(id)!;
                if (comentatrioBuscado != null)
                {
                    return ctx.ComentarioEvento.FirstOrDefault(x => x.IdComentarioEvento == id)!;
                }

                return null;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao buscar por id");
            }
        }

        public void Cadastrar(ComentarioEvento comentario)
        {
            ctx.ComentarioEvento.Add(comentario);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                ComentarioEvento comentarioBuscado = ctx.ComentarioEvento.Find(id)!;

                if (comentarioBuscado != null)
                {
                    ctx.ComentarioEvento.Remove(comentarioBuscado);
                }

                ctx.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar comentario");
            }
        }

        public List<ComentarioEvento> Listar()
        {
            try
            {
                return ctx.ComentarioEvento.ToList();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar");
            }
        }
    }
}
