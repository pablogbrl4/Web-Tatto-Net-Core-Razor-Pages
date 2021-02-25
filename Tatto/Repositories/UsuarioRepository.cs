using System.Linq;
using System.Threading.Tasks;
using Tatto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Tatto.Models.ViewModels;
using System;

namespace Tatto.Repositories
{
    public interface IContatosRepository
    {
        Task<IList<Contatos>> GetContatosByIdEstudio(string idEstudio);
        Task<IList<Contatos>> GetContatosByidUsuarioAndIdEstudio(int idUsuario, string idEstudio);
        Task<Contatos> RemoverContato(int idUsuario, string idEstudio);
        Task<Contatos> InsertByIds(int idUsuario, string idEstudio);

    }
    public class ContatosRepository : BaseRepository<Contatos>, IContatosRepository
    {
        Contatos contato = new Contatos();

        public ContatosRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Contatos> InsertByIds(int idUsuario, string idEstudio)
        {
            contato.IdUsuario = idUsuario;
            contato.IdEstudio = idEstudio;

            var apagarContato =
                 await dbSet.Where(c => c.IdEstudio == contato.IdEstudio)
                            .Where(c => c.IdUsuario == contato.IdUsuario)
                                .SingleOrDefaultAsync();

            if (apagarContato == null)
            {
                await dbSet.AddAsync(contato);
                await contexto.SaveChangesAsync();
            }

            return contato;
        }

        public async Task<IList<Contatos>> GetContatosByIdEstudio(string idEstudio)
        {
            if (!String.IsNullOrEmpty(idEstudio))
            {
                return await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return null;
        }

        public async Task<Contatos> RemoverContato(int idUsuario, string idEstudio)
        {
            contato.IdUsuario = idUsuario;
            contato.IdEstudio = idEstudio;

            var apagarContato =
                 await dbSet.Where(c => c.IdEstudio == contato.IdEstudio)
                            .Where(c => c.IdUsuario == contato.IdUsuario)
                                .SingleOrDefaultAsync();

            dbSet.Remove(apagarContato);

            await contexto.SaveChangesAsync();

            return contato;
        }

        public async Task<IList<Contatos>> GetContatosByidUsuarioAndIdEstudio(int idUsuario, string idEstudio)
        {
            if ( idUsuario != 0 && !String.IsNullOrEmpty(idEstudio))
            {
                return await dbSet.Where(q => q.IdUsuario.Equals(idUsuario))
                                  .Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
            }

            return null;
        }
    }
    public interface IUsuarioRepository
    {
        void Delete(string id);
        Task<Usuario> UpdateById(Usuario novoCadastroUsuario);
        Task<Usuario> UpdateByIdUsuario(Usuario novoCadastroUsuario);
        Task<Usuario> UpdateByCpf(Usuario novoCadastroUsuario);
        Task<IList<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<BuscaUsuariosViewModel> GetUsuariosByName(string nomeUsuario);
        Task<Usuario> GetUsuarioByCpf(string cpfUsuario);
        Task<Usuario> GetUsuarioByEmail(string emailUsuario);
        Task<Usuario> GetUsuarioByIdUsuario(string idUsuario);



        Task<Usuario> idNaoNull(string idEstudio);
        Task<Usuario> InsertNew(string Email, string Id, string UserName);
    }
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        Usuario usuario = new Usuario();
        public async Task<Usuario> idNaoNull(string idUsuario)
        {
            var cadastroDB = // objeto de cadastro a partir do DB Set
                 await dbSet.Where(c => c.IdUsuario == idUsuario)
                 .SingleOrDefaultAsync();

            return cadastroDB;
        }

        public async Task<Usuario> InsertNew(string Email, string Id, string UserName)
        {
            usuario.Email = Email;
            usuario.IdUsuario = Id;
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

            await dbSet.AddAsync(usuario);
            await contexto.SaveChangesAsync();

            return usuario;
        }


        public async Task<Usuario> Insert(Usuario novoCadastroUsuario)
        {
            await dbSet.AddAsync(novoCadastroUsuario);
            await contexto.SaveChangesAsync();

            return novoCadastroUsuario;
        }

        public void Delete(string id)
        {
            var idUsuario = dbSet.Find(id);

            dbSet.Remove(idUsuario);
            contexto.SaveChanges();

            // return idUsuario;
        }

        public async Task<Usuario> UpdateById(Usuario novoCadastroUsuario)
        {
            var cadastroDB =
                await dbSet.Where(c => c.Id == novoCadastroUsuario.Id)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(novoCadastroUsuario);
            }
            else
            {
                cadastroDB.Update(novoCadastroUsuario);
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<Usuario> UpdateByIdUsuario(Usuario novoCadastroUsuario) // atualiza usuário
        {
            var cadastroDB =
                await dbSet.Where(c => c.IdUsuario == novoCadastroUsuario.IdUsuario)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(novoCadastroUsuario);
            }
            else
            {
                cadastroDB.Update(novoCadastroUsuario);
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<Usuario> UpdateByCpf(Usuario novoCadastroUsuario)
        {
            var cadastroDB =
                await dbSet.Where(c => c.CPF == novoCadastroUsuario.CPF)
                .SingleOrDefaultAsync();

            if (cadastroDB == null)
            {
                await Insert(novoCadastroUsuario);
            }
            else
            {
                cadastroDB.Update(novoCadastroUsuario);
                await contexto.SaveChangesAsync();
            }

            return cadastroDB;
        }

        public async Task<IList<Usuario>> GetAllUsuarios()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            var usuario =
                 await dbSet.Where(c => c.Id == id)
                    .SingleOrDefaultAsync();

            return usuario;
        }

        public async Task<BuscaUsuariosViewModel> GetUsuariosByName(string nomeUsuario)
        {
            IQueryable<Usuario> query = dbSet;

            if (!string.IsNullOrEmpty(nomeUsuario))
            {
                query = query.Where(q => q.PrimeiroNome.Contains(nomeUsuario));
            }

            return new BuscaUsuariosViewModel(await query.ToListAsync(), nomeUsuario);
        }

        public async Task<Usuario> GetUsuarioByCpf(string cpfUsuario)
        {
            var usuario =
                await dbSet.Where(c => c.CPF == cpfUsuario)
                   .SingleOrDefaultAsync();

            return usuario;
        }

        public async Task<Usuario> GetUsuarioByIdUsuario(string idUsuario)
        {
            var usuario =
                await dbSet.Where(c => c.IdUsuario == idUsuario)
                   .SingleOrDefaultAsync();

            return usuario;
        }

        public async Task<Usuario> GetUsuarioByEmail(string emailUsuario)
        {
            var usuario =
                await dbSet.Where(c => c.Email == emailUsuario)
                    .SingleOrDefaultAsync();

            return usuario;
        }
    }
}
