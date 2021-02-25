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

    public class ClienteRepository : BaseRepositorio<Cliente>, IClienteRepository
    {
        public ClienteRepository(BaseContexto contexto) : base(contexto)
        {
        }

        Cliente usuario = new Cliente();
        public async Task<Cliente> idNaoNull(int idCliente)
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                 await _dbSet.Where(c => c.IdCliente == idCliente)
                 .SingleOrDefaultAsync();

            return cadastroDB;
        }

        public async Task<Cliente> InsertNew(string Email, int IdCliente, string UserName)
        {
            usuario.Email = Email;
            usuario.IdCliente = IdCliente;
            usuario.PrimeiroNome = UserName;

            usuario.Telefone = "";
            usuario.DataDeNascimento = "";
            usuario.Sexo = "";
            usuario.SobrenomeCompleto = "";
            usuario.OutroTelefone = "";
            usuario.CPF = null;

            usuario.CEP = "";
            usuario.Endereco = "";
            usuario.Numero = "";
            usuario.Bairro = "";
            usuario.Complemento = "";
            usuario.Cidade = "";
            usuario.UF = "";

            await _dbSet.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }


        public async Task<Cliente> Insert(Cliente novoCadastroCliente)
        {
            await _dbSet.AddAsync(novoCadastroCliente);
            await _context.SaveChangesAsync();

            return novoCadastroCliente;
        }

        public void Delete(string id)
        {
            var idCliente = _dbSet.Find(id);

            _dbSet.Remove(idCliente);
            _context.SaveChanges();

            // return idCliente;
        }

        public async Task<Cliente> UpdateById(Cliente novoCadastroCliente)
        {
            var cadastroDB =
                await _dbSet.Where(c => c.Id == novoCadastroCliente.Id)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(novoCadastroCliente);
            }
            else
            {
                cadastroDB.Update(novoCadastroCliente);
                await _context.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<Cliente> UpdateByIdCliente(Cliente novoCadastroCliente) // atualiza usuário
        {
            var cadastroDB =
                await _dbSet.Where(c => c.IdCliente == novoCadastroCliente.IdCliente)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(novoCadastroCliente);
            }
            else
            {
                cadastroDB.Update(novoCadastroCliente);
                await _context.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<Cliente> UpdateByCpf(Cliente novoCadastroCliente)
        {
            var cadastroDB =
                await _dbSet.Where(c => c.CPF == novoCadastroCliente.CPF)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(novoCadastroCliente);
            }
            else
            {
                cadastroDB.Update(novoCadastroCliente);
                await _context.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<IList<Cliente>> GetAllClientes()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            var usuario =
                 await _dbSet.Where(c => c.Id == id)
                    .SingleOrDefaultAsync();

            return usuario;
        }

        public async Task<BuscaClientesViewModel> GetClientesByName(string nomeCliente)
        {
            IQueryable<Cliente> query = _dbSet;

            if (!string.IsNullOrEmpty(nomeCliente))
            {
                query = query.Where(q => q.PrimeiroNome.Contains(nomeCliente));
            }

            return new BuscaClientesViewModel(await query.ToListAsync(), nomeCliente);
        }

        public async Task<Cliente> GetClienteByCpf(string cpfCliente)
        {
            var usuario =
                await _dbSet.Where(c => c.CPF == cpfCliente)
                   .SingleOrDefaultAsync();

            return usuario;
        }

        public async Task<Cliente> GetClienteByIdCliente(int idCliente)
        {
            var usuario =
                await _dbSet.Where(c => c.IdCliente == idCliente)
                   .SingleOrDefaultAsync();

            return usuario;
        }

        public async Task<Cliente> GetClienteByEmail(string emailCliente)
        {
            var usuario =
                await _dbSet.Where(c => c.Email == emailCliente)
                    .SingleOrDefaultAsync();

            return usuario;
        }


    }
}
