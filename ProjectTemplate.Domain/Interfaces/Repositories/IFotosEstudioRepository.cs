using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Repositories
{
    public interface IFotosEstudioRepository : IBaseRepositorio<FotosEstudio>
    {
        Task<IList<FotosEstudio>> GetFotosEstudioByIdEstudio(int idEstudio);
        Task<FotosEstudio> GetFotosEstudioByNomeFoto(string nomeFoto, int idEstudio);
        Task<BuscaFotosEstudioViewModel> GetAllFotosEstudio(int IdEstudio);

        Task<FotosEstudio> GetFotoById(int id);

        Task<FotosEstudio> DeletarFoto(int id);

        Task<FotosEstudio> UpdateFoto(FotosEstudio foto);
    }

}
