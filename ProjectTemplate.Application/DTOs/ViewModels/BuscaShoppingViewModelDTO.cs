using ProjectTemplate.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.DTOs.ViewModels
{
    public class BuscaShoppingViewModelDTO // fornece os dados necessários para a View
    {
        // O ViewModel permite fornecer como modelo à View uma classe que contenha todas as informações de que ela precisa, sem modificarmos as entidades do modelo da aplicação.
        public BuscaShoppingViewModelDTO(IList<ShoppingDTO> shoppings, string pesquisa)
        {
            Shoppings = shoppings;
            Pesquisa = pesquisa;
        }

        public IList<ShoppingDTO> Shoppings { get; }
        public string Pesquisa { get; set; }

        public ShoppingDTO Shopping { get; set; }

    }
}
