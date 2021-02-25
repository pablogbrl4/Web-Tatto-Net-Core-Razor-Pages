using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Interfaces
{
    public interface IBaseApp<T, TDTO> where T : BaseModel where TDTO : BaseEntidadeDTO
    {
        #region Escrita
        Task<int> Incluir(TDTO entidade);

        Task<TDTO> Alterar(TDTO entidade);

        Task<bool> Excluir(int id);
        #endregion


        #region Leitura
        Task<TDTO> BuscarPorId(int id);

        Task<IEnumerable<TDTO>> BuscarTodos();

        Task<IEnumerable<TDTO>> BuscarTodosComPesquisa(Expression<Func<T, bool>> expression);

        Task<TDTO> BuscarComPesquisa(Expression<Func<T, bool>> expression);

        #endregion
    }
}
