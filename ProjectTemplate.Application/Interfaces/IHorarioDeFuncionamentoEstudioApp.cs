using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IHorarioDeFuncionamentoEstudioApp : IBaseApp<HorarioDeFuncionamentoEstudio, HorarioDeFuncionamentoEstudioDTO>
    {
        Task<IList<HorarioDeFuncionamentoEstudioDTO>> GetHorarioDeFuncionamentoEstudioByIdEstudio(int idEstudio);
    }
}
