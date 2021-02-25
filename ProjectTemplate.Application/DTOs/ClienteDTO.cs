using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Application.DTOs
{

    public class ClienteDTO : BaseEntidadeDTO
    {
        public ClienteDTO(){ }

        [Required]
        int TipoCliente { get; set; }

        public int IdCliente { get; set; }

        // Dados Usuário
        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage = "PrimeiroNome é obrigatório")]
        public string PrimeiroNome { get; set; } = "";

        [Required(ErrorMessage = "Sobrenome Completo é obrigatório")]
        public string SobrenomeCompleto { get; set; } = "";

        [Required(ErrorMessage = "Sexo é obrigatório")]
        public string Sexo { get; set; } = "";


        // Dados Pessoais Usuário
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


        // Endereço
        [Required(ErrorMessage = "CEP é obrigatório")]
        public string CEP { get; set; } = "";

        [Required(ErrorMessage = "Endereco é obrigatório")]
        public string Endereco { get; set; } = "";

        //[Required(ErrorMessage = "Numero é obrigatório")]
        public string Numero { get; set; } = "";

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; } = "";

        [Required(ErrorMessage = "Complemento é obrigatório")]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; } = "";

        [Required(ErrorMessage = "UF é obrigatório")]
        public string UF { get; set; } = "";
    
        internal void Update(ClienteDTO novoCadastro) // Atualizar cadastro do Usuário
        {
            this.PrimeiroNome = novoCadastro.PrimeiroNome;
            this.SobrenomeCompleto = novoCadastro.SobrenomeCompleto;
            this.Sexo = novoCadastro.Sexo;
            this.Email = novoCadastro.Email;
            this.Telefone = novoCadastro.Telefone;
            this.OutroTelefone = novoCadastro.OutroTelefone;
            this.CPF = novoCadastro.CPF;
            this.DataDeNascimento = novoCadastro.DataDeNascimento;
            this.CEP = novoCadastro.CEP;
            this.Endereco = novoCadastro.Endereco;
            this.Numero = novoCadastro.Numero;
            this.Bairro = novoCadastro.Bairro;
            this.Complemento = novoCadastro.Complemento;
            this.Cidade = novoCadastro.Cidade;
            this.UF = novoCadastro.UF;
        }
    }
}
