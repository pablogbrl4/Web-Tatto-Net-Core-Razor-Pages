using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tatto.Models;
using Tatto.Repositories;
using Microsoft.AspNetCore.Identity;
using Tatto.Areas.Identity.Data;
using System;

namespace Tatto.Controllers
{
    public class TatuadorController : Controller
    {
        private readonly ITatuadorRepository tatuadorRepository; 
        private readonly UserManager<AppIdentityUser> userManager; 

        private readonly IEstudio_TatuadorRepository estudioTatuadorRepository;
        private readonly IEstudioRepository estudioRepository;

        private readonly IFotoTattoRepository fotoTattoRepository;

        public TatuadorController(ITatuadorRepository tatuadorRepository, UserManager<AppIdentityUser> userManager,
             IEstudio_TatuadorRepository estudioTatuadorRepository, IEstudioRepository estudioRepository,
             IFotoTattoRepository fotoTattoRepository)
        {
            this.tatuadorRepository = tatuadorRepository;
            this.userManager = userManager;

            this.estudioTatuadorRepository = estudioTatuadorRepository;
            this.estudioRepository = estudioRepository;

            this.fotoTattoRepository = fotoTattoRepository;
        }

        Tatuador tatuador = new Tatuador();

        // Público
        public async Task<IActionResult> PortifolioTatuador(string id = "")
        {
            var idTatuador = await tatuadorRepository.GetIdTatuadorByNomeUsuario(id);

            Tatuador tatuadorServer = new Tatuador();
            var tatuadorIdentity = await userManager.GetUserAsync(this.User); // acessar dados usuários no identity;

            if (!string.IsNullOrEmpty(idTatuador))
            {
                tatuadorIdentity = await userManager.FindByIdAsync(idTatuador);                
            }

            if (tatuadorIdentity == null)
            {
                return BadRequest(new { Erros = "Tatuador Não Possui Mais essa Conta" });
            }

            tatuadorServer.Email = tatuadorIdentity.Email;
            tatuadorServer.IdTatuador = tatuadorIdentity.Id;

            var tatuador = await tatuadorRepository.GetTatuadorById(tatuadorIdentity.Id);

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

            tatuadorServer.EstudioTatuador = await estudioTatuadorRepository.GetEstudioTatuadorByIdTatuador(tatuadorServer.IdTatuador);

            for (int i = 0; i < tatuadorServer.EstudioTatuador.Count; i++)
            {
                tatuadorServer.EstudioTatuador[i].Estudio = await estudioRepository.GetEstudioById(tatuadorServer.EstudioTatuador[i].IdEstudio);
            }

            return View(tatuadorServer);
        }

        // Público
        public async Task<IActionResult> GaleriaTatuador(string id = "")
        {
            var idTatuador = await tatuadorRepository.GetIdTatuadorByNomeUsuario(id);

            if (string.IsNullOrEmpty(idTatuador))
            {
                idTatuador = userManager.GetUserId(this.User);
            }

            tatuador = await tatuadorRepository.GetTatuadorByIdTatuador(idTatuador);
            tatuador.FotosTattos = await fotoTattoRepository.GetFotosByIdTatuador(idTatuador);

            return View(tatuador);
        }

        [Authorize(Roles = "Tatuador")]
        public async Task<IActionResult> CadastroTatuador(string id = "")
        {
            Tatuador tatuadorServer = new Tatuador();
            var tatuadorIdentity = await userManager.GetUserAsync(this.User); // acessar dados usuários no identity;

            if (!string.IsNullOrEmpty(id))
            {
                tatuadorIdentity = await userManager.FindByIdAsync(id);
            }

            tatuadorServer.Email = tatuadorIdentity.Email;
            tatuadorServer.IdTatuador = tatuadorIdentity.Id;

            var tatuador = await tatuadorRepository.GetTatuadorById(tatuadorIdentity.Id);

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
        public async Task<IActionResult> InserirDadosTatuador(Tatuador CadastroTatuador)
        {
            if (ModelState.IsValid) // verifica o estado do modelo, se é valido ou invalido
            {
                var tatuador = await userManager.FindByIdAsync(CadastroTatuador.IdTatuador);

                tatuador.Email = CadastroTatuador.Email;
                tatuador.UserName = CadastroTatuador.Email;
                tatuador.PhoneNumber = CadastroTatuador.Telefone;

                CadastroTatuador.CPF = CadastroTatuador.CPF.Replace(".", "").Replace("-", "");
                CadastroTatuador.Telefone = CadastroTatuador.Telefone.Replace(".", "").Replace("-", "");

                if (CadastroTatuador.OutroTelefone != "")
                {
                    CadastroTatuador.OutroTelefone = CadastroTatuador.OutroTelefone.Replace(".", "").Replace("-", "");
                }

                await userManager.UpdateAsync(tatuador); 

                await tatuadorRepository.Update(CadastroTatuador);

                return RedirectToAction("Index", "Home"); 

            }
            return RedirectToAction("CadastroTatuador"); 
        }

        [HttpGet]
        public async Task<IActionResult> ValidarCpf(string cpfUsuario)
        {
            if (string.IsNullOrEmpty(cpfUsuario))
            {
                return Json("False");
            }

            if (ModelState.IsValid)
            {
                cpfUsuario = cpfUsuario.Replace(".", "").Replace("-", "");

                var tatuador = await tatuadorRepository.GetTatuadorByCpf(cpfUsuario);

                if (tatuador != null)
                {
                    var idTatuador = userManager.GetUserId(this.User);

                    if (!string.IsNullOrEmpty(tatuador.IdTatuador))
                    {
                        if (idTatuador != tatuador.IdTatuador)
                        {
                            return Json("True"); // "Cpf Já está Cadastrado em algum IdTatuador"
                        }
                    }
                    else
                    {
                        if (await tatuadorRepository.GetTatuadorByIdTatuador(idTatuador) == null)
                        {
                            tatuador.IdTatuador = idTatuador;
                            await tatuadorRepository.UpdateByCpf(tatuador);
                        }
                        else
                        {
                            return Json("TrueFalse"); // "IdUsuario Já está cadastrado em algum Cpf"
                        }
                    }
                }
            }


            return Json("False");
        }

        [HttpGet]
        public async Task<IActionResult> ValidarEmail(string emailUsuario)
        {
            if (string.IsNullOrEmpty(emailUsuario))
            {
                return Json("False");
            }

            if (ModelState.IsValid)
            {
                var tatuador = await tatuadorRepository.GetTatuadorByEmail(emailUsuario);

                if (tatuador != null)
                {
                    var idTatuador = userManager.GetUserId(this.User);

                    if (!string.IsNullOrEmpty(tatuador.Email))
                    {
                        if (idTatuador != tatuador.IdTatuador)
                        {
                            return Json("True"); // "Email Já está Cadastrado em algum IdUsuario"
                        }
                    }
                }
            }
            return Json("False");
        }


        public async Task<string> TipoUsuarioAsync()
        {
            var user = await userManager.GetUserAsync(this.User);

            if (await userManager.IsInRoleAsync(user, "Estudio") == true)
            {
                return "Estudio";
            }
            else if (await userManager.IsInRoleAsync(user, "Tatuador") == true)
            {
                return "Tatuador";
            }

            return null;
        }

    }
}