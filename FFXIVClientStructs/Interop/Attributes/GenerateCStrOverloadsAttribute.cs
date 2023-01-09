namespace FFXIVClientStructs.Interop.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class GenerateCStrOverloadsAttribute : Attribute
{
    public GenerateCStrOverloadsAttribute(string? ignoreArgument = null)
    {
        this.IgnoreArgument = ignoreArgument;
    }
    
    public string? IgnoreArgument { get; }
}