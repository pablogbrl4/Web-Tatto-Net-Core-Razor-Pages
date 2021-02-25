using AutoMapper;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Services
{
    public class BaseServicoApp<T, TDTO> : IBaseApp<T, TDTO>
         where T : BaseModel
         where TDTO : BaseEntidadeDTO
    {
        protected readonly IBaseServico<T> _service;
        protected readonly IMapper _mapper;

        public BaseServicoApp(
            IBaseServico<T> service,
            IMapper mapper) : base()
        {
            _service = service;
            _mapper = mapper;
        }

        #region Leitura
        public async Task<TDTO> BuscarPorId(int id)
        {
            return _mapper.Map<TDTO>(await _service.BuscarPorId(id));
        }

        public async Task<IEnumerable<TDTO>> BuscarTodos()
        {
            return _mapper.Map<IEnumerable<TDTO>>(await _service.BuscarTodos());
        }

        public async Task<IEnumerable<TDTO>> BuscarTodosComPesquisa(Expression<Func<T, bool>> expression)
        {
            return _mapper.Map<IEnumerable<TDTO>>(await _service.BuscarTodosComPesquisa(expression));
        }

        public async Task<TDTO> BuscarComPesquisa(Expression<Func<T, bool>> expression)
        {
            return _mapper.Map<TDTO>(await _service.BuscarComPesquisa(expression));
        }
        #endregion

        #region Escrita
        public async Task<int> Incluir(TDTO entidade)
        {
            return await _service.Incluir(_mapper.Map<T>(entidade));
        }

        public async Task<TDTO> Alterar(TDTO entidade)
        {
            return _mapper.Map<TDTO>(await _service.Alterar(_mapper.Map<T>(entidade)));
        }

        public async Task<bool> Excluir(int id)
        {
            return await _service.Excluir(id);
        }
        #endregion

    }
}
