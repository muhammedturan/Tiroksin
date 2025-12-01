using Tiroksin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tiroksin.Infrastructure.Configurations;

public class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
{
    public void Configure(EntityTypeBuilder<QuestionOption> builder)
    {
        builder.ToTable("question_options");

        builder.HasKey(qo => qo.Id);
        builder.Property(qo => qo.Id).HasColumnName("id");

        builder.Property(qo => qo.QuestionId)
            .IsRequired()
            .HasColumnName("question_id");

        builder.Property(qo => qo.Text)
            .IsRequired()
            .HasMaxLength(1000)
            .HasColumnName("text");

        builder.Property(qo => qo.IsCorrect)
            .HasColumnName("is_correct");

        // Relationships
        builder.HasOne(qo => qo.Question)
            .WithMany(q => q.Options)
            .HasForeignKey(qo => qo.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
