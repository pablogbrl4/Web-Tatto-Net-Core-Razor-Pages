using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;

namespace ProjectTemplate.View.Pages.PageEstudio
{
    public class BuscaContatosModel : PageModel
    {

        private readonly IEstudioApp _estudioApp;
        private readonly IClienteApp _clienteApp;
        private readonly IContatosApp _contatosApp;

        public BuscaContatosModel(IEstudioApp estudioApp, IClienteApp clienteApp, IContatosApp contatosApp)
        {
            _estudioApp = estudioApp;
            _clienteApp = clienteApp;
            _contatosApp = contatosApp;
        }

        [BindProperty]
        public ClienteDTO Cliente { get; set; }

        [BindProperty]
        public IList<ClienteDTO> Clientes { get; set; }

        [BindProperty]
        public string Pesquisa { get; set; }

        int idFake = 1;

        public async Task OnGet()
        {
            Clientes = new List<ClienteDTO>();
            Cliente = new ClienteDTO();

            int idEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);

            var contatos = await _contatosApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));

            foreach (var contato in contatos)
            {
                if (contato != null)
                {
                    Clientes.Add(await _clienteApp.BuscarPorId(contato.IdCliente)); 
                }
            }
        }

        public async Task<IActionResult> OnPost()
        {
            int idEstudio = _estudioApp.GetIdEstudioByIdUser(idFake);
            var contatos = await _contatosApp.BuscarTodosComPesquisa(q => q.IdEstudio.Equals(idEstudio));

            foreach (var contato in contatos)
            {
                if (contato != null)
                {
                    // Adiciona na lista dados usuários que estão nos contatos
                    Clientes.Add(await _clienteApp.BuscarPorId(contato.IdCliente)); 
                }
            }

            // Busca Usuários por nome pesquisado
            if (!string.IsNullOrEmpty(Pesquisa)) 
            {
                Clientes = Clientes.Where(u => u.PrimeiroNome.Contains(Pesquisa.Trim())).ToList();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCadastrarContatobyCpf()
        {
            var cliente = await _clienteApp.GetClienteByCpf(Cliente.CPF);

            if (cliente != null)
            {
                await _contatosApp.InsertByIds(cliente.Id, idFake); // Insere Dados em Contatos
            }

            return RedirectToAction("BuscaContatos");

        }


        public async Task<IActionResult> OnPostCadastroUsuarioByEstudio()
        {
            await _clienteApp.BuscarPorId(idFake);
            return Page();
        }
    }
}
