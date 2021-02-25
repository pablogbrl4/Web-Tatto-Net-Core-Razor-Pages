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


    public class ShoppingRepository : BaseRepositorio<Shopping>, IShoppingRepository
    {
        public ShoppingRepository(BaseContexto contexto) : base(contexto)
        {
        }

        Shopping shopping = new Shopping();

        public async Task<Shopping> DeletarShopping(int id)
        {
            shopping =
                 await _dbSet.Where(c => c.Id == id)
                                .SingleOrDefaultAsync();

            _dbSet.Remove(shopping);

            await _context.SaveChangesAsync();

            return shopping;
        }

        public async Task<BuscaShoppingViewModel> GetAllShoppings(int idEstudio, string categoria)
        {
            IList<Shopping> query ;

            if (categoria == "Todos")
            {
                query = await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (!String.IsNullOrEmpty(categoria))
            {
                query = await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio))
                                   .Where(q => q.Categoria.Equals(categoria)).ToListAsync();
            }
            else
            {
                query = await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return new BuscaShoppingViewModel(query, categoria);
        }

        public async Task<Shopping> GetFotoById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<Shopping>> GetShoppingByIdEstudio(int idEstudio)
        {
            return await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
        }

        public async Task<Shopping> UpdateShopping(Shopping shopping)
        {
            var cadastroDB = 
                 await _dbSet.Where(c => c.Id == shopping.Id)
                 .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                _dbSet.Add(shopping);
                _context.SaveChanges(); 
            }
            else
            {
                cadastroDB.Update(shopping);// atualizar com novos dados do novo cadastro
                await _context.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<Shopping> GetShoppingByNomeFoto(string nomeFoto, int idEstudio)
        {
            shopping =
                await _dbSet.Where(c => c.ImageName == nomeFoto)
                           .Where(c => c.IdEstudio == idEstudio)
                                .SingleOrDefaultAsync();

            return shopping;
        }
    }
}
