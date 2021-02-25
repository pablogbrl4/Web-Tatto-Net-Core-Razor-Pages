using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageAgenda
{
    public class CadastroAgendaByEstudioModel : PageModel
    {

        private readonly IEstudioApp _estudioApp;

        private readonly ITatuadorApp _tatuadorApp;

        private readonly IClienteApp _clienteApp;

        private readonly IContatosApp _contatosApp;

        private readonly IEstudio_TatuadorApp _estudioTatuadorApp;

        public CadastroAgendaByEstudioModel(IEstudioApp estudioApp, ITatuadorApp tatuadorApp, IClienteApp clienteApp, 
            IContatosApp contatosApp, IEstudio_TatuadorApp estudioTatuadorApp)
        {
            _estudioApp = estudioApp;
            _tatuadorApp = tatuadorApp;
            _clienteApp = clienteApp;
            _contatosApp = contatosApp;
            _estudioTatuadorApp = estudioTatuadorApp;
        }

        public IList<TatuadorDTO> Tatuadores { get; set; }
        public IList<ClienteDTO> Clientes { get; set; }

        public AgendaDTO Agenda { get; set; }

        int idFake = 1;

        public async Task OnGet()
        {
            int IdEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);

            Agenda.Estudio = await _estudioApp.BuscarPorId(IdEstudio);
        
            var IdsEstudiosTatuadores = await _estudioTatuadorApp.GetIdsByIdEstudio(IdEstudio);

            foreach (var item in IdsEstudiosTatuadores)
            {
                if (item.IdTatuador != 0)
                {
                    Tatuadores.Add(await _tatuadorApp.BuscarPorId(item.IdTatuador));
                }
            }

            var IdsContatos = await _contatosApp.GetContatosByIdEstudio(Agenda.Estudio.IdEstudio);

            foreach (var item in IdsContatos)
            {
                if (item.IdCliente != 0)
                {
                    Clientes.Add(await _clienteApp.BuscarPorId(item.IdCliente));
                }
            }
        }
    }
}
