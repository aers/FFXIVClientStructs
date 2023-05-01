namespace FFXIVClientStructs.Attributes;

// Make CExporter ignore this field when building headers
[AttributeUsage(AttributeTargets.Field)]
public class IDAIgnoreAttribute : Attribute
{
}
