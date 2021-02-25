using System.Collections.Generic;

namespace Tatto.Models.ViewModels
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

