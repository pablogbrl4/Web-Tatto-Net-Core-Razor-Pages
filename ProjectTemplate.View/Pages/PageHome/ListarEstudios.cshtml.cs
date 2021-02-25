using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageHome
{
    public class ListarEstudiosModel : PageModel
    {

        private readonly IEstudioApp _estudioApp;

        public ListarEstudiosModel(IEstudioApp estudioApp)
        {
            _estudioApp = estudioApp;
        }

        [BindProperty]
        public IList<EstudioDTO> Estudios { get; set; }

        [BindProperty]
        public string Bairro { get; set; }

        [BindProperty]
        public HashSet<string> Bairros { get; set; }

        int idFake = 2;
        public async Task OnGet()
        {
            Estudios = (IList<EstudioDTO>)await _estudioApp.BuscarTodos();

            Bairros = new HashSet<string>();

            foreach (var item in Estudios)
            {
                Bairros.Add(item.Bairro);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            Estudios = (IList<EstudioDTO>)await _estudioApp.BuscarTodos();

            Bairros = new HashSet<string>();

            foreach (var item in Estudios)
            {
                Bairros.Add(item.Bairro);
            }

            Estudios = (IList<EstudioDTO>)await _estudioApp.BuscarTodosComPesquisa(q => q.Bairro.Contains(Bairro));

            return Page();
        }


        public IActionResult OnGetDetalhesEstudio(string id)
        {
            return RedirectToPage("../PageEstudio/DetalhesEstudio", new
            {
                userName = id
            });
        }
    }
}
