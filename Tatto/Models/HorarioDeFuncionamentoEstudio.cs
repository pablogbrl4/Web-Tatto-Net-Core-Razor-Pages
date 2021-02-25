using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Tatto.Models
{
    public class HorarioDeFuncionamentoEstudio : BaseModel
    {

        public HorarioDeFuncionamentoEstudio()
        { }

        public HorarioDeFuncionamentoEstudio(string idEstudio, string diaSemana, string abertura, string fechamento)
        {
            IdEstudio = idEstudio;
            DiaSemana = diaSemana;
            Abertura = abertura;
            Fechamento = fechamento;
        }

        internal void Update(HorarioDeFuncionamentoEstudio novoCadastro)
        {
            this.IdEstudio = novoCadastro.IdEstudio;

            this.DiaSemana = novoCadastro.DiaSemana;
            this.Abertura = novoCadastro.Abertura;
            this.Fechamento = novoCadastro.Fechamento;
        }

        //[ForeignKey("IdEstudio")]
        [Required]
        public string IdEstudio { get; set; }

        [Required]
        public string DiaSemana { get; set; }

        public string Abertura { get; set; }

        public string Fechamento { get; set; }
    }
}
