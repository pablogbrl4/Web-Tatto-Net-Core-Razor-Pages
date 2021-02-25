using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class TatuadorService : BaseServico<Tatuador>, ITatuadorService
    {
        protected readonly ITatuadorRepository _repository;

        public TatuadorService(ITatuadorRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public Task<Tatuador> Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetIdTatuadorByNomeCliente(string nomeCliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Tatuador>> GetTatuador()
        {
            throw new System.NotImplementedException();
        }

        public Task<Tatuador> GetTatuadorByCpf(string cpf)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tatuador> GetTatuadorByEmail(string emailTatuador)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tatuador> GetTatuadorById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tatuador> GetTatuadorByIdTatuador(int idTatuador)
        {
            throw new System.NotImplementedException();
        }

        public Task<BuscaTatuadorViewModel> GetTatuadoresAsync(string pesquisa)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tatuador> idNaoNull(int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tatuador> InsertNew(string Email, string Id, string UserName)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tatuador> Update(Tatuador novoCadastroTatuador)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tatuador> UpdateByCpf(Tatuador tatuador)
        {
            throw new System.NotImplementedException();
        }
    }
}
