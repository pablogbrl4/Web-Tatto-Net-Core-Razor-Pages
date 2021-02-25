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
    public interface IAgendaRepository
    {
        Task<Agenda> Update(Agenda agenda);
        Task<Agenda> Delete(int idagenda);
        Agenda GetAgendaByIdAgenda(int id);
        Task<IList<Agenda>> GetAgendasAsync(int pesquisa);
        Task<IList<Agenda>> GetAgendasByIdEstudio(string idEstudio);
        Task<IList<Agenda>> GetAgendasByIdUsuario(int idUsuario);
        Task<IList<Agenda>> GetAgendasByIdTatuador(string idTatuador);
        Task<IList<Agenda>> GetAgendasByIdUsuarioAndUsuario(int idUsuario, string idEstudio);
    }
    public class AgendaRepository : BaseRepository<Agenda>, IAgendaRepository
    {
        public AgendaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Agenda GetAgendaByIdAgenda(int id)
        {
            return dbSet.Find(id);
        }

        public void Insert(Agenda novoCadastroAgenda)
        {
            dbSet.Add(novoCadastroAgenda);
            contexto.SaveChanges();
        }

        public async Task<Agenda> Update(Agenda novoCadastroAgenda)
        {
            var cadastroDB =
                await dbSet.Where(c => c.Id == novoCadastroAgenda.Id)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                Insert(novoCadastroAgenda);
            }
            else
            {
                cadastroDB.Update(novoCadastroAgenda);
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<IList<Agenda>> GetAgendasAsync(int id)
        {
            if (id != 0)
            {
                return await dbSet.Where(q => q.Id.Equals(id)).ToListAsync();
            }

            return await dbSet.ToListAsync();
        }

        public async Task<IList<Agenda>> GetAgendasByIdEstudio(string idEstudio)
        {
            if (!string.IsNullOrEmpty(idEstudio))
            {
                return await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return await dbSet.ToListAsync();
        }

        public async Task<IList<Agenda>> GetAgendasByIdUsuario(int idUsuario)
        {
            if (idUsuario != 0)
            {
                return await dbSet.Where(q => q.IdUsuario.Equals(idUsuario)).ToListAsync();
            }

            return await dbSet.ToListAsync();
        }

        public async Task<IList<Agenda>> GetAgendasByIdTatuador(string idTatuador)
        {
            if (!String.IsNullOrEmpty(idTatuador))
            {
                return await dbSet.Where(q => q.IdTatuador.Equals(idTatuador)).ToListAsync();
            }

            return null;
        }

        public async Task<IList<Agenda>> GetAgendasByIdUsuarioAndUsuario(int idUsuario, string idEstudio)
        {
            if (!string.IsNullOrEmpty(idEstudio) && idUsuario != 0)
            {
                return await dbSet.Where(q => q.IdUsuario.Equals(idUsuario))
                                  .Where(q => q.IdEstudio.Equals(idEstudio))
                                  .ToListAsync();
            }

            return null;
        }

        public async Task<Agenda> Delete(int idagenda)
        {
            var agenda =
                 await dbSet.Where(c => c.Id == idagenda)
                                .SingleOrDefaultAsync();

            dbSet.Remove(agenda);

            await contexto.SaveChangesAsync();

            return agenda;
        }

    }
}
