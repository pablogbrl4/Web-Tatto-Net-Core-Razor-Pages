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


    public interface IEstudio_TatuadorRepository
    {
        Task<IList<Estudio_Tatuador>> getEstudiosTatuadores();
        Task<IList<Estudio_Tatuador>> GetIdsByIdEstudio(string idEstudio);
        Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdEstudio(string idEstudio);
        Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdTatuador(string idTatuador);
        Task<Estudio_Tatuador> RemoverEstudioTatuador(int id);
        Task<Estudio_Tatuador> InsertByIds(string idTatuador, string idEstudio);
    }
    public class Estudio_TatuadorRepository : BaseRepository<Estudio_Tatuador>, IEstudio_TatuadorRepository
    {
        public Estudio_TatuadorRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        Estudio_Tatuador estudioTatuador = new Estudio_Tatuador();

        public async Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdEstudio(string idEstudio)
        {
            return await dbSet.Where(q => q.IdEstudio.Contains(idEstudio)).ToListAsync();
        }

        public async Task<IList<Estudio_Tatuador>> GetEstudioTatuadorByIdTatuador(string idTatuador)
        {
            return await dbSet.Where(q => q.IdTatuador.Contains(idTatuador)).ToListAsync();
        }

        public async Task<IList<Estudio_Tatuador>> GetIdsByIdEstudio(string idEstudio)
        {
            return await dbSet.Where(q => q.IdEstudio.Contains(idEstudio)).ToListAsync();
        }

        public async Task<Estudio_Tatuador> InsertByIds(string idTatuador, string idEstudio)
        {
            estudioTatuador.IdTatuador = idTatuador;
            estudioTatuador.IdEstudio = idEstudio;

            var apagarContato =
                 await dbSet.Where(c => c.IdEstudio == estudioTatuador.IdEstudio)
                            .Where(c => c.IdTatuador == estudioTatuador.IdTatuador)
                                .SingleOrDefaultAsync();

            if (apagarContato == null)
            {
                await dbSet.AddAsync(estudioTatuador);
                await contexto.SaveChangesAsync();
            }

            return estudioTatuador;
        }

        public async Task<Estudio_Tatuador> RemoverEstudioTatuador(int id)
        {
            var apagarContato =
                 await dbSet.Where(c => c.Id == id)
                                .SingleOrDefaultAsync();

            dbSet.Remove(apagarContato);

            await contexto.SaveChangesAsync();

            return estudioTatuador;
        }

        public async Task<IList<Estudio_Tatuador>> getEstudiosTatuadores()
        {
            return await dbSet.ToListAsync();
        }
    }
}
