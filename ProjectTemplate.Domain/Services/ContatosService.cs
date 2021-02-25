using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class ContatosService : BaseServico<Contatos>, IContatosService
    {
        protected readonly IContatosRepository _repository;

        public ContatosService(IContatosRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public Task<IList<Contatos>> GetContatosByIdEstudio(int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Contatos>> GetContatosByidClienteAndIdEstudio(int idCliente, int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contatos> InsertByIds(int idCliente, int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contatos> RemoverContato(int idCliente, int idEstudio)
        {
            throw new System.NotImplementedException();
        }
    }
}
