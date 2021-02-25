using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.View.Pages.PageEstudio
{
    public class GaleriaEstudioModel : PageModel
    {
        private readonly IFotoTattoApp _fotoTattoApp;

        private readonly IEstudioApp _estudioApp;

        private readonly IHorarioDeFuncionamentoEstudioService _horarioDeFuncionamentoEstudioService;

        public GaleriaEstudioModel(IFotoTattoApp fotoTattoApp, IEstudioApp estudioApp, IHorarioDeFuncionamentoEstudioService horarioDeFuncionamentoEstudioService)
        {
            _fotoTattoApp = fotoTattoApp;
            _estudioApp = estudioApp;
            _horarioDeFuncionamentoEstudioService = horarioDeFuncionamentoEstudioService;
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
            int idEstudio = await GetDadosEstudioAsync();

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
            await GetDadosEstudioAsync();

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

        private async Task<int> GetDadosEstudioAsync()
        {
            int idEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);

            if (idEstudio != 0)
            {
                Estudio = await _estudioApp.BuscarPorId(idEstudio);
                Estudio.HorarioDeFuncionamentoEstudio = await _horarioDeFuncionamentoEstudioService.GetHorarioDeFuncionamentoEstudioByIdEstudio(Estudio.Id);
            }
            else
            {
                Estudio = new EstudioDTO();

                Estudio.HorarioDeFuncionamentoEstudio = new List<HorarioDeFuncionamentoEstudio>();

                string[] diaSemana = new string[] { "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sabado", "Domingo", "Feriado" };

                for (int i = 0; i < 8; i++)
                {
                    Estudio.HorarioDeFuncionamentoEstudio.Add(new HorarioDeFuncionamentoEstudio(0, diaSemana[i], "00:00", "00:00"));
                }
            }

            return idEstudio;
        }
    }
}
