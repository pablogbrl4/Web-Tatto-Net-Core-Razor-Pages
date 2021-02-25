using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectTemplate.Application.DTOs
{
    public class FotosEstudioDTO : BaseEntidadeDTO
    {
        public FotosEstudioDTO()
        {
        }

        internal void Update(FotosEstudioDTO foto)
        {
            this.IdEstudio = foto.IdEstudio;
            this.ImageName = foto.ImageName;
        }

        //[ForeignKey("IdEstudio")]
        [Required]
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "Nome Da foto é obrigatório")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
