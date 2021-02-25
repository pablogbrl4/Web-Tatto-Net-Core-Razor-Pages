using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.API.Controllers;
using ProjectTemplate.Domain.Interfaces.Repositories;

namespace Tatto.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : CoreController<Estudio, EstudioDTO>
    {

        private readonly IEstudioApp _estudioApp;

        private readonly IFotoTattoApp _fotoTattoApp;
        private readonly IFotosEstudioApp _fotosEstudioApp;
        private readonly IShoppingApp _shoppingApp;
        private readonly IHorarioDeFuncionamentoEstudioApp _horarioDeFuncionamentoEstudioApp;
        private readonly IEstudio_TatuadorApp _estudio_TatuadorApp;
        private readonly IDepoimentosApp _depoimentosApp;
        private readonly IAgendaApp _agendaApp;
        private readonly IContatosApp _contatosApp;
        private readonly ITatuadorApp _tatuadorApp;
        private readonly IClienteApp _usuarioApp;




        string idfake = "0";

        public EstudioController(IEstudioApp estudioApp) : base(estudioApp)
        {
            _estudioApp = estudioApp;
        }

        // EstudioDTO estudio = new EstudioDTO();

        //public EstudioController(IEstudioApp _estudioApp,

        //    IFotoTattoApp fotoTattoApp, IFotosEstudioApp fotosEstudioApp,
        //    IShoppingApp shoppingApp, IHorarioDeFuncionamentoEstudioApp horarioDeFuncionamentoEstudioApp,
        //    IDepoimentosApp depoimentosApp,
        //    IEstudio_TatuadorApp estudio_TatuadorApp, IAgendaApp agendaApp, IContatosApp contatosApp,
        //    IClienteApp usuarioApp, ITatuadorApp tatuadorApp)  : base(_estudioApp)

        //{
        //    this._estudioApp = _estudioApp;
        //    this._fotoTattoApp = fotoTattoApp;
        //    this._fotosEstudioApp = fotosEstudioApp;
        //    this._shoppingApp = shoppingApp;
        //    this._horarioDeFuncionamentoEstudioApp = horarioDeFuncionamentoEstudioApp;
        //    this._depoimentosApp = depoimentosApp;
        //    this._estudio_TatuadorApp = estudio_TatuadorApp;
        //    this._agendaApp = agendaApp;
        //    this._contatosApp = contatosApp;
        //    this._usuarioApp = usuarioApp;
        //    this._tatuadorApp = tatuadorApp;
        //}


        //// Público
        //public async Task<IActionResult> ListarEstudios(string id = "")
        //{
        //    return View(await _estudioApp.GetEstudiosByBairro(id));
        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> HomeEstudio()
        //{
        //    var tipoCliente = HomeController.getUserNow();


        //    estudio.Agenda = await _agendaApp.GetAgendasByIdEstudio(estudio.IdEstudio);

        //    for (int i = 0; i < estudio.Agenda.Count; i++)
        //    {
        //        estudio.Agenda[i].Cliente = await _usuarioApp.GetClienteById(estudio.Agenda[i].IdCliente);
        //        estudio.Agenda[i].Tatuador.Add(await _tatuadorApp.GetTatuadorById(estudio.Agenda[i].IdTatuador));
        //    }

        //    estudio.Agenda = estudio.Agenda.OrderByDescending(o => o.DataMarcação).ToList(); // Ordenar Lista

        //    estudio.Contatos = await _contatosApp.GetContatosByIdEstudio(estudio.IdEstudio);

        //    for (int i = 0; i < estudio.Contatos.Count; i++)
        //    {
        //        estudio.Contatos[i].Cliente = await _usuarioApp.GetClienteById(estudio.Contatos[i].IdCliente);

        //        var mes = Int32.Parse(estudio.Contatos[i].Cliente.DataDeNascimento.Substring(5, 2));
        //        var dia = Int32.Parse(estudio.Contatos[i].Cliente.DataDeNascimento.Substring(8, 2));

        //        if (mes == DateTime.Now.Month && dia == DateTime.Now.Day) // Aniversariantes do dia 
        //        {
        //            estudio.Contatos[i].Cliente.DataDeNascimento = "dia";
        //        }
        //        else if (mes == DateTime.Now.Month) // Aniversariantes do Mês 
        //        {
        //            estudio.Contatos[i].Cliente.DataDeNascimento = "mes";
        //        }
        //    }

        //    return View(estudio);
        //}

        //// Público
        //public async Task<IActionResult> ShoppingEstudio(string id = "")
        //{
        //    var idEstudio = await _estudioApp.GetIdEstudioByNomeCliente(id);

        //    estudio = await _estudioApp.GetEstudioById(idEstudio);

        //    estudio.HorarioDeFuncionamentoEstudio = await _horarioDeFuncionamentoEstudioApp.GetHorarioDeFuncionamentoEstudioByIdEstudio(estudio.IdEstudio);

        //    estudio.Shopping = await _shoppingApp.GetShoppingByIdEstudio(estudio.IdEstudio);

        //    for (int i = 0; i < estudio.Agenda.Count; i++)
        //    {
        //        estudio.Agenda[i].Tatuador.Add(await _tatuadorApp.GetTatuadorById(estudio.Agenda[i].IdTatuador));
        //    }

        //    return View(estudio);
        //}

        //// Público
        //public async Task<IActionResult> GaleriaEstudio(string id = "", string estilo = "", string parteCorpo = "")
        //{
        //    var idEstudio = await _estudioApp.GetIdEstudioByNomeCliente(id);

        //    estudio = await _estudioApp.GetEstudioById(idEstudio);

        //    estudio.HorarioDeFuncionamentoEstudio = await _horarioDeFuncionamentoEstudioApp.GetHorarioDeFuncionamentoEstudioByIdEstudio(estudio.IdEstudio);

        //    estudio.FotoTatto.EstiloTatto = estilo;
        //    estudio.FotoTatto.ParteDoCorpo = parteCorpo;

        //    estudio.FotosTattos = await _fotoTattoApp.GetFotosTattosByIdEstudio(idEstudio, estilo, parteCorpo);

        //    return View(estudio);
        //}

        //// Público
        //public async Task<IActionResult> DetalhesEstudio(string id = "")
        //{
        //    var idEstudio = await _estudioApp.GetIdEstudioByNomeCliente(id);

        //    estudio = await pegarDadosEstudio(idEstudio);

        //    estudio.FotosEstudio = await _fotosEstudioApp.GetFotosEstudioByIdEstudio(estudio.IdEstudio);

        //    estudio.Depoimentos = await _depoimentosApp.GetDepoimentosByIdEstudio(estudio.IdEstudio);

        //    estudio.EstudioTatuador = await _estudio_TatuadorApp.GetEstudioTatuadorByIdEstudio(estudio.IdEstudio);

        //    for (int i = 0; i < estudio.EstudioTatuador.Count; i++)
        //    {
        //        var tatuador = await _tatuadorApp.GetTatuadorById(estudio.EstudioTatuador[i].IdTatuador);

        //        if (tatuador != null)
        //        {
        //            estudio.EstudioTatuador[i].Tatuador = tatuador;
        //        }
        //        else
        //        {
        //            estudio.EstudioTatuador.Remove(estudio.EstudioTatuador[i]);
        //        }
        //    }

        //    estudio.HorarioDeFuncionamentoEstudio = await _horarioDeFuncionamentoEstudioApp.GetHorarioDeFuncionamentoEstudioByIdEstudio(estudio.IdEstudio);

        //    return View(estudio);
        //}

        //// Público
        //public async Task<IActionResult> DetalhesCliente(int id)
        //{

        //    estudio.Contatos = await _contatosApp.GetContatosByidClienteAndIdEstudio(id, estudio.IdEstudio);

        //    estudio.Contatos[0].Cliente = await _usuarioApp.GetClienteById(id);

        //    estudio.Agenda = await _agendaApp.GetAgendasByIdClienteAndCliente(id, estudio.IdEstudio);

        //    for (int i = 0; i < estudio.Agenda.Count; i++)
        //    {
        //        estudio.Agenda[i].Tatuador.Add(await _tatuadorApp.GetTatuadorById(estudio.Agenda[i].IdTatuador));
        //    }

        //    return View(estudio);
        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> CadastroEstudio(string id = "")
        //{
        //    estudio = await pegarDadosEstudio(id);
        //    estudio.HorarioDeFuncionamentoEstudio = await _horarioDeFuncionamentoEstudioApp.GetHorarioDeFuncionamentoEstudioByIdEstudio(estudio.IdEstudio);

        //    if (estudio.HorarioDeFuncionamentoEstudio.Count < 8)
        //    {
        //        string[] diaSemana = new string[] { "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sabado", "Domingo", "Feriado" };

        //        for (int i = 0; i < 8; i++)
        //        {
        //            estudio.HorarioDeFuncionamentoEstudio.Add(new HorarioDeFuncionamentoEstudioDTO(estudio.IdEstudio, diaSemana[i], "00:00", "00:00"));
        //        }

        //    }

        //    return View(estudio);
        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> InserirDadosEstudio(EstudioDTO estudio)
        //{

        //    if (!string.IsNullOrEmpty(estudio.CNPJ))
        //    {
        //        estudio.CNPJ = estudio.CNPJ.Replace(".", "").Replace("-", "");
        //    }

        //    estudio.Telefone = estudio.Telefone.Replace(".", "").Replace("-", "");

        //    if (!string.IsNullOrEmpty(estudio.OutroTelefone))
        //    {
        //        estudio.OutroTelefone = estudio.OutroTelefone.Replace(".", "").Replace("-", "");
        //    }


        //    await _horarioDeFuncionamentoEstudioApp.ApagarHorarios(estudio.IdEstudio);

        //    foreach (var horario in estudio.HorarioDeFuncionamentoEstudio)
        //    {
        //        await _horarioDeFuncionamentoEstudioApp.Insert(horario);
        //    }

        //    await _estudioApp.Update(estudio);

        //    return RedirectToAction("HomeEstudio");
        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> BuscaEstudio(string pesquisa = "")
        //{
        //    return View(await _estudioApp.GetEstudiosAsync(pesquisa));
        //}

        //[Authorize(Roles = "Estudio")]
        //private async Task<EstudioDTO> pegarDadosEstudio(int IdEstudio = "")
        //{

        //    var dadosEstudio = await _estudioApp.GetEstudioById(idfake);

        //    if (dadosEstudio != null)
        //    {
        //        estudio.NomeEstudio = dadosEstudio.NomeEstudio;
        //        estudio.NomeDeUsuario = dadosEstudio.NomeDeUsuario;

        //        estudio.Instagram = dadosEstudio.Instagram;
        //        estudio.Facebook = dadosEstudio.Facebook;
        //        estudio.Twitter = dadosEstudio.Twitter;
        //        estudio.LinkedIn = dadosEstudio.LinkedIn;
        //        estudio.YouTube = dadosEstudio.YouTube;
        //        estudio.WhatsApp = dadosEstudio.WhatsApp;
        //        estudio.TextoBibliografico = dadosEstudio.TextoBibliografico;
        //        estudio.FraseImpactante = dadosEstudio.FraseImpactante;

        //        estudio.Telefone = dadosEstudio.Telefone;
        //        estudio.OutroTelefone = dadosEstudio.OutroTelefone;
        //        estudio.CNPJ = dadosEstudio.CNPJ;
        //        estudio.DatadeFundacao = dadosEstudio.DatadeFundacao;
        //        estudio.CEP = dadosEstudio.CEP;
        //        estudio.Endereco = dadosEstudio.Endereco;
        //        estudio.Numero = dadosEstudio.Numero;
        //        estudio.Bairro = dadosEstudio.Bairro;
        //        estudio.Complemento = dadosEstudio.Complemento;
        //        estudio.Cidade = dadosEstudio.Cidade;
        //        estudio.UF = dadosEstudio.UF;
        //    }

        //    return estudio;
        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> ContratoMenor(string id = "")
        //{

        //    estudio = await _estudioApp.GetEstudioById(idfake);

        //    return View(estudio);
        //}

        //[HttpGet]
        //public async Task<IActionResult> ValidarEmail(string emailCliente)
        //{
        //    if (string.IsNullOrEmpty(emailCliente))
        //    {
        //        return Json("False");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        estudio = await _estudioApp.GetEstudioByEmail(emailCliente);

        //        if (estudio != null)
        //        {
        //            var idEstudio = idfake;

        //            if (!string.IsNullOrEmpty(estudio.Email))
        //            {
        //                if (idEstudio != estudio.IdEstudio)
        //                {
        //                    return Json("True"); // "Email Já está Cadastrado em algum IdCliente"
        //                }
        //            }
        //        }
        //    }
        //    return Json("False");
        //}
    }
}
