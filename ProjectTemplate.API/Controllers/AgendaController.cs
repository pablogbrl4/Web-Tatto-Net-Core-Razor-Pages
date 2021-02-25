using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ProjectTemplate.Application.Interfaces;


namespace ProjectTemplate.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : Controller // : CoreController<Agenda, AgendaDTO>
    {
        protected readonly IAgendaApp _agendaApp;

        //private readonly IEstudioApp _estudioApp;
        //private readonly ITatuadorApp _tatuadorApp;

        //private readonly IContatosApp _contatosApp;
        //private readonly IEstudio_TatuadorApp _estudio_TatuadorApp;

        //private readonly IClienteApp _usuarioApp;

        //string  idfake = "0";

        public AgendaController(IAgendaApp agendaApp) // : base(agendaApp)
        {
            _agendaApp = agendaApp;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var list = await _agendaApp.BuscarTodos();
                return new OkObjectResult(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //public AgendaController(IAgendaApp agendaApp,
        //    IEstudioApp estudioApp, ITatuadorApp tatuadorApp, IContatosApp contatosApp,
        //    IEstudio_TatuadorApp estudio_TatuadorApp, IClienteApp usuarioApp) : base(agendaApp)
        //{
        //    this._agendaApp = agendaApp;

        //    this._estudio_TatuadorApp = estudio_TatuadorApp;
        //    this._contatosApp = contatosApp;

        //    this._estudioApp = estudioApp;
        //    this._tatuadorApp = tatuadorApp;
        //    this._usuarioApp = usuarioApp;

        //}

        //AgendaDTO agenda = new AgendaDTO();

        //[Authorize(Roles = "Cliente")]
        //public async Task<IActionResult> AgendaCliente()
        //{

        //    var usuario = await _usuarioApp.GetClienteByIdCliente(idfake);
        //    agenda.IdCliente = usuario.Id;

        //    var agendas = await _agendaApp.GetAgendasByIdCliente(agenda.IdCliente);

        //    for (int i = 0; i < agendas.Count; i++)
        //    {
        //        agendas[i].Cliente = await _usuarioApp.GetClienteById(agendas[i].IdCliente);
        //        agendas[i].Estudio = await _estudioApp.GetEstudioById(agendas[i].IdEstudio);
        //        agendas[i].Tatuador.Add(await _tatuadorApp.GetTatuadorById(agendas[i].IdTatuador));
        //    }

        //    agendas = agendas.OrderByDescending(o => o.DataMarcação).ToList();

        //    return Ok(agendas);

        //   //  return View(new BuscaAgendaViewModel(agendas));
        //}

        //[Authorize(Roles = "Tatuador")]
        //public async Task<IActionResult> AgendaTatuador()
        //{

        //    var tatuador = await _tatuadorApp.GetTatuadorById(idfake);

        //    tatuador.Agenda = await _agendaApp.GetAgendasByIdTatuador(tatuador.IdTatuador);

        //    for (int i = 0; i < tatuador.Agenda.Count; i++)
        //    {
        //        tatuador.Agenda[i].Cliente = await _usuarioApp.GetClienteById(tatuador.Agenda[i].IdCliente);
        //        tatuador.Agenda[i].Estudio = await _estudioApp.GetEstudioById(tatuador.Agenda[i].IdEstudio);
        //        tatuador.Agenda[i].Tatuador.Add(await _tatuadorApp.GetTatuadorById(tatuador.Agenda[i].IdTatuador));
        //    }

        //    tatuador.Agenda = tatuador.Agenda.OrderByDescending(o => o.DataMarcação).ToList();


        //    return View(tatuador);
        //}

        //[Authorize(Roles = "Cliente")]
        //public async Task<IActionResult> DesmacarAgenda(int id)
        //{
        //    agenda = _agendaApp.GetAgendaByIdAgenda(id);
        //    agenda.Ativo = false;

        //    await _agendaApp.Update(agenda);

        //    return RedirectToAction("AgendaCliente", "Agenda");
        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> DesmacarAgendaByEstudio(int id)
        //{
        //    agenda = _agendaApp.GetAgendaByIdAgenda(id);
        //    agenda.Ativo = false;

        //    await _agendaApp.Update(agenda);

        //    return RedirectToAction("HomeEstudio", "Estudio");
        //}

        //[Authorize(Roles = "Cliente")]
        //public async Task<IActionResult> CadastroAgenda(string id = "")
        //{
        //    var idEstudio = await _estudioApp.GetIdEstudioByNomeCliente(id);

        //    agenda.Estudio = await _estudioApp.GetEstudioById(idEstudio);

        //    var IdsEstudiosTatuadores = await _estudio_TatuadorApp.GetIdsByIdEstudio(idEstudio);

        //    foreach (var item in IdsEstudiosTatuadores)
        //    {
        //        if (item.IdTatuador != null)
        //        {
        //            agenda.Tatuador.Add(await _tatuadorApp.GetTatuadorById(item.IdTatuador));
        //        }
        //    }

        //    var usuario = await _usuarioApp.GetClienteByIdCliente(idfake);
        //    agenda.IdCliente = usuario.Id;
        //    agenda.IdEstudio = idEstudio;

        //    return View(agenda);

        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> CadastroAgendaByEstudio()
        //{
        //    agenda.Estudio = await _estudioApp.GetEstudioById(idfake);
        //    agenda.IdEstudio = agenda.Estudio.IdEstudio;

        //    var IdsEstudiosTatuadores = await _estudio_TatuadorApp.GetIdsByIdEstudio(agenda.Estudio.IdEstudio);

        //    foreach (var item in IdsEstudiosTatuadores)
        //    {
        //        if (item.IdTatuador != null)
        //        {
        //            agenda.Tatuador.Add(await _tatuadorApp.GetTatuadorById(item.IdTatuador));
        //        }
        //    }

        //    var IdsContatos = await _contatosApp.GetContatosByIdEstudio(agenda.Estudio.IdEstudio);

        //    foreach (var item in IdsContatos)
        //    {
        //        if (item.IdCliente != 0)
        //        {
        //            agenda.Clientes.Add(await _usuarioApp.GetClienteById(item.IdCliente));
        //        }
        //    }

        //    return View(agenda);

        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> EditarAgenda(int id)
        //{

        //    agenda = _agendaApp.GetAgendaByIdAgenda((id));

        //    var IdsEstudiosTatuadores = await _estudio_TatuadorApp.GetIdsByIdEstudio(agenda.IdEstudio);

        //    foreach (var item in IdsEstudiosTatuadores)
        //    {
        //        if (item.IdTatuador != null)
        //        {
        //            agenda.Tatuador.Add(await _tatuadorApp.GetTatuadorById(item.IdTatuador));
        //        }
        //    }

        //    agenda.Cliente = await _usuarioApp.GetClienteById(agenda.IdCliente);

        //    return View(agenda);

        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> DeletarAgenda(int id)
        //{
        //    await _agendaApp.Delete(id);

        //    return RedirectToAction("HomeEstudio", "Estudio");

        //}

        //[Authorize(Roles = "Cliente")]
        //public async Task<IActionResult> DeletarAgendaByCliente(int id)
        //{
        //    await _agendaApp.Delete(id);

        //    return RedirectToAction("AgendaCliente", "Agenda");

        //}

        //[Authorize(Roles = "Cliente")]
        //public async Task<IActionResult> InserirDadosAgenda(AgendaDTO agenda)
        //{
        //    agenda.Ativo = true;
        //    await _agendaApp.Update(agenda);

        //    var usuario = await _usuarioApp.GetClienteById(agenda.IdCliente);
        //    var parsedDate = DateTime.Parse(usuario.DataDeNascimento);
        //    var idade = DateTime.Now - parsedDate;

        //    if ((idade.Days / 360) < 18)
        //    {
        //       return RedirectToAction("ContratoMenor", "Agenda", agenda);
        //    }

        //    return RedirectToAction("AgendaCliente", "Agenda");

        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> InserirDadosAgendaByEstudio(AgendaDTO cadastroAgenda)
        //{

        //    cadastroAgenda.Ativo = true;

        //    await _agendaApp.Update(cadastroAgenda);

        //    return RedirectToAction("HomeEstudio", "Estudio");

        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> AlterarDadosAgenda(AgendaDTO agenda)
        //{
        //    agenda.Ativo = true;

        //    await _agendaApp.Update(agenda);

        //    return RedirectToAction("HomeEstudio", "Estudio");

        //}

        //[Authorize(Roles = "Cliente")]
        //public async Task<IActionResult> ContratoMenor(AgendaDTO agenda)
        //{
        //    agenda.Estudio = await _estudioApp.GetEstudioById(agenda.IdEstudio);
        //    agenda.Cliente = await _usuarioApp.GetClienteById(agenda.IdCliente);

        //    return View(agenda);
        //}

        //[Authorize(Roles = "Estudio")]
        //public async Task<IActionResult> ContratoMenorByEstudio(int id)
        //{
        //    agenda.Estudio = await _estudioApp.GetEstudioById(idfake);
        //    agenda.Cliente = await _usuarioApp.GetClienteById(id);

        //    return View("ContratoMenor", agenda);
        //}

    }
}
