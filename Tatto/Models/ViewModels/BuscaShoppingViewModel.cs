using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tatto.Models.ViewModels
{
    public class BuscaShoppingViewModel // fornece os dados necessários para a View
    {
        // O ViewModel permite fornecer como modelo à View uma classe que contenha todas as informações de que ela precisa, sem modificarmos as entidades do modelo da aplicação.
        public BuscaShoppingViewModel(IList<Shopping> shoppings, string pesquisa)
        {
            Shoppings = shoppings;
            Pesquisa = pesquisa;
        }

        public IList<Shopping> Shoppings { get; }
        public string Pesquisa { get; set; }

        public Shopping Shopping { get; set; }

    }
}
