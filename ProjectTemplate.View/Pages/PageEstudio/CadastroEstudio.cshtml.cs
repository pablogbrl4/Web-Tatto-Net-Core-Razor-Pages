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
    public class CadastroEstudioModel : PageModel
    {
        private readonly IEstudioApp _estudioApp;

        private readonly IHorarioDeFuncionamentoEstudioService _horarioDeFuncionamentoEstudioService;

        [BindProperty]
        public EstudioDTO Estudio { get; set; }

        int idFake = 2;

        public CadastroEstudioModel(IEstudioApp estudioApp, IHorarioDeFuncionamentoEstudioService horarioDeFuncionamentoEstudioService)
        {
            _estudioApp = estudioApp;
            _horarioDeFuncionamentoEstudioService = horarioDeFuncionamentoEstudioService;
        }

        public async Task OnGet()
        {
            var idEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);

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
           
        }

        public async Task<IActionResult> OnPost()
        {

            if (Estudio.IdEstudio != 0)
            {
                await _estudioApp.Alterar(Estudio);
            }
            else
            {
                await _estudioApp.Incluir(Estudio);
            }

            return Page();

        }
    }
}
