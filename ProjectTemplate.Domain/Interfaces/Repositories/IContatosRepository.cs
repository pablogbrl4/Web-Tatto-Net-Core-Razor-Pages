using ProjectTemplate.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Repositories
{
    public interface IContatosRepository : IBaseRepositorio<Contatos>
    {
        Task<IList<Contatos>> GetContatosByIdEstudio(int idEstudio);
        Task<IList<Contatos>> GetContatosByidClienteAndIdEstudio(int idCliente, int idEstudio);
        Task<Contatos> RemoverContato(int idCliente, int idEstudio);
        Task<Contatos> InsertByIds(int idCliente, int idEstudio);

    }

}
