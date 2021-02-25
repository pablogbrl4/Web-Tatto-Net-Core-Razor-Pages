using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infra.Data.Contexto;
using ProjectTemplate.Domain.Interfaces.Repositories;

namespace ProjectTemplate.Infra.Data.Repositories
{ 
    public class DepoimentosRepository : BaseRepositorio<Depoimentos>, IDepoimentosRepository
    {
        public DepoimentosRepository(BaseContexto contexto) : base(contexto)
        {
        }

        public async Task<IList<Depoimentos>> GetDepoimentosByIdEstudio(int idEstudio)
        {
            return await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
        }
    }
}
