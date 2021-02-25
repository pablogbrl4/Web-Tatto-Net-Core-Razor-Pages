using ProjectTemplate.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Repositories
{
    public interface IHorarioDeFuncionamentoEstudioRepository : IBaseRepositorio<HorarioDeFuncionamentoEstudio>
    {
        Task<IList<HorarioDeFuncionamentoEstudio>> GetHorarioDeFuncionamentoEstudioByIdEstudio(int idEstudio);
        Task<HorarioDeFuncionamentoEstudio> ApagarHorarios(int idEstudio);
    }

}
