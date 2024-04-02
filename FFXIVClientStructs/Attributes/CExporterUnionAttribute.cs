namespace FFXIVClientStructs.Attributes;
[AttributeUsage(AttributeTargets.Field)]
internal class CExporterUnionAttribute : Attribute {
    public string Union { get; private set; }
    public string Struct { get; private set; }
    public bool IsStruct { get; private set; }
    
    /// <summary>
    /// Creates a struct union with the given name and fields.
    /// </summary>
    /// <param name="name">The name to use for the union and sub struct</param>
    public CExporterUnionAttribute(string name, bool isStruct = false) {
        var n = name.Split('.');
        if (n is not [{ } union, { } @struct]) throw new ArgumentException("Name must be in the format 'Union.Struct'", nameof(name));
        Union = union;
        Struct = @struct;
        IsStruct = isStruct;
    }
}
