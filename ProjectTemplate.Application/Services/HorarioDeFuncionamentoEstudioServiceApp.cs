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
    public class HorarioDeFuncionamentoEstudioServiceApp: BaseServicoApp<HorarioDeFuncionamentoEstudio, HorarioDeFuncionamentoEstudioDTO>, IHorarioDeFuncionamentoEstudioApp
    {
        protected readonly IHorarioDeFuncionamentoEstudioService _servico;

        public HorarioDeFuncionamentoEstudioServiceApp(IHorarioDeFuncionamentoEstudioService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public async Task<HorarioDeFuncionamentoEstudioDTO> ApagarHorarios(int idEstudio)
        {
            return _mapper.Map<HorarioDeFuncionamentoEstudioDTO>(await _servico.ApagarHorarios(idEstudio));
        }

        public async Task<IList<HorarioDeFuncionamentoEstudioDTO>> GetHorarioDeFuncionamentoEstudioByIdEstudio(int idEstudio)
        {
            return _mapper.Map<IList<HorarioDeFuncionamentoEstudioDTO>>(await _servico.GetHorarioDeFuncionamentoEstudioByIdEstudio(idEstudio));
        }

    }
}
