using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Application.DTOs
{
    public class ContatosDTO : BaseEntidadeDTO
    {
        //[ForeignKey("IdEstudio")]
        [Required]
        public int IdEstudio { get; set; }

        //[ForeignKey("IdCliente")]
        [Required]
        public int IdCliente { get; set; }

        [NotMapped]
        public ClienteDTO Cliente { get; set; }
    }
}
