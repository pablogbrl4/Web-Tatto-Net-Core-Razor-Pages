using System.Collections.Generic;

namespace ProjectTemplate.Domain.Entities.ViewModels
{
    public class BuscaAgendaViewModel
    {
        public BuscaAgendaViewModel(IList<Agenda> agendas)
        {
            Agendas = agendas;
        }

        public IList<Agenda> Agendas { get; }

        public Agenda Agenda { get; set; }
    }
}

