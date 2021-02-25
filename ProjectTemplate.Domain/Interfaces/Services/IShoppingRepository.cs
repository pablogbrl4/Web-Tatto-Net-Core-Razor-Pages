using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface IShoppingService : IBaseServico<Shopping>
    {
        Task<IList<Shopping>> GetShoppingByIdEstudio(int idEstudio);
        Task<Shopping> GetFotoById(int id);
        Task<BuscaShoppingViewModel> GetAllShoppings(int idEstudio, string categoria);
        Task<Shopping> DeletarShopping(int id);
        Task<Shopping> UpdateShopping(Shopping shopping);
        Task<Shopping> GetShoppingByNomeFoto(string nomeFoto, int idEstudio);
    }

}
