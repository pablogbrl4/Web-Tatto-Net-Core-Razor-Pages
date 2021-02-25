using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProjectTemplate.Application.DTOs
{
    public class TatuadorDTO : BaseEntidadeDTO
    {
        public TatuadorDTO()
        {

        }

        [Required]
        public int IdTatuador { get; set; }

        [Required(ErrorMessage = "Nome De Usuário é obrigatório")]
        public string NomeDeUsuario { get; set; }

        // Dados Tatuador
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage = "PrimeiroNome é obrigatório")]
        public string PrimeiroNome { get; set; } = "";

        [Required(ErrorMessage = "Sobrenome Completo é obrigatório")]
        public string SobrenomeCompleto { get; set; } = "";

        [Required(ErrorMessage = "Sexo é obrigatório")]
        public string Sexo { get; set; } = "";

        // Redes Sociais:
        public string Instagram { get; set; } = "";
        public string Facebook { get; set; } = "";
        public string Twitter { get; set; } = "";
        public string LinkedIn { get; set; } = "";
        public string YouTube { get; set; } = "";
        public string WhatsApp { get; set; } = "";

        // Texto Bibliografico Tatuador
        public string TextoBibliografico { get; set; } = "";

        // Dados Pessoais Tatuador
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; } = "";

        //[Required(ErrorMessage = "OutroTelefone é obrigatório")]
        public string OutroTelefone { get; set; } = "";

        //[Required(ErrorMessage = "CPF é obrigatório")]
        public string CPF { get; set; } = "";

        [Required(ErrorMessage = "Data de Nascimento é obrigatório")]
        public string DataDeNascimento { get; set; } = "";
      
        internal void Update(TatuadorDTO novoCadastro) // Atualizar cadastro do Tatuador
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


        [NotMapped]
        protected IList<AgendaDTO> Agenda { get; set; }

        [NotMapped]
        protected IList<FotoTattoDTO> FotoTatto { get; set; }

        [NotMapped]
        protected IList<Estudio_TatuadorDTO> EstudioTatuador { get; set; }

    }
}
