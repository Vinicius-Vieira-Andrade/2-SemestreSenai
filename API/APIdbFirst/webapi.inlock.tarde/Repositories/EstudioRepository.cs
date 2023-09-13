using Microsoft.AspNetCore.Http.HttpResults;
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
            Estudio estudioBuscado = AcessaBanco.Estudios.Find(id)!;

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }

            AcessaBanco.Update(estudioBuscado!);
            AcessaBanco.SaveChanges();
        }

        public Estudio BuscaPorId(Guid id)
        {
            Estudio buscaEstudio = AcessaBanco.Estudios.Find(id)!;

            if (buscaEstudio != null)
            {
                return AcessaBanco.Estudios.FirstOrDefault(x => x.IdEstudio == id)!;
            }

            return null;

        }

        public void Cadastrar(Estudio estudio)
        {
            AcessaBanco.Estudios.Add(estudio);

            AcessaBanco.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio buscaEstudio = AcessaBanco.Estudios.Find(id)!;

            if (buscaEstudio != null)
            {
                AcessaBanco.Estudios.Remove(buscaEstudio);
            }

            AcessaBanco.SaveChanges();

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
