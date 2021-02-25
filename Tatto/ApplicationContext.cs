using Microsoft.EntityFrameworkCore; // Extenssão do EntityFrameworkCore
using Tatto.Models;

namespace Tatto
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // Rotas Para Gravar
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>().HasKey(t => t.Id);
            //modelBuilder.Entity<Usuario>().HasIndex(t => t.IdUsuario).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(t => t.CPF).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(t => t.Email).IsUnique();

            modelBuilder.Entity<Contatos>().HasKey(t => t.Id);

            modelBuilder.Entity<Tatuador>().HasKey(t => t.Id);
            modelBuilder.Entity<Tatuador>().HasIndex(t => t.IdTatuador).IsUnique();
            modelBuilder.Entity<Tatuador>().HasIndex(t => t.CPF).IsUnique();
            modelBuilder.Entity<Tatuador>().HasIndex(t => t.Email).IsUnique();

            modelBuilder.Entity<Estudio>().HasKey(t => t.Id);
            modelBuilder.Entity<Estudio>().HasIndex(t => t.IdEstudio).IsUnique();
            modelBuilder.Entity<Estudio>().HasIndex(t => t.CNPJ).IsUnique();
            modelBuilder.Entity<Estudio>().HasIndex(t => t.Email).IsUnique();
            modelBuilder.Entity<Estudio>().HasIndex(t => t.NomeDeUsuario).IsUnique();

            modelBuilder.Entity<FotoTatto>().HasKey(t => t.Id);

            modelBuilder.Entity<FotosEstudio>().HasKey(t => t.Id);

            modelBuilder.Entity<Depoimentos>().HasKey(t => t.Id);

            modelBuilder.Entity<Shopping>().HasKey(t => t.Id);

            modelBuilder.Entity<Estudio_Tatuador>().HasKey(t => t.Id);

            modelBuilder.Entity<HorarioDeFuncionamentoEstudio>().HasKey(t => t.Id);

            modelBuilder.Entity<Agenda>().HasKey(t => t.Id);
            

        }
    }
}
