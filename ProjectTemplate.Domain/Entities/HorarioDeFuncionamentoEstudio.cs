using System.ComponentModel.DataAnnotations;

namespace ProjectTemplate.Domain.Entities
{
    public class HorarioDeFuncionamentoEstudio : BaseModel
    {

        public HorarioDeFuncionamentoEstudio()
        { }

        public HorarioDeFuncionamentoEstudio(int idEstudio, string diaSemana, string abertura, string fechamento)
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

        public int IdEstudio { get; set; }
        public string DiaSemana { get; set; }
        public string Abertura { get; set; }
        public string Fechamento { get; set; }


        public Estudio Estudio { get; set; }
    }
}
