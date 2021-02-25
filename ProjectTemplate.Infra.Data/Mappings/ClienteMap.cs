using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Data.Mappings
{
    public class ClienteMap : BaseEntidadeMap<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder.ToTable("Cliente");

            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.CPF).IsUnique();

        }
    }
}
