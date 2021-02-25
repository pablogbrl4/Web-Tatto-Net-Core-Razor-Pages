using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities
{

    public class Shopping : BaseModel
    {
        public Shopping() { }

        public void Update(Shopping shopping)
        {
            this.IdEstudio = shopping.IdEstudio;

            this.ImageName = shopping.ImageName;
            this.Preco = shopping.Preco;
            this.Categoria = shopping.Categoria;
        }

        public int IdEstudio { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public decimal Preco { get;  set; }
        public string Categoria { get;  set; }


        [NotMapped]
        public Estudio Estudio { get; set; }
    }
}
