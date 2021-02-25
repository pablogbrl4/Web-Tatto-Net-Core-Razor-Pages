using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Data.Mappings
{
    public class Estudio_TatuadorMap : BaseEntidadeMap<Estudio_Tatuador>
    {
        public override void Configure(EntityTypeBuilder<Estudio_Tatuador> builder)
        {
            base.Configure(builder);

            builder.ToTable("Estudio_Tatuador");

            // Define como chave composta
            builder
                .HasKey(p => new { p.IdEstudio, p.IdTatuador });

            builder.HasOne(s => s.Estudio)
              .WithMany(c => c.EstudioTatuador)
              .HasForeignKey(s => s.IdEstudio)
              .HasPrincipalKey(c => c.Id);

            builder.HasOne(s => s.Tatuador)
            .WithMany(c => c.EstudioTatuador)
            .HasForeignKey(s => s.IdTatuador)
            .HasPrincipalKey(c => c.Id);

        }
    }
}
