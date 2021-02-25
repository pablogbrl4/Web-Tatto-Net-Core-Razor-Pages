using AutoMapper;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.DTOs.ViewModels;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Services
{
    public class ShoppingServiceApp: BaseServicoApp<Shopping, ShoppingDTO>, IShoppingApp
    {
        protected readonly IShoppingService _servico;

        public ShoppingServiceApp(IShoppingService servico, IMapper mapper) : base (servico, mapper)
        {
            _servico = servico;
        }

        public Task<BuscaShoppingViewModelDTO> GetAllShoppings(int idEstudio, string categoria)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingDTO> GetFotoById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ShoppingDTO>> GetShoppingByIdEstudio(int idEstudio)
        {
            return _mapper.Map<IList<ShoppingDTO>>(await _servico.GetShoppingByIdEstudio(idEstudio));
        }

        public Task<ShoppingDTO> GetShoppingByNomeFoto(string nomeFoto, int idEstudio)
        {
            throw new NotImplementedException();
        }
    }
}
