using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Application.DTOs
{
    public class DepoimentosDTO : BaseEntidadeDTO
    {
        //[ForeignKey("IdEstudio")]
        [Required]
        public int IdEstudio { get; set; }

        //[ForeignKey("IdCliente")]
        [Required]
        public int IdCliente { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public string NomeCliente { get; set; }
    }
}
