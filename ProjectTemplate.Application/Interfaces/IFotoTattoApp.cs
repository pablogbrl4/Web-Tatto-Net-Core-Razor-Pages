using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.DTOs.ViewModels;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IFotoTattoApp : IBaseApp<FotoTatto, FotoTattoDTO>
    {
        Task<IList<FotoTattoDTO>> GetFotosTattoByIdEstudio(string id);
        Task<BuscaTatuagensViewModelDTO> GetFotosTattoByIdEstudio(int idEstudio, string estilo, string parteCorpo);
        Task<IList<FotoTattoDTO>> GetFotosTattosByIdEstudio(int idEstudio, string estilo, string parteCorpo);
        Task<IList<FotoTattoDTO>> GetFotosByIdTatuador(int idTatuador);
        Task<FotoTattoDTO> GetFotoTattoByNomeFoto(string nomeFoto, int idEstudio);
    }
}
