using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.API.Controllers;

namespace Tatto.Controllers
{
    public class TatuadorController : Controller // : CoreController<Tatuador, TatuadorDTO>
    {
        private readonly ITatuadorApp _tatuadorApp;
        private readonly IEstudio_TatuadorApp _estudio_TatuadorApp;
        private readonly IEstudioApp _estudioApp;
        private readonly IFotoTattoApp _fotoTattoApp;

        public TatuadorController(ITatuadorApp tatuadorApp, 
             IEstudio_TatuadorApp estudio_TatuadorApp, IEstudioApp estudioApp,
             IFotoTattoApp fotoTattoApp) // : base(tatuadorApp)
        {
            this._tatuadorApp = tatuadorApp;
            this._estudio_TatuadorApp = estudio_TatuadorApp;
            this._estudioApp = estudioApp;
            this._fotoTattoApp = fotoTattoApp;
        }

        TatuadorDTO tatuador = new TatuadorDTO();

        string idfake = "0";

        int idfakeInt = 0;

        // Público
        public async Task<IActionResult> PortifolioTatuador(string id = "")
        {
            var idTatuador = await _tatuadorApp.GetIdTatuadorByNomeCliente(id);

            TatuadorDTO tatuadorServer = new TatuadorDTO();

            //var tatuadorIdentity = await userManager.GetUserAsync(this.User); // acessar dados usuários no identity;

            //if (!string.IsNullOrEmpty(idTatuador))
            //{
            //    tatuadorIdentity = await userManager.FindByIdAsync(idTatuador);                
            //}

            //if (tatuadorIdentity == null)
            //{
            //    return BadRequest(new { Erros = "Tatuador Não Possui Mais essa Conta" });
            //}


            var tatuador = await _tatuadorApp.BuscarPorId(idfakeInt);

            if (tatuador != null)
            {
                tatuadorServer.PrimeiroNome = tatuador.PrimeiroNome;
                tatuadorServer.SobrenomeCompleto = tatuador.SobrenomeCompleto;
                tatuadorServer.NomeDeUsuario = tatuador.NomeDeUsuario;

                tatuadorServer.Instagram = tatuador.Instagram;
                tatuadorServer.Facebook = tatuador.Facebook;
                tatuadorServer.Twitter = tatuador.Twitter;
                tatuadorServer.LinkedIn = tatuador.LinkedIn;
                tatuadorServer.YouTube = tatuador.YouTube;
                tatuadorServer.WhatsApp = tatuador.WhatsApp;
                tatuadorServer.TextoBibliografico = tatuador.TextoBibliografico;

                tatuadorServer.Telefone = tatuador.Telefone;
                tatuadorServer.OutroTelefone = tatuador.OutroTelefone;

            }

            tatuadorServer.EstudioTatuador = await _estudio_TatuadorApp.GetEstudioTatuadorByIdTatuador(tatuadorServer.IdTatuador);

            for (int i = 0; i < tatuadorServer.EstudioTatuador.Count; i++)
            {
                tatuadorServer.EstudioTatuador[i].Estudio = await _estudioApp.BuscarPorId(tatuadorServer.EstudioTatuador[i].IdEstudio);
            }

            return View(tatuadorServer);
        }

        // Público
        public async Task<IActionResult> GaleriaTatuador(string id = "")
        {
            var idTatuador = await _tatuadorApp.GetIdTatuadorByNomeCliente(id);

            if (string.IsNullOrEmpty(idTatuador))
            {
                idTatuador = idfake;
            }

            tatuador = await _tatuadorApp.GetTatuadorByIdTatuador(idfakeInt);
            tatuador.FotosTattos = await _fotoTattoApp.GetFotosByIdTatuador(idfakeInt);

            return View(tatuador);
        }

        [Authorize(Roles = "Tatuador")]
        public async Task<IActionResult> CadastroTatuador(string id = "")
        {
            TatuadorDTO tatuadorServer = new TatuadorDTO();

            //var tatuadorIdentity = await userManager.GetUserAsync(this.User); // acessar dados usuários no identity;

            //if (!string.IsNullOrEmpty(id))
            //{
            //    tatuadorIdentity = await userManager.FindByIdAsync(id);
            //}

            //tatuadorServer.Email = tatuadorIdentity.Email;
            //tatuadorServer.IdTatuador = tatuadorIdentity.Id;

            var tatuador = await _tatuadorApp.BuscarPorId(idfakeInt);

            if (tatuador != null)
            {
                tatuadorServer.PrimeiroNome = tatuador.PrimeiroNome;
                tatuadorServer.SobrenomeCompleto = tatuador.SobrenomeCompleto;
                tatuadorServer.Sexo = tatuador.Sexo;

                tatuadorServer.NomeDeUsuario = tatuador.NomeDeUsuario;

                tatuadorServer.Instagram = tatuador.Instagram;
                tatuadorServer.Facebook = tatuador.Facebook;
                tatuadorServer.Twitter = tatuador.Twitter;
                tatuadorServer.LinkedIn = tatuador.LinkedIn;
                tatuadorServer.YouTube = tatuador.YouTube;
                tatuadorServer.WhatsApp = tatuador.WhatsApp;
                tatuadorServer.TextoBibliografico = tatuador.TextoBibliografico;

                tatuadorServer.Telefone = tatuador.Telefone;
                tatuadorServer.OutroTelefone = tatuador.OutroTelefone;
                tatuadorServer.CPF = tatuador.CPF;
                tatuadorServer.DataDeNascimento = tatuador.DataDeNascimento;
            }

            return View(tatuadorServer);

        }
  
        [Authorize(Roles = "Tatuador")]
        public async Task<IActionResult> InserirDadosTatuador(TatuadorDTO CadastroTatuador)
        {
            if (ModelState.IsValid) // verifica o estado do modelo, se é valido ou invalido
            {

                CadastroTatuador.CPF = CadastroTatuador.CPF.Replace(".", "").Replace("-", "");
                CadastroTatuador.Telefone = CadastroTatuador.Telefone.Replace(".", "").Replace("-", "");

                if (CadastroTatuador.OutroTelefone != "")
                {
                    CadastroTatuador.OutroTelefone = CadastroTatuador.OutroTelefone.Replace(".", "").Replace("-", "");
                }


                await _tatuadorApp.Alterar(CadastroTatuador);

                return RedirectToAction("Index", "Home"); 

            }
            return RedirectToAction("CadastroTatuador"); 
        }

        [HttpGet]
        public async Task<IActionResult> ValidarCpf(string cpfCliente)
        {
            if (string.IsNullOrEmpty(cpfCliente))
            {
                return Json("False");
            }

            if (ModelState.IsValid)
            {
                cpfCliente = cpfCliente.Replace(".", "").Replace("-", "");

                var tatuador = await _tatuadorApp.GetTatuadorByCpf(cpfCliente);

                if (tatuador != null)
                {
                    var idTatuador = idfakeInt;

                    if (tatuador.IdTatuador != 0)
                    {
                        if (idTatuador != tatuador.IdTatuador)
                        {
                            return Json("True"); // "Cpf Já está Cadastrado em algum IdTatuador"
                        }
                    }
                    else
                    {
                        if (await _tatuadorApp.GetTatuadorByIdTatuador(idTatuador) == null)
                        {
                            tatuador.IdTatuador = idTatuador;
                            await _tatuadorApp.UpdateByCpf(tatuador);
                        }
                        else
                        {
                            return Json("TrueFalse"); // "IdCliente Já está cadastrado em algum Cpf"
                        }
                    }
                }
            }


            return Json("False");
        }

        [HttpGet]
        public async Task<IActionResult> ValidarEmail(string emailCliente)
        {
            if (string.IsNullOrEmpty(emailCliente))
            {
                return Json("False");
            }

            if (ModelState.IsValid)
            {
                var tatuador = await _tatuadorApp.GetTatuadorByEmail(emailCliente);

                if (tatuador != null)
                {
                    var idTatuador = idfakeInt;

                    if (!string.IsNullOrEmpty(tatuador.Email))
                    {
                        if (idTatuador != tatuador.IdTatuador)
                        {
                            return Json("True"); // "Email Já está Cadastrado em algum IdCliente"
                        }
                    }
                }
            }
            return Json("False");
        }


        public async Task<string> TipoClienteAsync()
        {
            //var user = await userManager.GetUserAsync(this.User);

            //if (await userManager.IsInRoleAsync(user, "Estudio") == true)
            //{
            //    return "Estudio";
            //}
            //else if (await userManager.IsInRoleAsync(user, "Tatuador") == true)
            //{
            //    return "Tatuador";
            //}

            return null;
        }

    }
}