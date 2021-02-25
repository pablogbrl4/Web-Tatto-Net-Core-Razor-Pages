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
    public class FotosEstudioServiceApp: BaseServicoApp<FotosEstudio, FotosEstudioDTO>, IFotosEstudioApp
    {
        protected readonly IFotosEstudioService _servico;

        public FotosEstudioServiceApp(IFotosEstudioService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<IList<FotosEstudioDTO>> GetFotosEstudioByIdEstudio(string id)
        {
            throw new NotImplementedException();
        }

        public Task<FotosEstudioDTO> GetFotosEstudioByNomeFoto(string nomeFoto, int idEstudio)
        {
            throw new NotImplementedException();
        }
    }
}
