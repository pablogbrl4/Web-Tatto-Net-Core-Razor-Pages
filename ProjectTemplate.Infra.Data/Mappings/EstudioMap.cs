using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Data.Mappings
{
    public class EstudioMap : BaseEntidadeMap<Estudio>
    {
        public override void Configure(EntityTypeBuilder<Estudio> builder)
        {
            base.Configure(builder);

            builder.ToTable("Estudio");

            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.CNPJ).IsUnique();
            builder.HasIndex(p => p.NomeDeUsuario).IsUnique();

        }
    }
}
