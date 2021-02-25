using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTemplate.Domain.Entities;

namespace ProjectTemplate.Infra.Data.Mappings
{
    public class HorarioDeFuncionamentoEstudioMap : BaseEntidadeMap<HorarioDeFuncionamentoEstudio>
    {
        public override void Configure(EntityTypeBuilder<HorarioDeFuncionamentoEstudio> builder)
        {
            base.Configure(builder);

            builder.ToTable("HorarioDeFuncionamentoEstudio");

            builder.HasOne(s => s.Estudio)
                .WithMany(c => c.HorarioDeFuncionamentoEstudio)
                    .HasForeignKey(s => s.IdEstudio)
                         .HasPrincipalKey(c => c.Id);
        }
    }
}
