using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.View.Pages.PageHome
{
    public class ListarTatuadoresModel : PageModel
    {
        private readonly ITatuadorApp _tatuadorApp;

        private readonly IEstudioApp _estudioApp;

        private readonly IEstudio_TatuadorApp _estudioTatuadorApp;

        public ListarTatuadoresModel(ITatuadorApp tatuadorApp, IEstudioApp estudioApp, IEstudio_TatuadorApp estudioTatuadorApp)
        {
            _tatuadorApp = tatuadorApp;
            _estudioApp = estudioApp;
            _estudioTatuadorApp = estudioTatuadorApp;
        }

        [BindProperty]
        public HashSet<TatuadorDTO> Tatuadores { get; set; }

        [BindProperty]
        public string Bairro { get; set; }

        [BindProperty]
        public HashSet<string> Bairros { get; set; }

        public async Task OnGet()
        {
            var Estudios = (IList<EstudioDTO>)await _estudioApp.BuscarTodos();

            var estudiosTatuadores = new HashSet<Estudio_TatuadorDTO>();

            foreach (var estudio in Estudios)
            {
                var temp = await _estudioTatuadorApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(estudio.Id));

                if (temp != null)
                {
                    foreach (var item in temp)
                    {
                        estudiosTatuadores.Add(item);
                    }
                }
            }

            var tatuadores = new HashSet<TatuadorDTO>();

            foreach (var _estudioTatuador in estudiosTatuadores)
            {
                tatuadores.Add(await _tatuadorApp.BuscarPorId(_estudioTatuador.IdTatuador));
            }

            Tatuadores = tatuadores;

            
            Bairros = new HashSet<string>();

            foreach (var item in Estudios)
            {
                Bairros.Add(item.Bairro);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var Estudios = (IList<EstudioDTO>)await _estudioApp.BuscarTodosComPesquisa(q => q.Bairro.Contains(Bairro));

            var estudiosTatuadores = new HashSet<Estudio_TatuadorDTO>();

            foreach (var estudio in Estudios)
            {
                var temp = await _estudioTatuadorApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(estudio.Id));

                if (temp != null)
                {
                    foreach (var item in temp)
                    {
                        estudiosTatuadores.Add(item);
                    }
                }
            }

            Tatuadores = new HashSet<TatuadorDTO>();

            foreach (var _estudioTatuador in estudiosTatuadores)
            {
                Tatuadores.Add(await _tatuadorApp.BuscarPorId(_estudioTatuador.IdTatuador));
            }

            return Page();
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
