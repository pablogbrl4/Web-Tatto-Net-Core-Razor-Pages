using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tatto.Models;
using Tatto.Repositories;
using Microsoft.AspNetCore.Identity;
using Tatto.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Tatto.Models.ViewModels;

namespace Tatto.Controllers
{
    public class Estudio_TatuadorController : Controller
    {

        private readonly IEstudio_TatuadorRepository estudio_TatuadorRepository; 
        private readonly UserManager<AppIdentityUser> userManager;

        private readonly ITatuadorRepository tatuadorRepository;
        private readonly IEstudioRepository estudioRepository;

        public Estudio_TatuadorController(IEstudio_TatuadorRepository estudio_TatuadorRepository, UserManager<AppIdentityUser> userManager,
            ITatuadorRepository tatuadorRepository, IEstudioRepository estudioRepository)
        {
            this.estudio_TatuadorRepository = estudio_TatuadorRepository;
            this.userManager = userManager;

            this.tatuadorRepository = tatuadorRepository;
            this.estudioRepository = estudioRepository;
        }

        Estudio_Tatuador estudioTatuador = new Estudio_Tatuador();

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> BuscaTatuadores()
        {
            var idIdentity = userManager.GetUserId(this.User); 

            var listaEstudioTatuador = await estudio_TatuadorRepository.GetIdsByIdEstudio(idIdentity); 

            for (int i = 0; i < listaEstudioTatuador.Count; i++)
            {
                if (listaEstudioTatuador[i] != null)
              {
                    listaEstudioTatuador[i].Tatuador = await tatuadorRepository.GetTatuadorById(listaEstudioTatuador[i].IdTatuador); 
              }
            }

            return View(new BuscaEstudiosTatuadoresViewModel(listaEstudioTatuador, ""));
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastrarTatuadorbyCpf(string tatuadorbyCpf = "")
        {
            var tatuador = await tatuadorRepository.GetTatuadorByCpf(tatuadorbyCpf);

            if (tatuador != null)
            {
                await estudio_TatuadorRepository.InsertByIds(tatuador.IdTatuador, userManager.GetUserId(this.User));
            }

            return RedirectToAction("BuscaTatuadores");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> RemoverEstudio_Tatuador(int id)
        {
            await estudio_TatuadorRepository.RemoverEstudioTatuador(id); 

            return RedirectToAction("BuscaTatuadores");
        }

        // Público
        public async Task<IActionResult> ListarTatuadores(string id = "")
        {
            
            estudioTatuador.Estudios = (await estudioRepository.GetEstudiosByBairro(id)).Estudios;         

            var estudiosTatuadores = new HashSet<Estudio_Tatuador>();

            foreach (var estudio in estudioTatuador.Estudios)
            {
                var temp = await estudio_TatuadorRepository.GetEstudioTatuadorByIdEstudio(estudio.IdEstudio);

                if (temp != null)
                {
                    foreach (var item in temp)
                    {
                        estudiosTatuadores.Add(item);
                    }
                }                
            }

            var tatuadores = new HashSet<Tatuador>();

            foreach (var _estudioTatuador in estudiosTatuadores)
            {
                tatuadores.Add(await tatuadorRepository.GetTatuadorByIdTatuador(_estudioTatuador.IdTatuador));
            }

            var bairros = new HashSet<string>();

            foreach (var item in estudioTatuador.Estudios)
            {
                bairros.Add(item.Bairro);
            }

            return View(new BuscaEstudiosTatuadoresViewModel(tatuadores.ToList(), bairros.ToList()));

        }
    }
}
