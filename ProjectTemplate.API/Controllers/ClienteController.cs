using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.API.Controllers;
using ProjectTemplate.Application.Interfaces;


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
    public class ClienteController : Controller // : CoreController<Cliente, ClienteDTO>
    {

        private readonly IContatosApp _contatosApp;
        private readonly IClienteApp _usuarioApp;

        public ClienteController(IContatosApp contatosApp, IClienteApp usuarioApp) // : base(usuarioApp)
        {
            this._contatosApp = contatosApp;
            this._usuarioApp = usuarioApp;
        }

        string idfake = "0";
        int idfakeInt = 0;

        ClienteDTO usuario = new ClienteDTO();

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> CadastroCliente(string id = "")
        {
            ClienteDTO usuario = new ClienteDTO();


            usuario.Email = idfake;
            usuario.IdCliente = idfakeInt;

            var user = await _usuarioApp.BuscarPorId(idfakeInt);

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
        public async Task<IActionResult> CadastroClienteByEstudio(int id = 0)
        {
            usuario = await _usuarioApp.GetClienteById(id);

            return View(usuario);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroClienteByTatuador(int id = 0)
        {
            usuario = await _usuarioApp.GetClienteById(id);

            return View(usuario);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> BuscaContatos(string pesquisa = "")
        {

            var contatos = await _contatosApp.GetContatosByIdEstudio(idfakeInt); // Chama Lista de Contatos

            IList<ClienteDTO> usuarios = new List<ClienteDTO>();

            foreach (var contato in contatos)
            {
                if (contato != null)
                {
                    usuarios.Add(await _usuarioApp.GetClienteById(contato.IdCliente)); // Adiciona na lista dados usuários que estão nos contatos
                }
            }

            if (!string.IsNullOrEmpty(pesquisa)) // Busca Usuários por nome pesquisado
            {
                usuarios = usuarios.Where(u => u.PrimeiroNome.Contains(pesquisa.Trim())).ToList();
            }

            return Ok(usuarios);

            //return View(new BuscaClientesViewModel(usuarios, pesquisa));
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastrarContatobyCpf(string ContatobyCpf = "")
        {
            usuario = await _usuarioApp.GetClienteByCpf(ContatobyCpf);

            if (usuario != null)
            {
                await _contatosApp.InsertByIds(usuario.Id, idfakeInt); // Insere Dados em Contatos
            }

            return RedirectToAction("BuscaContatos");
        }

        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> InserirDadosCliente(ClienteDTO CadastroCliente)
        {
            if (ModelState.IsValid) // verifica o estado do modelo, se é valido ou invalido
            {
                CadastroCliente.Telefone = CadastroCliente.Telefone.Replace(".", "").Replace("-", "");

                if (!String.IsNullOrEmpty(CadastroCliente.CPF))
                {
                    CadastroCliente.CPF = CadastroCliente.CPF.Replace(".", "").Replace("-", "");
                }

                if (!String.IsNullOrEmpty(CadastroCliente.OutroTelefone))
                {
                    CadastroCliente.OutroTelefone = CadastroCliente.OutroTelefone.Replace(".", "").Replace("-", "");
                }

                await _usuarioApp.UpdateByIdCliente(CadastroCliente);

                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("CadastroCliente");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosClienteByEstudio(ClienteDTO CadastroCliente)
        {

            if (!string.IsNullOrEmpty(CadastroCliente.Telefone))
            {
                CadastroCliente.Telefone = CadastroCliente.Telefone.Replace(".", "").Replace("-", "");
            }

            if (!string.IsNullOrEmpty(CadastroCliente.CPF))
            {
                CadastroCliente.CPF = CadastroCliente.CPF.Replace(".", "").Replace("-", "");

                var cpf = await _usuarioApp.GetClienteByCpf(CadastroCliente.CPF);

                if (cpf != null)
                {
                    CadastroCliente.IdCliente = cpf.IdCliente;  // CadastroCliente.Id = cpf.Id;
                }
            }

            if (!string.IsNullOrEmpty(CadastroCliente.OutroTelefone))
            {
                CadastroCliente.OutroTelefone = CadastroCliente.OutroTelefone.Replace(".", "").Replace("-", "");
            }
          
            await _usuarioApp.Alterar(CadastroCliente); // Atualiza ou Insere novo usuário

            await _contatosApp.InsertByIds(CadastroCliente.Id, idfakeInt); // Insere Dados em Contatos

            return RedirectToAction("BuscaContatos"); // volta para tela de cadastro

        }

        public async Task<IActionResult> DeletarCliente(int id) // Possivel de exclusão
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _usuarioApp.Excluir(id); // Deleta Usuário na tabela Cliente

            return RedirectToAction("BuscaClientes", "Cliente");

        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> RemoverContato(int id)
        {
            await _contatosApp.RemoverContato(id, idfakeInt); // Insere Dados em Contatos

            return RedirectToAction("BuscaContatos", "Cliente");
        }

        [HttpGet]
        public async Task<IActionResult> ValidarCpf(string cpfCliente)
        {
            if (String.IsNullOrEmpty(cpfCliente))
            {
                return Json("False");
            }

            if (ModelState.IsValid)
            {
                cpfCliente = cpfCliente.Replace(".", "").Replace("-", "");

                var usuarioByCpf = await _usuarioApp.GetClienteByCpf(cpfCliente);

                if (usuarioByCpf != null)
                {
                    var idCliente = idfakeInt;

                    if (usuarioByCpf.IdCliente != 0 && usuarioByCpf.IdCliente != 0)
                    {
                        if (idCliente != usuarioByCpf.IdCliente)
                        {
                            return Json("True"); // "Cpf Já está Cadastrado em algum IdCliente"
                        }
                    }
                    else
                    {
                        if (await _usuarioApp.BuscarPorId(idCliente) == null)
                        {
                            usuarioByCpf.IdCliente = idCliente;
                            await _usuarioApp.UpdateByCpf(usuarioByCpf);
                        }
                        else
                        {
                            return Json("TrueFalse"); // "IdCliente Já está cadastrado em algum Cpf"
                        }
                    }
                }
            }


            return Json("False");
        }

        [HttpGet]
        public async Task<IActionResult> ValidarEmail(string emailCliente)
        {
            if (string.IsNullOrEmpty(emailCliente))
            {
                return Json("False");
            }

            if (ModelState.IsValid)
            {
                var usuarioByEmail = await _usuarioApp.GetClienteByEmail(emailCliente);

                if (usuarioByEmail != null)
                {
                    var idCliente = idfakeInt;

                    if (usuarioByEmail.Email != null && usuarioByEmail.Email != "")
                    {
                        if (idCliente != usuarioByEmail.IdCliente)
                        {
                            return Json("True"); // "Email Já está Cadastrado em algum IdCliente"
                        }
                    }
                }
            }
            return Json("False");
        }
    }
}