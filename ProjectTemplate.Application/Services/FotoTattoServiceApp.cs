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
    public class FotoTattoServiceApp: BaseServicoApp<FotoTatto, FotoTattoDTO>, IFotoTattoApp
    {
        protected readonly IFotoTattoService _servico;

        public FotoTattoServiceApp(IFotoTattoService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<IList<FotoTattoDTO>> GetFotosByIdTatuador(int idTatuador)
        {
            throw new NotImplementedException();
        }

        public Task<IList<FotoTattoDTO>> GetFotosTattoByIdEstudio(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BuscaTatuagensViewModelDTO> GetFotosTattoByIdEstudio(int idEstudio, string estilo, string parteCorpo)
        {
            throw new NotImplementedException();
        }

        public Task<IList<FotoTattoDTO>> GetFotosTattosByIdEstudio(int idEstudio, string estilo, string parteCorpo)
        {
            throw new NotImplementedException();
        }

        public Task<FotoTattoDTO> GetFotoTattoByNomeFoto(string nomeFoto, int idEstudio)
        {
            throw new NotImplementedException();
        }
    }
}
