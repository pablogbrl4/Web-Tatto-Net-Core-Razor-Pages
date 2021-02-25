using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTemplate.Application.DTOs
{

    public class AgendaDTO : BaseEntidadeDTO
    {
        public AgendaDTO()
        {
        }


        internal void Update(AgendaDTO novoCadastro) // Atualizar cadastro da Agenda
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

        [Required]
        //[ForeignKey("IdCliente")]
        public int IdCliente { get; set; }

        [Required]
        //[ForeignKey("IdEstudio")]
        public int IdEstudio { get; set; }

        [Required]
        //[ForeignKey("IdTatuador")]
        public int IdTatuador { get; set; }

        // Data Seção
        [Required(ErrorMessage = "Data de Marcação é obrigatória")]
        public DateTime DataMarcação { get; set; }

        [Required]
        public bool Ativo { get; set; }

        //    Infromações de Saúde

        [Required(ErrorMessage = "Alergia é obrigatório")]
        public bool Alergia { get; set; }
        public string TextoAlergia { get; set; } = "";


        [Required(ErrorMessage = "Hepatite é obrigatório")]
        public bool Hepatite { get; set; }
        public string TextoHepatite { get; set; } = "";


        [Required(ErrorMessage = "DST é obrigatório")]
        public bool DST { get; set; }
        public string TextoDST { get; set; } = "";


        [Required(ErrorMessage = "UtilizaMedicamento é obrigatório")]
        public bool UtilizaMedicamento { get; set; }
        public string TextoUtilizaMedicamento { get; set; } = "";


        [Required(ErrorMessage = "problemaDermatológico é obrigatório")]
        public bool problemaDermatológico { get; set; }
        public string TextoproblemaDermatológico { get; set; } = "";


        [Required(ErrorMessage = "Epilepsia é obrigatório")]
        public bool Epilepsia { get; set; }
        public string TextoEpilepsia { get; set; } = "";


        [Required(ErrorMessage = "ProblemaCardiaco é obrigatório")]
        public bool ProblemaCardiaco { get; set; }
        public string TextoProblemaCardiaco { get; set; } = "";


        [Required(ErrorMessage = "UsaDrogas é obrigatório")]
        public bool UsaDrogas { get; set; }
        public string TextoUsaDrogas { get; set; } = "";


        [Required(ErrorMessage = "TipoSanguineo é obrigatório")]
        public string TipoSanguineo { get; set; } = "";

        [Required(ErrorMessage = "AlimentouBem é obrigatório")]
        public bool AlimentouBem { get; set; }

        [Required(ErrorMessage = "Gravida é obrigatório")]
        public bool Gravida { get; set; }


        [NotMapped]
        public EstudioDTO Estudio { get; set; }

        [NotMapped]
        public ClienteDTO Cliente { get; set; }

        [NotMapped]
        public TatuadorDTO Tatuador { get; set; }


    }
}
