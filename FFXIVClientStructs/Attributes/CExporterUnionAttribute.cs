using System.Diagnostics.CodeAnalysis;

namespace FFXIVClientStructs.Attributes;
[AttributeUsage(AttributeTargets.Field)]
internal class CExporterUnionAttribute : Attribute {
    public string Union { get; }
    public string Struct { get; }
    public bool IsStruct { get; }

    /// <summary>
    /// Creates a struct union with the given name and fields.
    /// </summary>
    /// <param name="name">The name to use for the union and sub struct</param>
    public CExporterUnionAttribute(string name, bool isStruct = false) {
        var n = name.Split('.');
        if (n is not [{ } union, { } @struct] || n.Length > 2) throw new ArgumentException("Name must be in the format 'Union.Struct'", nameof(name));
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
internal class CExporterStructUnionAttribute : Attribute { }
