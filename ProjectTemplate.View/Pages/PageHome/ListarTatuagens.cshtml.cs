using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageHome
{
    public class ListarTatuagensModel : PageModel
    {
        private readonly IFotoTattoApp _fotoTattoApp;

        private readonly IEstudioApp _estudioApp;

        public ListarTatuagensModel(IFotoTattoApp fotoTattoApp, IEstudioApp estudioApp)
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
            FotoTatto = new FotoTattoDTO();

            FotoTatto.EstiloTatto = "Todos";
            FotoTatto.ParteDoCorpo = "Todas";
            FotoTatto.Genero = "Todos";
            FotoTatto.Cor = "Todas";

            FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodos();

            if (FotosTattos == null)
            {
                FotosTattos = new List<FotoTattoDTO>();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            string estilo = FotoTatto.EstiloTatto;
            string parteCorpo = FotoTatto.ParteDoCorpo;
            string genero = FotoTatto.Genero;
            string cor = FotoTatto.Cor;

            if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodos();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(q => q.EstiloTatto.Equals(estilo));
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.EstiloTatto.Equals(estilo) && q.ParteDoCorpo.Equals(parteCorpo));
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.EstiloTatto.Equals(estilo)
                                  && q.ParteDoCorpo.Equals(parteCorpo)
                                   && q.Genero.Equals(genero));
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.EstiloTatto.Equals(estilo)
                                   && q.ParteDoCorpo.Equals(parteCorpo)
                                   && q.Genero.Equals(genero)
                                   && q.Cor.Equals(cor));
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                     q => q.EstiloTatto.Equals(estilo)
                                   && q.ParteDoCorpo.Equals(parteCorpo)
                                   && q.Cor.Equals(cor));
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.ParteDoCorpo.Equals(parteCorpo)
                                   && q.Genero.Equals(genero)
                                   && q.Cor.Equals(cor));
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.EstiloTatto.Equals(estilo)
                                   && q.Genero.Equals(genero)
                                   && q.Cor.Equals(cor));
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.EstiloTatto.Equals(estilo));
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.ParteDoCorpo.Equals(parteCorpo));
            }
            else if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.Genero.Equals(genero));
            }
            else if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                   q => q.Cor.Equals(cor));
            }

            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                   q => q.EstiloTatto.Equals(estilo)
                                   && q.ParteDoCorpo.Equals(parteCorpo));
            }
            else if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.Genero.Equals(genero)
                                   && q.Cor.Equals(cor));
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                   q => q.ParteDoCorpo.Equals(parteCorpo)
                                   && q.Genero.Equals(genero));
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.EstiloTatto.Equals(estilo)
                                   && q.Cor.Equals(cor));
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.EstiloTatto.Equals(estilo)
                                   && q.Genero.Equals(genero));
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodosComPesquisa(
                    q => q.ParteDoCorpo.Equals(parteCorpo)
                                   && q.Cor.Equals(cor));
            }
            else
            {
                FotosTattos = (IList<FotoTattoDTO>)await _fotoTattoApp.BuscarTodos();
            }

            return Page();

        }
    }
}
