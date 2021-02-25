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
    public class FotoTattoRepository : BaseRepositorio<FotoTatto>, IFotoTattoRepository
    {
        public FotoTattoRepository(BaseContexto contexto) : base(contexto)
        {
        }

        FotoTatto foto = new FotoTatto();
        public async Task<IList<FotoTatto>> GetFotosTattoByIdEstudio(int idEstudio)
        {
            return await _dbSet.Where(q => q.IdEstudio == idEstudio).ToListAsync();
        }

        public async Task<BuscaTatuagensViewModel> GetAllFotosTatto(string estilo, string parteCorpo, string genero = "", string cor = "")
        {
            IList<FotoTatto> query;

            if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.ToListAsync();
            }

            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo)).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }


            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }

            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo)).ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.Genero.Equals(genero)).ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.Cor.Equals(cor)).ToListAsync();
            }

            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.Genero.Equals(genero))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo) && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.Genero.Equals(genero))
                                   .ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo) && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(cor))
            {
                query = await _dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.Cor.Equals(cor))
                                   .ToListAsync();
            }

            else
            {
                query = await _dbSet.ToListAsync();
            }

            return new BuscaTatuagensViewModel(query, estilo, parteCorpo, genero, cor);
        }

        public async Task<BuscaTatuagensViewModel> GetFotosTattoByIdEstudio(int idEstudio, string estilo, string parteCorpo)
        {
            IList<FotoTatto> query;

            if (string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo))
            {
                query = await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo))
            {
                query = await _dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && string.IsNullOrEmpty(parteCorpo))
            {
                query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (!string.IsNullOrEmpty(estilo) && !string.IsNullOrEmpty(parteCorpo))
            {
                query = await _dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else
            {
                query = await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return new BuscaTatuagensViewModel(query, estilo, parteCorpo);
        }

        public async Task<FotoTatto> DeletarFoto(int id)
        {
            foto =
                 await _dbSet.Where(c => c.Id == id)
                                .SingleOrDefaultAsync();

            _dbSet.Remove(foto);

            await _context.SaveChangesAsync();

            return foto;
        }

        public async Task<FotoTatto> GetFotoById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<FotoTatto> UpdateFoto(FotoTatto foto)
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                await _dbSet.Where(c => c.Id == foto.Id)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                _dbSet.Add(foto); //  Adiciona no Banco
                _context.SaveChanges(); // Salva no Banco 
            }
            else
            {
                cadastroDB.Update(foto); // atualizar com novos dados do novo cadastro
                await _context.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<FotoTatto> GetFotoTattoByNomeFoto(string nomeFoto, int idEstudio)
        {
            foto =
                await _dbSet.Where(c => c.ImageName == nomeFoto)
                           .Where(c => c.IdEstudio == idEstudio)
                                .SingleOrDefaultAsync();

            return foto;
        }

        public async Task<IList<FotoTatto>> GetFotosByIdTatuador(int idTatuador)
        {
            IList<FotoTatto> query;
            query = await _dbSet.Where(q => q.IdTatuador.Equals(idTatuador)).ToListAsync();
            return query;
        }

        public async Task<IList<FotoTatto>> GetFotosTattosByIdEstudio(int idEstudio, string estilo, string parteCorpo)
        {
            IList<FotoTatto> query;


            if (string.IsNullOrEmpty(estilo))
            {
                if (string.IsNullOrEmpty(parteCorpo))
                {
                    query = await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
                }
                else
                {
                    query = await _dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(parteCorpo))
                {
                    query = await _dbSet.Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
                }
                else
                {
                    query = await _dbSet.Where(q => q.ParteDoCorpo.Equals(parteCorpo))
                                   .Where(q => q.EstiloTatto.Equals(estilo))
                                   .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
                }
            }

            return query;
        }
    }
}
