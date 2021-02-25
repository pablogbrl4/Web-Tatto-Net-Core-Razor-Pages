using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class HorarioDeFuncionamentoEstudioService : BaseServico<HorarioDeFuncionamentoEstudio>, IHorarioDeFuncionamentoEstudioService
    {
        protected readonly IHorarioDeFuncionamentoEstudioRepository _repository;

        public HorarioDeFuncionamentoEstudioService(IHorarioDeFuncionamentoEstudioRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public async Task<HorarioDeFuncionamentoEstudio> ApagarHorarios(int idEstudio)
        {
            return await _repository.ApagarHorarios(idEstudio);
        }

        public async Task<IList<HorarioDeFuncionamentoEstudio>> GetHorarioDeFuncionamentoEstudioByIdEstudio(int idEstudio)
        {
            return await _repository.GetHorarioDeFuncionamentoEstudioByIdEstudio(idEstudio);
        }
    }
}
