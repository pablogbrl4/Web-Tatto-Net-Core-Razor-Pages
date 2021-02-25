using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.API.Controllers;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Application.Interfaces;

namespace Tatto.Controllers
{
    public class FotosEstudioController : Controller // : CoreController<FotosEstudio, FotosEstudioDTO>
    {
        private readonly IFotosEstudioApp _fotosEstudioApp;
        private readonly IWebHostEnvironment _hostEnvironment;

        FotosEstudioDTO foto = new FotosEstudioDTO();

        string idfake = "0";

        int idfakeInt = 0;


        public FotosEstudioController(IFotosEstudioApp fotosEstudioApp, 
            IWebHostEnvironment hostEnvironment) // : base(fotosEstudioApp)
        {
            this._fotosEstudioApp = fotosEstudioApp;
            this._hostEnvironment = hostEnvironment;
        }


        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroFotoEstudio(int id = 0)
        {
            if (id != 0)
            {
                foto = await _fotosEstudioApp.BuscarPorId(id);
            }
            else
            {
                foto.IdEstudio = idfakeInt;
            }

            return View(foto);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosFotosEstudio(FotosEstudioDTO foto)
        {
            if (foto.ImageFile != null && foto.Id == 0) // New Picure
            {
                await cadastrarFotoRepositorioAsync(foto);
            }
            else if (!String.IsNullOrEmpty(foto.ImageName) && foto.ImageFile == null && foto.Id != 0) // Edit Name Picture
            {
                var fotoOrignalName = await _fotosEstudioApp.BuscarPorId(foto.Id);
                System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(foto));
            }
            else if (!String.IsNullOrEmpty(foto.ImageName) && foto.ImageFile != null && foto.Id != 0) // Edit Name And Picture
            {
                var fotoOrignalName = await _fotosEstudioApp.BuscarPorId(foto.Id);

                FileInfo file = new FileInfo(consultarFotoRepositorio(foto));

                if (file.Exists)
                {
                    System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(foto));
                }

                await cadastrarFotoRepositorioAsync(foto);
            }

            await _fotosEstudioApp.Alterar(foto);

            return RedirectToAction("ListarFotosEstudios");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> ListarFotosEstudios(string pesquisa = "")
        {
            if (pesquisa == "")
            {
                pesquisa = idfake;
            }

            return View(await _fotosEstudioApp.BuscarTodos());
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> DeletarFoto(int id)
        {

            foto = await _fotosEstudioApp.BuscarPorId(id);

            FileInfo file = new FileInfo(consultarFotoRepositorio(foto));

            if (file.Exists)
            {
                file.Delete();
            }

            await _fotosEstudioApp.Excluir(foto.Id);    

            return RedirectToAction("ListarFotosEstudios");

        }

        [HttpGet]
        public async Task<IActionResult> ValidarNomeFoto(string nomeFoto)
        {
            if (String.IsNullOrEmpty(nomeFoto))
            {
                return Json("False");
            }

            if (ModelState.IsValid)
            {
                foto = await _fotosEstudioApp.GetFotosEstudioByNomeFoto(nomeFoto, idfakeInt);

                if (foto != null)
                {
                    return Json("True"); 

                }
            }

            return Json("False");
        }

        public string consultarFotoRepositorio(FotosEstudioDTO foto)
        {
            string hoststr = _hostEnvironment.WebRootPath;
            string fileLocation = Path.Combine("\\images\\estudio\\FotosEstudios\\" + foto.IdEstudio);
            string path = Path.Combine(hoststr + fileLocation, foto.ImageName + ".jpg");

            return path;
        }

        public async Task cadastrarFotoRepositorioAsync(FotosEstudioDTO foto)
        {
            string hoststr = _hostEnvironment.WebRootPath;
            string fileLocation = Path.Combine("\\images\\estudio\\FotosEstudios\\" + foto.IdEstudio);

            string[] path = fileLocation.Split("\\");
            if (!Directory.Exists(hoststr + "\\" + path[1]))
            {
                Directory.CreateDirectory(hoststr + "\\" + path[1]);
                Directory.CreateDirectory(hoststr + "\\" + path[1] + "\\" + path[2]);
            }
            else if (!Directory.Exists(hoststr + fileLocation))
            {
                Directory.CreateDirectory(hoststr + "\\" + fileLocation);
            }

            string fileName = foto.ImageName;
            string extension = ".jpg";
            fileName = fileName + extension;

            string fullpath = Path.Combine(hoststr + fileLocation, fileName);

            using (var fileStream = new FileStream(fullpath, FileMode.Create))
            {
                await foto.ImageFile.CopyToAsync(fileStream);
                fileStream.Close();
            }
        }
    }
}