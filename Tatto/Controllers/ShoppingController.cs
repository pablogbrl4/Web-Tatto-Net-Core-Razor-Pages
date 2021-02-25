using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Tatto.Areas.Identity.Data;
using Tatto.Models;
using Tatto.Models.ViewModels;
using Tatto.Repositories;

namespace Tatto.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IShoppingRepository ShoppingRepository;
        private readonly UserManager<AppIdentityUser> userManager;

        private readonly IWebHostEnvironment _hostEnvironment;

        Shopping shopping = new Shopping();

        public ShoppingController(IShoppingRepository ShoppingRepository, UserManager<AppIdentityUser> userManager,
            IWebHostEnvironment hostEnvironment)
        {
            this.ShoppingRepository = ShoppingRepository;
            this.userManager = userManager;

            this._hostEnvironment = hostEnvironment;
        }


        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroShopping(int id = 0)
        {
            if (id != 0)
            {
                shopping = await ShoppingRepository.GetFotoById(id);
            }
            else
            {
                shopping.IdEstudio = userManager.GetUserId(this.User);
            }

            return View(shopping);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> ListarShopping(string pesquisa)
        {
            return View(await ShoppingRepository.GetAllShoppings(userManager.GetUserId(this.User), pesquisa));               
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> DeletarFoto(int id)
        {
            shopping = await ShoppingRepository.GetFotoById(id);

            FileInfo file = new FileInfo(consultarFotoRepositorio(shopping));

            if (file.Exists)
            {
                file.Delete();
            }

            await ShoppingRepository.DeletarShopping(id);

            return RedirectToAction("ListarShopping");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosShopping(Shopping shopping)
        {
            if (shopping.ImageFile != null && shopping.Id == 0) // New Picure
            {
                await cadastrarFotoRepositorioAsync(shopping);
            }
            else if (!String.IsNullOrEmpty(shopping.ImageName) && shopping.ImageFile == null && shopping.Id != 0) // Edit Name Picture
            {
                var fotoOrignalName = await ShoppingRepository.GetFotoById(shopping.Id);
                System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(shopping));
            }
            else if (!String.IsNullOrEmpty(shopping.ImageName) && shopping.ImageFile != null && shopping.Id != 0) // Edit Name And Picture
            {
                var fotoOrignalName = await ShoppingRepository.GetFotoById(shopping.Id);

                FileInfo file = new FileInfo(consultarFotoRepositorio(shopping));

                if (file.Exists)
                {
                    System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(shopping));
                }

                await cadastrarFotoRepositorioAsync(shopping);
            }

            await ShoppingRepository.UpdateShopping(shopping);

            return RedirectToAction("ListarShopping");
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
                shopping = await ShoppingRepository.GetShoppingByNomeFoto(nomeFoto, userManager.GetUserId(this.User));

                if (shopping != null)
                {
                    return Json("True"); // "nomeFoto Já está Cadastrado em algum IdEstudio"

                }
            }

            return Json("False");
        }

        public string consultarFotoRepositorio(Shopping foto)
        {
            string hoststr = _hostEnvironment.WebRootPath;
            string fileLocation = Path.Combine("\\images\\estudio\\FotosShoping\\" + foto.IdEstudio);
            string path = Path.Combine(hoststr + fileLocation, foto.ImageName + ".jpg");

            return path;
        }

        public async Task cadastrarFotoRepositorioAsync(Shopping foto)
        {
            string hoststr = _hostEnvironment.WebRootPath;
            string fileLocation = Path.Combine("\\images\\estudio\\FotosShoping\\" + foto.IdEstudio);

            string[] path = fileLocation.Split("\\"); // Desmembra em um array o caminho do diretorio onde será armazenada a foto
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