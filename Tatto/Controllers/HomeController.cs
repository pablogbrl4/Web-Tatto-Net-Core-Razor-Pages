using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tatto.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Tatto.Areas.Identity.Data;
using Tatto.Repositories;

namespace Tatto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly UserManager<AppIdentityUser> userManager; // injeção de dependencia identity      

        public static string tipoUsuario { get; set; }

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment, UserManager<AppIdentityUser> userManager)
        {
            _logger = logger;
            this._hostEnvironment = hostEnvironment;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var usuario = await userManager.GetUserAsync(this.User);

            if (usuario == null)
            {
                return View();
            }
            else if (await userManager.IsInRoleAsync(usuario, "Estudio") == true)
            {
                tipoUsuario = "Estudio";
                return RedirectToAction("HomeEstudio", "Estudio");
            }
            else if (await userManager.IsInRoleAsync(usuario, "Tatuador") == true)
            {
                tipoUsuario = "Tatuador";
                return RedirectToAction("AgendaTatuador", "Agenda");
            }
            else if (await userManager.IsInRoleAsync(usuario, "Cliente") == true)
            {            
                return View();
            }

            return View();
        }

        [HttpPost]
        public void pegarUsuarioAtual(string tipeUser)
        {
            tipoUsuario = tipeUser;
        }

        public static string getUserNow()
        {
            return tipoUsuario;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private bool IsValidExtension(IFormFile filename)
        {
            bool isValid = false;
            Char delimiter = '.';
            string fileExtension;
            string[] imgTypes = new string[] { "png", "jpg", "gif", "jpeg" };
            string[] documentsTypes = new string[] { "doc", "docx", "xls", "xlsx", "pdf", "ppt", "pptx" };
            string[] collTypes = new string[] { "zip", "rar", "tar" };
            string[] VideoTypes = new string[] { "mp4", "flv", "mkv", "3gp" };
            fileExtension = filename.FileName.Split(delimiter).Last();
            // fileExtension = substrings[substrings.Length - 1].ToString();
            int fileType = 0;
            if (imgTypes.Contains(fileExtension.ToLower()))
            {
                fileType = 1;
            }
            else if (documentsTypes.Contains(fileExtension.ToLower()))
            {
                fileType = 2;
            }
            else if (collTypes.Contains(fileExtension.ToLower()))
            {
                fileType = 3;
            }
            else if (VideoTypes.Contains(fileExtension.ToLower()))
            {
                fileType = 4;
            }
            switch (fileType)
            {
                case 1:
                    if (imgTypes.Contains(fileExtension.ToLower()))
                    {
                        isValid = true;
                    }
                    break;
                case 2:
                    if (documentsTypes.Contains(fileExtension.ToLower()))
                    {
                        isValid = false;
                    }
                    break;
                case 3:
                    if (collTypes.Contains(fileExtension.ToLower()))
                    {
                        isValid = false;
                    }
                    break;
                case 4:
                    if (VideoTypes.Contains(fileExtension.ToLower()))
                    {
                        isValid = true;
                    }
                    break;
                default:
                    isValid = false;
                    break;
            }
            return isValid;
        }

        private string GetNewFileName(string filenamestart)
        {
            // Char delimiter = '.';
            string fileExtension;
            string strFileName = string.Empty;
            //fileExtension = filename.FileName.Split(delimiter).Last();
            fileExtension = "jpg";
            strFileName = $"{filenamestart}.{fileExtension}";
            return strFileName;
        }

        public IActionResult UploadFilesWihtLocation()
        {
            string hoststr = _hostEnvironment.WebRootPath;

            string[] strFileNames;
            ///string url = "";
            try
            {
                long size = 0;
                var files = Request.Form.Files; // Pega os Dados da Fotos 
                strFileNames = new string[files.Count];
                string fileLocation = Request.Form["UploadLocation"].ToString(); // Pega Os Dados do local onde será gravada a foto
                //string[] path = fileLocation.Split("/");
                string fileInitals = Request.Form["FileInitials"].ToString(); // Primeira parte do nome que a foto irá receber
                int i = 0;
                string[] path = fileLocation.Split("\\"); // Desmembra em um array o caminho do diretorio onde será armazenada a foto
                if (!Directory.Exists(hoststr + "\\" + path[1]))
                {
                    Directory.CreateDirectory(hoststr + "\\" + path[1]);
                    Directory.CreateDirectory(hoststr + "\\" + path[1] + "\\" + path[2]);
                }
                else if (!Directory.Exists(hoststr + fileLocation))
                {
                    //Directory.CreateDirectory(hoststr + "\\" + path[1] + "\\" + path[2] + "\\" + path[3]);
                    Directory.CreateDirectory(hoststr + "\\" + fileLocation);
                }

                foreach (var file in files)
                {
                    if (IsValidExtension(file))
                    {
                        var filename = GetNewFileName(fileInitals);
                        strFileNames[i] = fileLocation + filename;
                        string fullpath = hoststr + fileLocation + $@"\{filename}";
                        size += file.Length;
                        using (FileStream fs = System.IO.File.Create(fullpath))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                            fs.Close();
                        }
                    }
                    else
                    {
                        strFileNames = new string[1];
                        strFileNames[0] = "Invalid File";
                    }
                    i = i + 1;
                }
            }
            catch (Exception ex)
            {
                strFileNames = new string[1];
                strFileNames[0] = ex.Message;
            }
            return Json(strFileNames);
        }

        
    }
}
