using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Data.Mappings
{
    public class ContatosMap : BaseEntidadeMap<Contatos>
    {
        public override void Configure(EntityTypeBuilder<Contatos> builder)
        {
            base.Configure(builder);

            builder.ToTable("Contatos");

            // Define como chave composta
            builder
                .HasKey(p => new { p.IdEstudio, p.IdCliente });

            builder.HasOne(s => s.Estudio)
              .WithMany(c => c.Contatos)
              .HasForeignKey(s => s.IdEstudio)
              .HasPrincipalKey(c => c.Id);

            builder.HasOne(s => s.Cliente)
            .WithMany(c => c.Contatos)
            .HasForeignKey(s => s.IdCliente)
            .HasPrincipalKey(c => c.Id);

        }
    }
}
