using Tiroksin.Core.BaseClasses;

namespace Tiroksin.Domain.Entities;

/// <summary>
/// Parameter value - stores predefined values for parameter definitions (like enum values)
/// Example: For USER_TYPE definition: {value: "teacher", name: "Öğretmen", order_no: 1}
/// </summary>
public class ParameterValue : AuditEntity
{
    /// <summary>
    /// Reference to the parameter definition
    /// </summary>
    public Guid ParameterDefinitionId { get; set; }

    /// <summary>
    /// Code/Key value used in backend (e.g., "matematik", "teacher")
    /// </summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>
    /// Display name shown in UI (e.g., "Matematik", "Öğretmen")
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Sort order for displaying in dropdowns/combos
    /// </summary>
    public int OrderNo { get; set; } = 0;

    // Navigation property
    public virtual ParameterDefinition ParameterDefinition { get; set; } = null!;
}
