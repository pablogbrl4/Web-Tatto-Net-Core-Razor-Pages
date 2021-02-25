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

    public class TatuadorRepository : BaseRepositorio<Tatuador>, ITatuadorRepository
    {
        public TatuadorRepository(BaseContexto contexto) : base(contexto)
        {
        }

        Tatuador tatuador = new Tatuador();

        public async Task<Tatuador> idNaoNull(int idTatuador)
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                 await _dbSet.Where(c => c.IdTatuador == idTatuador)
                 .SingleOrDefaultAsync();

            return cadastroDB;
        }

        public async Task<Tatuador> InsertNew(string Email, int IdTatuador, string UserName)
        {
            tatuador.Email = Email;
            tatuador.IdTatuador = IdTatuador;
            tatuador.PrimeiroNome = UserName;

            tatuador.NomeDeUsuario = Email;

            tatuador.CPF = null;

            tatuador.Telefone = "";
            tatuador.Sexo = "";
            tatuador.DataDeNascimento = "";

            tatuador.OutroTelefone = "";
            tatuador.SobrenomeCompleto = "";
            tatuador.TextoBibliografico = "";

            await _dbSet.AddAsync(tatuador);
            await _context.SaveChangesAsync();

            return tatuador;
        }


        public async Task<Tatuador> Insert(Tatuador tatuador)
        {
            await _dbSet.AddAsync(tatuador); //  Deleta do Banco
            await _context.SaveChangesAsync(); // Salva no Banco

            return tatuador;
        }

        public async Task<Tatuador> Delete(int? id)
        {
            tatuador = _dbSet.Find(id);

            _dbSet.Remove(tatuador); //  Exclui no Banco
            await _context.SaveChangesAsync(); // Salva no Banco

            return tatuador;
        }

        public async Task<Tatuador> Update(Tatuador tatuador) // atualiza usuário
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                await _dbSet.Where(c => c.IdTatuador == tatuador.IdTatuador)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(tatuador); // Insere com novos dados do novo cadastro       
            }
            else
            {
                cadastroDB.Update(tatuador); // atualizar com novos dados do novo cadastro
                await _context.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<IList<Tatuador>> GetTatuador()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Tatuador> GetTatuadorById(string id)
        {
            tatuador =
                await _dbSet.Where(c => c.IdTatuador.Equals(id))
                .SingleOrDefaultAsync();

            return tatuador;
        }

        public async Task<BuscaTatuadorViewModel> GetTatuadoresAsync(string pesquisa)
        {
            IQueryable<Tatuador> query = _dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.PrimeiroNome.Contains(pesquisa));
            }

            return new BuscaTatuadorViewModel(await query.ToListAsync());
        }

        public async Task<BuscaTatuadorViewModel> GetEstudioTutuadorByIdEstudio(int IdTatuador)
        {
            IQueryable<Tatuador> query = _dbSet;

            if (IdTatuador != 0)
            {
                query = query.Where(q => q.IdTatuador.Equals(IdTatuador));
            }

            return new BuscaTatuadorViewModel(await query.ToListAsync());
        }

        public async Task<Tatuador> GetTatuadorByCpf(string cpf)
        {
            tatuador =
                await _dbSet.Where(c => c.CPF == cpf)
                .SingleOrDefaultAsync();

            return tatuador;
        }

        public async Task<Tatuador> GetTatuadorByIdTatuador(int idTatuador)
        {
            tatuador =
                await _dbSet.Where(c => c.IdTatuador == idTatuador)
                   .SingleOrDefaultAsync();

            return tatuador;
        }

        public async Task<Tatuador> UpdateByCpf(Tatuador tatuador)
        {
            var cadastroDB =
                await _dbSet.Where(c => c.CPF == tatuador.CPF)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(tatuador);
            }
            else
            {
                cadastroDB.Update(tatuador);
                await _context.SaveChangesAsync();
            }

            return cadastroDB;

        }

        public async Task<Tatuador> GetTatuadorByEmail(string emailTatuador)
        {
            tatuador =
                await _dbSet.Where(c => c.Email == emailTatuador)
                    .SingleOrDefaultAsync();

            return tatuador;
        }

        public async Task<int> GetIdTatuadorByNomeCliente(string nomeCliente)
        {
            tatuador =
              await _dbSet.Where(c => c.NomeDeUsuario == nomeCliente)
                  .SingleOrDefaultAsync();

            if (tatuador == null)
            {
                return 0;
            }

            return tatuador.IdTatuador;
        }

        Task<string> ITatuadorRepository.GetIdTatuadorByNomeCliente(string nomeCliente)
        {
            throw new NotImplementedException();
        }

    }
}
