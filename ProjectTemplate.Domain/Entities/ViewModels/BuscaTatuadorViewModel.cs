using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities.ViewModels
{
    public class BuscaTatuadorViewModel
    {
        public BuscaTatuadorViewModel(IList<Tatuador> tatuadores)
        {
            Tatuadores = tatuadores;
        }

        [NotMapped]
        public IList<Tatuador> Tatuadores { get; }

        [NotMapped]
        public Tatuador Tatuador { get; set; }
    }
}
