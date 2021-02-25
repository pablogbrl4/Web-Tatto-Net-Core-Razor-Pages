using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageTatuador
{
    public class GaleriaTatuadorModel : PageModel
    {
        private readonly IFotoTattoApp _fotoTattoApp;
        private readonly ITatuadorApp _tatuadorApp;
        private readonly IEstudioApp _estudioApp;
        private readonly IEstudio_TatuadorApp _estudioTatuadorApp;

        public GaleriaTatuadorModel(IFotoTattoApp fotoTattoApp, ITatuadorApp tatuadorApp, IEstudioApp estudioApp, IEstudio_TatuadorApp estudioTatuadorApp)
        {
            _fotoTattoApp = fotoTattoApp;
            _tatuadorApp = tatuadorApp;
            _estudioApp = estudioApp;
            _estudioTatuadorApp = estudioTatuadorApp;
        }

        [BindProperty]
        public IList<FotoTattoDTO> FotosTattos { get; set; }

        [BindProperty]
        public TatuadorDTO Tatuador { get; set; }

        [BindProperty]
        public IList<Estudio_TatuadorDTO> EstudioTatuador { get; set; }


        public async Task OnGet(int id)
        {
            Tatuador = await _tatuadorApp.BuscarPorId(id);

            FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(id));

            if (FotosTattos == null)
            {
                FotosTattos = new List<FotoTattoDTO>();
            }
        }

        public IActionResult OnGetPortifolioTatuador(string id)
        {
            return RedirectToPage("../PageTatuador/PortifolioTatuador", new
            {
                userName = id
            });
        }
    }
}
