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

    public interface IShoppingRepository
    {
        Task<IList<Shopping>> GetShoppingByIdEstudio(int idEstudio);
        Task<Shopping> GetFotoById(int id);
        Task<BuscaShoppingViewModel> GetAllShoppings(string idEstudio, string categoria);
        Task<Shopping> DeletarShopping(int id);
        Task<Shopping> UpdateShopping(Shopping shopping);
        Task<Shopping> GetShoppingByNomeFoto(string nomeFoto, string idEstudio);
    }
    public class ShoppingRepository : BaseRepository<Shopping>, IShoppingRepository
    {
        public ShoppingRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        Shopping shopping = new Shopping();

        public async Task<Shopping> DeletarShopping(int id)
        {
            shopping =
                 await dbSet.Where(c => c.Id == id)
                                .SingleOrDefaultAsync();

            dbSet.Remove(shopping);

            await contexto.SaveChangesAsync();

            return shopping;
        }

        public async Task<BuscaShoppingViewModel> GetAllShoppings(string idEstudio, string categoria)
        {
            IList<Shopping> query ;

            if (categoria == "Todos")
            {
                query = await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }
            else if (!String.IsNullOrEmpty(categoria))
            {
                query = await dbSet.Where(q => q.IdEstudio.Equals(idEstudio))
                                   .Where(q => q.Categoria.Equals(categoria)).ToListAsync();
            }
            else
            {
                query = await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return new BuscaShoppingViewModel(query, categoria);
        }

        public async Task<Shopping> GetFotoById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IList<Shopping>> GetShoppingByIdEstudio(int idEstudio)
        {
            return await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
        }

        public async Task<Shopping> UpdateShopping(Shopping shopping)
        {
            var cadastroDB = 
                 await dbSet.Where(c => c.Id == shopping.Id)
                 .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                dbSet.Add(shopping); 
                contexto.SaveChanges(); 
            }
            else
            {
                cadastroDB.Update(shopping);// atualizar com novos dados do novo cadastro
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<Shopping> GetShoppingByNomeFoto(string nomeFoto, string idEstudio)
        {
            shopping =
                await dbSet.Where(c => c.ImageName == nomeFoto)
                           .Where(c => c.IdEstudio == idEstudio)
                                .SingleOrDefaultAsync();

            return shopping;
        }
    }
}
