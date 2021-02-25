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
    public interface IEstudioRepository
    {
        void Delete(int? id);
        Task<Estudio> InsertNew(string Email, string Id, string UserName);
        Task<Estudio> Update(Estudio novoCadastroEstudio);
        Task<IList<Estudio>> GetEstudio(); // Retorna todos os usuários
        Task<Estudio> GetEstudioById(string id); // Retorna Estudio por Id
        Task<string> GetIdEstudioByNomeUsuario(string nomeUsuario);
        Task<BuscaEstudioViewModel> GetEstudiosAsync(string pesquisa);
        Task<BuscaEstudioViewModel> GetEstudiosByBairro(string bairro);
        Task<Estudio> GetEstudioByEmail(string emailEstudio);
        Task<Estudio> idNaoNull(string idEstudio);

    }
    public class EstudioRepository : BaseRepository<Estudio>, IEstudioRepository
    {
        public EstudioRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        Estudio estudio = new Estudio();

        public async Task<Estudio> idNaoNull(string idEstudio)
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                 await dbSet.Where(c => c.IdEstudio == idEstudio)
                 .SingleOrDefaultAsync();

            return cadastroDB;
        }

        public async Task<Estudio> InsertNew(string Email, string Id, string UserName)
        {
            estudio.Email = Email;
            estudio.IdEstudio = Id;
            estudio.NomeEstudio = UserName;
            estudio.CNPJ = null;

            estudio.NomeDeUsuario = Email;

            estudio.Telefone = "";
            estudio.DatadeFundação = "";

            estudio.CEP = "";
            estudio.Endereco = "";
            estudio.Numero = "";
            estudio.Bairro = "";
            estudio.Complemento = "";
            estudio.Cidade = "";
            estudio.UF = "";

            await dbSet.AddAsync(estudio);
            await contexto.SaveChangesAsync();

            return estudio;
        }

        public void Delete(int? id)
        {
            var idEstudio = dbSet.Find(id);

            dbSet.Remove(idEstudio); //  Exclui no Banco
            contexto.SaveChanges(); // Salva no Banco

        }

        public async Task<Estudio> Update(Estudio novoCadastroEstudio)
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                await dbSet.Where(c => c.IdEstudio == novoCadastroEstudio.IdEstudio)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await dbSet.AddAsync(novoCadastroEstudio); //  Deleta do Banco
                await contexto.SaveChangesAsync(); // Salva no Banco   
            }
            else
            {
                cadastroDB.Update(novoCadastroEstudio); // atualizar com novos dados do novo cadastro
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<IList<Estudio>> GetEstudio()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Estudio> GetEstudioById(string id)
        {
            var estudio =
                 await dbSet.Where(c => c.IdEstudio == id)
                     .SingleOrDefaultAsync();

            return estudio;
        }

        public async Task<BuscaEstudioViewModel> GetEstudiosAsync(string pesquisa)
        {
            IQueryable<Estudio> query = dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.NomeEstudio.Contains(pesquisa));
            }

            return new BuscaEstudioViewModel(await query.ToListAsync(), pesquisa);
        }

        public async Task<BuscaEstudioViewModel> GetEstudiosByBairro(string bairro)
        {
            IQueryable<Estudio> query = dbSet;

            var bairros = new HashSet<string>();

            if (!string.IsNullOrEmpty(bairro))
            {
                query = query.Where(q => q.Bairro.Contains(bairro));
            }


            foreach (var item in query)
            {
                bairros.Add(item.Bairro);
            }

            return new BuscaEstudioViewModel(await query.ToListAsync(), bairros.ToList());
        }

        public async Task<Estudio> GetEstudioByEmail(string emailEstudio)
        {
            estudio =
                await dbSet.Where(c => c.Email == emailEstudio)
                    .SingleOrDefaultAsync();

            return estudio;

        }

        public async Task<string> GetIdEstudioByNomeUsuario(string nomeUsuario)
        {
            estudio =
              await dbSet.Where(c => c.NomeDeUsuario == nomeUsuario)
                  .SingleOrDefaultAsync();

            if (estudio == null)
            {
                return null;
            }
            return estudio.IdEstudio;
        }
    }
}