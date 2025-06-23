namespace KefTools.Frontend.Framework.Generators.Property;

/// <summary>
/// Contract for a reusable UserControl that represents a setting.
/// </summary>
public interface IPropertyControl
{
    /// <summary>Get or set the current value of the setting control.</summary>
    string Value { get; set; }

    /// <summary>Label displayed for the setting (optional).</summary>
    string Label { get; set; }
}
