using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IContatosApp : IBaseApp<Contatos, ContatosDTO>
    {
        Task<IList<ContatosDTO>> GetContatosByIdEstudio(int idEstudio);
        Task<IList<ContatosDTO>> GetContatosByidClienteAndIdEstudio(int idCliente, int idEstudio);
        Task<ContatosDTO> RemoverContato(int idCliente, int idEstudio);
        Task<ContatosDTO> InsertByIds(int idCliente, int idEstudio);
    }
}
