using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class DepoimentosService : BaseServico<Depoimentos>, IDepoimentosService
    {
        protected readonly IDepoimentosRepository _repository;

        public DepoimentosService(IDepoimentosRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public Task<IList<Depoimentos>> GetDepoimentosByIdEstudio(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
