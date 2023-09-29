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

        List<Medico> BuscarEspecialidade(Especialidade especialidade);
        /*
         Ususario usuarioBiscado = ctx.Usuario
        .ToList()
        .Where(e => e.Titulo == especialidade.Titulo);
         */

        List<Consulta> ListarConsulta(Guid id);

    }
}
