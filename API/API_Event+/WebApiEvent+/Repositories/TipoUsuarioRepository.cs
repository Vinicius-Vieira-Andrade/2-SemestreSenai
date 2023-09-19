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
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
