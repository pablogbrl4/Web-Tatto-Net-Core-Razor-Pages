using System.Linq;
using System.Threading.Tasks;
using Tatto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tatto.Models.ViewModels;

namespace Tatto.Repositories
{
    public interface ITatuadorRepository
    {
        Task<Tatuador> Delete(int? id);
        Task<Tatuador> Update(Tatuador novoCadastroTatuador);
        Task<IList<Tatuador>> GetTatuador();
        Task<Tatuador> GetTatuadorById(string id);
        Task<Tatuador> GetTatuadorByCpf(string cpf);
        Task<BuscaTatuadorViewModel> GetTatuadoresAsync(string pesquisa);
        Task<Tatuador> GetTatuadorByIdTatuador(string idTatuador);

        Task<string> GetIdTatuadorByNomeUsuario(string nomeUsuario);

        Task<Tatuador> UpdateByCpf(Tatuador tatuador);
        Task<Tatuador> GetTatuadorByEmail(string emailTatuador);


        Task<Tatuador> idNaoNull(string idEstudio);
        Task<Tatuador> InsertNew(string Email, string Id, string UserName);
    }
    public class TatuadorRepository : BaseRepository<Tatuador>, ITatuadorRepository
    {
        public TatuadorRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        Tatuador tatuador = new Tatuador();

        public async Task<Tatuador> idNaoNull(string idTatuador)
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                 await dbSet.Where(c => c.IdTatuador == idTatuador)
                 .SingleOrDefaultAsync();

            return cadastroDB;
        }

        public async Task<Tatuador> InsertNew(string Email, string Id, string UserName)
        {
            tatuador.Email = Email;
            tatuador.IdTatuador = Id;
            tatuador.PrimeiroNome = UserName;

            tatuador.NomeDeUsuario = Email;

            tatuador.CPF = null;

            tatuador.Telefone = "";
            tatuador.Sexo = "";
            tatuador.DataDeNascimento = "";

            tatuador.OutroTelefone = "";
            tatuador.SobrenomeCompleto = "";
            tatuador.TextoBibliografico = "";

            await dbSet.AddAsync(tatuador);
            await contexto.SaveChangesAsync();

            return tatuador;
        }


        public async Task<Tatuador> Insert(Tatuador tatuador)
        {
            await dbSet.AddAsync(tatuador); //  Deleta do Banco
            await contexto.SaveChangesAsync(); // Salva no Banco

            return tatuador;
        }

        public async Task<Tatuador> Delete(int? id)
        {
            tatuador = dbSet.Find(id);

            dbSet.Remove(tatuador); //  Exclui no Banco
            await contexto.SaveChangesAsync(); // Salva no Banco

            return tatuador;
        }

        public async Task<Tatuador> Update(Tatuador tatuador) // atualiza usuário
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                await dbSet.Where(c => c.IdTatuador == tatuador.IdTatuador)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(tatuador); // Insere com novos dados do novo cadastro       
            }
            else
            {
                cadastroDB.Update(tatuador); // atualizar com novos dados do novo cadastro
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<IList<Tatuador>> GetTatuador()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Tatuador> GetTatuadorById(string id)
        {
            tatuador =
                await dbSet.Where(c => c.IdTatuador == id)
                .SingleOrDefaultAsync();

            return tatuador;
        }

        public async Task<BuscaTatuadorViewModel> GetTatuadoresAsync(string pesquisa)
        {
            IQueryable<Tatuador> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.PrimeiroNome.Contains(pesquisa));
            }

            return new BuscaTatuadorViewModel(await query.ToListAsync());
        }

        public async Task<BuscaTatuadorViewModel> GetEstudioTutuadorByIdEstudio(string pesquisa)
        {
            IQueryable<Tatuador> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.IdTatuador.Contains(pesquisa));
            }

            return new BuscaTatuadorViewModel(await query.ToListAsync());
        }

        public async Task<Tatuador> GetTatuadorByCpf(string cpf)
        {
            tatuador =
                await dbSet.Where(c => c.CPF == cpf)
                .SingleOrDefaultAsync();

            return tatuador;
        }

        public async Task<Tatuador> GetTatuadorByIdTatuador(string idTatuador)
        {
            tatuador =
                await dbSet.Where(c => c.IdTatuador == idTatuador)
                   .SingleOrDefaultAsync();

            return tatuador;
        }

        public async Task<Tatuador> UpdateByCpf(Tatuador tatuador)
        {
            var cadastroDB =
                await dbSet.Where(c => c.CPF == tatuador.CPF)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(tatuador);
            }
            else
            {
                cadastroDB.Update(tatuador);
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;

        }

        public async Task<Tatuador> GetTatuadorByEmail(string emailTatuador)
        {
            tatuador =
                await dbSet.Where(c => c.Email == emailTatuador)
                    .SingleOrDefaultAsync();

            return tatuador;
        }

        public async Task<string> GetIdTatuadorByNomeUsuario(string nomeUsuario)
        {
            tatuador =
              await dbSet.Where(c => c.NomeDeUsuario == nomeUsuario)
                  .SingleOrDefaultAsync();

            if (tatuador == null)
            {
                return null;
            }

            return tatuador.IdTatuador;
        }
    }
}
