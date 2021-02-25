using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Tatto.Models
{
    public class FotoTatto : BaseModel
    {

        public FotoTatto() { }

        internal void Update(FotoTatto foto)
        {
            this.IdEstudio = foto.IdEstudio;
            this.IdTatuador = foto.IdTatuador;
            this.ImageName = foto.ImageName;
            this.EstiloTatto = foto.EstiloTatto;
            this.ParteDoCorpo = foto.ParteDoCorpo;
        }

        //[ForeignKey("IdEstudio")]
        [Required]
        public string IdEstudio { get; set; }

        //[Required]
        public string IdTatuador { get; set; }

        //[Required]
        public int IdUsuario { get; set; }

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
        public IList<Tatuador> Tatuador { get; set; } = new List<Tatuador>();

        [NotMapped]
        public IList<Usuario> Usuario { get; set; } = new List<Usuario>();
    }
}
