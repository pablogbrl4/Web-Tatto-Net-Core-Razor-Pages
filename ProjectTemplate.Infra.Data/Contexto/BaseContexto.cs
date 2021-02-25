using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infra.Data.Mappings;
using System;
using System.Threading.Tasks;

namespace ProjectTemplate.Infra.Data.Contexto
{
    public class BaseContexto : DbContext
    {
        public DbSet<Agenda> Agenda { get; set; }

        public DbSet<Depoimentos> Depoimentos { get; set; }

        public DbSet<Estudio> Estudio { get; set; }

        public DbSet<Estudio_Tatuador> Estudio_Tatuador { get; set; }

        public DbSet<FotosEstudio> FotosEstudio { get; set; }

        public DbSet<FotoTatto> FotoTatto { get; set; }

        public DbSet<HorarioDeFuncionamentoEstudio> HorarioDeFuncionamentoEstudio { get; set; }

        public DbSet<Shopping> Shopping { get; set; }

        public DbSet<Tatuador> Tatuador { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Contatos> Contatos { get; set; }

        public DbSet<User> User { get; set; }



        protected IDbContextTransaction _contextoTransaction { get; set; }

        public BaseContexto(DbContextOptions<BaseContexto> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public async Task<IDbContextTransaction> IniciarTransaction()
        {
            if (_contextoTransaction == null)
            {
                _contextoTransaction = await this.Database.BeginTransactionAsync();
            }
            return _contextoTransaction;
        }


        private async Task RollBack()
        {
            if (_contextoTransaction != null)
            {
                await _contextoTransaction.RollbackAsync();
            }
        }

        private async Task Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await RollBack();
                throw new Exception(ex.Message);
            }
        }

        private async Task Commit()
        {
            if (_contextoTransaction != null)
            {
                await _contextoTransaction.CommitAsync();
                await _contextoTransaction.DisposeAsync();
                _contextoTransaction = null;
            }
        }

        public async Task SalvarMudancas()
        {
            await Salvar();
            await Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AgendaMap());

            modelBuilder.ApplyConfiguration(new ClienteMap());

            modelBuilder.ApplyConfiguration(new ContatosMap());

            modelBuilder.ApplyConfiguration(new Estudio_TatuadorMap());

            modelBuilder.ApplyConfiguration(new EstudioMap());

            modelBuilder.ApplyConfiguration(new FotoTattoMap());

            modelBuilder.ApplyConfiguration(new HorarioDeFuncionamentoEstudioMap());

            modelBuilder.ApplyConfiguration(new ShoppingMap());

            modelBuilder.ApplyConfiguration(new TatuadorMap());


        }
    }
}
