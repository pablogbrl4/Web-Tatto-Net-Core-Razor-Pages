using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Data.Mappings
{
    public class FotoTattoMap : BaseEntidadeMap<FotoTatto>
    {
        public override void Configure(EntityTypeBuilder<FotoTatto> builder)
        {
            base.Configure(builder);

            builder.ToTable("FotoTatto");


            builder.HasOne(s => s.Estudio)
                .WithMany(c => c.FotoTatto)
                    .HasForeignKey(s => s.IdEstudio)
                         .HasPrincipalKey(c => c.Id);

            builder.HasOne(s => s.Cliente)
                .WithMany(c => c.FotoTatto)
                    .HasForeignKey(s => s.IdCliente)
                         .HasPrincipalKey(c => c.Id);

            builder.HasOne(s => s.Tatuador)
                .WithMany(c => c.FotoTatto)
                    .HasForeignKey(s => s.IdTatuador)
                         .HasPrincipalKey(c => c.Id);

        }
    }
}
