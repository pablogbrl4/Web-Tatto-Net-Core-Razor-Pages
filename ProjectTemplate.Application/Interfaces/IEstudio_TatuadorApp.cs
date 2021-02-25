using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IEstudio_TatuadorApp : IBaseApp<Estudio_Tatuador, Estudio_TatuadorDTO>
    {
        Task<IList<Estudio_TatuadorDTO>> GetIdsByIdEstudio(int idEstudio);
        Task<IList<Estudio_TatuadorDTO>> GetEstudioTatuadorByIdEstudio(int idEstudio);
        Task<IList<Estudio_TatuadorDTO>> GetEstudioTatuadorByIdTatuador(int idTatuador);
        Task<Estudio_TatuadorDTO> InsertByIds(int idTatuador, int idEstudio);
    }
}
