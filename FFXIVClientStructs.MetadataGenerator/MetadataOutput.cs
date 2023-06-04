using System.Text.Json;
using System.Text.Json.Serialization;

namespace FFXIVClientStructs.MetadataGenerator;

public class MetadataOutput {
    public List<MetadataStruct> Structs { get; set; }
    public List<MetadataEnum> Enums { get; set; }
    public List<MetadataUnion> Unions { get; set; }
    public List<MetadataFunction> Functions { get; set; }
    public List<MetadataStaticAddressInfo> Globals { get; set; }
}

public class MetadataStruct {
    public string Name { get; set; }
    public uint? Size { get; set; }
    public MetadataStaticAddressInfo? VTableAddress { get; set; }
    public List<MetadataField> Fields { get; set; }
}

public class MetadataEnum {
    public string Name { get; set; }

    [JsonConverter(typeof(MetadataTypeConverter))]
    public Type Type { get; set; }

    public Dictionary<string, long> Values { get; set; }
}

public class MetadataUnion {
    public string Name { get; set; }
    public List<MetadataField> Fields { get; set; }
}

public class MetadataField {
    public string Name { get; set; }
    public uint Offset { get; set; }
    public uint Size { get; set; }
    public uint PointerIndirection { get; set; }
    public uint ArraySize { get; set; }

    // Omega jank ahead
    [JsonConverter(typeof(MetadataTypeConverter))] [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Type? Type { get; set; }

    [JsonConverter(typeof(MetadataUnionConverter))] [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UnionType { get; set; }
}

public class MetadataFunction {
    public string Name { get; set; }
    public MetadataAddressInfo AddressInfo { get; set; }

    [JsonConverter(typeof(MetadataArgumentConverter))]
    public List<(Type, string)> Arguments { get; set; }

    [JsonConverter(typeof(MetadataTypeConverter))]
    public Type ReturnType { get; set; }
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(MetadataMemberFunctionInfo), "MemberFunction")]
[JsonDerivedType(typeof(MetadataVirtualFunctionInfo), "VirtualFunction")]
public class MetadataAddressInfo { }

public class MetadataMemberFunctionInfo : MetadataAddressInfo {
    public string Signature { get; set; }
}

public class MetadataVirtualFunctionInfo : MetadataAddressInfo {
    public string VTable { get; set; }
    public uint Index { get; set; }
}

public class MetadataStaticAddressInfo {
    public string Signature { get; set; }
    public int Offset { get; set; }
    public bool IsPointer { get; set; }
    public string Name { get; set; }

    [JsonConverter(typeof(MetadataTypeConverter))]
    public Type Type { get; set; }
}

// Very stupid way of doing this
public class MetadataTypeConverter : JsonConverter<Type> {
    public override Type Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        throw new NotImplementedException();

    public override void Write(Utf8JsonWriter writer, Type? value, JsonSerializerOptions options) {
        if (value == null) return;
        writer.WriteStringValue(NameHelpers.FixTypeName(value));
    }
}

public class MetadataArgumentConverter : JsonConverter<List<(Type, string)>> {
    public override List<(Type, string)> Read(ref Utf8JsonReader reader, Type typeToConvert,
        JsonSerializerOptions options) =>
        throw new NotImplementedException();

    public override void Write(Utf8JsonWriter writer, List<(Type, string)> value, JsonSerializerOptions options) {
        writer.WriteStartArray();

        foreach (var type in value) {
            writer.WriteStartArray();
            writer.WriteStringValue(NameHelpers.FixTypeName(type.Item1));
            writer.WriteStringValue(type.Item2);
            writer.WriteEndArray();
        }

        writer.WriteEndArray();
    }
}

// Unions aren't real types in this, so it's easier to just fake it, lol
public class MetadataUnionConverter : JsonConverter<string> {
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        throw new NotImplementedException();

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options) {
        if (value == null) return;
        writer.WriteStringValue(value);
    }
}
