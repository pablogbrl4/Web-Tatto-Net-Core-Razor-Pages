using ProjectTemplate.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Application.DTOs
{
    public class HorarioDeFuncionamentoEstudioDTO : BaseEntidadeDTO
    {

        public HorarioDeFuncionamentoEstudioDTO()
        { }

        public HorarioDeFuncionamentoEstudioDTO(int idEstudio, string diaSemana, string abertura, string fechamento)
        {
            IdEstudio = idEstudio;
            DiaSemana = diaSemana;
            Abertura = abertura;
            Fechamento = fechamento;
        }

        internal void Update(HorarioDeFuncionamentoEstudioDTO novoCadastro)
        {
            this.IdEstudio = novoCadastro.IdEstudio;

            this.DiaSemana = novoCadastro.DiaSemana;
            this.Abertura = novoCadastro.Abertura;
            this.Fechamento = novoCadastro.Fechamento;
        }

        //[ForeignKey("IdEstudio")]
        [Required]
        public int IdEstudio { get; set; }

        [Required]
        public string DiaSemana { get; set; }

        public string Abertura { get; set; }

        public string Fechamento { get; set; }

        [NotMapped]
        public Estudio Estudio { get; set; }
    }
}
