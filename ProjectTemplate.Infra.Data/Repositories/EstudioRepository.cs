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

    public class EstudioRepository : BaseRepositorio<Estudio>, IEstudioRepository
    {
        public EstudioRepository(BaseContexto contexto) : base(contexto)
        {
        }

        Estudio estudio = new Estudio();

        public async Task<Estudio> idNaoNull(int idEstudio)
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                 await _dbSet.Where(c => c.IdEstudio == idEstudio)
                 .SingleOrDefaultAsync();

            return cadastroDB;
        }

        public async Task<Estudio> InsertNew(string Email, int idEstudio, string UserName)
        {
            estudio.Email = Email;
            estudio.IdEstudio = idEstudio;
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

            await _dbSet.AddAsync(estudio);
            await _context.SaveChangesAsync();

            return estudio;
        }

        public async Task<BuscaEstudioViewModel> GetEstudiosAsync(string pesquisa)
        {
            IQueryable<Estudio> query = _dbSet;

            if (!string.IsNullOrEmpty(pesquisa))
            {
                query = query.Where(q => q.NomeEstudio.Contains(pesquisa));
            }

            return new BuscaEstudioViewModel(await query.ToListAsync(), pesquisa);
        }

        public async Task<BuscaEstudioViewModel> GetEstudiosByBairro(string bairro)
        {
            IQueryable<Estudio> query = _dbSet;

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
                await _dbSet.Where(c => c.Email == emailEstudio)
                    .SingleOrDefaultAsync();

            return estudio;

        }

        public async Task<int> GetIdEstudioByNomeCliente(string nomeCliente)
        {
            estudio =
              await _dbSet.Where(c => c.NomeDeUsuario == nomeCliente)
                  .SingleOrDefaultAsync();

            if (estudio == null)
            {
                return 0;
            }

            return estudio.Id;
        }

        public int GetIdEstudioByIdUser(int idUser)
        {
            estudio =
               _dbSet.Where(c => c.IdEstudio.Equals(idUser))
                  .FirstOrDefault();

            if (estudio == null)
            {
                return 0;
            }

            return estudio.Id;
        }

        public async Task<Estudio> Update(Estudio estudio)
        {
            var cadastroDB =
                await _dbSet.Where(c => c.IdEstudio == estudio.IdEstudio)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Incluir(estudio);
            }
            else
            {

                await _context.IniciarTransaction();
                // _context.Entry(estudio).State = EntityState.Unchanged;
                _context.Entry(estudio).State = EntityState.Detached;
                await _context.SalvarMudancas();

                //cadastroDB.Update(estudio);
                // await _context.SaveChangesAsync();
            }

            return cadastroDB;
        }
    }
}