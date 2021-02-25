using ProjectTemplate.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface IHorarioDeFuncionamentoEstudioService : IBaseServico<HorarioDeFuncionamentoEstudio>
    {
        Task<IList<HorarioDeFuncionamentoEstudio>> GetHorarioDeFuncionamentoEstudioByIdEstudio(int idEstudio);
        Task<HorarioDeFuncionamentoEstudio> ApagarHorarios(int idEstudio);
    }

}
