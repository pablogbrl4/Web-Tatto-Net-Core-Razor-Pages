using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities
{
    public class Tatuador : BaseModel
    {
        public Tatuador()
        {

        }


        public int IdTatuador { get; set; }
        public string NomeDeUsuario { get; set; }    
        public string PrimeiroNome { get; set; } 
        public string SobrenomeCompleto { get; set; } 
        public string Sexo { get; set; } 

        // Redes Sociais:
        public string Instagram { get; set; } 
        public string Facebook { get; set; } 
        public string Twitter { get; set; } 
        public string LinkedIn { get; set; } 
        public string YouTube { get; set; } 
        public string WhatsApp { get; set; } 

        // Texto Bibliografico Tatuador
        public string TextoBibliografico { get; set; } 
        public string Email { get; set; } 
        public string Telefone { get; set; } 
        public string OutroTelefone { get; set; } 
        public string CPF { get; set; } 
        public string DataDeNascimento { get; set; }

        [NotMapped]
        public IList<Agenda> Agenda { get; set; }

        [NotMapped]
        public IList<FotoTatto> FotoTatto { get; set; }

        [NotMapped]
        public IList<Estudio_Tatuador> EstudioTatuador { get; set; }

        public void Update(Tatuador novoCadastro) 
        {
            this.PrimeiroNome = novoCadastro.PrimeiroNome;
            this.SobrenomeCompleto = novoCadastro.SobrenomeCompleto;
            this.Sexo = novoCadastro.Sexo;

            this.NomeDeUsuario = novoCadastro.NomeDeUsuario;

            this.Instagram = novoCadastro.Instagram;
            this.Facebook = novoCadastro.Facebook;
            this.Twitter = novoCadastro.Twitter;
            this.LinkedIn = novoCadastro.LinkedIn;
            this.YouTube = novoCadastro.YouTube;
            this.WhatsApp = novoCadastro.WhatsApp;
            this.TextoBibliografico = novoCadastro.TextoBibliografico;

            this.Email = novoCadastro.Email;
            this.Telefone = novoCadastro.Telefone;
            this.OutroTelefone = novoCadastro.OutroTelefone;
            this.CPF = novoCadastro.CPF;
            this.DataDeNascimento = novoCadastro.DataDeNascimento;
        }
    }
}
