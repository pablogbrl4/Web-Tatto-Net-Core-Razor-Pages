using ProjectTemplate.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Repositories
{
    public interface IEstudio_TatuadorRepository : IBaseRepositorio<Estudio_Tatuador>
    {
        Task<IList<Estudio_Tatuador>> getEstudiosTatuadores();
        Task<IList<Estudio_Tatuador>> GetIdsByIdEstudio(int idEstudio);
        Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdEstudio(int idEstudio);
        Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdTatuador(int idTatuador);
        Task<Estudio_Tatuador> RemoverEstudioTatuador(int id);
        Task<Estudio_Tatuador> InsertByIds(int idTatuador, int idEstudio);
    }

}
