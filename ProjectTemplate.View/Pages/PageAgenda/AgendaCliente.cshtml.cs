using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageAgenda
{
    public class AgendaClienteModel : PageModel
    {

        private readonly IAgendaApp _agendaApp;

        private readonly IEstudioApp _estudioApp;

        private readonly ITatuadorApp _tatuadorApp;

        public AgendaClienteModel(IAgendaApp agendaApp, IEstudioApp estudioApp, ITatuadorApp tatuadorApp)
        {
            _agendaApp = agendaApp;
            _estudioApp = estudioApp;
            _tatuadorApp = tatuadorApp;
        }

        public IList<AgendaDTO> Agendas { get; set; }

        int idFake = 1;

        public async Task OnGet()
        {
            int IdCliente = _estudioApp.GetIdEstudioByIdUser(idFake);

            Agendas = await _agendaApp.GetAgendasByIdCliente(IdCliente);

            for (int i = 0; i < Agendas.Count; i++)
            {
                Agendas[i].Estudio = await _estudioApp.BuscarPorId(Agendas[i].IdEstudio);
                Agendas[i].Tatuador = await _tatuadorApp.BuscarPorId(Agendas[i].IdTatuador);
            }

            Agendas = Agendas.OrderByDescending(o => o.DataMarcação).ToList();
        }
    }
}
