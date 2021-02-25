using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Interfaces.Repositories
{
    public interface IEstudioRepository : IBaseRepositorio<Estudio>
    {
        Task<Estudio> InsertNew(string Email, int idEstudio, string UserName);
        Task<int> GetIdEstudioByNomeCliente(string nomeCliente);
        Task<BuscaEstudioViewModel> GetEstudiosAsync(string pesquisa);
        Task<BuscaEstudioViewModel> GetEstudiosByBairro(string bairro);
        Task<Estudio> GetEstudioByEmail(string emailEstudio);
        Task<Estudio> idNaoNull(int idEstudio);
        int GetIdEstudioByIdUser(int idUser);

        Task<Estudio> Update(Estudio estudio);

    }

}
