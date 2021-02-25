using ProjectTemplate.Application.DTOs;
using System.Collections.Generic;

namespace ProjectTemplate.Application.DTOs.ViewModels
{
    public class BuscaEstudioViewModelDTO
    {

        public BuscaEstudioViewModelDTO(IList<EstudioDTO> estudios)
        {
            Estudios = estudios;
        }

        public BuscaEstudioViewModelDTO(IList<EstudioDTO> estudios, string pesquisa)
        {
            Estudios = estudios;
            Pesquisa = pesquisa;
        }

        public BuscaEstudioViewModelDTO(IList<EstudioDTO> estudios, IList<string> bairros)
        {
            Estudios = estudios;
            Bairros = bairros;
        }

        public IList<EstudioDTO> Estudios { get; }
        public string Pesquisa { get; set; }
        public EstudioDTO Estudio { get; set; }

        public IList<string> Bairros { get; }
    }
}
