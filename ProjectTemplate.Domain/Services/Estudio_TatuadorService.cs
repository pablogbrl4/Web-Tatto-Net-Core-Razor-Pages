using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class Estudio_TatuadorService : BaseServico<Estudio_Tatuador>, IEstudio_TatuadorService
    {
        protected readonly IEstudio_TatuadorRepository _repository;

        public Estudio_TatuadorService(IEstudio_TatuadorRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public Task<IList<Estudio_Tatuador>> getEstudiosTatuadores()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdEstudio(int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdTatuador(int idTatuador)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Estudio_Tatuador>> GetIdsByIdEstudio(int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<Estudio_Tatuador> InsertByIds(int idTatuador, int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<Estudio_Tatuador> RemoverEstudioTatuador(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
