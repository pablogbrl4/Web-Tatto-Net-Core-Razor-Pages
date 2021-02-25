using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface IFotoTattoService : IBaseServico<FotoTatto>
    {
        Task<IList<FotoTatto>> GetFotosTattoByIdEstudio(string id);

        Task<BuscaTatuagensViewModel> GetAllFotosTatto(string estilo, string parteCorpo, string genero = "", string cor = "");
        Task<BuscaTatuagensViewModel> GetFotosTattoByIdEstudio(int idEstudio, string estilo, string parteCorpo);

        Task<IList<FotoTatto>> GetFotosTattosByIdEstudio(int idEstudio, string estilo, string parteCorpo);

        Task<IList<FotoTatto>> GetFotosByIdTatuador(int idTatuador);

        Task<FotoTatto> GetFotoById(int id);

        Task<FotoTatto> DeletarFoto(int id);

        Task<FotoTatto> UpdateFoto(FotoTatto foto);

        Task<FotoTatto> GetFotoTattoByNomeFoto(string nomeFoto, int idEstudio);
    }

}
