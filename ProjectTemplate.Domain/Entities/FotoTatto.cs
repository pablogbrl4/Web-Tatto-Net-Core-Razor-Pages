using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ProjectTemplate.Domain.Entities
{
    public class FotoTatto : BaseModel
    {

        public FotoTatto() { }

        public void Update(FotoTatto foto)
        {
            this.IdEstudio = foto.IdEstudio;
            this.IdTatuador = foto.IdTatuador;
            this.ImageName = foto.ImageName;
            this.EstiloTatto = foto.EstiloTatto;
            this.ParteDoCorpo = foto.ParteDoCorpo;
        }
      
        public int IdEstudio { get; set; }
        public int IdTatuador { get; set; }
        public int IdCliente { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        // Tipos
        public string EstiloTatto { get; set; }
        public string ParteDoCorpo { get; set; }
        public string Genero { get; set; }
        public string Cor { get; set; }

        [NotMapped]
        public Estudio Estudio { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; }

        [NotMapped]
        public Tatuador Tatuador { get; set; }
    }
}
