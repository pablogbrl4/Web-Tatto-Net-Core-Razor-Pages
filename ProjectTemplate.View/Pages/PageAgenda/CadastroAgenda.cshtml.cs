using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.View.Pages.PageAgenda
{
    public class CadastroAgendaModel : PageModel
    {
        private readonly IAgendaApp _agendaApp;
        private readonly IClienteApp _clienteApp;
        private readonly IEstudioApp _estudioApp;
        private readonly IEstudio_TatuadorApp _estudio_TatuadorApp;
        private readonly ITatuadorApp _tatuadorApp;

        public CadastroAgendaModel(IAgendaApp agendaApp, IClienteApp clienteApp, IEstudioApp estudioApp, IEstudio_TatuadorApp estudio_TatuadorApp, ITatuadorApp tatuadorApp)
        {
            _agendaApp = agendaApp;
            _clienteApp = clienteApp;
            _estudioApp = estudioApp;
            _estudio_TatuadorApp = estudio_TatuadorApp;
            _tatuadorApp = tatuadorApp;
        }

        [BindProperty]
        public AgendaDTO Agenda { get; set; }

        [BindProperty]
        public EstudioDTO Estudio { get; set; }

        [BindProperty]
        public IList<TatuadorDTO> Tatuador { get; set; }

        int idFake = 2;
        string userNameFake = "pablo.oliveira";

        public async Task OnGet()
        {
            Estudio = await _estudioApp.BuscarComPesquisa(c => c.NomeDeUsuario.Contains(userNameFake));
            int idEstudio = Estudio.Id;

            var IdsEstudiosTatuadores = await _estudio_TatuadorApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));

            Tatuador = new List<TatuadorDTO>();

            foreach (var item in IdsEstudiosTatuadores)
            {
                if (item.IdTatuador != 0)
                {
                    Tatuador.Add(await _tatuadorApp.BuscarPorId(item.IdTatuador));
                }
            }

            var cliente = await _clienteApp.BuscarPorId(idFake);

            Agenda = new AgendaDTO();
            Agenda.IdCliente = cliente.Id;
            Agenda.IdEstudio = idEstudio;

        }

        public async Task<IActionResult> OnPost()
        {
            Agenda.Ativo = true;

            await _agendaApp.Incluir(Agenda);

            var usuario = await _clienteApp.BuscarPorId(Agenda.IdCliente);
            var parsedDate = DateTime.Parse(usuario.DataDeNascimento);
            var idade = DateTime.Now - parsedDate;

            if ((idade.Days / 360) < 18)
            {
                return RedirectToAction("ContratoMenor", "Agenda", Agenda);
            }

            return RedirectToAction("AgendaUsuario", "Agenda");

        }
    }
}
