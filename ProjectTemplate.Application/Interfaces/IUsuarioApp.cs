using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IClienteApp : IBaseApp<Cliente, ClienteDTO>
    {
        Task<ClienteDTO> UpdateByIdCliente(ClienteDTO novoCadastroCliente);
        Task<ClienteDTO> UpdateByCpf(ClienteDTO novoCadastroCliente);
        Task<ClienteDTO> GetClienteById(int id);
        // Task<BuscaClientesDTOViewModel> GetClientesByName(string nomeCliente);
        Task<ClienteDTO> GetClienteByCpf(string cpfCliente);
        Task<ClienteDTO> GetClienteByEmail(string emailCliente);
        Task<ClienteDTO> idNaoNull(int idEstudio);
        Task<ClienteDTO> InsertNew(string Email, string Id, string UserName);
    }
}
