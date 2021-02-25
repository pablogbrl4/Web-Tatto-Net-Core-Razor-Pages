using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tatto.Models;
using Tatto.Repositories;
using Microsoft.AspNetCore.Identity;
using Tatto.Areas.Identity.Data;
using System;
using Tatto.Models.ViewModels;
using System.Linq;

namespace Tatto.Controllers
{
    public class AgendaController : Controller
    {
        private readonly IAgendaRepository agendaRepository;
        private readonly IEstudioRepository estudioRepository;
        private readonly ITatuadorRepository tatuadorRepository;

        private readonly IContatosRepository contatosRepository;
        private readonly IEstudio_TatuadorRepository estudio_TatuadorRepository;

        private readonly UserManager<AppIdentityUser> userManager;

        private readonly IUsuarioRepository usuarioRepository;

        public AgendaController(IAgendaRepository agendaRepository, UserManager<AppIdentityUser> userManager,
            IEstudioRepository estudioRepository, ITatuadorRepository tatuadorRepository, IContatosRepository contatosRepository,
            IEstudio_TatuadorRepository estudio_TatuadorRepository, IUsuarioRepository usuarioRepository)
        {
            this.agendaRepository = agendaRepository;
            this.userManager = userManager;

            this.estudio_TatuadorRepository = estudio_TatuadorRepository;
            this.contatosRepository = contatosRepository;

            this.estudioRepository = estudioRepository;
            this.tatuadorRepository = tatuadorRepository;
            this.usuarioRepository = usuarioRepository;

        }

        Agenda agenda = new Agenda();
        AppIdentityUser user = new AppIdentityUser();

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> AgendaUsuario()
        {
            var usuario = await usuarioRepository.GetUsuarioByIdUsuario(userManager.GetUserId(this.User));
            agenda.IdUsuario = usuario.Id;

            var agendas = await agendaRepository.GetAgendasByIdUsuario(agenda.IdUsuario);

            for (int i = 0; i < agendas.Count; i++)
            {
                agendas[i].Usuario = await usuarioRepository.GetUsuarioById(agendas[i].IdUsuario);
                agendas[i].Estudio = await estudioRepository.GetEstudioById(agendas[i].IdEstudio);
                agendas[i].Tatuador.Add(await tatuadorRepository.GetTatuadorById(agendas[i].IdTatuador));
            }

            agendas = agendas.OrderByDescending(o => o.DataMarcação).ToList();


            return View(new BuscaAgendaViewModel(agendas));
        }

        [Authorize(Roles = "Tatuador")]
        public async Task<IActionResult> AgendaTatuador()
        {

            var tatuador = await tatuadorRepository.GetTatuadorById(userManager.GetUserId(this.User));

            tatuador.Agenda = await agendaRepository.GetAgendasByIdTatuador(tatuador.IdTatuador);

            for (int i = 0; i < tatuador.Agenda.Count; i++)
            {
                tatuador.Agenda[i].Usuario = await usuarioRepository.GetUsuarioById(tatuador.Agenda[i].IdUsuario);
                tatuador.Agenda[i].Estudio = await estudioRepository.GetEstudioById(tatuador.Agenda[i].IdEstudio);
                tatuador.Agenda[i].Tatuador.Add(await tatuadorRepository.GetTatuadorById(tatuador.Agenda[i].IdTatuador));
            }

            tatuador.Agenda = tatuador.Agenda.OrderByDescending(o => o.DataMarcação).ToList();


            return View(tatuador);
        }

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> DesmacarAgenda(int id)
        {
            agenda = agendaRepository.GetAgendaByIdAgenda(id);
            agenda.Ativo = false;

            await agendaRepository.Update(agenda);

            return RedirectToAction("AgendaUsuario", "Agenda");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> DesmacarAgendaByEstudio(int id)
        {
            agenda = agendaRepository.GetAgendaByIdAgenda(id);
            agenda.Ativo = false;

            await agendaRepository.Update(agenda);

            return RedirectToAction("HomeEstudio", "Estudio");
        }

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> CadastroAgenda(string id = "")
        {
            var idEstudio = await estudioRepository.GetIdEstudioByNomeUsuario(id);

            agenda.Estudio = await estudioRepository.GetEstudioById(idEstudio);

            var IdsEstudiosTatuadores = await estudio_TatuadorRepository.GetIdsByIdEstudio(idEstudio);

            foreach (var item in IdsEstudiosTatuadores)
            {
                if (item.IdTatuador != null)
                {
                    agenda.Tatuador.Add(await tatuadorRepository.GetTatuadorById(item.IdTatuador));
                }
            }

            var usuario = await usuarioRepository.GetUsuarioByIdUsuario(userManager.GetUserId(this.User));
            agenda.IdUsuario = usuario.Id;
            agenda.IdEstudio = idEstudio;

            return View(agenda);

        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroAgendaByEstudio()
        {
            agenda.Estudio = await estudioRepository.GetEstudioById(userManager.GetUserId(this.User));
            agenda.IdEstudio = agenda.Estudio.IdEstudio;

            var IdsEstudiosTatuadores = await estudio_TatuadorRepository.GetIdsByIdEstudio(agenda.Estudio.IdEstudio);

            foreach (var item in IdsEstudiosTatuadores)
            {
                if (item.IdTatuador != null)
                {
                    agenda.Tatuador.Add(await tatuadorRepository.GetTatuadorById(item.IdTatuador));
                }
            }

            var IdsContatos = await contatosRepository.GetContatosByIdEstudio(agenda.Estudio.IdEstudio);

            foreach (var item in IdsContatos)
            {
                if (item.IdUsuario != 0)
                {
                    agenda.Usuarios.Add(await usuarioRepository.GetUsuarioById(item.IdUsuario));
                }
            }

            return View(agenda);

        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> EditarAgenda(int id)
        {

            agenda = agendaRepository.GetAgendaByIdAgenda((id));

            var IdsEstudiosTatuadores = await estudio_TatuadorRepository.GetIdsByIdEstudio(agenda.IdEstudio);

            foreach (var item in IdsEstudiosTatuadores)
            {
                if (item.IdTatuador != null)
                {
                    agenda.Tatuador.Add(await tatuadorRepository.GetTatuadorById(item.IdTatuador));
                }
            }

            agenda.Usuario = await usuarioRepository.GetUsuarioById(agenda.IdUsuario);

            return View(agenda);

        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> DeletarAgenda(int id)
        {
            await agendaRepository.Delete(id);

            return RedirectToAction("HomeEstudio", "Estudio");

        }

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> DeletarAgendaByCliente(int id)
        {
            await agendaRepository.Delete(id);

            return RedirectToAction("AgendaUsuario", "Agenda");

        }

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> InserirDadosAgenda(Agenda agenda)
        {
            agenda.Ativo = true;
            await agendaRepository.Update(agenda);

            var usuario = await usuarioRepository.GetUsuarioById(agenda.IdUsuario);
            var parsedDate = DateTime.Parse(usuario.DataDeNascimento);
            var idade = DateTime.Now - parsedDate;

            if ((idade.Days / 360) < 18)
            {
               return RedirectToAction("ContratoMenor", "Agenda", agenda);
            }

            return RedirectToAction("AgendaUsuario", "Agenda");

        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosAgendaByEstudio(Agenda cadastroAgenda)
        {

            cadastroAgenda.Ativo = true;

            await agendaRepository.Update(cadastroAgenda);

            return RedirectToAction("HomeEstudio", "Estudio");

        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> AlterarDadosAgenda(Agenda agenda)
        {
            agenda.Ativo = true;

            await agendaRepository.Update(agenda);

            return RedirectToAction("HomeEstudio", "Estudio");

        }

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> ContratoMenor(Agenda agenda)
        {
            agenda.Estudio = await estudioRepository.GetEstudioById(agenda.IdEstudio);
            agenda.Usuario = await usuarioRepository.GetUsuarioById(agenda.IdUsuario);

            return View(agenda);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> ContratoMenorByEstudio(int id)
        {
            agenda.Estudio = await estudioRepository.GetEstudioById(userManager.GetUserId(this.User));
            agenda.Usuario = await usuarioRepository.GetUsuarioById(id);

            return View("ContratoMenor", agenda);
        }

    }
}
