using ProjectTemplate.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Repositories
{
    public interface IDepoimentosRepository : IBaseRepositorio<Depoimentos>
    {
        Task<IList<Depoimentos>> GetDepoimentosByIdEstudio(int idEstudio);
    }

}
