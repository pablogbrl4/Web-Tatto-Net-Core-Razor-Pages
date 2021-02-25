using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tatto.Areas.Identity.Data;
using Tatto.Models;
using Tatto.Repositories;

namespace Tatto.Controllers
{
    public class EstudioController : Controller
    {
        private readonly IEstudioRepository estudioRepository; // Consome Repositorios
        private readonly UserManager<AppIdentityUser> userManager; // injeção de dependencia identity

        private readonly IFotoTattoRepository fotoTattoRepository;
        private readonly IFotosEstudioRepository fotosEstudioRepository;
        private readonly IShoppingRepository shoppingRepository;
        private readonly IHorarioDeFuncionamentoEstudioRepository horarioDeFuncionamentoEstudioRepository;

        private readonly IDepoimentosRepository depoimentosRepository;

        private readonly IEstudio_TatuadorRepository estudioTatuadorRepository;
        private readonly IAgendaRepository agendaRepository;
        private readonly IContatosRepository contatosRepository;

        private readonly IUsuarioRepository usuarioRepository;
        private readonly ITatuadorRepository tatuadorRepository;


        Estudio estudio = new Estudio();
        AppIdentityUser userEstudio = new AppIdentityUser(); // acessar dados Estudio no identity;

        public EstudioController(IEstudioRepository estudioRepository, UserManager<AppIdentityUser> userManager,

            IFotoTattoRepository fotoTattoRepository, IFotosEstudioRepository fotosEstudioRepository,
            IShoppingRepository shoppingRepository, IHorarioDeFuncionamentoEstudioRepository horarioDeFuncionamentoEstudioRepository,

            IDepoimentosRepository depoimentosRepository,

            IEstudio_TatuadorRepository estudioTatuadorRepository, IAgendaRepository agendaRepository, IContatosRepository contatosRepository,

            IUsuarioRepository usuarioRepository, ITatuadorRepository tatuadorRepository)

        {
            this.estudioRepository = estudioRepository;
            this.userManager = userManager;

            this.fotoTattoRepository = fotoTattoRepository;
            this.fotosEstudioRepository = fotosEstudioRepository;
            this.shoppingRepository = shoppingRepository;
            this.horarioDeFuncionamentoEstudioRepository = horarioDeFuncionamentoEstudioRepository;

            this.depoimentosRepository = depoimentosRepository;

            this.estudioTatuadorRepository = estudioTatuadorRepository;
            this.agendaRepository = agendaRepository;
            this.contatosRepository = contatosRepository;

            this.usuarioRepository = usuarioRepository;
            this.tatuadorRepository = tatuadorRepository;
        }


        // Público
        public async Task<IActionResult> ListarEstudios(string id = "")
        {
            return View(await estudioRepository.GetEstudiosByBairro(id));
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> HomeEstudio()
        {
            var tipoUsuario = HomeController.getUserNow();

            estudio.IdEstudio = userManager.GetUserId(this.User);

            estudio.Agenda = await agendaRepository.GetAgendasByIdEstudio(estudio.IdEstudio);

            for (int i = 0; i < estudio.Agenda.Count; i++)
            {
                estudio.Agenda[i].Usuario = await usuarioRepository.GetUsuarioById(estudio.Agenda[i].IdUsuario);
                estudio.Agenda[i].Tatuador.Add(await tatuadorRepository.GetTatuadorById(estudio.Agenda[i].IdTatuador));
            }

            estudio.Agenda = estudio.Agenda.OrderByDescending(o => o.DataMarcação).ToList(); // Ordenar Lista

            estudio.Contatos = await contatosRepository.GetContatosByIdEstudio(estudio.IdEstudio);

            for (int i = 0; i < estudio.Contatos.Count; i++)
            {
                estudio.Contatos[i].Usuario = await usuarioRepository.GetUsuarioById(estudio.Contatos[i].IdUsuario);

                var mes = Int32.Parse(estudio.Contatos[i].Usuario.DataDeNascimento.Substring(5, 2));
                var dia = Int32.Parse(estudio.Contatos[i].Usuario.DataDeNascimento.Substring(8, 2));

                if (mes == DateTime.Now.Month && dia == DateTime.Now.Day) // Aniversariantes do dia 
                {
                    estudio.Contatos[i].Usuario.DataDeNascimento = "dia";
                }
                else if (mes == DateTime.Now.Month) // Aniversariantes do Mês 
                {
                    estudio.Contatos[i].Usuario.DataDeNascimento = "mes";
                }
            }

            return View(estudio);
        }

        // Público
        public async Task<IActionResult> ShoppingEstudio(string id = "")
        {
            var idEstudio = await estudioRepository.GetIdEstudioByNomeUsuario(id);

            estudio = await estudioRepository.GetEstudioById(idEstudio);

            estudio.HorarioDeFuncionamentoEstudio = await horarioDeFuncionamentoEstudioRepository.GetHorarioDeFuncionamentoEstudioByIdEstudio(estudio.IdEstudio);

            estudio.Shopping = await shoppingRepository.GetShoppingByIdEstudio(estudio.Id);

            for (int i = 0; i < estudio.Agenda.Count; i++)
            {
                estudio.Agenda[i].Tatuador.Add(await tatuadorRepository.GetTatuadorById(estudio.Agenda[i].IdTatuador));
            }

            return View(estudio);
        }

        // Público
        public async Task<IActionResult> GaleriaEstudio(string id = "", string estilo = "", string parteCorpo = "")
        {
            var idEstudio = await estudioRepository.GetIdEstudioByNomeUsuario(id);

            estudio = await estudioRepository.GetEstudioById(idEstudio);

            estudio.HorarioDeFuncionamentoEstudio = await horarioDeFuncionamentoEstudioRepository.GetHorarioDeFuncionamentoEstudioByIdEstudio(estudio.IdEstudio);

            estudio.FotoTatto.EstiloTatto = estilo;
            estudio.FotoTatto.ParteDoCorpo = parteCorpo;

            estudio.FotosTattos = await fotoTattoRepository.GetFotosTattosByIdEstudio(idEstudio, estilo, parteCorpo);

            return View(estudio);
        }

        // Público
        public async Task<IActionResult> DetalhesEstudio(string id = "")
        {
            var idEstudio = await estudioRepository.GetIdEstudioByNomeUsuario(id);

            estudio = await pegarDadosEstudio(idEstudio);

            estudio.FotosEstudio = await fotosEstudioRepository.GetFotosEstudioByIdEstudio(estudio.IdEstudio);

            estudio.Depoimentos = await depoimentosRepository.GetDepoimentosByIdEstudio(estudio.IdEstudio);

            estudio.EstudioTatuador = await estudioTatuadorRepository.GetEstudioTatuadorByIdEstudio(estudio.IdEstudio);

            for (int i = 0; i < estudio.EstudioTatuador.Count; i++)
            {
                var tatuador = await tatuadorRepository.GetTatuadorById(estudio.EstudioTatuador[i].IdTatuador);
                
                if (tatuador != null)
                {
                    estudio.EstudioTatuador[i].Tatuador = tatuador;
                }
                else
                {
                    estudio.EstudioTatuador.Remove(estudio.EstudioTatuador[i]);
                }
            }

            estudio.HorarioDeFuncionamentoEstudio = await horarioDeFuncionamentoEstudioRepository.GetHorarioDeFuncionamentoEstudioByIdEstudio(estudio.IdEstudio);

            return View(estudio);
        }

        // Público
        public async Task<IActionResult> DetalhesUsuario(int id)
        {
            estudio.IdEstudio = userManager.GetUserId(this.User);

            estudio.Contatos = await contatosRepository.GetContatosByidUsuarioAndIdEstudio(id, estudio.IdEstudio);

            estudio.Contatos[0].Usuario = await usuarioRepository.GetUsuarioById(id);

            estudio.Agenda = await agendaRepository.GetAgendasByIdUsuarioAndUsuario(id, estudio.IdEstudio);

            for (int i = 0; i < estudio.Agenda.Count; i++)
            {
                estudio.Agenda[i].Tatuador.Add(await tatuadorRepository.GetTatuadorById(estudio.Agenda[i].IdTatuador));
            }

            return View(estudio);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> CadastroEstudio(string id = "")
        {
            estudio = await pegarDadosEstudio(id);
            estudio.HorarioDeFuncionamentoEstudio = await horarioDeFuncionamentoEstudioRepository.GetHorarioDeFuncionamentoEstudioByIdEstudio(estudio.IdEstudio);

            if (estudio.HorarioDeFuncionamentoEstudio.Count < 8)
            {
                string[] diaSemana = new string[] { "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sabado", "Domingo", "Feriado" };

                for (int i = 0; i < 8; i++)
                {
                    estudio.HorarioDeFuncionamentoEstudio.Add(new HorarioDeFuncionamentoEstudio(estudio.IdEstudio, diaSemana[i], "00:00", "00:00"));
                }

            }

            return View(estudio);
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> InserirDadosEstudio(Estudio estudio)
        {
            userEstudio = await userManager.FindByIdAsync(estudio.IdEstudio);

            userEstudio.Email = estudio.Email;
            userEstudio.UserName = estudio.NomeEstudio;
            userEstudio.PhoneNumber = estudio.Telefone;

            if (!string.IsNullOrEmpty(estudio.CNPJ))
            {
                estudio.CNPJ = estudio.CNPJ.Replace(".", "").Replace("-", "");
            }
   
            estudio.Telefone = estudio.Telefone.Replace(".", "").Replace("-", "");

            if (!string.IsNullOrEmpty(estudio.OutroTelefone))
            {
                estudio.OutroTelefone = estudio.OutroTelefone.Replace(".", "").Replace("-", "");
            }

            await userManager.UpdateAsync(userEstudio);

            await horarioDeFuncionamentoEstudioRepository.ApagarHorarios(estudio.IdEstudio);

            foreach (var horario in estudio.HorarioDeFuncionamentoEstudio)
            {
                await horarioDeFuncionamentoEstudioRepository.Insert(horario);
            }

            await estudioRepository.Update(estudio);

            return RedirectToAction("HomeEstudio");
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> BuscaEstudio(string pesquisa = "")
        {
            return View(await estudioRepository.GetEstudiosAsync(pesquisa));
        }

        [Authorize(Roles = "Estudio")]
        private async Task<Estudio> pegarDadosEstudio(string IdEstudio = "")
        {
            if (!string.IsNullOrEmpty(IdEstudio))
            {
                userEstudio = await userManager.FindByIdAsync(IdEstudio);
            }
            else
            {
                userEstudio = await userManager.GetUserAsync(this.User);
            }

            //userEstudio = await userManager.FindByIdAsync(IdEstudio);

            estudio.Email = userEstudio.Email;
            estudio.IdEstudio = userEstudio.Id;

            var dadosEstudio = await estudioRepository.GetEstudioById(userEstudio.Id);

            if (dadosEstudio != null)
            {
                estudio.NomeEstudio = dadosEstudio.NomeEstudio;
                estudio.NomeDeUsuario = dadosEstudio.NomeDeUsuario;

                estudio.Instagram = dadosEstudio.Instagram;
                estudio.Facebook = dadosEstudio.Facebook;
                estudio.Twitter = dadosEstudio.Twitter;
                estudio.LinkedIn = dadosEstudio.LinkedIn;
                estudio.YouTube = dadosEstudio.YouTube;
                estudio.WhatsApp = dadosEstudio.WhatsApp;
                estudio.TextoBibliografico = dadosEstudio.TextoBibliografico;
                estudio.FraseImpactante = dadosEstudio.FraseImpactante;

                estudio.Telefone = dadosEstudio.Telefone;
                estudio.OutroTelefone = dadosEstudio.OutroTelefone;
                estudio.CNPJ = dadosEstudio.CNPJ;
                estudio.DatadeFundação = dadosEstudio.DatadeFundação;
                estudio.CEP = dadosEstudio.CEP;
                estudio.Endereco = dadosEstudio.Endereco;
                estudio.Numero = dadosEstudio.Numero;
                estudio.Bairro = dadosEstudio.Bairro;
                estudio.Complemento = dadosEstudio.Complemento;
                estudio.Cidade = dadosEstudio.Cidade;
                estudio.UF = dadosEstudio.UF;
            }

            return estudio;
        }

        [Authorize(Roles = "Estudio")]
        public async Task<IActionResult> ContratoMenor(string id = "")
        {
            if (id != "")
            {
                userEstudio = await userManager.FindByIdAsync(id);
            }
            else
            {
                userEstudio = await userManager.GetUserAsync(this.User);
            }

            estudio = await estudioRepository.GetEstudioById(userEstudio.Id);


            return View(estudio);
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
                estudio = await estudioRepository.GetEstudioByEmail(emailUsuario);

                if (estudio != null)
                {
                    var idEstudio = userManager.GetUserId(this.User);

                    if (!string.IsNullOrEmpty(estudio.Email))
                    {
                        if (idEstudio != estudio.IdEstudio)
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
