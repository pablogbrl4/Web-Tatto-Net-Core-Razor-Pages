using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities
{

    public class Contatos : BaseModel
    {
        public int IdEstudio { get; set; }
        public int IdCliente { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; }

        [NotMapped]
        public Estudio Estudio { get; set; }
    }
}
