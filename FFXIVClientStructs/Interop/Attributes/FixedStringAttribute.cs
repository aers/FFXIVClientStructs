namespace FFXIVClientStructs.Interop.Attributes;

[AttributeUsage(AttributeTargets.Field)]
public class FixedStringAttribute : Attribute {
    public FixedStringAttribute(string propertyName = "") {
        this.PropertyName = propertyName;
    }

    public string? PropertyName { get; }
}
