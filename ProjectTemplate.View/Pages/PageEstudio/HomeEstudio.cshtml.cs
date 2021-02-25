using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageEstudio
{
    public class HomeEstudioModel : PageModel
    {
        private readonly IAgendaApp _agendaApp;
        private readonly IEstudioApp _estudioApp;
        private readonly IClienteApp _clienteApp;
        private readonly ITatuadorApp _tatuadorApp;
        private readonly IContatosApp _contatosApp;

        public HomeEstudioModel(IAgendaApp agendaApp, IEstudioApp estudioApp, IClienteApp clienteApp, 
            ITatuadorApp tatuadorApp, IContatosApp contatosApp)
        {
            _agendaApp = agendaApp;
            _estudioApp = estudioApp;
            _clienteApp = clienteApp;
            _tatuadorApp = tatuadorApp;
            _contatosApp = contatosApp;
        }

        [BindProperty]
        public IList<AgendaDTO> Agenda { get; set; }

        [BindProperty]
        public IList<ContatosDTO> Contatos { get; set; }

        int idFake = 1;

        public async Task OnGet()
        {

            int idEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);

            Agenda = (IList<AgendaDTO>)await _agendaApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));

            for (int i = 0; i < Agenda.Count; i++)
            {
                Agenda[i].Cliente = await _clienteApp.BuscarPorId(Agenda[i].IdCliente);
                Agenda[i].Tatuador = await _tatuadorApp.BuscarPorId(Agenda[i].IdTatuador);
            }

            Agenda = Agenda.OrderByDescending(o => o.DataMarcação).ToList(); // Ordenar Lista

            Contatos = (IList<ContatosDTO>)await _contatosApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));

            for (int i = 0; i < Contatos.Count; i++)
            {
                Contatos[i].Cliente = await _clienteApp.BuscarPorId(Contatos[i].IdCliente);

                var mes = Int32.Parse(Contatos[i].Cliente.DataDeNascimento.Substring(5, 2));
                var dia = Int32.Parse(Contatos[i].Cliente.DataDeNascimento.Substring(8, 2));

                if (mes == DateTime.Now.Month && dia == DateTime.Now.Day) // Aniversariantes do dia 
                {
                    Contatos[i].Cliente.DataDeNascimento = "dia";
                }
                else if (mes == DateTime.Now.Month) // Aniversariantes do Mês 
                {
                    Contatos[i].Cliente.DataDeNascimento = "mes";
                }
            }
        }
    }
}
