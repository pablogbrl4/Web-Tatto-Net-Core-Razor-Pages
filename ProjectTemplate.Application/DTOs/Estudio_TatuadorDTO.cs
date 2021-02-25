using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Application.DTOs
{
    public class Estudio_TatuadorDTO : BaseEntidadeDTO
    {
        //[ForeignKey("IdEstudio")]
        [Required]
        public int IdEstudio { get; set; }

        //[ForeignKey("IdTatuador")]
        [Required]
        public int IdTatuador { get; set; }

        [NotMapped]
        public virtual TatuadorDTO Tatuador { get; set; } = new TatuadorDTO();

        [NotMapped]
        public IList<TatuadorDTO> Tatuadores { get; set; } = new List<TatuadorDTO>();

        [NotMapped]
        public virtual EstudioDTO Estudio { get; set; } = new EstudioDTO();

        [NotMapped]
        public IList<EstudioDTO> Estudios { get; set; } = new List<EstudioDTO>();
    }
}
