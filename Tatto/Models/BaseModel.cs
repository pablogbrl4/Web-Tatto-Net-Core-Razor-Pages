using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Tatto.Models
{
    [DataContract]
    public abstract class BaseModel
    {
        [DataMember] //  especifica que o membro faz parte de um contrato de dados
        [Key]
        public int Id { get; set; }
    }
}