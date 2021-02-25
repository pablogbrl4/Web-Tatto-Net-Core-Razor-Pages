using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class ClienteService : BaseServico<Cliente>, IClienteService
    {
        protected readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Cliente>> GetAllClientes()
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> GetClienteByCpf(string cpfCliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> GetClienteByEmail(string emailCliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> GetClienteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> GetClienteByIdCliente(int idCliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<BuscaClientesViewModel> GetClientesByName(string nomeCliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> idNaoNull(int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> InsertNew(string Email, string Id, string UserName)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> UpdateByCpf(Cliente novoCadastroCliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> UpdateById(Cliente novoCadastroCliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<Cliente> UpdateByIdCliente(Cliente novoCadastroCliente)
        {
            throw new System.NotImplementedException();
        }
    }
}
