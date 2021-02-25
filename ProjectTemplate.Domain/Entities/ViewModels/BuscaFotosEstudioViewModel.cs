using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Entities.ViewModels
{
    public class BuscaFotosEstudioViewModel // fornece os dados necessários para a View
    {
        // O ViewModel permite fornecer como modelo à View uma classe que contenha todas as informações de que ela precisa, sem modificarmos as entidades do modelo da aplicação.
        public BuscaFotosEstudioViewModel(IList<FotosEstudio> fotosEstudios)
        {
            FotosEstudios = fotosEstudios;
        }

        public IList<FotosEstudio> FotosEstudios { get; }

        public FotosEstudio FotosEstudio { get; set; }

    }
}
