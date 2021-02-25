using System.Linq;
using System.Threading.Tasks;
using Tatto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tatto.Models.ViewModels;

namespace Tatto.Repositories
{
    public interface IFotoTattoRepository
    {
        Task<IList<FotoTatto>> GetFotosTattoByIdEstudio(string id);

        Task<BuscaTatuagensViewModel> GetAllFotosTatto(string estilo, string parteCorpo, string genero = "", string cor = "");
        Task<BuscaTatuagensViewModel> GetFotosTattoByIdEstudio(string idEstudio, string estilo, string parteCorpo);

        Task<IList<FotoTatto>> GetFotosTattosByIdEstudio(string idEstudio, string estilo, string parteCorpo);

        Task<IList<FotoTatto>> GetFotosByIdTatuador(string idTatuador);

        Task<FotoTatto> GetFotoById(int id);

        Task<FotoTatto> DeletarFoto(int id);

        Task<FotoTatto> UpdateFoto(FotoTatto foto);

        Task<FotoTatto> GetFotoTattoByNomeFoto(string nomeFoto, string idEstudio);
    }
    public class FotoTattoRepository : BaseRepository<FotoTatto>, IFotoTattoRepository
    {
        public FotoTattoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        FotoTatto foto = new FotoTatto();
        public async Task<IList<FotoTatto>> GetFotosTattoByIdEstudio(string idEstudio)
        {
            return await dbSet.Where(q => q.IdEstudio == idEstudio).ToListAsync();
        }

        public async Task<BuscaTatuagensViewModel> GetAllFotosTatto(string estilo, string parteCorpo, string genero = "", string cor = "")
        {
            IList<FotoTatto> query;

            if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.ToListAsync();
            }

            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo)).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }


            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }

            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo)).ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.Genero.Equals(genero)).ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.Cor.Equals(cor)).ToListAsync();
            }

            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.Genero.Equals(genero))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }

            else
            {
                query = await dbSet.ToListAsync();
            }

            return new BuscaTatuagensViewModel(query, estilo, parteCorpo, genero, cor);
        }

        public async Task<BuscaTatuagensViewModel> GetFotosTattoByIdEstudio(string idEstudio, string estilo, string parteCorpo)
        {
            IList<FotoTatto> query;

            if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo))
            {
                query = await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo))
            {
                query = await dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo))
            {
                query = await dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else
            {
                query = await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return new BuscaTatuagensViewModel(query, estilo, parteCorpo);
        }

        public async Task<FotoTatto> DeletarFoto(int id)
        {
            foto =
                 await dbSet.Where(c => c.Id == id)
                                .SingleOrDefaultAsync();

            dbSet.Remove(foto);

            await contexto.SaveChangesAsync();

            return foto;
        }

        public async Task<FotoTatto> GetFotoById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<FotoTatto> UpdateFoto(FotoTatto foto)
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                await dbSet.Where(c => c.Id == foto.Id)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                dbSet.Add(foto); //  Adiciona no Banco
                contexto.SaveChanges(); // Salva no Banco 
            }
            else
            {
                cadastroDB.Update(foto); // atualizar com novos dados do novo cadastro
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<FotoTatto> GetFotoTattoByNomeFoto(string nomeFoto, string idEstudio)
        {
            foto =
                await dbSet.Where(c => c.ImageName == nomeFoto)
                           .Where(c => c.IdEstudio == idEstudio)
                                .SingleOrDefaultAsync();

            return foto;
        }

        public async Task<IList<FotoTatto>> GetFotosByIdTatuador(string idTatuador)
        {
            IList<FotoTatto> query;
            query = await dbSet.Where(q => q.IdTatuador.Equals(idTatuador)).ToListAsync();
            return query;
        }

        public async Task<IList<FotoTatto>> GetFotosTattosByIdEstudio(string idEstudio, string estilo, string parteCorpo)
        {
            IList<FotoTatto> query;

            if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo))
            {
                query = await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo))
            {
                query = await dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo))
            {
                query = await dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo))
            {
                query = await dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else
            {
                query = await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return query;
        }
    }
}
