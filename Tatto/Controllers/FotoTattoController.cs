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
    public class FotoTattoController : Controller
    {
        private readonly IFotoTattoRepository fotoTattoRepository;
        private readonly UserManager<AppIdentityUser> userManager;

        private readonly ITatuadorRepository tatuadorRepository;

        private readonly IUsuarioRepository usuarioRepository;
        private readonly IContatosRepository contatoRepository;

        private readonly IEstudio_TatuadorRepository estudio_TatuadorRepository;

        private readonly IWebHostEnvironment _hostEnvironment;

        FotoTatto foto = new FotoTatto();

        public FotoTattoController(IFotoTattoRepository fotoTattoRepository, UserManager<AppIdentityUser> userManager,
            IWebHostEnvironment hostEnvironment, ITatuadorRepository tatuadorRepository,
            IUsuarioRepository usuarioRepository, IContatosRepository contatoRepository,
            IEstudio_TatuadorRepository estudio_TatuadorRepository)
        {
            this.fotoTattoRepository = fotoTattoRepository;
            this.userManager = userManager;

            this._hostEnvironment = hostEnvironment;

            this.tatuadorRepository = tatuadorRepository;

            this.usuarioRepository = usuarioRepository;
            this.contatoRepository = contatoRepository;

            this.estudio_TatuadorRepository = estudio_TatuadorRepository;
        }


        // Público
        public async Task<IActionResult> ListarTatuagens(string estilo = "", string parteCorpo = "", string genero = "", string cor = "")
        {
            return View(await fotoTattoRepository.GetAllFotosTatto(estilo, parteCorpo, genero, cor));
        }      

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroFotoTattoo(int id = 0)
        {
            if (id != 0)
            {
                foto = await fotoTattoRepository.GetFotoById(id);
            }
            else
            {
                foto.IdEstudio = userManager.GetUserId(this.User);
            }

            var IdsEstudiosTatuadores = await estudio_TatuadorRepository.GetIdsByIdEstudio(userManager.GetUserId(this.User));

            foreach (var item in IdsEstudiosTatuadores)
            {
                if (item.IdTatuador != null)
                {
                    foto.Tatuador.Add(await tatuadorRepository.GetTatuadorById(item.IdTatuador));
                }
            }

            var IdsContatos = await contatoRepository.GetContatosByIdEstudio(userManager.GetUserId(this.User));

            foreach (var item in IdsContatos)
            {
                if (item.IdUsuario != 0)
                {
                    foto.Usuario.Add(await usuarioRepository.GetUsuarioById(item.IdUsuario));
                }
            }

            return View(foto);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> ListarFotosTattoos(string estilo = "", string parteCorpo = "")
        {
            return View(await fotoTattoRepository.GetFotosTattoByIdEstudio(userManager.GetUserId(this.User), estilo, parteCorpo));
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> DeletarFoto(int id)
        {
            foto = await fotoTattoRepository.GetFotoById(id);

            FileInfo file = new FileInfo(consultarFotoRepositorio(foto));

            if (file.Exists)
            {
                file.Delete();
            }

            await fotoTattoRepository.DeletarFoto(id);

            return RedirectToAction("ListarFotosTattoos");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosFotoTattoo(FotoTatto foto)
        {
            if (foto.ImageFile != null && foto.Id == 0) // New Picure
            {
                await cadastrarFotoRepositorioAsync(foto);
            }
            else if (!String.IsNullOrEmpty(foto.ImageName) && foto.ImageFile == null && foto.Id != 0) // Edit Name Picture
            {
                var fotoOrignalName = await fotoTattoRepository.GetFotoById(foto.Id);
                System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(foto));
            }
            else if (!String.IsNullOrEmpty(foto.ImageName) && foto.ImageFile != null && foto.Id != 0) // Edit Name And Picture
            {
                var fotoOrignalName = await fotoTattoRepository.GetFotoById(foto.Id);

                FileInfo file = new FileInfo(consultarFotoRepositorio(foto));

                if (file.Exists)
                {
                    System.IO.File.Move(consultarFotoRepositorio(fotoOrignalName), consultarFotoRepositorio(foto));
                }
                
                await cadastrarFotoRepositorioAsync(foto);
            }

            await fotoTattoRepository.UpdateFoto(foto);

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
                foto = await fotoTattoRepository.GetFotoTattoByNomeFoto(nomeFoto, userManager.GetUserId(this.User));

                if (foto != null)
                {
                    return Json("True"); // "nomeFoto Já está Cadastrado em algum IdEstudio"

                }
            }

            return Json("False");
        }

        public string consultarFotoRepositorio(FotoTatto foto)
        {
            string hoststr = _hostEnvironment.WebRootPath;
            string fileLocation = Path.Combine("\\images\\estudio\\FotosTatuagens\\" + foto.IdEstudio);
            string path = Path.Combine(hoststr + fileLocation, foto.ImageName + ".jpg");

            return path;
        }

        public async Task cadastrarFotoRepositorioAsync(FotoTatto foto)
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