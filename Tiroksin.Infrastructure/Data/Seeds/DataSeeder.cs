using Tiroksin.Domain.Entities;
using Tiroksin.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Tiroksin.Infrastructure.Data.Seeds;

public static class DataSeeder
{
    // Question IDs
    private static readonly Guid MathQ1Id = Guid.Parse("eeeeeeee-1111-1111-1111-111111111111");
    private static readonly Guid MathQ2Id = Guid.Parse("eeeeeeee-2222-2222-2222-222222222222");
    private static readonly Guid MathQ3Id = Guid.Parse("eeeeeeee-3333-3333-3333-333333333333");

    // User IDs
    private static readonly Guid MuhammedUserId = Guid.Parse("cdce62f1-cdf8-4ca7-9e56-a5f85303cee6");

    public static void SeedUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = MuhammedUserId,
                Username = "muhammedturan",
                Email = "muhammedturan@yahoo.com",
                DisplayName = "muhammed",
                PasswordHash = "$2a$11$MKiZ20zeoqBTNPV5HxwRruNo8uK4KQmNcD9eK3ndrZQZCHyOoesAW", // Password: 123456
                Avatar = "👤",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
    }

    public static void SeedParameterDefinitions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParameterDefinition>().HasData(
            // QUESTION_TIME - Soru başına süre
            new ParameterDefinition
            {
                Id = Guid.Parse("00000001-1111-1111-1111-111111111111"),
                Key = "QUESTION_TIME",
                Name = "Soru Başına Süre",
                Description = "Her soru için verilen süre (saniye cinsinden)",
                DataType = "int",
                DefaultValue = "60",
                IsRequired = false,
                ValidationRules = "{\"min\": 10, \"max\": 300}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // CATEGORY - Soru kategorisi
            new ParameterDefinition
            {
                Id = Guid.Parse("00000002-2222-2222-2222-222222222222"),
                Key = "CATEGORY",
                Name = "Kategori",
                Description = "Sorunun ait olduğu kategori (örn: Matematik, Fizik, Kimya)",
                DataType = "string",
                DefaultValue = null,
                IsRequired = false,
                ValidationRules = "{\"maxLength\": 100}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // SUBJECT - Soru konusu
            new ParameterDefinition
            {
                Id = Guid.Parse("00000003-3333-3333-3333-333333333333"),
                Key = "SUBJECT",
                Name = "Konu",
                Description = "Sorunun ait olduğu konu (örn: Türev, Integral)",
                DataType = "string",
                DefaultValue = null,
                IsRequired = false,
                ValidationRules = "{\"maxLength\": 200}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // TOPIC - Alt konu
            new ParameterDefinition
            {
                Id = Guid.Parse("00000004-4444-4444-4444-444444444444"),
                Key = "TOPIC",
                Name = "Alt Konu",
                Description = "Sorunun ait olduğu alt konu",
                DataType = "string",
                DefaultValue = null,
                IsRequired = false,
                ValidationRules = "{\"maxLength\": 200}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // DIFFICULTY - Zorluk seviyesi
            new ParameterDefinition
            {
                Id = Guid.Parse("00000005-5555-5555-5555-555555555555"),
                Key = "DIFFICULTY",
                Name = "Zorluk Seviyesi",
                Description = "Sorunun zorluk seviyesi (Kolay, Orta, Zor)",
                DataType = "string",
                DefaultValue = "Orta",
                IsRequired = false,
                ValidationRules = "{\"enum\": [\"Kolay\", \"Orta\", \"Zor\"]}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // TAGS - Etiketler
            new ParameterDefinition
            {
                Id = Guid.Parse("00000006-6666-6666-6666-666666666666"),
                Key = "TAGS",
                Name = "Etiketler",
                Description = "Soru etiketleri (JSON array)",
                DataType = "json",
                DefaultValue = "[]",
                IsRequired = false,
                ValidationRules = "{\"type\": \"array\"}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // SOURCE - Soru kaynağı
            new ParameterDefinition
            {
                Id = Guid.Parse("00000007-7777-7777-7777-777777777777"),
                Key = "SOURCE",
                Name = "Kaynak",
                Description = "Sorunun kaynağı (örn: TYT 2023, AYT 2022)",
                DataType = "string",
                DefaultValue = null,
                IsRequired = false,
                ValidationRules = "{\"maxLength\": 100}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // YEAR - Sınav yılı
            new ParameterDefinition
            {
                Id = Guid.Parse("00000008-8888-8888-8888-888888888888"),
                Key = "YEAR",
                Name = "Yıl",
                Description = "Sorunun ait olduğu sınav yılı",
                DataType = "int",
                DefaultValue = null,
                IsRequired = false,
                ValidationRules = "{\"min\": 2000, \"max\": 2100}",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
    }

    public static void SeedQuestions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>().HasData(
            new Question
            {
                Id = MathQ1Id,
                Text = "5 + 3 x 2 işleminin sonucu kaçtır?",
                ExamType = ExamType.YksTyt,
                Difficulty = Difficulty.Easy,
                CreatedBy = MuhammedUserId,
                OptionsLayout = OptionsLayout.Vertical,
                Status = QuestionStatus.Approved,
                IsPublic = true,
                Points = 2,
                CategoryPr = "1", // Matematik
                SubjectPr = "1", // Temel Matematik
                TopicPr = "1", // İşlem Önceliği
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Question
            {
                Id = MathQ2Id,
                Text = "x² - 4 = 0 denkleminin çözüm kümesi nedir?",
                ExamType = ExamType.YksTyt,
                Difficulty = Difficulty.Medium,
                CreatedBy = MuhammedUserId,
                OptionsLayout = OptionsLayout.Vertical,
                Status = QuestionStatus.Approved,
                IsPublic = true,
                Points = 3,
                CategoryPr = "1", // Matematik
                SubjectPr = "2", // Cebir
                TopicPr = "2", // İkinci Dereceden Denklemler
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Question
            {
                Id = MathQ3Id,
                Text = "Bir dikdörtgenin alanı 24 cm², kısa kenarı 4 cm ise uzun kenarı kaç cm'dir?",
                ExamType = ExamType.YksTyt,
                Difficulty = Difficulty.Easy,
                CreatedBy = MuhammedUserId,
                OptionsLayout = OptionsLayout.Vertical,
                Status = QuestionStatus.Approved,
                IsPublic = true,
                Points = 2,
                CategoryPr = "1", // Matematik
                SubjectPr = "3", // Geometri
                TopicPr = "3", // Alan Hesaplama
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
    }

    public static void SeedQuestionOptions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuestionOption>().HasData(
            // Question 1 options
            new QuestionOption { Id = Guid.Parse("00000001-0001-0001-0001-000000000001"), QuestionId = MathQ1Id, OptionKey = "", Text = "16", IsCorrect = false },
            new QuestionOption { Id = Guid.Parse("00000001-0001-0001-0001-000000000002"), QuestionId = MathQ1Id, OptionKey = "", Text = "11", IsCorrect = true },
            new QuestionOption { Id = Guid.Parse("00000001-0001-0001-0001-000000000003"), QuestionId = MathQ1Id, OptionKey = "", Text = "13", IsCorrect = false },
            new QuestionOption { Id = Guid.Parse("00000001-0001-0001-0001-000000000004"), QuestionId = MathQ1Id, OptionKey = "", Text = "10", IsCorrect = false },
            new QuestionOption { Id = Guid.Parse("00000001-0001-0001-0001-000000000005"), QuestionId = MathQ1Id, OptionKey = "", Text = "8", IsCorrect = false },

            // Question 2 options
            new QuestionOption { Id = Guid.Parse("00000001-0002-0002-0002-000000000001"), QuestionId = MathQ2Id, OptionKey = "", Text = "{2}", IsCorrect = false },
            new QuestionOption { Id = Guid.Parse("00000001-0002-0002-0002-000000000002"), QuestionId = MathQ2Id, OptionKey = "", Text = "{-2}", IsCorrect = false },
            new QuestionOption { Id = Guid.Parse("00000001-0002-0002-0002-000000000003"), QuestionId = MathQ2Id, OptionKey = "", Text = "{-2, 2}", IsCorrect = true },
            new QuestionOption { Id = Guid.Parse("00000001-0002-0002-0002-000000000004"), QuestionId = MathQ2Id, OptionKey = "", Text = "{4}", IsCorrect = false },
            new QuestionOption { Id = Guid.Parse("00000001-0002-0002-0002-000000000005"), QuestionId = MathQ2Id, OptionKey = "", Text = "Çözüm yok", IsCorrect = false },

            // Question 3 options
            new QuestionOption { Id = Guid.Parse("00000001-0003-0003-0003-000000000001"), QuestionId = MathQ3Id, OptionKey = "", Text = "4 cm", IsCorrect = false },
            new QuestionOption { Id = Guid.Parse("00000001-0003-0003-0003-000000000002"), QuestionId = MathQ3Id, OptionKey = "", Text = "5 cm", IsCorrect = false },
            new QuestionOption { Id = Guid.Parse("00000001-0003-0003-0003-000000000003"), QuestionId = MathQ3Id, OptionKey = "", Text = "6 cm", IsCorrect = true },
            new QuestionOption { Id = Guid.Parse("00000001-0003-0003-0003-000000000004"), QuestionId = MathQ3Id, OptionKey = "", Text = "8 cm", IsCorrect = false },
            new QuestionOption { Id = Guid.Parse("00000001-0003-0003-0003-000000000005"), QuestionId = MathQ3Id, OptionKey = "", Text = "10 cm", IsCorrect = false }
        );
    }

    public static void SeedParameterValues(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParameterValue>().HasData(
            // CATEGORY values
            new ParameterValue
            {
                Id = Guid.Parse("10000001-0001-0001-0001-000000000001"),
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "1",
                Name = "Matematik",
                OrderNo = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000001-0001-0001-0001-000000000002"),
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "2",
                Name = "Fizik",
                OrderNo = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000001-0001-0001-0001-000000000003"),
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "3",
                Name = "Kimya",
                OrderNo = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000001-0001-0001-0001-000000000004"),
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "4",
                Name = "Biyoloji",
                OrderNo = 4,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000001-0001-0001-0001-000000000005"),
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "5",
                Name = "Türkçe",
                OrderNo = 5,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // SUBJECT values
            new ParameterValue
            {
                Id = Guid.Parse("10000002-0001-0001-0001-000000000001"),
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "1",
                Name = "Temel Matematik",
                OrderNo = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000002-0001-0001-0001-000000000002"),
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "2",
                Name = "Cebir",
                OrderNo = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000002-0001-0001-0001-000000000003"),
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "3",
                Name = "Geometri",
                OrderNo = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000002-0001-0001-0001-000000000004"),
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "4",
                Name = "Türev",
                OrderNo = 4,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000002-0001-0001-0001-000000000005"),
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "5",
                Name = "İntegral",
                OrderNo = 5,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // TOPIC values
            new ParameterValue
            {
                Id = Guid.Parse("10000003-0001-0001-0001-000000000001"),
                ParameterDefinitionId = Guid.Parse("00000004-4444-4444-4444-444444444444"), // TOPIC
                Value = "1",
                Name = "İşlem Önceliği",
                OrderNo = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000003-0001-0001-0001-000000000002"),
                ParameterDefinitionId = Guid.Parse("00000004-4444-4444-4444-444444444444"), // TOPIC
                Value = "2",
                Name = "İkinci Dereceden Denklemler",
                OrderNo = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000003-0001-0001-0001-000000000003"),
                ParameterDefinitionId = Guid.Parse("00000004-4444-4444-4444-444444444444"), // TOPIC
                Value = "3",
                Name = "Alan Hesaplama",
                OrderNo = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
    }
}
