using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Tatto.Areas.Identity.Data;
using Tatto.Models;
using Tatto.Repositories;

namespace Tatto.Controllers
{
    public class FotosEstudioController : Controller
    {
        private readonly IFotosEstudioRepository fotosEstudioRepository;
        private readonly UserManager<AppIdentityUser> userManager;

        private readonly IWebHostEnvironment _hostEnvironment;

        FotosEstudio foto = new FotosEstudio();

        public FotosEstudioController(IFotosEstudioRepository FotosEstudioRepository, UserManager<AppIdentityUser> userManager,
            IWebHostEnvironment hostEnvironment)
        {
            this.fotosEstudioRepository = FotosEstudioRepository;
            this.userManager = userManager;

            this._hostEnvironment = hostEnvironment;
        }


        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroFotoEstudio(int id = 0)
        {
            if (id != 0)
            {
                foto = await fotosEstudioRepository.GetFotoById(id);
            }
            else
            {
                foto.IdEstudio = userManager.GetUserId(this.User);
            }

            return View(foto);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosFotosEstudio(FotosEstudio foto)
        {
            if (foto.ImageFile != null && foto.Id == 0) // New Picure
            {
                await cadastrarFotoRepositorioAsync(foto);
            }
            else if (!String.IsNullOrEmpty(foto.ImageName) && foto.ImageFile == null && foto.Id != 0) // Edit Name Picture
            {
                var fotoOrignalName = await fotosEstudioRepository.GetFotoById(foto.Id);
                System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(foto));
            }
            else if (!String.IsNullOrEmpty(foto.ImageName) && foto.ImageFile != null && foto.Id != 0) // Edit Name And Picture
            {
                var fotoOrignalName = await fotosEstudioRepository.GetFotoById(foto.Id);

                FileInfo file = new FileInfo(consultarFotoRepositorio(foto));

                if (file.Exists)
                {
                    System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(foto));
                }

                await cadastrarFotoRepositorioAsync(foto);
            }

            await fotosEstudioRepository.UpdateFoto(foto);

            return RedirectToAction("ListarFotosEstudios");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> ListarFotosEstudios(string pesquisa = "")
        {
            if (pesquisa == "")
            {
                pesquisa = userManager.GetUserId(this.User); ;
            }

            return View(await fotosEstudioRepository.GetAllFotosEstudio(pesquisa));
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> DeletarFoto(int id)
        {

            foto = await fotosEstudioRepository.GetFotoById(id);

            FileInfo file = new FileInfo(consultarFotoRepositorio(foto));

            if (file.Exists)
            {
                file.Delete();
            }

            await fotosEstudioRepository.DeletarFoto(foto.Id);    

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
                foto = await fotosEstudioRepository.GetFotosEstudioByNomeFoto(nomeFoto, userManager.GetUserId(this.User));

                if (foto != null)
                {
                    return Json("True"); 

                }
            }

            return Json("False");
        }

        public string consultarFotoRepositorio(FotosEstudio foto)
        {
            string hoststr = _hostEnvironment.WebRootPath;
            string fileLocation = Path.Combine("\\images\\estudio\\FotosEstudios\\" + foto.IdEstudio);
            string path = Path.Combine(hoststr + fileLocation, foto.ImageName + ".jpg");

            return path;
        }

        public async Task cadastrarFotoRepositorioAsync(FotosEstudio foto)
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