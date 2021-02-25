using System.Collections.Generic;
using System.IO;
using Tatto;

namespace Tatto
{
    public partial class Startup
    {
        class DataService : IDataService
        {
            private readonly ApplicationContext contexto;
            //private readonly IProdutoRepository produtoRepository;

            public DataService(ApplicationContext contexto) // injeção de dependencias
            {
                this.contexto = contexto;
                //this.produtoRepository = produtoRepository;
            }

            public void InicializaDB() // inicializa banco de dados
            {
                contexto.Database.EnsureCreated(); // acessa o contexto
            }
        }
    }


}

