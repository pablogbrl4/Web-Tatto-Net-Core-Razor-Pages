using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Infra.Data.Repositories
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : BaseModel
    {
        protected readonly BaseContexto _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepositorio(BaseContexto context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        #region Leitura

        public async Task<T> BuscarPorId(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> BuscarTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> BuscarTodosComPesquisa(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> BuscarComPesquisa(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).SingleOrDefaultAsync();
        }

        #endregion

        #region Escrita

        public async Task<int> Incluir(T entidade)
        {
            await _context.IniciarTransaction();
            var obj = await _dbSet.AddAsync(entidade);
            await _context.SalvarMudancas();
            return obj.Entity.Id;
        }

        public async Task<T> Alterar(T entidade)
        {
            await _context.IniciarTransaction();
            _context.Entry(entidade).State = EntityState.Modified;
            await _context.SalvarMudancas();
            return entidade;
        }

        public async Task<bool> Excluir(int id)
        {
            try
            {
                var entidade = await BuscarPorId(id);
                if (entidade != null)
                {
                    await _context.IniciarTransaction();
                    _dbSet.Remove(entidade);
                    await _context.SalvarMudancas();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
