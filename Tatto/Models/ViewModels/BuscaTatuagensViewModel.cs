using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tatto.Models.ViewModels
{
    public class BuscaTatuagensViewModel // fornece os dados necessários para a View
    {
        // O ViewModel permite fornecer como modelo à View uma classe que contenha todas as informações de que ela precisa, sem modificarmos as entidades do modelo da aplicação.
        public BuscaTatuagensViewModel(IList<FotoTatto> tatuagens)
        {
            Tatuagens = tatuagens;
        }

        public BuscaTatuagensViewModel(IList<FotoTatto> tatuagens, string estilo, string parteCorpo)
        {
            Tatuagens = tatuagens;
            Tatuagem.EstiloTatto = estilo;
            Tatuagem.ParteDoCorpo = parteCorpo;
        }

        public BuscaTatuagensViewModel(IList<FotoTatto> tatuagens, string estilo, string parteCorpo, string genero = "", string cor = "")
        {
            Tatuagens = tatuagens;
            Tatuagem.EstiloTatto = estilo;
            Tatuagem.ParteDoCorpo = parteCorpo;
            Tatuagem.Genero = genero;
            Tatuagem.Cor = cor;
        }

        public IList<FotoTatto> Tatuagens { get; }

        public FotoTatto Tatuagem { get; set; } = new FotoTatto();

    }
}