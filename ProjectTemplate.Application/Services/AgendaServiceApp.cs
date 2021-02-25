using AutoMapper;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Services
{
    public class AgendaServiceApp: BaseServicoApp<Agenda, AgendaDTO>, IAgendaApp
    {
        protected readonly IAgendaService _servico;

        public AgendaServiceApp(IAgendaService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<IList<AgendaDTO>> GetAgendasByIdCliente(int idCliente)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AgendaDTO>> GetAgendasByIdClienteAndCliente(int idCliente, int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AgendaDTO>> GetAgendasByIdEstudio(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AgendaDTO>> GetAgendasByIdTatuador(int idTatuador)
        {
            throw new NotImplementedException();
        }
    }
}
