using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Tatto.Models
{

    public class Shopping : BaseModel
    {
        public Shopping() { }

        internal void Update(Shopping shopping)
        {
            this.IdEstudio = shopping.IdEstudio;

            this.ImageName = shopping.ImageName;
            this.Preco = shopping.Preco;
            this.Categoria = shopping.Categoria;
        }


        //[ForeignKey("IdEstudio")]
        [Required]
        public string IdEstudio { get; set; }

        [Required(ErrorMessage = "Nome de produto é obrigatório")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        public decimal Preco { get;  set; }

        [Required(ErrorMessage = "Preço é obrigatória")]
        public string Categoria { get;  set; }
    }
}
