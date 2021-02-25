using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infra.Data.Contexto;
using ProjectTemplate.Domain.Interfaces.Repositories;

namespace ProjectTemplate.Infra.Data.Repositories
{
    public class ContatosRepository : BaseRepositorio<Contatos>, IContatosRepository
    {
        Contatos contato = new Contatos();

        public ContatosRepository(BaseContexto contexto) : base(contexto)
        {
        }

        public async Task<Contatos> InsertByIds(int idCliente, int idEstudio)
        {
            contato.IdCliente = idCliente;
            contato.IdEstudio = idEstudio;

            var apagarContato =
                 await _dbSet.Where(c => c.IdEstudio == contato.IdEstudio)
                            .Where(c => c.IdCliente == contato.IdCliente)
                                .SingleOrDefaultAsync();

            if (apagarContato == null)
            {
                await _dbSet.AddAsync(contato);
                await _context.SaveChangesAsync();
            }

            return contato;
        }

        public async Task<IList<Contatos>> GetContatosByIdEstudio(int idEstudio)
        {
            if (idEstudio != 0)
            {
                return await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return null;
        }

        public async Task<Contatos> RemoverContato(int idCliente, int idEstudio)
        {
            contato.IdCliente = idCliente;
            contato.IdEstudio = idEstudio;

            var apagarContato =
                 await _dbSet.Where(c => c.IdEstudio == contato.IdEstudio)
                            .Where(c => c.IdCliente == contato.IdCliente)
                                .SingleOrDefaultAsync();

            _dbSet.Remove(apagarContato);

            await _context.SaveChangesAsync();

            return contato;
        }

        public async Task<IList<Contatos>> GetContatosByidClienteAndIdEstudio(int idCliente, int idEstudio)
        {
            if (idCliente != 0 && idEstudio != 0)
            {
                return await _dbSet.Where(q => q.IdCliente.Equals(idCliente))
                                  .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return null;
        }
    }
}
