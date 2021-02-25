using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProjectTemplate.Domain.Entities
{
    public class Estudio : BaseModel
    {
        public Estudio() {}

        //[NotMapped]
        //public IList<Depoimentos> Depoimentos { get; set; } = new List<Depoimentos>();

        //[NotMapped]
        //public IList<FotoTatto> FotosTattos { get; set; } = new List<FotoTatto>();

        //[NotMapped]
        //public FotoTatto FotoTatto { get; set; } = new FotoTatto();

        //[NotMapped]
        //public IList<FotosEstudio> FotosEstudio { get; set; } = new List<FotosEstudio>();

        //[NotMapped]
        //public IList<Shopping> Shopping { get; set; } = new List<Shopping>();

        //[NotMapped]
        //public IList<Estudio_Tatuador> EstudioTatuador { get; set; } = new List<Estudio_Tatuador>();

        //[NotMapped]
        //public IList<HorarioDeFuncionamentoEstudio> HorarioDeFuncionamentoEstudio { get; set; } = new List<HorarioDeFuncionamentoEstudio>();

        //[NotMapped]
        //public IList<Contatos> Contatos { get; set; } = new List<Contatos>();

        //[NotMapped]
        //public IList<Agenda> Agenda { get; set; } = new List<Agenda>();

        public void Update(Estudio novoCadastro) 
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

        public int IdEstudio { get; set; }
        public string NomeDeUsuario { get; set; }
        public string NomeEstudio { get; set; } 
        public string Email { get; set; }  
        public string Telefone { get; set; }  
        public string OutroTelefone { get; set; }  
        public string CNPJ { get; set; }  
        public string DatadeFundação { get; set; }  


        // Redes Sociais do Estudio:
        public string Instagram { get; set; }  
        public string Facebook { get; set; }  
        public string Twitter { get; set; }  
        public string LinkedIn { get; set; }  
        public string YouTube { get; set; }  
        public string WhatsApp { get; set; }  


        // Texto Bibliografico Estudio
        public string TextoBibliografico { get; set; }  
        public string FraseImpactante { get; set; }  


        // Endereço do Estudio
        public string CEP { get; set; }  
        public string Endereco { get; set; }  
        public string Numero { get; set; }  
        public string Bairro { get; set; }  
        public string Complemento { get; set; }  
        public string Cidade { get; set; }  
        public string UF { get; set; }


        [NotMapped]
        public IList<HorarioDeFuncionamentoEstudio> HorarioDeFuncionamentoEstudio { get; set; }

        [NotMapped]
        public IList<Agenda> Agenda { get; set; }

        [NotMapped]
        public IList<FotoTatto> FotoTatto { get; set; }

        [NotMapped]
        public IList<Shopping> Shopping { get; set; }

        [NotMapped]
        public IList<Estudio_Tatuador> EstudioTatuador { get; set; }

        [NotMapped]
        public IList<Contatos> Contatos { get; set; } 
    }
}
