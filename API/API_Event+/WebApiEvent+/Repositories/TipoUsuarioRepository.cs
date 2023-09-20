using WebApiEvent_.Contexts;
using WebApiEvent_.Domains;
using WebApiEvent_.Interfaces;

namespace WebApiEvent_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario usuarioBuscado = ctx.TipoUsuario.FirstOrDefault(u => u.IdTipoUsuario == id)!;

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Titulo = tipoUsuario.Titulo;
                }

                ctx.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao atualizar tipo de usuario");
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    return ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == id)!;
                }

                return null;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao buscar por id");
            }
        }

        public void Cadastrar(TipoUsuario tipousuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipousuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar");
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id)!;

                if (tipoUsuarioBuscado != null)
                {
                    ctx.TipoUsuario.Remove(tipoUsuarioBuscado);
                }

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar tipo de usuario");
            }
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
