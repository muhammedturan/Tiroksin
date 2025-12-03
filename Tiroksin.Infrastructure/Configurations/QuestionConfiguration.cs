using Tiroksin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tiroksin.Infrastructure.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("questions");

        builder.HasKey(q => q.Id);
        builder.Property(q => q.Id).HasColumnName("id");

        builder.Property(q => q.Text)
            .IsRequired()
            .HasColumnName("text"); // Removed MaxLength to allow large HTML content with images

        builder.Property(q => q.ImageUrl)
            .HasMaxLength(500)
            .HasColumnName("image_url");

        builder.Property(q => q.OptionsLayout)
            .IsRequired()
            .HasColumnName("options_layout")
            .HasConversion<int>();

        builder.Property(q => q.ExamType)
            .IsRequired()
            .HasColumnName("exam_type")
            .HasConversion<int>();

        // Parameter columns (db: _pr suffix, code: no suffix)
        builder.Property(q => q.Category).HasColumnName("category_pr");
        builder.Property(q => q.Subject).HasColumnName("subject_pr");
        builder.Property(q => q.Topic).HasColumnName("topic_pr");

        builder.Property(q => q.Status)
            .IsRequired()
            .HasColumnName("status")
            .HasConversion<int>();

        builder.Property(q => q.IsPublic)
            .IsRequired()
            .HasColumnName("is_public");

        builder.Property(q => q.ViewCount)
            .IsRequired()
            .HasColumnName("view_count");

        builder.Property(q => q.AttemptCount)
            .IsRequired()
            .HasColumnName("attempt_count");

        builder.Property(q => q.CorrectCount)
            .IsRequired()
            .HasColumnName("correct_count");

        builder.Property(q => q.Points)
            .IsRequired()
            .HasColumnName("points");

        // Audit fields from AuditEntity
        builder.Property(q => q.CreatedAt).HasColumnName("created_at");
        builder.Property(q => q.UpdatedAt).HasColumnName("updated_at");
        builder.Property(q => q.CreatedBy).HasColumnName("created_by");
        builder.Property(q => q.UpdatedBy).HasColumnName("updated_by");

        // Relationships
        builder.HasOne(q => q.Creator)
            .WithMany()
            .HasForeignKey(q => q.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

        // NOTE: Subject and Topic relationships removed - now using ParameterValue system

        builder.HasMany(q => q.Options)
            .WithOne(o => o.Question)
            .HasForeignKey(o => o.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // NOTE: UserAnswers removed - Elimination mode only uses GameAnswer
    }
}
