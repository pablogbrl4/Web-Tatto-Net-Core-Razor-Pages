using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Data.Mappings
{
    public class ShoppingMap : BaseEntidadeMap<Shopping>
    {
        public override void Configure(EntityTypeBuilder<Shopping> builder)
        {
            base.Configure(builder);

            builder.ToTable("Shopping");

            builder.HasOne(s => s.Estudio)
               .WithMany(c => c.Shopping)
                   .HasForeignKey(s => s.IdEstudio)
                        .HasPrincipalKey(c => c.Id);

        }
    }
}
