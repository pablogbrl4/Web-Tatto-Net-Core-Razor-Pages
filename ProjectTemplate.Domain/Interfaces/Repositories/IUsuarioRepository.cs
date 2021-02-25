using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Repositories
{

    public interface IClienteRepository : IBaseRepositorio<Cliente>
    {
        void Delete(string id);
        Task<Cliente> UpdateById(Cliente novoCadastroCliente);
        Task<Cliente> UpdateByIdCliente(Cliente novoCadastroCliente);
        Task<Cliente> UpdateByCpf(Cliente novoCadastroCliente);
        Task<IList<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<BuscaClientesViewModel> GetClientesByName(string nomeCliente);
        Task<Cliente> GetClienteByCpf(string cpfCliente);
        Task<Cliente> GetClienteByEmail(string emailCliente);
        Task<Cliente> GetClienteByIdCliente(int idCliente);
        Task<Cliente> idNaoNull(int idCliente);
        Task<Cliente> InsertNew(string Email, int IdCliente, string UserName);
    }

}
