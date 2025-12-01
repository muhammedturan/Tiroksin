using Tiroksin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tiroksin.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnName("id");

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("username");

        builder.HasIndex(u => u.Username).IsUnique();

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255)
            .HasColumnName("email");

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.DisplayName)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("display_name");

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasColumnName("password_hash");

        builder.Property(u => u.Avatar)
            .HasMaxLength(500)
            .HasColumnName("avatar");

        builder.Property(u => u.CreatedAt).HasColumnName("created_at");
        builder.Property(u => u.UpdatedAt).HasColumnName("updated_at");
        builder.Property(u => u.CreatedBy).HasColumnName("created_by");
        builder.Property(u => u.UpdatedBy).HasColumnName("updated_by");
    }
}
