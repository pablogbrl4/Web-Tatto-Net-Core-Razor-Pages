using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infra.Data.Contexto;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;

namespace ProjectTemplate.Infra.Data.Repositories
{
  
    public class AgendaRepository : BaseRepositorio<Agenda>, IAgendaRepository
    {
        public AgendaRepository(BaseContexto context) : base(context)
        {
        }

        public Agenda GetAgendaByIdAgenda(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(Agenda novoCadastroAgenda)
        {
            _dbSet.Add(novoCadastroAgenda);
            _context.SaveChanges();
        }

        public async Task<Agenda> Update(Agenda novoCadastroAgenda)
        {
            var cadastroDB =
                await _dbSet.Where(c => c.Id == novoCadastroAgenda.Id)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                Insert(novoCadastroAgenda);
            }
            else
            {
                cadastroDB.Update(novoCadastroAgenda);
                await _context.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<IList<Agenda>> GetAgendasAsync(int id)
        {
            if (id != 0)
            {
                return await _dbSet.Where(q => q.Id.Equals(id)).ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public async Task<IList<Agenda>> GetAgendasByIdEstudio(int idEstudio)
        {
            if (idEstudio != 0)
            {
                return await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public async Task<IList<Agenda>> GetAgendasByIdCliente(int idCliente)
        {
            if (idCliente != 0)
            {
                return await _dbSet.Where(q => q.IdCliente.Equals(idCliente)).ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public async Task<IList<Agenda>> GetAgendasByIdTatuador(int idTatuador)
        {
            if (idTatuador != 0)
            {
                return await _dbSet.Where(q => q.IdTatuador.Equals(idTatuador)).ToListAsync();
            }

            return null;
        }

        public async Task<IList<Agenda>> GetAgendasByIdClienteAndCliente(int idCliente, int idEstudio)
        {
            if (idEstudio != 0 && idCliente != 0)
            {
                return await _dbSet.Where(q => q.IdCliente.Equals(idCliente))
                                  .Where(q => q.IdEstudio.Equals(idEstudio))
                                  .ToListAsync();
            }

            return null;
        }

        public async Task<Agenda> Delete(int idagenda)
        {
            var agenda =
                 await _dbSet.Where(c => c.Id == idagenda)
                                .SingleOrDefaultAsync();

            _dbSet.Remove(agenda);

            await _context.SaveChangesAsync();

            return agenda;
        }

    }
}
