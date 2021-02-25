using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tatto.Repositories;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Tatto.Areas.Identity.Data;
using Tatto.Models;
using Microsoft.Extensions.Hosting;

namespace Tatto
{
    public partial class Startup
    {
        private readonly ILoggerFactory _loggerFactory;

        public Startup(ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            services.AddMvc(options => options.EnableEndpointRouting = false); // AddMvc carrega praticamente todos os recursos necessários de uma aplicação ASP.NET, 
            services.AddDistributedMemoryCache(); // Adicionar serviço para manter cache na memoria
            services.AddSession(); // Adciona uma sessão 

            String connectionString = Configuration.GetConnectionString("Default"); // Faz conexão com o Banco Através do Json

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connectionString) // Faz conexão com o Banco Através do Json 
            );


            services.AddTransient<IDataService, DataService>(); // DataService, Injeção de dependência
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ITatuadorRepository, TatuadorRepository>();
            services.AddTransient<IEstudioRepository, EstudioRepository>();
            services.AddTransient<IAgendaRepository, AgendaRepository>();
            services.AddTransient<IEstudio_TatuadorRepository, Estudio_TatuadorRepository>();
            services.AddTransient<IContatosRepository, ContatosRepository>();
            services.AddTransient<IFotoTattoRepository, FotoTattoRepository>();
            services.AddTransient<IDepoimentosRepository, DepoimentosRepository>();
            services.AddTransient<IShoppingRepository, ShoppingRepository>();
            services.AddTransient<IFotosEstudioRepository, FotosEstudioRepository>();
            services.AddTransient<IHorarioDeFuncionamentoEstudioRepository, HorarioDeFuncionamentoEstudioRepository>();

            //services.AddControllersWithViews();

            services.AddAuthentication()
                   .AddGoogle(options =>
                   {
                       options.ClientId = Configuration["externallogin:google:clientid"];
                       options.ClientSecret = Configuration["externallogin:google:clientsecret"];
                   });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env, IServiceProvider serviceProvider)// Configura onde se utilizara o serviço
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();  // cria um canal de comunicação entre o ambiente de desenvolvimento e um ou mais navegadores da Web
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); // Faz com que conssigamos adicionar o Identity dentro do fluxo do asp .net core (integra atráves de um middleware)


            app.UseSession(); // Utiliza a Sessão criada na ConfigureServices()
                              // Se utiliza a UseSession Para a aplicação não perder uma informação importante do usuário enquanto o usuário navega pelas páginas da aplicação

            //app.UseRouting();

            //app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
                //template: "{controller=Estudio}/{action=HomeEstudio}/{id?}");
            });

            serviceProvider.GetService<IDataService>().InicializaDB(); // Gerar e inicializa Banco de Dados Caso não Exista
        }

    }
}
