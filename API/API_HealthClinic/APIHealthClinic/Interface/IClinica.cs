using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IClinica
    {
        void CadastrarClinica(Clinica clinica);

        void RemoverClinica(Guid id);
    }
}
