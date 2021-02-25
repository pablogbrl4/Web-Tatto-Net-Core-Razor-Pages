using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.DTOs.ViewModels;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IShoppingApp : IBaseApp<Shopping, ShoppingDTO>
    {
        Task<IList<ShoppingDTO>> GetShoppingByIdEstudio(int idEstudio);
        Task<ShoppingDTO> GetFotoById(int id);
        Task<BuscaShoppingViewModelDTO> GetAllShoppings(int idEstudio, string categoria);
        Task<ShoppingDTO> GetShoppingByNomeFoto(string nomeFoto, int idEstudio);
    }
}
