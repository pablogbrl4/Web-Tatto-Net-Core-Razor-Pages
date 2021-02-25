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

    public interface IHorarioDeFuncionamentoEstudioRepository
    {
        Task<IList<HorarioDeFuncionamentoEstudio>> GetHorarioDeFuncionamentoEstudioByIdEstudio(string id);
        Task<HorarioDeFuncionamentoEstudio> Insert(HorarioDeFuncionamentoEstudio horario);
        Task<HorarioDeFuncionamentoEstudio> ApagarHorarios(string idEstudio);
    }

    public class HorarioDeFuncionamentoEstudioRepository : BaseRepository<HorarioDeFuncionamentoEstudio>, IHorarioDeFuncionamentoEstudioRepository
    {
        public HorarioDeFuncionamentoEstudioRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        HorarioDeFuncionamentoEstudio horario = new HorarioDeFuncionamentoEstudio();
        public async Task<IList<HorarioDeFuncionamentoEstudio>> GetHorarioDeFuncionamentoEstudioByIdEstudio(string idEstudio)
        {
            return await dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
        }

        public async Task<HorarioDeFuncionamentoEstudio> ApagarHorarios(string idEstudio)
        {
            horario.IdEstudio = idEstudio;

            IList<HorarioDeFuncionamentoEstudio> apagarHorarios = new List<HorarioDeFuncionamentoEstudio>();

            apagarHorarios =
                  dbSet.Where(c => c.IdEstudio == horario.IdEstudio).ToList();

            dbSet.RemoveRange(apagarHorarios);

            await contexto.SaveChangesAsync();

            return horario;
        }

        public async Task<HorarioDeFuncionamentoEstudio> Insert(HorarioDeFuncionamentoEstudio horario)
        {
            dbSet.Add(horario);
            await contexto.SaveChangesAsync(); // Salva no Banco

            return horario;
        }
    }
}
