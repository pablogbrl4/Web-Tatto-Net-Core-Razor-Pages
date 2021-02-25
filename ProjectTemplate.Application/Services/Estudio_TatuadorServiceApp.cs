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
    public class Estudio_TatuadorServiceApp: BaseServicoApp<Estudio_Tatuador, Estudio_TatuadorDTO>, IEstudio_TatuadorApp
    {
        protected readonly IEstudio_TatuadorService _servico;

        public Estudio_TatuadorServiceApp(IEstudio_TatuadorService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<IList<Estudio_TatuadorDTO>> GetEstudioTatuadorByIdEstudio(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Estudio_TatuadorDTO>> GetEstudioTatuadorByIdTatuador(int idTatuador)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Estudio_TatuadorDTO>> GetIdsByIdEstudio(int idEstudio)
        {
            throw new NotImplementedException();
        }

        public Task<Estudio_TatuadorDTO> InsertByIds(int idTatuador, int idEstudio)
        {
            throw new NotImplementedException();
        }
    }
}
