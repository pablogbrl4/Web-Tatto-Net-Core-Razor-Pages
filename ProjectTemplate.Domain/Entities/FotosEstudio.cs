using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectTemplate.Domain.Entities
{
    public class FotosEstudio : BaseModel
    {
        public FotosEstudio()
        {
        }

        public void Update(FotosEstudio foto)
        {
            this.IdEstudio = foto.IdEstudio;
            this.ImageName = foto.ImageName;
        }

        public int IdEstudio { get; set; }

        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
