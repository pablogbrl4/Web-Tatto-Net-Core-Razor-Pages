using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Data.Mappings
{
    public class TatuadorMap : BaseEntidadeMap<Tatuador>
    {
        public override void Configure(EntityTypeBuilder<Tatuador> builder)
        {
            base.Configure(builder);

            builder.ToTable("Tatuador");

            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.CPF).IsUnique();
            builder.HasIndex(p => p.NomeDeUsuario).IsUnique();

        }
    }
}
