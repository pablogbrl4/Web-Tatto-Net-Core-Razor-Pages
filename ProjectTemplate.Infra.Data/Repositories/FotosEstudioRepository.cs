using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infra.Data.Contexto;
using ProjectTemplate.Domain.Entities.ViewModels;
using ProjectTemplate.Domain.Interfaces.Repositories;

namespace ProjectTemplate.Infra.Data.Repositories
{

    public class FotosEstudioRepository : BaseRepositorio<FotosEstudio>, IFotosEstudioRepository
    {
        public FotosEstudioRepository(BaseContexto contexto) : base(contexto)
        {
        }

        FotosEstudio foto = new FotosEstudio();

        public async Task<IList<FotosEstudio>> GetFotosEstudioByIdEstudio(int idEstudio)
        {
            return await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
        }

        public async Task<FotosEstudio> GetFotosEstudioByNomeFoto(string nomeFoto, int idEstudio)
        {
            foto =
                await _dbSet.Where(c => c.ImageName == nomeFoto)
                           .Where(c => c.IdEstudio == idEstudio)
                                .SingleOrDefaultAsync();
            return foto;
        }

        public async Task<BuscaFotosEstudioViewModel> GetAllFotosEstudio(int IdEstudio)
        {
            var query = await _dbSet.ToListAsync();

            if (IdEstudio != 0)
            {
                query = await _dbSet.Where(q => q.IdEstudio == IdEstudio).ToListAsync();
            }

            return new BuscaFotosEstudioViewModel(query);
        }

        public async Task<FotosEstudio> DeletarFoto(int id)
        {
            var foto =
                 await _dbSet.Where(c => c.Id == id)
                                .SingleOrDefaultAsync();

            _dbSet.Remove(foto);

            await _context.SaveChangesAsync();

            return foto;
        }

        public async Task<FotosEstudio> GetFotoById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<FotosEstudio> UpdateFoto(FotosEstudio foto)
        {
            var cadastroDB = 
                await _dbSet.Where(c => c.Id == foto.Id)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                _dbSet.Add(foto);
                await _context.SaveChangesAsync(); 
            }
            else
            {
                cadastroDB.Update(foto); 
                await _context.SaveChangesAsync();
            }

            return cadastroDB;
        }


    }

}
