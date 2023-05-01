namespace FFXIVClientStructs.Attributes;

// Control whether field is considered a member or a base class.
// By default, field at offset 0 is considered a base class if it has the same name as the type.
// For multiple inheritance, it is possible to manually mark successive fields as bases.
// Default behaviour can also be suppressed if desired.
[AttributeUsage(AttributeTargets.Field)]
public class IDABaseClassAttribute : Attribute
{
    public bool IsBase;

    public IDABaseClassAttribute(bool isBase = true)
    {
        IsBase = isBase;
    }
}
