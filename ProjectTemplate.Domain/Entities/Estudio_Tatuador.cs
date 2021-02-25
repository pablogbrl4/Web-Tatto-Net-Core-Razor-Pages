using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities
{
    public class Estudio_Tatuador  : BaseModel
    {
         
        public int IdEstudio { get; set; }
       
        public int IdTatuador { get; set; }

        [NotMapped]
        public virtual Tatuador Tatuador { get; set; } 

        [NotMapped]
        public Estudio Estudio { get; set; } 
    }
}
