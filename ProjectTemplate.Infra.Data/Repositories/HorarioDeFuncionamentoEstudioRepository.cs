using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infra.Data.Contexto;
using ProjectTemplate.Domain.Interfaces.Repositories;

namespace ProjectTemplate.Infra.Data.Repositories
{

    public class HorarioDeFuncionamentoEstudioRepository : BaseRepositorio<HorarioDeFuncionamentoEstudio>, IHorarioDeFuncionamentoEstudioRepository
    {
        public HorarioDeFuncionamentoEstudioRepository(BaseContexto contexto) : base(contexto)
        {
        }

        HorarioDeFuncionamentoEstudio horario = new HorarioDeFuncionamentoEstudio();

        public async Task<IList<HorarioDeFuncionamentoEstudio>> GetHorarioDeFuncionamentoEstudioByIdEstudio(int idEstudio)
        {
            return await _dbSet.Where(q => q.IdEstudio.Equals(idEstudio)).ToListAsync();
        }

        public async Task<HorarioDeFuncionamentoEstudio> ApagarHorarios(int idEstudio)
        {
            horario.IdEstudio = idEstudio;

            IList<HorarioDeFuncionamentoEstudio> apagarHorarios = new List<HorarioDeFuncionamentoEstudio>();

            apagarHorarios =
                  _dbSet.Where(c => c.IdEstudio == horario.IdEstudio).ToList();

            _dbSet.RemoveRange(apagarHorarios);

            await _context.SaveChangesAsync();

            return horario;
        }

    }
}
