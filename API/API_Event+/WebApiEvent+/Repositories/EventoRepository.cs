using WebApiEvent_.Contexts;
using WebApiEvent_.Domains;
using WebApiEvent_.Interfaces;

namespace WebApiEvent_.Repositories
{
    public class EventoRepository : IEvento
    {
        private readonly EventContext ctx;
        public EventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscar = ctx.Evento.Find(id)!;

            if (eventoBuscar != null) 
            {
                eventoBuscar.Descricao = evento.Descricao;
                eventoBuscar.DataEvento = evento.DataEvento;
                eventoBuscar.Nome = evento.Nome;
                eventoBuscar.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscar.IdInstituicao = evento.IdInstituicao;
            }

            ctx.Evento.Update(evento);
            ctx.SaveChanges();

        }

        public Evento BuscarId(Guid id)
        {
            Evento eventoBuscado = ctx.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                return ctx.Evento.FirstOrDefault(x => x.IdEvento == id)!;
            }

            return null!;
        }

        public void Cadastrar(Evento evento)
        {
            ctx.Evento.Add(evento);
            ctx.SaveChanges();
           
        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = ctx.Evento.Find(id)!;

            if (eventoBuscado != null)
            {
                ctx.Evento.Remove(eventoBuscado);
            }

            ctx.SaveChanges();
        }

        public List<Evento> Listar()
        {
            return ctx.Evento.ToList();
        }
    }
}
