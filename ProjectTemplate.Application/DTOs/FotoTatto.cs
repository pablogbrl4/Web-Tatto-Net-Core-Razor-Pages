using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ProjectTemplate.Application.DTOs
{
    public class FotoTattoDTO : BaseEntidadeDTO
    {

        public FotoTattoDTO() { }

        internal void Update(FotoTattoDTO foto)
        {
            this.IdEstudio = foto.IdEstudio;
            this.IdTatuador = foto.IdTatuador;
            this.ImageName = foto.ImageName;
            this.EstiloTatto = foto.EstiloTatto;
            this.ParteDoCorpo = foto.ParteDoCorpo;
        }

        //[ForeignKey("IdEstudio")]
        [Required]
        public int IdEstudio { get; set; }

        //[Required]
        public int IdTatuador { get; set; }

        //[Required]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Nome Da foto é obrigatório")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        [Required(ErrorMessage = "Foto é obrigatória")]
        public IFormFile ImageFile { get; set; }

        // Tipos
        [Required(ErrorMessage = "Estilo da Tatuagem é obrigatório")]
        public string EstiloTatto { get; set; }

        [Required(ErrorMessage = "Parte Do Corpo é obrigatório")]
        public string ParteDoCorpo { get; set; }

        [Required(ErrorMessage = "Gênero é obrigatório")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Cor é obrigatória")]
        public string Cor { get; set; }


        [NotMapped]
        public IList<TatuadorDTO> Tatuador { get; set; } = new List<TatuadorDTO>();

        [NotMapped]
        public IList<ClienteDTO> Cliente { get; set; } = new List<ClienteDTO>();
    }
}
