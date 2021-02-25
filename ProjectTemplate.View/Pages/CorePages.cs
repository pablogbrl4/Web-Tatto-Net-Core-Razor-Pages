using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectTemplate.Application.DTOs;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.API.Controllers
{
    public class CorePages<T, TDTO> 
        where T : BaseModel
        where TDTO : BaseEntidadeDTO
    {
        protected readonly IBaseApp<T, TDTO> _app;

        public CorePages(IBaseApp<T, TDTO> app)
        {
            _app = app;
        }

        public async Task<IActionResult> Listar()
        {
                var list = await _app.BuscarTodos();
                return new OkObjectResult(list);
        }

        public async Task<IActionResult> SelecionarPorId(int id)
        {

                var objById = await _app.BuscarPorId(id);
                return new OkObjectResult(objById);

        }

        public async Task<IActionResult> Incluir([FromBody] TDTO dado)
        {

                return new OkObjectResult(await _app.Incluir(dado));

        }

        public async Task<IActionResult> Alterar([FromBody] TDTO dado)
        {

                await _app.Alterar(dado);
                return new OkObjectResult(true);

        }

        public async Task<IActionResult> Excluir(int id)
        {
                await _app.Excluir(id);
                return new OkObjectResult(true);


        }
    }
}
