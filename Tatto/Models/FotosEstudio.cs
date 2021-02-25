using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Tatto.Models
{
    public class FotosEstudio : BaseModel
    {
        public FotosEstudio()
        {
        }

        internal void Update(FotosEstudio foto)
        {
            this.IdEstudio = foto.IdEstudio;
            this.ImageName = foto.ImageName;
        }

        //[ForeignKey("IdEstudio")]
        [Required]
        public string IdEstudio { get; set; }

        [Required(ErrorMessage = "Nome Da foto é obrigatório")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
