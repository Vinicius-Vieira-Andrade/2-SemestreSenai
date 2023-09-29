using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IConsultaRepository
    {
        List<Consulta> ListarConsultas();
        void AgendarConsulta(Consulta consulta);
        void CancelarConsulta(Guid id);
        void AtualizarConsulta(Guid id, Consulta consulta);
        void BuscarConsultaId(Guid id);

        
    }
}
