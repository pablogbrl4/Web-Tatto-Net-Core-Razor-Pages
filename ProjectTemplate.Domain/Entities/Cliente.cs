using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities
{

    public class Cliente : BaseModel
    {
        public Cliente(){ }
     
        int TipoCliente { get; set; }
        public int IdCliente { get; set; }

        // Dados Usuário
        public string PrimeiroNome { get; set; }  
        public string SobrenomeCompleto { get; set; }  
        public string Sexo { get; set; }  


        // Dados Pessoais Usuário
        public string Email { get; set; }  
        public string Telefone { get; set; }  
        public string OutroTelefone { get; set; }  
        public string CPF { get; set; }  
        public string DataDeNascimento { get; set; }  


        // Endereço    
        public string CEP { get; set; }  
        public string Endereco { get; set; }  
        public string Numero { get; set; }  
        public string Bairro { get; set; }  
        public string Complemento { get; set; }  
        public string Cidade { get; set; }  
        public string UF { get; set; }

        [NotMapped]
        public IList<Agenda> Agenda { get; set; }

        [NotMapped]
        public IList<FotoTatto> FotoTatto { get; set; }

        [NotMapped]
        public IList<Contatos> Contatos { get; set; }

        public void Update(Cliente novoCadastro)
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
