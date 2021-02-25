using ProjectTemplate.Application.DTOs;
using System.Collections.Generic;

namespace ProjectTemplate.Application.DTOs.ViewModels
{
    public class BuscaAgendaViewModelDTO
    {
        public BuscaAgendaViewModelDTO(IList<AgendaDTO> agendas)
        {
            Agendas = agendas;
        }

        public IList<AgendaDTO> Agendas { get; }

        public AgendaDTO Agenda { get; set; }
    }
}

