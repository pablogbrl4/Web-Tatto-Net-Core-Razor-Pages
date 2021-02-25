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
    public class EstudioServiceApp : BaseServicoApp<Estudio, EstudioDTO>, IEstudioApp
    {
        protected readonly IEstudioService _servico;

        public EstudioServiceApp(IEstudioService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<EstudioDTO> GetEstudioByEmail(string emailEstudioDTO)
        {
            throw new NotImplementedException();
        }

        public Task<BuscaEstudioViewModelDTO> GetEstudiosByBairro(string bairro)
        {
            throw new NotImplementedException();
        }

        public int GetIdEstudioByIdUser(int idUser)
        {
            return _servico.GetIdEstudioByIdUser(idUser);
        }

        public async Task<int> GetIdEstudioByNomeCliente(string nomeCliente)
        {
            return await _servico.GetIdEstudioByNomeCliente(nomeCliente);
        }

        public Task<EstudioDTO> idNaoNull(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<EstudioDTO> InsertNew(string Email, string Id, string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
