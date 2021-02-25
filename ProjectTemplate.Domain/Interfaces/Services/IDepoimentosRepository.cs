using ProjectTemplate.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface IDepoimentosService : IBaseServico<Depoimentos>
    {
        Task<IList<Depoimentos>> GetDepoimentosByIdEstudio(string id);
    }

}
