using System.Collections.Generic;

namespace ProjectTemplate.Domain.Entities.ViewModels
{
    public class BuscaEstudioViewModel
    {

        public BuscaEstudioViewModel(IList<Estudio> estudios)
        {
            Estudios = estudios;
        }

        public BuscaEstudioViewModel(IList<Estudio> estudios, string pesquisa)
        {
            Estudios = estudios;
            Pesquisa = pesquisa;
        }

        public BuscaEstudioViewModel(IList<Estudio> estudios, IList<string> bairros)
        {
            Estudios = estudios;
            Bairros = bairros;
        }

        public IList<Estudio> Estudios { get; }
        public string Pesquisa { get; set; }
        public Estudio Estudio { get; set; }

        public IList<string> Bairros { get; }
    }
}
