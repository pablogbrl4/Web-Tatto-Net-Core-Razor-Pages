using System;
using System.Linq;
using System.Threading.Tasks;
using Tatto.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;
using Tatto.Models.ViewModels;

namespace Tatto.Repositories
{

    public interface IDepoimentosRepository
    {
        Task<IList<Depoimentos>> GetDepoimentosByIdEstudio(string id);
    }
    public class DepoimentosRepository : BaseRepository<Depoimentos>, IDepoimentosRepository
    {
        public DepoimentosRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<IList<Depoimentos>> GetDepoimentosByIdEstudio(string idEstudio)
        {
            return await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
        }
    }
}
