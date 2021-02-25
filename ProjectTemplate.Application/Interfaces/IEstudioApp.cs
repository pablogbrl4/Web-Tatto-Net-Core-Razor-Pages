using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.DTOs.ViewModels;
using ProjectTemplate.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IEstudioApp : IBaseApp<Estudio, EstudioDTO>
    {
        Task<EstudioDTO> InsertNew(string Email, string Id, string UserName);
        Task<int> GetIdEstudioByNomeCliente(string nomeCliente);
        Task<BuscaEstudioViewModelDTO> GetEstudiosByBairro(string bairro);
        Task<EstudioDTO> GetEstudioByEmail(string emailEstudioDTO);
        Task<EstudioDTO> idNaoNull(int idEstudio);
        int GetIdEstudioByIdUser(int idCliente);
    }
}
