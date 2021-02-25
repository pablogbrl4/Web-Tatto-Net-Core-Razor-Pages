using ProjectTemplate.Application.DTOs;
using System.Collections.Generic;

namespace ProjectTemplate.Application.DTOs.ViewModels
{
    public class BuscaEstudiosTatuadoresViewModelDTO
    {
        public BuscaEstudiosTatuadoresViewModelDTO(IList<Estudio_TatuadorDTO> estudioTatuador, string pesquisa)
        {
            Pesquisa = pesquisa;
            EstudiosTatuadores = estudioTatuador;
        }

        public BuscaEstudiosTatuadoresViewModelDTO(IList<TatuadorDTO> tatuadores, IList<string> bairros)
        {
            Tatuadores = tatuadores;
            Bairros = bairros;
        }

        public string Pesquisa { get; set; }

        public IList<Estudio_TatuadorDTO> EstudiosTatuadores { get; }
        public Estudio_TatuadorDTO EstudioTatuador { get; set; }

        public IList<TatuadorDTO> Tatuadores { get; }
        public IList<string> Bairros { get; }

    }
}
