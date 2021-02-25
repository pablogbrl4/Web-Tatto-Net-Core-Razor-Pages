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
    public class DepoimentosServiceApp: BaseServicoApp<Depoimentos, DepoimentosDTO>, IDepoimentosApp
    {
        protected readonly IDepoimentosService _servico;

        public DepoimentosServiceApp(IDepoimentosService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<IList<DepoimentosDTO>> GetDepoimentosByIdEstudio(string id)
        {
            throw new NotImplementedException();
        }
    }
}
