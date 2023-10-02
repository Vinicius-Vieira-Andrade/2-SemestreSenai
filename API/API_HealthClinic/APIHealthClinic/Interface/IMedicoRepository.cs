using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IMedicoRepository 
    {
        void CadastrarMedico(Medico medico);

        List<Medico> ListarMedicos();

        Medico BuscarId(Guid id);

        void Remover(Guid id);

        void AtualizarMedico(Guid id, Medico medico);

        List<Consulta> ListarConsulta(string Nome);

    }
}
