using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Services;

namespace ProjectTemplate.View.Pages.PageEstudio
{
    public class DetalhesEstudioModel : PageModel
    {
        private readonly IEstudioApp _estudioApp;
        private readonly IEstudio_TatuadorApp _estudioTatuadorApp;
        private readonly IFotosEstudioApp _fotosEstudioApp;
        private readonly IDepoimentosApp _depoimentosApp;
        private readonly ITatuadorApp _tatuadorApp;
        private readonly IHorarioDeFuncionamentoEstudioService _horarioDeFuncionamentoEstudioService;

        public DetalhesEstudioModel(IEstudioApp estudioApp, IEstudio_TatuadorApp estudioTatuadorApp, IFotosEstudioApp fotosEstudioApp, 
            IDepoimentosApp depoimentosApp, ITatuadorApp tatuadorApp, IHorarioDeFuncionamentoEstudioService horarioDeFuncionamentoEstudioService)
        {
            _estudioApp = estudioApp;
            _estudioTatuadorApp = estudioTatuadorApp;
            _fotosEstudioApp = fotosEstudioApp;
            _depoimentosApp = depoimentosApp;
            _tatuadorApp = tatuadorApp;
            _horarioDeFuncionamentoEstudioService = horarioDeFuncionamentoEstudioService;
        }

        [BindProperty]
        public EstudioDTO Estudio { get; set; }

        [BindProperty]
        public IList<Estudio_TatuadorDTO> EstudioTatuadores { get; set; }

        [BindProperty]
        public IList<FotosEstudioDTO> FotosEstudios { get; set; }

        [BindProperty]
        public IList<DepoimentosDTO> Depoimentos { get; set; }

        public async Task OnGet(string userName)
        {
            int idEstudio = await GetDadosEstudioAsync(userName);

            FotosEstudios = (IList<FotosEstudioDTO>)await _fotosEstudioApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));

            Depoimentos = (IList<DepoimentosDTO>)await _depoimentosApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));

            EstudioTatuadores = (IList<Estudio_TatuadorDTO>)await _estudioTatuadorApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));

            for (int i = 0; i < EstudioTatuadores.Count; i++)
            {
                var tatuador = await _tatuadorApp.BuscarPorId(EstudioTatuadores[i].IdTatuador);

                if (tatuador != null)
                {
                    EstudioTatuadores[i].Tatuador = tatuador;
                }
                else
                {
                    EstudioTatuadores.Remove(EstudioTatuadores[i]);
                }
            }
        }

        private async Task<int> GetDadosEstudioAsync(string userName)
        {
            Estudio = await _estudioApp.BuscarComPesquisa(c => c.NomeDeUsuario.Contains(userName));

            if (Estudio != null)
            {
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

            return Estudio.IdEstudio;
        }


    }
}
