using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.DTOs.ViewModels
{
    public class BuscaClientesViewModelDTO // fornece os dados necessários para a View
    {
        // O ViewModel permite fornecer como modelo à View uma classe que contenha todas as informações de que ela precisa, sem modificarmos as entidades do modelo da aplicação.
        public BuscaClientesViewModelDTO(IList<ClienteDTO> usuarios, string pesquisa)
        {
            Clientes = usuarios;
            Pesquisa = pesquisa;
        }

        public IList<ClienteDTO> Clientes { get; }
        public string Pesquisa { get; set; }

        public ClienteDTO Cliente { get; set; }

    }
}
