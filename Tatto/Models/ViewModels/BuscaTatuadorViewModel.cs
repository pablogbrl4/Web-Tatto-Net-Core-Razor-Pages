using System.Collections.Generic;

namespace Tatto.Models.ViewModels
{
    public class BuscaTatuadorViewModel
    {
        public BuscaTatuadorViewModel(IList<Tatuador> tatuadores)
        {
            Tatuadores = tatuadores;
        }

        public IList<Tatuador> Tatuadores { get; }

        public Tatuador Tatuador { get; set; }
    }
}
