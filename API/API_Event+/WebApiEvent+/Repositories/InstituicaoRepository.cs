using WebApiEvent_.Contexts;
using WebApiEvent_.Domains;
using WebApiEvent_.Interfaces;

namespace WebApiEvent_.Repositories
{
    public class InstituicaoRepository : Iinstituicao
    {
         private readonly EventContext ctx;

        public InstituicaoRepository()
        {
            ctx = new EventContext();
        }


        public void Atualizar(Guid id, Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoBuscada = ctx.Instituicao.Find(id)!;

                if (instituicaoBuscada != null)
                {
                    instituicaoBuscada.CNPJ = instituicao.CNPJ;
                    instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
                    instituicaoBuscada.Endereco = instituicao.Endereco;
                }

                ctx.Instituicao.Update(instituicaoBuscada!);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao atualizar instituicao");
            }
        }

        public Instituicao BuscarId(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = ctx.Instituicao.Find(id)!;

                if (instituicaoBuscada != null)
                {
                    return ctx.Instituicao.FirstOrDefault(x => x.IdInstituicao == id)!;
                }

                return null!;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao listar instituicao por id");
            }
        }

        public void Cadastrar(Instituicao instituicao)
        {
            try
            {
                ctx.Instituicao.Add(instituicao);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao cadastrar nova instituicao");
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscado = ctx.Instituicao.Find(id)!;

                if (instituicaoBuscado != null)
                {
                    ctx.Instituicao.Remove(instituicaoBuscado);
                }

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro a deletar instituicao");
            }
        }

        public List<Instituicao> Listar()
        {
            return ctx.Instituicao.ToList();
        }
    }
}
