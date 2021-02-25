using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.DTOs.ViewModels;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface ITatuadorApp : IBaseApp<Tatuador, TatuadorDTO>
    {

        Task<TatuadorDTO> GetTatuadorByCpf(string cpf);   
        Task<TatuadorDTO> GetTatuadorByIdTatuador(int idTatuador);
        Task<string> GetIdTatuadorByNomeCliente(string nomeCliente);
        Task<TatuadorDTO> UpdateByCpf(TatuadorDTO tatuador);
        Task<TatuadorDTO> GetTatuadorByEmail(string emailTatuadorDTO);
        Task<TatuadorDTO> idNaoNull(int idEstudio);
        Task<TatuadorDTO> InsertNew(string Email, string Id, string UserName);
    }
}
