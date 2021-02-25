using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tatto.Models.ViewModels
{
    public class BuscaUsuariosViewModel // fornece os dados necessários para a View
    {
        // O ViewModel permite fornecer como modelo à View uma classe que contenha todas as informações de que ela precisa, sem modificarmos as entidades do modelo da aplicação.
        public BuscaUsuariosViewModel(IList<Usuario> usuarios, string pesquisa)
        {
            Usuarios = usuarios;
            Pesquisa = pesquisa;
        }

        public IList<Usuario> Usuarios { get; }
        public string Pesquisa { get; set; }

        public Usuario Usuario { get; set; }

    }
}
