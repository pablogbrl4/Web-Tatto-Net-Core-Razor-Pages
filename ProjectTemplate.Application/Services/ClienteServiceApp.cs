using AutoMapper;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Services
{
    public class ClienteServiceApp: BaseServicoApp<Cliente, ClienteDTO>, IClienteApp
    {
        protected readonly IClienteService _servico;

        public ClienteServiceApp(IClienteService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<ClienteDTO> GetClienteByCpf(string cpfCliente)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> GetClienteByEmail(string emailCliente)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> GetClienteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> idNaoNull(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> InsertNew(string Email, string Id, string UserName)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> UpdateByCpf(ClienteDTO novoCadastroCliente)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDTO> UpdateByIdCliente(ClienteDTO novoCadastroCliente)
        {
            throw new NotImplementedException();
        }
    }
}
