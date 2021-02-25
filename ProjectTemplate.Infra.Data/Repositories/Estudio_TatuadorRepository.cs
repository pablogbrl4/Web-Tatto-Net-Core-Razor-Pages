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

    public class Estudio_TatuadorRepository : BaseRepositorio<Estudio_Tatuador>, IEstudio_TatuadorRepository
    {
        public Estudio_TatuadorRepository(BaseContexto contexto) : base(contexto)
        {
        }

        Estudio_Tatuador estudioTatuador = new Estudio_Tatuador();

        public async Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdEstudio(int idEstudio)
        {
            return await _dbSet.Where(q => q.IdEstudio == idEstudio).ToListAsync();
        }

        public async Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdTatuador(int idTatuador)
        {
            return await _dbSet.Where(q => q.IdTatuador.Equals(idTatuador)).ToListAsync();
        }

        public async Task<IList<Estudio_Tatuador>> GetIdsByIdEstudio(int idEstudio)
        {
            return await _dbSet.Where(q => q.IdEstudio == idEstudio).ToListAsync();
        }

        public async Task<Estudio_Tatuador> InsertByIds(int idTatuador, int idEstudio)
        {
            estudioTatuador.IdTatuador = idTatuador;
            estudioTatuador.IdEstudio = idEstudio;

            var apagarContato =
                 await _dbSet.Where(c => c.IdEstudio == estudioTatuador.IdEstudio)
                            .Where(c => c.IdTatuador == estudioTatuador.IdTatuador)
                                .SingleOrDefaultAsync();

            if (apagarContato == null)
            {
                await _dbSet.AddAsync(estudioTatuador);
                await _context.SaveChangesAsync();
            }

            return estudioTatuador;
        }

        public async Task<Estudio_Tatuador> RemoverEstudioTatuador(int id)
        {
            var apagarContato =
                 await _dbSet.Where(c => c.Id == id)
                                .SingleOrDefaultAsync();

            _dbSet.Remove(apagarContato);

            await _context.SaveChangesAsync();

            return estudioTatuador;
        }

        public async Task<IList<Estudio_Tatuador>> getEstudiosTatuadores()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
