using Microsoft.Extensions.DependencyInjection;
using ProjectTemplate.Application.Interfaces;
using ProjectTemplate.Application.Services;
using ProjectTemplate.Domain.Interfaces.Repositories;
using ProjectTemplate.Domain.Interfaces.Services;
using ProjectTemplate.Domain.Services;
using ProjectTemplate.Infra.Data.Repositories;

namespace ProjectTemplate.Infra.IoC
{
    public static class InjectorDependencies
    {
        public static void Registrer(IServiceCollection services)
        {
            //Application
            services.AddScoped(typeof(IBaseApp<,>), typeof(BaseServicoApp<,>));

            services.AddScoped<IAgendaApp, AgendaServiceApp>();
            services.AddScoped<IDepoimentosApp, DepoimentosServiceApp>();
            services.AddScoped<IEstudioApp, EstudioServiceApp>();
            services.AddScoped<IEstudio_TatuadorApp, Estudio_TatuadorServiceApp>();
            services.AddScoped<IFotosEstudioApp, FotosEstudioServiceApp>();
            services.AddScoped<IFotoTattoApp, FotoTattoServiceApp>();
            services.AddScoped<IHorarioDeFuncionamentoEstudioApp, HorarioDeFuncionamentoEstudioServiceApp>();
            services.AddScoped<IShoppingApp, ShoppingServiceApp>();
            services.AddScoped<ITatuadorApp, TatuadorServiceApp>();
            services.AddScoped<IClienteApp, ClienteServiceApp>();
            services.AddScoped<IContatosApp, ContatosServiceApp>();

            //Domínio 
            services.AddScoped(typeof(IBaseServico<>), typeof(BaseServico<>));

            services.AddScoped<IAgendaService, AgendaService>();
            services.AddScoped<IDepoimentosService, DepoimentosService>();
            services.AddScoped<IEstudioService, EstudioService>();
            services.AddScoped<IEstudio_TatuadorService, Estudio_TatuadorService>();
            services.AddScoped<IFotosEstudioService, FotosEstudioService>();
            services.AddScoped<IFotoTattoService, FotoTattoService>();
            services.AddScoped<IHorarioDeFuncionamentoEstudioService, HorarioDeFuncionamentoEstudioService>();
            services.AddScoped<IShoppingService, ShoppingService>();
            services.AddScoped<ITatuadorService, TatuadorService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IContatosService, ContatosService>();

            //Repository
            services.AddScoped(typeof(IBaseRepositorio<>), typeof(BaseRepositorio<>));

            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IDepoimentosRepository, DepoimentosRepository>();
            services.AddScoped<IEstudioRepository, EstudioRepository>();
            services.AddScoped<IEstudio_TatuadorRepository, Estudio_TatuadorRepository>();
            services.AddScoped<IFotosEstudioRepository, FotosEstudioRepository>();
            services.AddScoped<IFotoTattoRepository, FotoTattoRepository>();
            services.AddScoped<IHorarioDeFuncionamentoEstudioRepository, HorarioDeFuncionamentoEstudioRepository>();
            services.AddScoped<IShoppingRepository, ShoppingRepository>();
            services.AddScoped<ITatuadorRepository, TatuadorRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContatosRepository, ContatosRepository>();
        }
    }
}
