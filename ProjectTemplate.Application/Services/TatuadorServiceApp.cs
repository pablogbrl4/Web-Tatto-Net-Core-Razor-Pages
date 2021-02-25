using AutoMapper;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.DTOs.ViewModels;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Services
{
    public class TatuadorServiceApp: BaseServicoApp<Tatuador, TatuadorDTO>, ITatuadorApp
    {
        protected readonly ITatuadorService _servico;

        public TatuadorServiceApp(ITatuadorService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<string> GetIdTatuadorByNomeCliente(string nomeCliente)
        {
            throw new NotImplementedException();
        }

        public Task<TatuadorDTO> GetTatuadorByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public Task<TatuadorDTO> GetTatuadorByEmail(string emailTatuadorDTO)
        {
            throw new NotImplementedException();
        }

        public Task<TatuadorDTO> GetTatuadorByIdTatuador(int idTatuador)
        {
            throw new NotImplementedException();
        }

        public Task<TatuadorDTO> idNaoNull(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<TatuadorDTO> InsertNew(string Email, string Id, string UserName)
        {
            throw new NotImplementedException();
        }

        public Task<TatuadorDTO> UpdateByCpf(TatuadorDTO tatuador)
        {
            throw new NotImplementedException();
        }
    }
}
