using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext AcessaBanco = new InLockContext();

        public void Atualizar(Guid id, Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public Estudio BuscaPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Estudio estudio)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Estudio> Listar()
        {
            return AcessaBanco.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return AcessaBanco.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
