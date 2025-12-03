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
                // DEV ONLY: Seed user için güçlü şifre kullanılmalı, production'da değiştirilmeli
                // Bu hash development ortamı içindir
                PasswordHash = "$2a$11$K7sXL9VF.W8eQ4Qm7ybZwuPxHjVnZq3KvLmRcDfTgNhYjMpUvXsBC",
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

            // CATEGORY - Soru kategorisi (parent: EXAM_TYPE)
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
                ParentDefinitionId = Guid.Parse("00000009-9999-9999-9999-999999999999"), // EXAM_TYPE
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // SUBJECT - Soru konusu (parent: CATEGORY)
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
                ParentDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // TOPIC - Alt konu (parent: SUBJECT)
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
                ParentDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
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
            },

            // EXAM_TYPE - Sınav tipi
            new ParameterDefinition
            {
                Id = Guid.Parse("00000009-9999-9999-9999-999999999999"),
                Key = "EXAM_TYPE",
                Name = "Sınav Tipi",
                Description = "Sorunun ait olduğu sınav tipi (LGS, TYT, AYT, KPSS vb.)",
                DataType = "string",
                DefaultValue = null,
                IsRequired = false,
                ValidationRules = null,
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
                CreatedBy = MuhammedUserId,
                OptionsLayout = OptionsLayout.Vertical,
                Status = QuestionStatus.Approved,
                IsPublic = true,
                Points = 2,
                Category = "1", // Matematik
                Subject = "1", // Temel Matematik
                Topic = "1", // İşlem Önceliği
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Question
            {
                Id = MathQ2Id,
                Text = "x² - 4 = 0 denkleminin çözüm kümesi nedir?",
                ExamType = ExamType.YksTyt,
                CreatedBy = MuhammedUserId,
                OptionsLayout = OptionsLayout.Vertical,
                Status = QuestionStatus.Approved,
                IsPublic = true,
                Points = 3,
                Category = "1", // Matematik
                Subject = "2", // Cebir
                Topic = "2", // İkinci Dereceden Denklemler
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Question
            {
                Id = MathQ3Id,
                Text = "Bir dikdörtgenin alanı 24 cm², kısa kenarı 4 cm ise uzun kenarı kaç cm'dir?",
                ExamType = ExamType.YksTyt,
                CreatedBy = MuhammedUserId,
                OptionsLayout = OptionsLayout.Vertical,
                Status = QuestionStatus.Approved,
                IsPublic = true,
                Points = 2,
                Category = "1", // Matematik
                Subject = "3", // Geometri
                Topic = "3", // Alan Hesaplama
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

    // EXAM_TYPE IDs
    private static readonly Guid ExamTypeLgsId = Guid.Parse("10000004-0001-0001-0001-000000000001");
    private static readonly Guid ExamTypeTytId = Guid.Parse("10000004-0001-0001-0001-000000000002");
    private static readonly Guid ExamTypeAytId = Guid.Parse("10000004-0001-0001-0001-000000000003");

    // LGS CATEGORY IDs
    private static readonly Guid CategoryLgsMatId = Guid.Parse("10000001-0001-0001-0001-000000000101");
    private static readonly Guid CategoryLgsFenId = Guid.Parse("10000001-0001-0001-0001-000000000102");
    private static readonly Guid CategoryLgsTurkceId = Guid.Parse("10000001-0001-0001-0001-000000000103");
    private static readonly Guid CategoryLgsSosyalId = Guid.Parse("10000001-0001-0001-0001-000000000104");
    private static readonly Guid CategoryLgsIngilizceId = Guid.Parse("10000001-0001-0001-0001-000000000105");
    private static readonly Guid CategoryLgsDinId = Guid.Parse("10000001-0001-0001-0001-000000000106");

    // TYT CATEGORY IDs
    private static readonly Guid CategoryTytMatId = Guid.Parse("10000001-0001-0001-0001-000000000201");
    private static readonly Guid CategoryTytFizikId = Guid.Parse("10000001-0001-0001-0001-000000000202");
    private static readonly Guid CategoryTytKimyaId = Guid.Parse("10000001-0001-0001-0001-000000000203");
    private static readonly Guid CategoryTytBiyolojiId = Guid.Parse("10000001-0001-0001-0001-000000000204");
    private static readonly Guid CategoryTytTurkceId = Guid.Parse("10000001-0001-0001-0001-000000000205");
    private static readonly Guid CategoryTytCografyaId = Guid.Parse("10000001-0001-0001-0001-000000000206");
    private static readonly Guid CategoryTytTarihId = Guid.Parse("10000001-0001-0001-0001-000000000207");

    // LGS Matematik SUBJECT IDs
    private static readonly Guid SubjectLgsMatSayilarId = Guid.Parse("10000002-0001-0001-0001-000000000101");
    private static readonly Guid SubjectLgsMatCebirId = Guid.Parse("10000002-0001-0001-0001-000000000102");
    private static readonly Guid SubjectLgsMatGeometriId = Guid.Parse("10000002-0001-0001-0001-000000000103");

    // TYT Matematik SUBJECT IDs
    private static readonly Guid SubjectTytMatTemelId = Guid.Parse("10000002-0001-0001-0001-000000000201");
    private static readonly Guid SubjectTytMatCebirId = Guid.Parse("10000002-0001-0001-0001-000000000202");
    private static readonly Guid SubjectTytMatGeometriId = Guid.Parse("10000002-0001-0001-0001-000000000203");
    private static readonly Guid SubjectTytMatOlasilikId = Guid.Parse("10000002-0001-0001-0001-000000000204");

    public static void SeedParameterValues(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParameterValue>().HasData(
            // ========== EXAM_TYPE values (ROOT - no parent) ==========
            new ParameterValue
            {
                Id = ExamTypeLgsId,
                ParameterDefinitionId = Guid.Parse("00000009-9999-9999-9999-999999999999"), // EXAM_TYPE
                Value = "LGS",
                Name = "LGS",
                OrderNo = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = ExamTypeTytId,
                ParameterDefinitionId = Guid.Parse("00000009-9999-9999-9999-999999999999"), // EXAM_TYPE
                Value = "TYT",
                Name = "TYT",
                OrderNo = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = ExamTypeAytId,
                ParameterDefinitionId = Guid.Parse("00000009-9999-9999-9999-999999999999"), // EXAM_TYPE
                Value = "AYT",
                Name = "AYT",
                OrderNo = 3,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000004-0001-0001-0001-000000000004"),
                ParameterDefinitionId = Guid.Parse("00000009-9999-9999-9999-999999999999"), // EXAM_TYPE
                Value = "KPSS",
                Name = "KPSS",
                OrderNo = 4,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // ========== LGS CATEGORY values (ParentValueId = LGS) ==========
            new ParameterValue
            {
                Id = CategoryLgsMatId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "lgs_matematik",
                Name = "Matematik",
                OrderNo = 1,
                ParentValueId = ExamTypeLgsId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryLgsFenId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "lgs_fen",
                Name = "Fen Bilimleri",
                OrderNo = 2,
                ParentValueId = ExamTypeLgsId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryLgsTurkceId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "lgs_turkce",
                Name = "Türkçe",
                OrderNo = 3,
                ParentValueId = ExamTypeLgsId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryLgsSosyalId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "lgs_sosyal",
                Name = "Sosyal Bilgiler",
                OrderNo = 4,
                ParentValueId = ExamTypeLgsId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryLgsIngilizceId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "lgs_ingilizce",
                Name = "İngilizce",
                OrderNo = 5,
                ParentValueId = ExamTypeLgsId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryLgsDinId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "lgs_din",
                Name = "Din Kültürü",
                OrderNo = 6,
                ParentValueId = ExamTypeLgsId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // ========== TYT CATEGORY values (ParentValueId = TYT) ==========
            new ParameterValue
            {
                Id = CategoryTytMatId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "tyt_matematik",
                Name = "Temel Matematik",
                OrderNo = 1,
                ParentValueId = ExamTypeTytId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryTytFizikId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "tyt_fizik",
                Name = "Fizik",
                OrderNo = 2,
                ParentValueId = ExamTypeTytId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryTytKimyaId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "tyt_kimya",
                Name = "Kimya",
                OrderNo = 3,
                ParentValueId = ExamTypeTytId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryTytBiyolojiId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "tyt_biyoloji",
                Name = "Biyoloji",
                OrderNo = 4,
                ParentValueId = ExamTypeTytId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryTytTurkceId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "tyt_turkce",
                Name = "Türkçe",
                OrderNo = 5,
                ParentValueId = ExamTypeTytId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryTytCografyaId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "tyt_cografya",
                Name = "Coğrafya",
                OrderNo = 6,
                ParentValueId = ExamTypeTytId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = CategoryTytTarihId,
                ParameterDefinitionId = Guid.Parse("00000002-2222-2222-2222-222222222222"), // CATEGORY
                Value = "tyt_tarih",
                Name = "Tarih",
                OrderNo = 7,
                ParentValueId = ExamTypeTytId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // ========== LGS Matematik SUBJECT values ==========
            new ParameterValue
            {
                Id = SubjectLgsMatSayilarId,
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "lgs_mat_sayilar",
                Name = "Sayılar ve İşlemler",
                OrderNo = 1,
                ParentValueId = CategoryLgsMatId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = SubjectLgsMatCebirId,
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "lgs_mat_cebir",
                Name = "Cebir",
                OrderNo = 2,
                ParentValueId = CategoryLgsMatId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = SubjectLgsMatGeometriId,
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "lgs_mat_geometri",
                Name = "Geometri",
                OrderNo = 3,
                ParentValueId = CategoryLgsMatId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // ========== TYT Matematik SUBJECT values ==========
            new ParameterValue
            {
                Id = SubjectTytMatTemelId,
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "tyt_mat_temel",
                Name = "Temel Kavramlar",
                OrderNo = 1,
                ParentValueId = CategoryTytMatId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = SubjectTytMatCebirId,
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "tyt_mat_cebir",
                Name = "Cebir",
                OrderNo = 2,
                ParentValueId = CategoryTytMatId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = SubjectTytMatGeometriId,
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "tyt_mat_geometri",
                Name = "Geometri",
                OrderNo = 3,
                ParentValueId = CategoryTytMatId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = SubjectTytMatOlasilikId,
                ParameterDefinitionId = Guid.Parse("00000003-3333-3333-3333-333333333333"), // SUBJECT
                Value = "tyt_mat_olasilik",
                Name = "Olasılık ve İstatistik",
                OrderNo = 4,
                ParentValueId = CategoryTytMatId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // ========== TOPIC values for LGS Matematik/Sayılar ==========
            new ParameterValue
            {
                Id = Guid.Parse("10000003-0001-0001-0001-000000000101"),
                ParameterDefinitionId = Guid.Parse("00000004-4444-4444-4444-444444444444"), // TOPIC
                Value = "lgs_mat_sayilar_dogal",
                Name = "Doğal Sayılar",
                OrderNo = 1,
                ParentValueId = SubjectLgsMatSayilarId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000003-0001-0001-0001-000000000102"),
                ParameterDefinitionId = Guid.Parse("00000004-4444-4444-4444-444444444444"), // TOPIC
                Value = "lgs_mat_sayilar_kesir",
                Name = "Kesirler",
                OrderNo = 2,
                ParentValueId = SubjectLgsMatSayilarId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            // ========== TOPIC values for TYT Matematik/Temel Kavramlar ==========
            new ParameterValue
            {
                Id = Guid.Parse("10000003-0001-0001-0001-000000000201"),
                ParameterDefinitionId = Guid.Parse("00000004-4444-4444-4444-444444444444"), // TOPIC
                Value = "tyt_mat_temel_sayi",
                Name = "Sayı Basamakları",
                OrderNo = 1,
                ParentValueId = SubjectTytMatTemelId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000003-0001-0001-0001-000000000202"),
                ParameterDefinitionId = Guid.Parse("00000004-4444-4444-4444-444444444444"), // TOPIC
                Value = "tyt_mat_temel_bolunebilme",
                Name = "Bölünebilme Kuralları",
                OrderNo = 2,
                ParentValueId = SubjectTytMatTemelId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new ParameterValue
            {
                Id = Guid.Parse("10000003-0001-0001-0001-000000000203"),
                ParameterDefinitionId = Guid.Parse("00000004-4444-4444-4444-444444444444"), // TOPIC
                Value = "tyt_mat_temel_ebob_ekok",
                Name = "EBOB-EKOK",
                OrderNo = 3,
                ParentValueId = SubjectTytMatTemelId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        );
    }
}
