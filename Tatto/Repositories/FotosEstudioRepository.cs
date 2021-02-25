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


    public interface IFotosEstudioRepository
    {
        Task<IList<FotosEstudio>> GetFotosEstudioByIdEstudio(string id);
        Task<FotosEstudio> GetFotosEstudioByNomeFoto(string nomeFoto, string idEstudio);
        Task<BuscaFotosEstudioViewModel> GetAllFotosEstudio(string pesquisa);

        Task<FotosEstudio> GetFotoById(int id);

        Task<FotosEstudio> DeletarFoto(int id);

        Task<FotosEstudio> UpdateFoto(FotosEstudio foto);
    }
    public class FotosEstudioRepository : BaseRepository<FotosEstudio>, IFotosEstudioRepository
    {
        public FotosEstudioRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        FotosEstudio foto = new FotosEstudio();

        public async Task<IList<FotosEstudio>> GetFotosEstudioByIdEstudio(string idEstudio)
        {
            return await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
        }

        public async Task<FotosEstudio> GetFotosEstudioByNomeFoto(string nomeFoto, string idEstudio)
        {
            foto =
                await dbSet.Where(c => c.ImageName == nomeFoto)
                           .Where(c => c.IdEstudio == idEstudio)
                                .SingleOrDefaultAsync();
            return foto;
        }

        public async Task<BuscaFotosEstudioViewModel> GetAllFotosEstudio(string pesquisa)
        {
            var query = await dbSet.ToListAsync();

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = await dbSet.Where(q => q.IdEstudio == pesquisa).ToListAsync();
            }

            return new BuscaFotosEstudioViewModel(query);
        }

        public async Task<FotosEstudio> DeletarFoto(int id)
        {
            var foto =
                 await dbSet.Where(c => c.Id == id)
                                .SingleOrDefaultAsync();

            dbSet.Remove(foto);

            await contexto.SaveChangesAsync();

            return foto;
        }

        public async Task<FotosEstudio> GetFotoById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<FotosEstudio> UpdateFoto(FotosEstudio foto)
        {
            var cadastroDB = 
                await dbSet.Where(c => c.Id == foto.Id)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                dbSet.Add(foto);
                await contexto.SaveChangesAsync(); 
            }
            else
            {
                cadastroDB.Update(foto); 
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;
        }


    }

}
