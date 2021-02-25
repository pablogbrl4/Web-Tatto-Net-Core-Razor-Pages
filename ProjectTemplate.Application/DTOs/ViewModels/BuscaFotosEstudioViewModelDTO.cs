using ProjectTemplate.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.DTOs.ViewModels
{
    public class BuscaFotosEstudioViewModelDTO // fornece os dados necessários para a View
    {
        // O ViewModel permite fornecer como modelo à View uma classe que contenha todas as informações de que ela precisa, sem modificarmos as entidades do modelo da aplicação.
        public BuscaFotosEstudioViewModelDTO(IList<FotosEstudioDTO> fotosEstudios)
        {
            FotosEstudios = fotosEstudios;
        }

        public IList<FotosEstudioDTO> FotosEstudios { get; }

        public FotosEstudioDTO FotosEstudio { get; set; }

    }
}
