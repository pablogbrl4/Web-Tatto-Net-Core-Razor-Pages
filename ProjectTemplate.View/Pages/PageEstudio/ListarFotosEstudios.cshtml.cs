using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageEstudio
{
    public class ListarFotosEstudiosModel : PageModel
    {
        private readonly IFotosEstudioApp _fotosEstudioApp;
        private readonly IEstudioApp _estudioApp;

        public ListarFotosEstudiosModel(IFotosEstudioApp fotosEstudioApp, IEstudioApp estudioApp)
        {
            _fotosEstudioApp = fotosEstudioApp;
            _estudioApp = estudioApp;
        }

        [BindProperty]
        public IList<FotosEstudioDTO> FotosEstudios { get; set; }

        int idFake = 1;

        public async Task OnGet()
        {
            int idEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);

            if (idEstudio != 0)
            {
                FotosEstudios = (IList<FotosEstudioDTO>)await _fotosEstudioApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));
            }

            if (FotosEstudios == null)
            {
                FotosEstudios = new List<FotosEstudioDTO>();
            }
        }
    }
}
