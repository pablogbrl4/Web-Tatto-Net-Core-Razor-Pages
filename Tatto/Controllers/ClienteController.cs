using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tatto.Models;
using Tatto.Repositories;
using Microsoft.AspNetCore.Identity;
using Tatto.Areas.Identity.Data;
using System.Collections.Generic;
using Tatto.Models.ViewModels;
using System.Linq;
using System;
using System.Security.Claims;


//public class JavaScriptResult : ContentResult
//{
//    public JavaScriptResult(string script)
//    {
//        this.Content = script;
//        this.ContentType = "application/javascript";
//    }
//}

namespace Tatto.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly UserManager<AppIdentityUser> userManager;

        private readonly IContatosRepository contatosRepository;

        public ClienteController(IUsuarioRepository usuarioRepository, UserManager<AppIdentityUser> userManager,
            IContatosRepository contatosRepository)
        {
            this.usuarioRepository = usuarioRepository;
            this.userManager = userManager;

            this.contatosRepository = contatosRepository;
        }

        Usuario usuario = new Usuario();

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> CadastroUsuario(string id = "")
        {
            Usuario usuario = new Usuario();
            var usuarioIdentity = await userManager.GetUserAsync(this.User); // acessar dados usuários no identityario;

            if (id != "")
            {
                usuarioIdentity = await userManager.FindByIdAsync(id);
            }

            usuario.Email = usuarioIdentity.Email;
            usuario.IdUsuario = usuarioIdentity.Id;

            var user = await usuarioRepository.GetUsuarioByIdUsuario(usuarioIdentity.Id);

            if (user != null)
            {
                usuario.PrimeiroNome = user.PrimeiroNome;
                usuario.SobrenomeCompleto = user.SobrenomeCompleto;
                usuario.Sexo = user.Sexo;
                usuario.Telefone = user.Telefone;
                usuario.OutroTelefone = user.OutroTelefone;
                usuario.CPF = user.CPF;
                usuario.DataDeNascimento = user.DataDeNascimento;
                usuario.CEP = user.CEP;
                usuario.Endereco = user.Endereco;
                usuario.Numero = user.Numero;
                usuario.Bairro = user.Bairro;
                usuario.Complemento = user.Complemento;
                usuario.Cidade = user.Cidade;
                usuario.UF = user.UF;
            }

            return View(usuario);

        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroUsuarioByEstudio(int id = 0)
        {
            usuario = await usuarioRepository.GetUsuarioById(id);

            return View(usuario);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroUsuarioByTatuador(int id = 0)
        {
            usuario = await usuarioRepository.GetUsuarioById(id);

            return View(usuario);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> BuscaContatos(string pesquisa = "")
        {
            var idIdentity = userManager.GetUserId(this.User); // Pega Id do Estúdio

            var contatos = await contatosRepository.GetContatosByIdEstudio(idIdentity); // Chama Lista de Contatos

            IList<Usuario> usuarios = new List<Usuario>();

            foreach (var contato in contatos)
            {
                if (contato != null)
                {
                    usuarios.Add(await usuarioRepository.GetUsuarioById(contato.IdUsuario)); // Adiciona na lista dados usuários que estão nos contatos
                }
            }

            if (!string.IsNullOrEmpty(pesquisa)) // Busca Usuários por nome pesquisado
            {
                usuarios = usuarios.Where(u => u.PrimeiroNome.Contains(pesquisa.Trim())).ToList();
            }

            return View(new BuscaUsuariosViewModel(usuarios, pesquisa));
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastrarContatobyCpf(string ContatobyCpf = "")
        {
            usuario = await usuarioRepository.GetUsuarioByCpf(ContatobyCpf);

            if (usuario != null)
            {
                await contatosRepository.InsertByIds(usuario.Id, userManager.GetUserId(this.User)); // Insere Dados em Contatos
            }

            return RedirectToAction("BuscaContatos");
        }

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> InserirDadosUsuario(Usuario CadastroUsuario)
        {
            if (ModelState.IsValid) // verifica o estado do modelo, se é valido ou invalido
            {
                CadastroUsuario.Telefone = CadastroUsuario.Telefone.Replace(".", "").Replace("-", "");

                if (!String.IsNullOrEmpty(CadastroUsuario.CPF))
                {
                    CadastroUsuario.CPF = CadastroUsuario.CPF.Replace(".", "").Replace("-", "");
                }

                if (!String.IsNullOrEmpty(CadastroUsuario.OutroTelefone))
                {
                    CadastroUsuario.OutroTelefone = CadastroUsuario.OutroTelefone.Replace(".", "").Replace("-", "");
                }

                var identityUser = await userManager.FindByIdAsync(CadastroUsuario.IdUsuario);

                if (identityUser != null)
                {
                    identityUser.Email = CadastroUsuario.Email;
                    identityUser.UserName = CadastroUsuario.Email;
                    identityUser.PhoneNumber = CadastroUsuario.Telefone;

                    await userManager.UpdateAsync(identityUser); // grava dados na tabela de users
                }

                await usuarioRepository.UpdateByIdUsuario(CadastroUsuario);

                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("CadastroUsuario");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosUsuarioByEstudio(Usuario CadastroUsuario)
        {

            if (!string.IsNullOrEmpty(CadastroUsuario.Telefone))
            {
                CadastroUsuario.Telefone = CadastroUsuario.Telefone.Replace(".", "").Replace("-", "");
            }

            if (!string.IsNullOrEmpty(CadastroUsuario.CPF))
            {
                CadastroUsuario.CPF = CadastroUsuario.CPF.Replace(".", "").Replace("-", "");

                var cpf = await usuarioRepository.GetUsuarioByCpf(CadastroUsuario.CPF);

                if (cpf != null)
                {
                    CadastroUsuario.Id = cpf.Id;
                }
            }

            if (!string.IsNullOrEmpty(CadastroUsuario.OutroTelefone))
            {
                CadastroUsuario.OutroTelefone = CadastroUsuario.OutroTelefone.Replace(".", "").Replace("-", "");
            }
          
            await usuarioRepository.UpdateById(CadastroUsuario); // Atualiza ou Insere novo usuário

            await contatosRepository.InsertByIds(CadastroUsuario.Id, userManager.GetUserId(this.User)); // Insere Dados em Contatos

            return RedirectToAction("BuscaContatos"); // volta para tela de cadastro

        }

        public async Task<IActionResult> DeletarCliente(string id) // Possivel de exclusão
        {
            if (id == null)
            {
                return NotFound();
            }

            var identityUser = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(identityUser); // deleta dados na tabela  do Users

            usuarioRepository.Delete(id); // Deleta Usuário na tabela Usuario

            return RedirectToAction("BuscaUsuarios", "Cliente");

        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> RemoverContato(int id)
        {
            await contatosRepository.RemoverContato(id, userManager.GetUserId(this.User)); // Insere Dados em Contatos

            return RedirectToAction("BuscaContatos", "Cliente");
        }

        [HttpGet]
        public async Task<IActionResult> ValidarCpf(string cpfUsuario)
        {
            if (String.IsNullOrEmpty(cpfUsuario))
            {
                return Json("False");
            }

            if (ModelState.IsValid)
            {
                cpfUsuario = cpfUsuario.Replace(".", "").Replace("-", "");

                var usuarioByCpf = await usuarioRepository.GetUsuarioByCpf(cpfUsuario);

                if (usuarioByCpf != null)
                {
                    var idUsuario = userManager.GetUserId(this.User);

                    if (usuarioByCpf.IdUsuario != null && usuarioByCpf.IdUsuario != "")
                    {
                        if (idUsuario != usuarioByCpf.IdUsuario)
                        {
                            return Json("True"); // "Cpf Já está Cadastrado em algum IdUsuario"
                        }
                    }
                    else
                    {
                        if (await usuarioRepository.GetUsuarioByIdUsuario(idUsuario) == null)
                        {
                            usuarioByCpf.IdUsuario = idUsuario;
                            await usuarioRepository.UpdateByCpf(usuarioByCpf);
                        }
                        else
                        {
                            return Json("TrueFalse"); // "IdUsuario Já está cadastrado em algum Cpf"
                        }
                    }
                }
            }


            return Json("False");
        }

        [HttpGet]
        public async Task<IActionResult> ValidarEmail(string emailUsuario)
        {
            if (string.IsNullOrEmpty(emailUsuario))
            {
                return Json("False");
            }

            if (ModelState.IsValid)
            {
                var usuarioByEmail = await usuarioRepository.GetUsuarioByEmail(emailUsuario);

                if (usuarioByEmail != null)
                {
                    var idUsuario = userManager.GetUserId(this.User);

                    if (usuarioByEmail.Email != null && usuarioByEmail.Email != "")
                    {
                        if (idUsuario != usuarioByEmail.IdUsuario)
                        {
                            return Json("True"); // "Email Já está Cadastrado em algum IdUsuario"
                        }
                    }
                }
            }
            return Json("False");
        }
    }
}