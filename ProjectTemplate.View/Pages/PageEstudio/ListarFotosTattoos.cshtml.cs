using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageEstudio
{
    public class ListarFotosTattoosModel : PageModel
    {
        private readonly IFotoTattoApp _fotoTattoApp;

        private readonly IEstudioApp _estudioApp;

        public ListarFotosTattoosModel(IFotoTattoApp fotoTattoApp, IEstudioApp estudioApp)
        {
            _fotoTattoApp = fotoTattoApp;
            _estudioApp = estudioApp;
        }

        [BindProperty]
        public FotoTattoDTO FotoTatto { get; set; }

        [BindProperty]
        public IList<FotoTattoDTO> FotosTattos { get; set; }

        [BindProperty]
        public EstudioDTO Estudio { get; set; }

        int idFake = 1;

        public async Task OnGet()
        {
            int idEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);

            Estudio = await _estudioApp.BuscarPorId(idEstudio);

            FotoTatto = new FotoTattoDTO();
            FotoTatto.EstiloTatto = "Todos";
            FotoTatto.ParteDoCorpo = "Todas";

            if (idEstudio != 0)
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));
            }

            if (FotosTattos == null)
            {
                FotosTattos = new List<FotoTattoDTO>();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            int idEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);

            Estudio = await _estudioApp.BuscarPorId(idEstudio);

            if (string.IsNullOrEmpty(FotoTatto.EstiloTatto))
            {
                if (string.IsNullOrEmpty(FotoTatto.ParteDoCorpo))
                {
                    FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                        q => q.IdEstudio.Equals(Estudio.Id));
                }
                else
                {
                    FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                        q => q.ParteDoCorpo.Equals(FotoTatto.ParteDoCorpo) &&
                        q.IdEstudio.Equals(Estudio.Id));
                }
            }
            else
            {
                if (string.IsNullOrEmpty(FotoTatto.ParteDoCorpo))
                {
                    FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                        q => q.EstiloTatto.Equals(FotoTatto.EstiloTatto) &&
                        q.IdEstudio.Equals(Estudio.Id));
                }
                else
                {
                    FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                         q => q.ParteDoCorpo.Equals(FotoTatto.ParteDoCorpo)
                         && q.EstiloTatto.Equals(FotoTatto.EstiloTatto)
                         && q.IdEstudio.Equals(Estudio.Id));
                }
            }
            return Page();
        }

    }
}
