using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Domain.Entities
{
    public class Agenda : BaseModel
    {
        public Agenda()
        {
        }
     
        public void Update(Agenda novoCadastro) 
        {
            this.IdCliente = novoCadastro.IdCliente;
            this.IdEstudio = novoCadastro.IdEstudio;
            this.IdTatuador = novoCadastro.IdTatuador;

            this.DataMarcação = novoCadastro.DataMarcação;
            this.Ativo = novoCadastro.Ativo;

            this.Alergia = novoCadastro.Alergia;
            this.TextoAlergia = novoCadastro.TextoAlergia;
            this.Hepatite = novoCadastro.Hepatite;
            this.TextoHepatite = novoCadastro.TextoHepatite;
            this.DST = novoCadastro.DST;
            this.TextoDST = novoCadastro.TextoDST;
            this.UtilizaMedicamento = novoCadastro.UtilizaMedicamento;
            this.TextoUtilizaMedicamento = novoCadastro.TextoUtilizaMedicamento;
            this.problemaDermatológico = novoCadastro.problemaDermatológico;
            this.TextoproblemaDermatológico = novoCadastro.TextoproblemaDermatológico;
            this.Epilepsia = novoCadastro.Epilepsia;
            this.TextoEpilepsia = novoCadastro.TextoEpilepsia;
            this.ProblemaCardiaco = novoCadastro.ProblemaCardiaco;
            this.TextoProblemaCardiaco = novoCadastro.TextoProblemaCardiaco;
            this.UsaDrogas = novoCadastro.UsaDrogas;
            this.TextoUsaDrogas = novoCadastro.TextoUsaDrogas;
            this.TipoSanguineo = novoCadastro.TipoSanguineo;
            this.AlimentouBem = novoCadastro.AlimentouBem;
            this.Gravida = novoCadastro.Gravida;
        }

        public int IdCliente { get; set; }
        public int IdEstudio { get; set; }
        public int IdTatuador { get; set; }
        public DateTime DataMarcação { get; set; }
        public bool Ativo { get; set; }
        public bool Alergia { get; set; }
        public string TextoAlergia { get; set; } 
        public bool Hepatite { get; set; }
        public string TextoHepatite { get; set; } 
        public bool DST { get; set; }
        public string TextoDST { get; set; } 
        public bool UtilizaMedicamento { get; set; }
        public string TextoUtilizaMedicamento { get; set; } 
        public bool problemaDermatológico { get; set; }
        public string TextoproblemaDermatológico { get; set; } 
        public bool Epilepsia { get; set; }
        public string TextoEpilepsia { get; set; }
        public bool ProblemaCardiaco { get; set; }
        public string TextoProblemaCardiaco { get; set; }
        public bool UsaDrogas { get; set; }
        public string TextoUsaDrogas { get; set; } 
        public string TipoSanguineo { get; set; } 
        public bool AlimentouBem { get; set; }
        public bool Gravida { get; set; }

        [NotMapped]
        public Estudio Estudio { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; }

        [NotMapped]
        public Tatuador Tatuador { get; set; }

    }
}
