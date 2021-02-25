using System.Collections.Generic;

namespace Tatto.Models.ViewModels
{
    public class BuscaEstudiosTatuadoresViewModel
    {
        public BuscaEstudiosTatuadoresViewModel(IList<Estudio_Tatuador> estudioTatuador, string pesquisa)
        {
            Pesquisa = pesquisa;
            EstudiosTatuadores = estudioTatuador;
        }

        public BuscaEstudiosTatuadoresViewModel(IList<Tatuador> tatuadores, IList<string> bairros)
        {
            Tatuadores = tatuadores;
            Bairros = bairros;
        }

        public string Pesquisa { get; set; }

        public IList<Estudio_Tatuador> EstudiosTatuadores { get; }
        public Estudio_Tatuador EstudioTatuador { get; set; }

        public IList<Tatuador> Tatuadores { get; }
        public IList<string> Bairros { get; }

    }
}
