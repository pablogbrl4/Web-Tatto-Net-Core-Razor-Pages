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
    public class FotoTattoController : Controller // : CoreController<FotoTatto, FotoTattoDTO>
    {
        private readonly IFotoTattoApp _fotoTattoApp;
        private readonly ITatuadorApp _tatuadorApp;
        private readonly IClienteApp _usuarioApp;
        private readonly IContatosApp _contatosApp;
        private readonly IEstudio_TatuadorApp _estudio_TatuadorApp;

        private readonly IWebHostEnvironment _hostEnvironment;

        FotoTattoDTO foto = new FotoTattoDTO();

        string idfake = "0";

        int idfakeInt = 2;

        public FotoTattoController(IFotoTattoApp fotoTattoApp, 
            IWebHostEnvironment hostEnvironment, ITatuadorApp tatuadorApp,
            IClienteApp usuarioApp, IContatosApp contatosApp,
            IEstudio_TatuadorApp estudio_TatuadorApp) // : base(fotoTattoApp)
        {
            this._fotoTattoApp = fotoTattoApp;
            this._hostEnvironment = hostEnvironment;
            this._tatuadorApp = tatuadorApp;
            this._usuarioApp = usuarioApp;
            this._contatosApp = contatosApp;
            this._estudio_TatuadorApp = estudio_TatuadorApp;
        }


        // Público
        //public async Task<IActionResult> ListarTatuagens(string estilo = "", string parteCorpo = "", string genero = "", string cor = "")
        //{
        //    return View(await _fotoTattoApp.GetAllFotosTatto(estilo, parteCorpo, genero, cor));
        //}      

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroFotoTattoo(int id = 0)
        {
            if (id != 0)
            {
                foto = await _fotoTattoApp.BuscarPorId(id);
            }
            else
            {
                foto.IdEstudio = idfakeInt;
            }

            var IdsEstudiosTatuadores = await _estudio_TatuadorApp.GetIdsByIdEstudio(idfakeInt);

            foreach (var item in IdsEstudiosTatuadores)
            {
                if (item.IdTatuador != 0)
                {
                    foto.Tatuador.Add(await _tatuadorApp.BuscarPorId(item.IdTatuador));
                }
            }

            var IdsContatos = await _contatosApp.GetContatosByIdEstudio(idfakeInt);

            foreach (var item in IdsContatos)
            {
                if (item.IdCliente != 0)
                {
                    foto.Cliente.Add(await _usuarioApp.GetClienteById(item.IdCliente));
                }
            }

            return View(foto);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> ListarFotosTattoos(string estilo = "", string parteCorpo = "")
        {
            return View(await _fotoTattoApp.GetFotosTattoByIdEstudio(idfakeInt, estilo, parteCorpo));
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> DeletarFoto(int id)
        {
            foto = await _fotoTattoApp.BuscarPorId(id);

            FileInfo file = new FileInfo(consultarFotoRepositorio(foto));

            if (file.Exists)
            {
                file.Delete();
            }

            await _fotoTattoApp.Excluir(id);

            return RedirectToAction("ListarFotosTattoos");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosFotoTattoo(FotoTattoDTO foto)
        {
            if (foto.ImageFile != null && foto.Id == 0) // New Picure
            {
                await cadastrarFotoRepositorioAsync(foto);
            }
            else if (!String.IsNullOrEmpty(foto.ImageName) && foto.ImageFile == null && foto.Id != 0) // Edit Name Picture
            {
                var fotoOrignalName = await _fotoTattoApp.BuscarPorId(foto.Id);
                System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(foto));
            }
            else if (!String.IsNullOrEmpty(foto.ImageName) && foto.ImageFile != null && foto.Id != 0) // Edit Name And Picture
            {
                var fotoOrignalName = await _fotoTattoApp.BuscarPorId(foto.Id);

                FileInfo file = new FileInfo(consultarFotoRepositorio(foto));

                if (file.Exists)
                {
                    System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(foto));
                }
                
                await cadastrarFotoRepositorioAsync(foto);
            }

            await _fotoTattoApp.Alterar(foto);

            return RedirectToAction("ListarFotosTattoos");
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
                foto = await _fotoTattoApp.GetFotoTattoByNomeFoto(nomeFoto, idfakeInt);

                if (foto != null)
                {
                    return Json("True"); // "nomeFoto Já está Cadastrado em algum IdEstudio"

                }
            }

            return Json("False");
        }

        public string consultarFotoRepositorio(FotoTattoDTO foto)
        {
            string hoststr = _hostEnvironment.WebRootPath;
            string fileLocation = Path.Combine("\\images\\estudio\\FotosTatuagens\\" + foto.IdEstudio);
            string path = Path.Combine(hoststr + fileLocation, foto.ImageName + ".jpg");

            return path;
        }

        public async Task cadastrarFotoRepositorioAsync(FotoTattoDTO foto)
        {
            string hoststr = _hostEnvironment.WebRootPath;
            string fileLocation = Path.Combine("\\images\\estudio\\FotosTatuagens\\" + foto.IdEstudio);

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