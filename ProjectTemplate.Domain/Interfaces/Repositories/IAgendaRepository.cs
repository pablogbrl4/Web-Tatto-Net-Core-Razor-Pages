using ProjectTemplate.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Repositories
{
    public interface IAgendaRepository : IBaseRepositorio<Agenda>
    {
        Task<Agenda> Update(Agenda agenda);
        Task<Agenda> Delete(int idagenda);
        Agenda GetAgendaByIdAgenda(int id);
        Task<IList<Agenda>> GetAgendasAsync(int pesquisa);
        Task<IList<Agenda>> GetAgendasByIdEstudio(int idEstudio);
        Task<IList<Agenda>> GetAgendasByIdCliente(int idCliente);
        Task<IList<Agenda>> GetAgendasByIdTatuador(int idTatuador);
        Task<IList<Agenda>> GetAgendasByIdClienteAndCliente(int idCliente, int idEstudio);
    }

}
