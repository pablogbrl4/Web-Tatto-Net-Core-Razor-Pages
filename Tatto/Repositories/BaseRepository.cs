using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tatto.Models;

namespace Tatto.Repositories
{
    public class BaseRepository<T> where T : BaseModel  // T é um tipo generico
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> dbSet; // Uma versão não genérica do DbSet<TEntity> que pode ser usada quando o tipo de entidade não é conhecido no momento da criação.

        public BaseRepository(ApplicationContext contexto) // construtor
        {
            this.contexto = contexto;
            dbSet = contexto.Set<T>();
        }
    }
}
