using senai.inlock.webApi.Domain;

namespace senai.inlock.webApi.Interface
{
    public interface IJogoRepository
    {
        List<JogoDomain> ListaJogos();

        void CadastraJogos(JogoDomain novoJogo);

        JogoDomain ListaIdJogos(int id);
    }
}
