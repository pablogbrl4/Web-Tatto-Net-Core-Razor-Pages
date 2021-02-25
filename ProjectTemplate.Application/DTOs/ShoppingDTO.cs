using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectTemplate.Application.DTOs
{

    public class ShoppingDTO : BaseEntidadeDTO
    {
        public ShoppingDTO() { }

        internal void Update(ShoppingDTO shopping)
        {
            this.IdEstudio = shopping.IdEstudio;

            this.ImageName = shopping.ImageName;
            this.Preco = shopping.Preco;
            this.Categoria = shopping.Categoria;
        }


        //[ForeignKey("IdEstudio")]
        [Required]
        public int IdEstudio { get; set; }

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
