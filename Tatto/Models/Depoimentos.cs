using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Tatto.Models
{
    public class Depoimentos : BaseModel
    {
        //[ForeignKey("IdEstudio")]
        [Required]
        public string IdEstudio { get; set; }

        //[ForeignKey("IdUsuario")]
        [Required]
        public string IdUsuario { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public string NomeUsuario { get; set; }
    }
}
