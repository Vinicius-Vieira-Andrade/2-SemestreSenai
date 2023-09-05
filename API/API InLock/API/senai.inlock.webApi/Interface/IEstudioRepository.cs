using senai.inlock.webApi.Domain;

namespace senai.inlock.webApi.Interface
{
    public interface IEstudioRepository
    {
        List<EstudioDomain> ListaEstudios();

        void Cadastrar(EstudioDomain novoEstudio);

        EstudioDomain ListaIdEstudio(int id);
    }
}
