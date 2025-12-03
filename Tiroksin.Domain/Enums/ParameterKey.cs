namespace Tiroksin.Domain.Enums;

/// <summary>
/// Sistemdeki parametre tanımlarının key değerleri
/// </summary>
public enum ParameterKey
{
    /// <summary>
    /// Soru başına süre (saniye)
    /// </summary>
    QuestionTime = 1,

    /// <summary>
    /// Soru kategorisi (Matematik, Fizik, Kimya vb.)
    /// </summary>
    Category = 2,

    /// <summary>
    /// Soru konusu (Türev, İntegral vb.)
    /// </summary>
    Subject = 3,

    /// <summary>
    /// Alt konu
    /// </summary>
    Topic = 4,

    /// <summary>
    /// Etiketler (JSON array)
    /// </summary>
    Tags = 6,

    /// <summary>
    /// Soru kaynağı (TYT 2023, AYT 2022 vb.)
    /// </summary>
    Source = 7,

    /// <summary>
    /// Sınav yılı
    /// </summary>
    Year = 8,

    /// <summary>
    /// Sınav tipi (LGS, TYT, AYT, KPSS vb.)
    /// </summary>
    ExamType = 9
}

/// <summary>
/// ParameterKey enum için extension metodları
/// </summary>
public static class ParameterKeyExtensions
{
    /// <summary>
    /// Enum değerini veritabanındaki string key'e çevirir
    /// </summary>
    public static string ToKeyString(this ParameterKey key)
    {
        return key switch
        {
            ParameterKey.QuestionTime => "QUESTION_TIME",
            ParameterKey.Category => "CATEGORY",
            ParameterKey.Subject => "SUBJECT",
            ParameterKey.Topic => "TOPIC",
            ParameterKey.Tags => "TAGS",
            ParameterKey.Source => "SOURCE",
            ParameterKey.Year => "YEAR",
            ParameterKey.ExamType => "EXAM_TYPE",
            _ => throw new ArgumentOutOfRangeException(nameof(key), key, null)
        };
    }

    /// <summary>
    /// String key'i enum değerine çevirir
    /// </summary>
    public static ParameterKey? FromKeyString(string keyString)
    {
        return keyString?.ToUpperInvariant() switch
        {
            "QUESTION_TIME" => ParameterKey.QuestionTime,
            "CATEGORY" => ParameterKey.Category,
            "SUBJECT" => ParameterKey.Subject,
            "TOPIC" => ParameterKey.Topic,
            "TAGS" => ParameterKey.Tags,
            "SOURCE" => ParameterKey.Source,
            "YEAR" => ParameterKey.Year,
            "EXAM_TYPE" => ParameterKey.ExamType,
            _ => null
        };
    }
}
