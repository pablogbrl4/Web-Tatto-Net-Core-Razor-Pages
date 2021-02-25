using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.API.Controllers;

namespace Tatto.Controllers
{
    public class ShoppingController : Controller // : CoreController<Shopping, ShoppingDTO>
    {
        private readonly IShoppingApp _shoppingApp;
        private readonly IWebHostEnvironment _hostEnvironment;

        ShoppingDTO shopping = new ShoppingDTO();

        string idfake = "0";

        int idfakeInt = 0;

        public ShoppingController(IShoppingApp shoppingApp, IWebHostEnvironment hostEnvironment) // : base(shoppingApp)
        {
            this._shoppingApp = shoppingApp;
            this._hostEnvironment = hostEnvironment;
        }


        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroShopping(int id = 0)
        {
            if (id != 0)
            {
                shopping = await _shoppingApp.GetFotoById(id);
            }
            else
            {
                shopping.IdEstudio = idfakeInt;
            }

            return View(shopping);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> ListarShopping(string pesquisa)
        {
            return View(await _shoppingApp.GetAllShoppings(idfakeInt, pesquisa));               
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> DeletarFoto(int id)
        {
            shopping = await _shoppingApp.GetFotoById(id);

            FileInfo file = new FileInfo(consultarFotoRepositorio(shopping));

            if (file.Exists)
            {
                file.Delete();
            }

            await _shoppingApp.Excluir(id);

            return RedirectToAction("ListarShopping");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosShopping(ShoppingDTO shopping)
        {
            if (shopping.ImageFile != null && shopping.Id == 0) // New Picure
            {
                await cadastrarFotoRepositorioAsync(shopping);
            }
            else if (!String.IsNullOrEmpty(shopping.ImageName) && shopping.ImageFile == null && shopping.Id != 0) // Edit Name Picture
            {
                var fotoOrignalName = await _shoppingApp.GetFotoById(shopping.Id);
                System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(shopping));
            }
            else if (!String.IsNullOrEmpty(shopping.ImageName) && shopping.ImageFile != null && shopping.Id != 0) // Edit Name And Picture
            {
                var fotoOrignalName = await _shoppingApp.GetFotoById(shopping.Id);

                FileInfo file = new FileInfo(consultarFotoRepositorio(shopping));

                if (file.Exists)
                {
                    System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(shopping));
                }

                await cadastrarFotoRepositorioAsync(shopping);
            }

            await _shoppingApp.Alterar(shopping);

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
                shopping = await _shoppingApp.GetShoppingByNomeFoto(nomeFoto, idfakeInt);

                if (shopping != null)
                {
                    return Json("True"); // "nomeFoto Já está Cadastrado em algum IdEstudio"

                }
            }

            return Json("False");
        }

        public string consultarFotoRepositorio(ShoppingDTO foto)
        {
            string hoststr = _hostEnvironment.WebRootPath;
            string fileLocation = Path.Combine("\\images\\estudio\\FotosShoping\\" + foto.IdEstudio);
            string path = Path.Combine(hoststr + fileLocation, foto.ImageName + ".jpg");

            return path;
        }

        public async Task cadastrarFotoRepositorioAsync(ShoppingDTO foto)
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