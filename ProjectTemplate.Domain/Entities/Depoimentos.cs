using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Domain.Entities
{
    public class Depoimentos : BaseModel
    {
         
        public int IdEstudio { get; set; }

         
        public int IdCliente { get; set; }

         
        public string Texto { get; set; }

         
        public string NomeCliente { get; set; }
    }
}
