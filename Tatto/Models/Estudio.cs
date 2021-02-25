using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Tatto.Models
{
    public class Estudio : BaseModel
    {
        public Estudio() {}

        [NotMapped]
        public IList<Depoimentos> Depoimentos { get; set; } = new List<Depoimentos>();

        [NotMapped]
        public IList<FotoTatto> FotosTattos { get; set; } = new List<FotoTatto>();

        [NotMapped]
        public FotoTatto FotoTatto { get; set; } = new FotoTatto();

        [NotMapped]
        public IList<FotosEstudio> FotosEstudio { get; set; } = new List<FotosEstudio>();

        [NotMapped]
        public IList<Shopping> Shopping { get; set; } = new List<Shopping>();

        [NotMapped]
        public IList<Estudio_Tatuador> EstudioTatuador { get; set; } = new List<Estudio_Tatuador>();

        [NotMapped]
        public IList<HorarioDeFuncionamentoEstudio> HorarioDeFuncionamentoEstudio { get; set; } = new List<HorarioDeFuncionamentoEstudio>();

        [NotMapped]
        public IList<Contatos> Contatos { get; set; } = new List<Contatos>();

        [NotMapped]
        public IList<Agenda> Agenda { get; set; } = new List<Agenda>();

        internal void Update(Estudio novoCadastro) // Atualizar cadastro do Tatuador
        {
            this.NomeEstudio = novoCadastro.NomeEstudio;
            this.NomeDeUsuario = novoCadastro.NomeDeUsuario;

            this.Instagram = novoCadastro.Instagram;
            this.Facebook = novoCadastro.Facebook;
            this.Twitter = novoCadastro.Twitter;
            this.LinkedIn = novoCadastro.LinkedIn;
            this.YouTube = novoCadastro.YouTube;
            this.WhatsApp = novoCadastro.WhatsApp;
            this.TextoBibliografico = novoCadastro.TextoBibliografico; 
            this.FraseImpactante = novoCadastro.FraseImpactante;

            this.Email = novoCadastro.Email;
            this.Telefone = novoCadastro.Telefone;
            this.OutroTelefone = novoCadastro.OutroTelefone;
            this.CNPJ = novoCadastro.CNPJ;
            this.DatadeFundação = novoCadastro.DatadeFundação;

            this.CEP = novoCadastro.CEP;
            this.Endereco = novoCadastro.Endereco;
            this.Numero = novoCadastro.Numero;
            this.Bairro = novoCadastro.Bairro;
            this.Complemento = novoCadastro.Complemento;
            this.Cidade = novoCadastro.Cidade;
            this.UF = novoCadastro.UF;
        }

        // IdEstudio
        [Required]
        public string IdEstudio { get; set; }

        [Required(ErrorMessage = "Nome De Usuário é obrigatório")]
        public string NomeDeUsuario { get; set; }

        // Dados Estudio
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage = "PrimeiroNome é obrigatório")]
        public string NomeEstudio { get; set; } = "";

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; } = "";

        //[Required(ErrorMessage = "OutroTelefone é obrigatório")]
        public string OutroTelefone { get; set; } = "";

        //[Required(ErrorMessage = "CNPJ é obrigatório")]
        public string CNPJ { get; set; } = "";

        //[Required(ErrorMessage = "Data de Fundação é obrigatório")]
        public string DatadeFundação { get; set; } = "";


        // Redes Sociais do Estudio:
        public string Instagram { get; set; } = "";
        public string Facebook { get; set; } = "";
        public string Twitter { get; set; } = "";
        public string LinkedIn { get; set; } = "";
        public string YouTube { get; set; } = "";
        public string WhatsApp { get; set; } = "";


        // Texto Bibliografico Estudio
        public string TextoBibliografico { get; set; } = "";
        public string FraseImpactante { get; set; } = "";


        // Endereço do Estudio
        [Required(ErrorMessage = "CEP é obrigatório")]
        public string CEP { get; set; } = "";

        [Required(ErrorMessage = "Endereco é obrigatório")]
        public string Endereco { get; set; } = "";

        [Required(ErrorMessage = "Numero é obrigatório")]
        public string Numero { get; set; } = "";

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; } = "";

        [Required(ErrorMessage = "Complemento é obrigatório")]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; } = "";

        [Required(ErrorMessage = "UF é obrigatório")]
        public string UF { get; set; } = "";
    }
}
