using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IClinicaRepository
    {
        void CadastrarClinica(Clinica clinica);

        void RemoverClinica(Guid id);
    }
}
