using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IFeedbackRepository
    {
        void Cadastrar(Feedback coment);

        void Deletar(Guid id);
    }
}
