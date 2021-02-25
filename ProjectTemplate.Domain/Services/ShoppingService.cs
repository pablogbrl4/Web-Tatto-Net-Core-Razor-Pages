using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class ShoppingService : BaseServico<Shopping>, IShoppingService
    {
        protected readonly IShoppingRepository _repository;

        public ShoppingService(IShoppingRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public Task<Shopping> DeletarShopping(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<BuscaShoppingViewModel> GetAllShoppings(int idEstudio, string categoria)
        {
            throw new System.NotImplementedException();
        }

        public Task<Shopping> GetFotoById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Shopping>> GetShoppingByIdEstudio(int idEstudio)
        {
            return await _repository.GetShoppingByIdEstudio(idEstudio);
        }

        public Task<Shopping> GetShoppingByNomeFoto(string nomeFoto, int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<Shopping> UpdateShopping(Shopping shopping)
        {
            throw new System.NotImplementedException();
        }
    }
}
