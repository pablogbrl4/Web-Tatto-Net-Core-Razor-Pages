using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Tatto.Models
{
    public class Estudio_Tatuador : BaseModel
    {
        //[ForeignKey("IdEstudio")]
        [Required]
        public string IdEstudio { get; set; }

        //[ForeignKey("IdTatuador")]
        [Required]
        public string IdTatuador { get; set; }

        [NotMapped]
        public virtual Tatuador Tatuador { get; set; } = new Tatuador();

        [NotMapped]
        public IList<Tatuador> Tatuadores { get; set; } = new List<Tatuador>();

        [NotMapped]
        public virtual Estudio Estudio { get; set; } = new Estudio();

        [NotMapped]
        public IList<Estudio> Estudios { get; set; } = new List<Estudio>();
    }
}
