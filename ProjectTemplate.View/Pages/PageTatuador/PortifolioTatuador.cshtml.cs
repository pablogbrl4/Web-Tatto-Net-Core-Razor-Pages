using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageTatuador
{
    public class PortifolioTatuadorModel : PageModel
    {
        private readonly ITatuadorApp _tatuadorApp;
        private readonly IEstudioApp _estudioApp;
        private readonly IEstudio_TatuadorApp _estudioTatuadorApp;

        public PortifolioTatuadorModel(ITatuadorApp tatuadorApp, IEstudioApp estudioApp, IEstudio_TatuadorApp estudioTatuadorApp)
        {
            _tatuadorApp = tatuadorApp;
            _estudioApp = estudioApp;
            _estudioTatuadorApp = estudioTatuadorApp;
        }

        [BindProperty]
        public TatuadorDTO Tatuador { get; set; }

        [BindProperty]
        public IList<Estudio_TatuadorDTO> EstudioTatuador { get; set; }

        public async Task OnGet(string userName)
        {
            Tatuador = await _tatuadorApp.BuscarComPesquisa(c => c.NomeDeUsuario.Contains(userName));

            if (Tatuador == null)
            {
               // return BadRequest(new { Erros = "Tatuador Não Possui Mais essa Conta" });
            }

            EstudioTatuador = (IList<Estudio_TatuadorDTO>)await _estudioTatuadorApp.BuscarTodosComPesquisa(c => c.IdTatuador.Equals(Tatuador.Id));

            for (int i = 0; i < EstudioTatuador.Count; i++)
            {
                EstudioTatuador[i].Estudio = await _estudioApp.BuscarPorId(EstudioTatuador[i].IdEstudio);
            }

        }

        public async Task OnGetPortifolioTatuador(int id)
        {
            Tatuador = await _tatuadorApp.BuscarPorId(id);

            if (Tatuador == null)
            {
                // return BadRequest(new { Erros = "Tatuador Não Possui Mais essa Conta" });
            }

            EstudioTatuador = (IList<Estudio_TatuadorDTO>)await _estudioTatuadorApp.BuscarTodosComPesquisa(c => c.IdTatuador.Equals(Tatuador.Id));

            for (int i = 0; i < EstudioTatuador.Count; i++)
            {
                EstudioTatuador[i].Estudio = await _estudioApp.BuscarPorId(EstudioTatuador[i].IdEstudio);
            }

        }

        public IActionResult OnGetGaleriaTatuador(int id)
        {
            return RedirectToPage("../PageTatuador/GaleriaTatuador", new
            {
                id = id
            });
        }
        }
}
