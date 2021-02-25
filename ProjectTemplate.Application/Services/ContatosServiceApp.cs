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
    public class ContatosServiceApp: BaseServicoApp<Contatos, ContatosDTO>, IContatosApp
    {
        protected readonly IContatosService _servico;

        public ContatosServiceApp(IContatosService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<IList<ContatosDTO>> GetContatosByidClienteAndIdEstudio(int idCliente, int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ContatosDTO>> GetContatosByIdEstudio(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<ContatosDTO> InsertByIds(int idCliente, int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<ContatosDTO> RemoverContato(int idCliente, int idEstudio)
        {
            throw new NotImplementedException();
        }
    }
}
