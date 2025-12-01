using Tiroksin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tiroksin.Infrastructure.Configurations;

public class ParameterValueConfiguration : IEntityTypeConfiguration<ParameterValue>
{
    public void Configure(EntityTypeBuilder<ParameterValue> builder)
    {
        builder.ToTable("parameter_values");

        builder.HasKey(pv => pv.Id);
        builder.Property(pv => pv.Id).HasColumnName("id");

        builder.Property(pv => pv.ParameterDefinitionId)
            .IsRequired()
            .HasColumnName("parameter_definition_id");

        builder.Property(pv => pv.Value)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("value");

        builder.Property(pv => pv.Name)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("name");

        builder.Property(pv => pv.OrderNo)
            .IsRequired()
            .HasColumnName("order_no");

        builder.Property(pv => pv.CreatedAt).HasColumnName("created_at");
        builder.Property(pv => pv.UpdatedAt).HasColumnName("updated_at");
        builder.Property(pv => pv.UpdatedBy).HasColumnName("updated_by");

        // Note: Relationship and unique constraint already configured in ApplicationDbContext
    }
}
