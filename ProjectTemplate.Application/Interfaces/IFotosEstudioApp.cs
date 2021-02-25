using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.DTOs.ViewModels;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IFotosEstudioApp : IBaseApp<FotosEstudio, FotosEstudioDTO>
    {
        Task<IList<FotosEstudioDTO>> GetFotosEstudioByIdEstudio(string id);
        Task<FotosEstudioDTO> GetFotosEstudioByNomeFoto(string nomeFoto, int idEstudio);
    }
}
