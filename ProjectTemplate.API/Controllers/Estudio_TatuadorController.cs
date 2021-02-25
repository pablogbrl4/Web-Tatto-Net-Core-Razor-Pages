using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.API.Controllers;

namespace Tatto.Controllers
{
    public class Estudio_TatuadorController : Controller // : CoreController<Estudio_Tatuador, Estudio_TatuadorDTO>
    {

        private readonly IEstudioApp _estudioApp;
        private readonly ITatuadorApp _tatuadorApp;
        private readonly IEstudio_TatuadorApp _estudio_TatuadorApp;

        int idfake = 0;

        public Estudio_TatuadorController(IEstudio_TatuadorApp estudio_TatuadorApp,
            ITatuadorApp tatuadorApp, IEstudioApp estudioApp) // : base(estudio_TatuadorApp)
        {
            this._estudio_TatuadorApp = estudio_TatuadorApp;
            this._tatuadorApp = tatuadorApp;
            this._estudioApp = estudioApp;
        }

        Estudio_TatuadorDTO estudioTatuador = new Estudio_TatuadorDTO();

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> BuscaTatuadores()
        {

            var listaEstudioTatuador = await _estudio_TatuadorApp.GetIdsByIdEstudio(idfake); 

            for (int i = 0; i < listaEstudioTatuador.Count; i++)
            {
                if (listaEstudioTatuador[i] != null)
              {
                    listaEstudioTatuador[i].Tatuador = await _tatuadorApp.BuscarPorId(listaEstudioTatuador[i].IdTatuador); 
              }
            }

            // return View(new BuscaEstudiosTatuadoresViewModel(listaEstudioTatuador, ""));

            return Ok(listaEstudioTatuador);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastrarTatuadorbyCpf(string tatuadorbyCpf = "")
        {
            var tatuador = await _tatuadorApp.GetTatuadorByCpf(tatuadorbyCpf);

            if (tatuador != null)
            {
                await _estudio_TatuadorApp.InsertByIds(tatuador.IdTatuador, idfake);
            }

            return RedirectToAction("BuscaTatuadores");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> RemoverEstudio_Tatuador(int id)
        {
            await _estudio_TatuadorApp.Excluir(id); 

            return RedirectToAction("BuscaTatuadores");
        }

        // Público
        public async Task<IActionResult> ListarTatuadores(string id = "")
        {
            
            estudioTatuador.Estudios = (await _estudioApp.GetEstudiosByBairro(id)).Estudios;         

            var estudiosTatuadores = new HashSet<Estudio_TatuadorDTO>();

            foreach (var estudio in estudioTatuador.Estudios)
            {
                var temp = await _estudio_TatuadorApp.GetEstudioTatuadorByIdEstudio(estudio.IdEstudio);

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
                tatuadores.Add(await _tatuadorApp.GetTatuadorByIdTatuador(_estudioTatuador.IdTatuador));
            }

            var bairros = new HashSet<string>();

            foreach (var item in estudioTatuador.Estudios)
            {
                bairros.Add(item.Bairro);
            }

            // return View(new BuscaEstudiosTatuadoresViewModel(tatuadores.ToList(), bairros.ToList()));

            return Ok(tatuadores.ToList());

        }
    }
}
