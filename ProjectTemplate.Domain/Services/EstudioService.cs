using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class EstudioService : BaseServico<Estudio>, IEstudioService
    {
        protected readonly IEstudioRepository _repository;

        public EstudioService(IEstudioRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public Task<Estudio> GetEstudioByEmail(string emailEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<BuscaEstudioViewModel> GetEstudiosAsync(string pesquisa)
        {
            throw new System.NotImplementedException();
        }

        public Task<BuscaEstudioViewModel> GetEstudiosByBairro(string bairro)
        {
            throw new System.NotImplementedException();
        }

        public int GetIdEstudioByIdUser(int idUser)
        {
            return  _repository.GetIdEstudioByIdUser(idUser);
        }

        public async Task<int> GetIdEstudioByNomeCliente(string nomeCliente)
        {
            return await _repository.GetIdEstudioByNomeCliente(nomeCliente);
        }

        public async Task<Estudio> idNaoNull(int idEstudio)
        {
            return await _repository.idNaoNull(idEstudio);
        }

        public Task<Estudio> InsertNew(string Email, string Id, string UserName)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Estudio> Update(Estudio estudio)
        {
            return await _repository.Update(estudio);
        }
    }
}
