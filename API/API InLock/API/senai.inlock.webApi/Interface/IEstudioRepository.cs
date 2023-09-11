using senai.inlock.webApi.Domain;

namespace senai.inlock.webApi.Interface
{
    public interface IEstudioRepository
    {
        List<EstudioDomain> ListaEstudios();

        void Cadastrar(EstudioDomain novoEstudio);

        //EXTRA DESAFIO (Em andamento)
        List<EstudioDomain> BuscarEstudios();
    }
}
