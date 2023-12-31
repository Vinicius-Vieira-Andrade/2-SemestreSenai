﻿using APIHealthClinic.Domain;

namespace APIHealthClinic.Interface
{
    public interface IConsultaRepository
    {
        List<Consulta> ListarConsultas();
        void AgendarConsulta(Consulta consulta);
        void CancelarConsulta(Guid id);
        void AtualizarConsulta(Guid id, Consulta consulta);
        Consulta BuscarConsultaId(Guid id);
        void FazerComentario(Guid id, Feedback comentario);
    }
}
