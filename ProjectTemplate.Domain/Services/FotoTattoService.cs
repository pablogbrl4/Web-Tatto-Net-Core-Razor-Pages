using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Domain.Entities.ViewModels;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectTemplate.Domain.Services
{
    public class FotoTattoService : BaseServico<FotoTatto>, IFotoTattoService
    {
        protected readonly IFotoTattoRepository _repository;

        public FotoTattoService(IFotoTattoRepository repositorio) : base(repositorio)
        {
            _repository = repositorio;
        }

        public Task<FotoTatto> DeletarFoto(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<BuscaTatuagensViewModel> GetAllFotosTatto(string estilo, string parteCorpo, string genero = "", string cor = "")
        {
            throw new System.NotImplementedException();
        }

        public Task<FotoTatto> GetFotoById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<FotoTatto>> GetFotosByIdTatuador(int idTatuador)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<FotoTatto>> GetFotosTattoByIdEstudio(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<BuscaTatuagensViewModel> GetFotosTattoByIdEstudio(int idEstudio, string estilo, string parteCorpo)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<FotoTatto>> GetFotosTattosByIdEstudio(int idEstudio, string estilo, string parteCorpo)
        {
            throw new System.NotImplementedException();
        }

        public Task<FotoTatto> GetFotoTattoByNomeFoto(string nomeFoto, int idEstudio)
        {
            throw new System.NotImplementedException();
        }

        public Task<FotoTatto> UpdateFoto(FotoTatto foto)
        {
            throw new System.NotImplementedException();
        }
    }
}
