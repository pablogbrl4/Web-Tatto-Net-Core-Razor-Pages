using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.DTOs.ViewModels
{
    public class BuscaTatuagensViewModelDTO // fornece os dados necessários para a View
    {
        // O ViewModel permite fornecer como modelo à View uma classe que contenha todas as informações de que ela precisa, sem modificarmos as entidades do modelo da aplicação.
        public BuscaTatuagensViewModelDTO(IList<FotoTattoDTO> tatuagens)
        {
            Tatuagens = tatuagens;
        }

        public BuscaTatuagensViewModelDTO(IList<FotoTattoDTO> tatuagens, string estilo, string parteCorpo)
        {
            Tatuagens = tatuagens;
            Tatuagem.EstiloTatto = estilo;
            Tatuagem.ParteDoCorpo = parteCorpo;
        }

        public BuscaTatuagensViewModelDTO(IList<FotoTattoDTO> tatuagens, string estilo, string parteCorpo, string genero = "", string cor = "")
        {
            Tatuagens = tatuagens;
            Tatuagem.EstiloTatto = estilo;
            Tatuagem.ParteDoCorpo = parteCorpo;
            Tatuagem.Genero = genero;
            Tatuagem.Cor = cor;
        }

        public IList<FotoTattoDTO> Tatuagens { get; }

        public FotoTattoDTO Tatuagem { get; set; } = new FotoTattoDTO();

    }
}