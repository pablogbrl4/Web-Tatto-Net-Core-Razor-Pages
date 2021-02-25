using Microsoft.AspNetCore.Authorization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Tatto.Areas.Identity.Data;
using Tatto.Controllers;
using Tatto.Repositories;

namespace Tatto.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterConfirmationModel : PageModel
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly IEmailSender _sender;

        private readonly IUsuarioRepository usuarioRepository;
        private readonly ITatuadorRepository tatuadorRepository;
        private readonly IEstudioRepository estudioRepository;

        public RegisterConfirmationModel(UserManager<AppIdentityUser> userManager, IEmailSender sender,
            IEstudioRepository estudioRepository, IUsuarioRepository usuarioRepository, ITatuadorRepository tatuadorRepository)
        {
            _userManager = userManager;
            _sender = sender;

            this.estudioRepository = estudioRepository;
            this.usuarioRepository = usuarioRepository;
            this.tatuadorRepository = tatuadorRepository;
        }

        public string Email { get; set; }

        public bool DisplayConfirmAccountLink { get; set; }

        public string EmailConfirmationUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(string email, string returnUrl = null)
        {

            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com e-mail '{email}'.");
            }

            Email = email;
            // Once you add a real email sender, you should remove this code that lets you confirm the account
            DisplayConfirmAccountLink = true;
            if (DisplayConfirmAccountLink)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                EmailConfirmationUrl = Url.Page(
                    "/Account/ConfirmEmail",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    protocol: Request.Scheme);
            }

            var tipoUsuario = HomeController.getUserNow();

            await _userManager.AddToRoleAsync(user, tipoUsuario);

            if (tipoUsuario == "Cliente")
            {
                if (await usuarioRepository.idNaoNull(user.Id) == null)
                {
                    await usuarioRepository.InsertNew(user.Email, user.Id, user.UserName);
                }
            }
            else if (tipoUsuario == "Estudio")
            {
                if (await estudioRepository.idNaoNull(user.Id) == null)
                {
                    await estudioRepository.InsertNew(user.Email, user.Id, user.UserName);
                }

            }
            else if (tipoUsuario == "Tatuador")
            {
                if (await tatuadorRepository.idNaoNull(user.Id) == null)
                {
                    await tatuadorRepository.InsertNew(user.Email, user.Id, user.UserName);
                }
            }

            return Page();
        }
    }
}
