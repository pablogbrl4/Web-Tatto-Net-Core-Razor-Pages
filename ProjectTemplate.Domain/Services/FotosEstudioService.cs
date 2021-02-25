using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class FotosEstudioService : BaseServico<FotosEstudio>, IFotosEstudioService
    {
        protected readonly IFotosEstudioRepository _repository;

        public FotosEstudioService(IFotosEstudioRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public Task<FotosEstudio> DeletarFoto(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<BuscaFotosEstudioViewModel> GetAllFotosEstudio(string pesquisa)
        {
            throw new System.NotImplementedException();
        }

        public Task<FotosEstudio> GetFotoById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<FotosEstudio>> GetFotosEstudioByIdEstudio(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<FotosEstudio> GetFotosEstudioByNomeFoto(string nomeFoto, int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<FotosEstudio> UpdateFoto(FotosEstudio foto)
        {
            throw new System.NotImplementedException();
        }
    }
}
