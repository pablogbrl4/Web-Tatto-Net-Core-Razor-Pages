using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Entities.ViewModels
{
    public class BuscaClientesViewModel // fornece os dados necessários para a View
    {
        // O ViewModel permite fornecer como modelo à View uma classe que contenha todas as informações de que ela precisa, sem modificarmos as entidades do modelo da aplicação.
        public BuscaClientesViewModel(IList<Cliente> usuarios, string pesquisa)
        {
            Clientes = usuarios;
            Pesquisa = pesquisa;
        }

        public IList<Cliente> Clientes { get; }
        public string Pesquisa { get; set; }

        public Cliente Cliente { get; set; }

    }
}
