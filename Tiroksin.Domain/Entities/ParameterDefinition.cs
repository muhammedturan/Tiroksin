using Tiroksin.Core.BaseClasses;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Generic parameter definition - defines parameter types that can be used across the system
/// Examples: QUESTION_TIME, CATEGORY, DIFFICULTY, etc.
/// </summary>
public class ParameterDefinition : AuditEntity
{
    /// <summary>
    /// Unique key for the parameter (e.g., "QUESTION_TIME", "CATEGORY", "DIFFICULTY")
    /// </summary>
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Display name for the parameter
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Description of what this parameter is used for
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Data type: string, int, bool, json, decimal
    /// </summary>
    public string DataType { get; set; } = "string";

    /// <summary>
    /// Default value (stored as string, parsed based on DataType)
    /// </summary>
    public string? DefaultValue { get; set; }

    /// <summary>
    /// Is this parameter required?
    /// </summary>
    public bool IsRequired { get; set; } = false;

    /// <summary>
    /// Validation rules (JSON format)
    /// Example: {"min": 10, "max": 300} for QUESTION_TIME
    /// </summary>
    public string? ValidationRules { get; set; }

    // Navigation property
    public virtual ICollection<ParameterValue> Values { get; set; } = new List<ParameterValue>();
}
