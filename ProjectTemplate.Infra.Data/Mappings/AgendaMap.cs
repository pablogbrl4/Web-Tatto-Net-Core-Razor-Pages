using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Data.Mappings
{
    public class AgendaMap : BaseEntidadeMap<Agenda>
    {
        public override void Configure(EntityTypeBuilder<Agenda> builder)
        {
            base.Configure(builder);

            builder.ToTable("Agenda");

            builder.HasOne(s => s.Estudio)
                .WithMany(c => c.Agenda)
                    .HasForeignKey(s => s.IdEstudio)
                         .HasPrincipalKey(c => c.Id);

            builder.HasOne(s => s.Cliente)
                .WithMany(c => c.Agenda)
                    .HasForeignKey(s => s.IdCliente)
                         .HasPrincipalKey(c => c.Id);

            builder.HasOne(s => s.Tatuador)
                .WithMany(c => c.Agenda)
                    .HasForeignKey(s => s.IdTatuador)
                         .HasPrincipalKey(c => c.Id);

        }
    }
}
