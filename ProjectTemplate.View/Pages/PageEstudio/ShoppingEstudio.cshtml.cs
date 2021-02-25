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
    public class ShoppingEstudioModel : PageModel
    {
        private readonly IShoppingApp _shoppingApp;

        private readonly IEstudioApp _estudioApp;

        private readonly IHorarioDeFuncionamentoEstudioService _horarioDeFuncionamentoEstudioService;

        [BindProperty]
        public IList<ShoppingDTO> Shopping { get; set; }

        [BindProperty]
        public EstudioDTO Estudio { get; set; }

        int idFake = 1;

        string nomeCliente = "pablo.zz";

        public ShoppingEstudioModel(IShoppingApp shoppingApp, IEstudioApp estudioApp, IHorarioDeFuncionamentoEstudioService horarioDeFuncionamentoEstudioService)
        {
            _shoppingApp = shoppingApp;
            _estudioApp = estudioApp;
            _horarioDeFuncionamentoEstudioService = horarioDeFuncionamentoEstudioService;
        }

        public async Task OnGet()
        {
            int idEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);
            //  int idEstudio = await _estudioApp.GetIdEstudioByNomeCliente(nomeCliente);

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

            if (idEstudio != 0)
            {
                Shopping = (IList<ShoppingDTO>)await _shoppingApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));
            }

            if (Shopping == null)
            {
                Shopping = new List<ShoppingDTO>();
            }
        }
    }
}