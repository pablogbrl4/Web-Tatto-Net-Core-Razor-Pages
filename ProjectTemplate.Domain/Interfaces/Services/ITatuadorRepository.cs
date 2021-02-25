using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Services
{
    public interface ITatuadorService : IBaseServico<Tatuador>
    {
        Task<Tatuador> Delete(int? id);
        Task<Tatuador> Update(Tatuador novoCadastroTatuador);
        Task<IList<Tatuador>> GetTatuador();
        Task<Tatuador> GetTatuadorById(string id);
        Task<Tatuador> GetTatuadorByCpf(string cpf);
        Task<BuscaTatuadorViewModel> GetTatuadoresAsync(string pesquisa);
        Task<Tatuador> GetTatuadorByIdTatuador(int idTatuador);

        Task<string> GetIdTatuadorByNomeCliente(string nomeCliente);

        Task<Tatuador> UpdateByCpf(Tatuador tatuador);
        Task<Tatuador> GetTatuadorByEmail(string emailTatuador);


        Task<Tatuador> idNaoNull(int idEstudio);
        Task<Tatuador> InsertNew(string Email, string Id, string UserName);
    }

}
