namespace KefTools.Frontend.Framework.Generators.Property
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PropertyAttribute(PropertyType type, string? label = null) : Attribute
    {
        public PropertyType Type { get; } = type;
        public string? Label { get; } = label;
    }
}