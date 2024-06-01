namespace FFXIVClientStructs.Attributes;

[AttributeUsage(AttributeTargets.Field)]
internal class CExporterUnionAttribute : Attribute {
    public string Union { get; }
    public string Struct { get; }
    public bool IsStruct { get; }

    /// <summary>
    /// Creates a struct union with the given union and fields.
    /// </summary>
    /// <param name="union">The union to use for the union and sub struct</param>
    /// <param name="isStruct"></param>
    public CExporterUnionAttribute(string union, string @struct = "", bool isStruct = false) {
        if (isStruct && string.IsNullOrEmpty(@struct)) throw new ArgumentException("Struct name must be provided if IsStruct is true");
        Union = union;
        Struct = @struct;
        IsStruct = isStruct;
    }

    public bool Equals(CExporterUnionAttribute? other) => other is not null && Union == other.Union && Struct == other.Struct && IsStruct == other.IsStruct;

    public override bool Equals(object? obj) => obj is CExporterUnionAttribute attr && Equals(attr);

    public override int GetHashCode() => HashCode.Combine(Union, Struct, IsStruct);

    public static bool operator ==(CExporterUnionAttribute? left, CExporterUnionAttribute? right) => left?.Equals(right) ?? right is null;

    public static bool operator !=(CExporterUnionAttribute? left, CExporterUnionAttribute? right) => !(left == right);

    public override string ToString() => $"{Union}.{Struct}";
}

[AttributeUsage(AttributeTargets.Struct)]
internal class CExporterStructUnionAttribute : Attribute;
