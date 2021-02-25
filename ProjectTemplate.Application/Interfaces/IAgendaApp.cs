using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IAgendaApp : IBaseApp<Agenda, AgendaDTO>
    {
        Task<IList<AgendaDTO>> GetAgendasByIdEstudio(int idEstudio);
        Task<IList<AgendaDTO>> GetAgendasByIdCliente(int idCliente);
        Task<IList<AgendaDTO>> GetAgendasByIdTatuador(int idTatuador);
        Task<IList<AgendaDTO>> GetAgendasByIdClienteAndCliente(int idCliente, int idEstudio);
    }
}
