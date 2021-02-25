using System.Collections.Generic;

namespace ProjectTemplate.Application.DTOs.ViewModels
{
    public class BuscaTatuadorViewModelDTO
    {
        public BuscaTatuadorViewModelDTO(IList<TatuadorDTO> tatuadores)
        {
            Tatuadores = tatuadores;
        }

        public IList<TatuadorDTO> Tatuadores { get; }

        public TatuadorDTO Tatuador { get; set; }
    }
}
