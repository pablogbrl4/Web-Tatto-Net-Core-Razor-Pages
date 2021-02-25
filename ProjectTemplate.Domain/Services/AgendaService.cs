using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class AgendaService : BaseServico<Agenda>, IAgendaService
    {
        protected readonly IAgendaRepository _repository;

        public AgendaService(IAgendaRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public async Task<Agenda> Delete(int idagenda)
        {
            return await _repository.Delete(idagenda);
        }

        public Agenda GetAgendaByIdAgenda(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Agenda>> GetAgendasAsync(int pesquisa)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Agenda>> GetAgendasByIdEstudio(int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Agenda>> GetAgendasByIdTatuador(int idTatuador)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Agenda>> GetAgendasByIdCliente(int idCliente)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Agenda>> GetAgendasByIdClienteAndCliente(int idCliente, int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<Agenda> Update(Agenda agenda)
        {
            throw new System.NotImplementedException();
        }
    }
}
