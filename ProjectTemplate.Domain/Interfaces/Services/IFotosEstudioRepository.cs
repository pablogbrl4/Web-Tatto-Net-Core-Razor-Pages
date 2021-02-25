using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface IFotosEstudioService : IBaseServico<FotosEstudio>
    {
        Task<IList<FotosEstudio>> GetFotosEstudioByIdEstudio(string id);
        Task<FotosEstudio> GetFotosEstudioByNomeFoto(string nomeFoto, int idEstudio);
        Task<BuscaFotosEstudioViewModel> GetAllFotosEstudio(string pesquisa);

        Task<FotosEstudio> GetFotoById(int id);

        Task<FotosEstudio> DeletarFoto(int id);

        Task<FotosEstudio> UpdateFoto(FotosEstudio foto);
    }

}
