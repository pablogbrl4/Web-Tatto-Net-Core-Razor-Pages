using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class BaseServico<T> : IBaseServico<T> where T : BaseModel
    {
        protected readonly IBaseRepositorio<T> _repositorio;

        public BaseServico(IBaseRepositorio<T> repositorio)
        {
            _repositorio = repositorio;
        }

        #region Escrita
        public async Task<int> Incluir(T entidade)
        {
            return await _repositorio.Incluir(entidade);
        }

        public async Task<T> Alterar(T entidade)
        {
            return await _repositorio.Alterar(entidade);
        }

        public async Task<bool> Excluir(int id)
        {
            return await _repositorio.Excluir(id);
        }

        #endregion


        #region Leitura
        public async Task<T> BuscarPorId(int id)
        {
            return await _repositorio.BuscarPorId(id);
        }

        public async Task<T> BuscarComPesquisa(Expression<Func<T, bool>> expression)
        {
            return await _repositorio.BuscarComPesquisa(expression);
        }

        public async Task<IEnumerable<T>> BuscarTodos()
        {
            return await _repositorio.BuscarTodos();
        }

        public async Task<IEnumerable<T>> BuscarTodosComPesquisa(Expression<Func<T, bool>> expression)
        {
            return await _repositorio.BuscarTodosComPesquisa(expression);
        }



        #endregion
    }
}
