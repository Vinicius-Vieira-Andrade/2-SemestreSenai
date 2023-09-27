using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IFeedback
    {
        void Cadastrar(Feedback coment);

        void Deletar(Feedback coment);
    }
}
