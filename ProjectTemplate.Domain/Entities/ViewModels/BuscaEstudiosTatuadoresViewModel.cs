using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities.ViewModels
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

        [NotMapped]
        public IList<Estudio_Tatuador> EstudiosTatuadores { get; }

        [NotMapped]
        public Estudio_Tatuador EstudioTatuador { get; set; }

        [NotMapped]
        public IList<Tatuador> Tatuadores { get; }

        [NotMapped]
        public IList<string> Bairros { get; }

    }
}
