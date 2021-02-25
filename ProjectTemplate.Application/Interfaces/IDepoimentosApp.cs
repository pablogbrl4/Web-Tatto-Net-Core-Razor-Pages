using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IDepoimentosApp : IBaseApp<Depoimentos, DepoimentosDTO>
    {
        Task<IList<DepoimentosDTO>> GetDepoimentosByIdEstudio(string id);
    }
}
