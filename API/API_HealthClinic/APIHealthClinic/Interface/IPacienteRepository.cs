using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IPacienteRepository
    {
        void CadastrarPaciente(Paciente paciente);

        List<Paciente> ListarPaciente();

        Paciente BuscarId(Guid id);

        void Remover(Guid id);

        void AtualizarPaciente(Guid id, Paciente paciente);

        List<Consulta> ListarConsulta(Guid id);
    }
}
