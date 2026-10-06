using System;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;

namespace CExporter;

public class YamlExport {
    public required ProcessedEnum[] Enums;
    public required ProcessedStruct[] Structs;
}

public class ProcessedBitField {
    public required int Size;
    public required int Offset;
    public required Type Type;
    public required string Name;
}

public class ProcessedFieldUnion {
    public required Type FieldType;
    public required string FieldName;
    public required string? FieldTypeOverride;
}

public class ProcessedField {
    public string? FieldTypeOverride;
    public bool? FieldTypeOverrideCheck;
    public Type[]? FieldTypeOverrideTemplates;
    public required Type FieldType;
    public required string FieldName;
    public required int FieldOffset;
    public required bool IsUnion;
    public required ProcessedFieldUnion[] UnionValues;
    public bool IsBase;
    public required ProcessedBitField[] Bits;
    public virtual int FieldSize => FieldType.SizeOf();
}

public class ProcessedFixedField : ProcessedField {
    public required int FixedSize;
    public bool FixedString;

    public override int FieldSize => FixedSize * FieldType.SizeOf();
}

public class ProcessedFunctionField : ProcessedField {
    public required Type FunctionReturnType;
    public required ProcessedField[] FunctionParameters;
}

public class ProcessedStaticMembers {
    public required string Signature;
    public required ushort[] RelativeFollowOffsets;
    public bool IsPointer;
    public required Type ReturnType;
}

// TODO: Export if struct is generic with types
public class ProcessedStruct {
    public required string? StructTypeOverride;
    public required bool IsUnion;
    public required Type StructType;
    public required string StructName;
    public required string StructNamespace;
    public required int StructSize;
    public required ProcessedField[] Fields;
    public required int VirtualFunctionSize;
    public ProcessedVirtualFunction[]? VirtualFunctions; // null if there are no virtual functions, empty if there's a vtable with unknown contents
    public required ProcessedMemberFunction[] MemberFunctions;
    public ProcessedMemberFunction[]? StaticMemberFunctions;
    public ProcessedStaticMembers[]? StaticMembers;
    public required string[] TemplateTypes;
    [YamlIgnore]
    public string StructTypeName => StructTypeOverride ?? StructType.FixTypeName();
    [YamlIgnore]
    private string[] _dependencyNames = [];
    [YamlIgnore]
    public string[] DependencyNames {
        get {
            if (_dependencyNames.Length == 0) {
                _dependencyNames = Fields
                    .Where(t => {
                        if (t.FieldTypeOverride == null) return (t.GetType() == typeof(ProcessedField) || t.GetType() == typeof(ProcessedFixedField)) && !t.FieldType.ShouldNotExportType() && !ExporterStatics.BaseTypeNames.Contains(t.FieldType.FixTypeName()) && !t.FieldType.ContainsGenericParameters;
                        if (t.FieldTypeOverride.EndsWith('*') || t.FieldTypeOverride.StartsWith("Component::Exd::Sheets::") || ExporterStatics.BaseTypeNames.Contains(t.FieldTypeOverride)) return false;
                        return !t.FieldTypeOverrideCheck.HasValue || !t.FieldTypeOverrideCheck.Value;
                    })
                    .SelectMany(t => {
                        if (t.FieldTypeOverride?.StartsWith(ExporterStatics.StdCppNamespace) ?? false) return t.FieldTypeOverrideTemplates!.Where(k => !k.ShouldNotExportType()).Select(k => k.FixTypeName()).Where(k => !ExporterStatics.BaseTypeNames.Contains(k));
                        return [t.FieldTypeOverride ?? t.FieldType.FixTypeName()];
                    }).Distinct().ToArray();
            }
            return _dependencyNames;
        }
    }
    public ProcessedStruct FixOrder() {
        Fields = [.. Fields.OrderBy(t => t.FieldOffset)];
        return this;
    }
}

public class ProcessedEnum {
    public required Type EnumType;
    public required string EnumName;
    public required string EnumNamespace;
    public required bool IsFlags;
    public required Dictionary<string, string> EnumValues;
}

public class ProcessedVirtualFunction {
    public required string VirtualFunctionName;
    public required int Offset;
    public required Type? VirtualFunctionReturnType;
    public required ProcessedField[]? VirtualFunctionParameters;
    public required string? VirtualFunctionReturnTypeOverride;
}

public class ProcessedMemberFunction {
    public required string MemberFunctionSignature;
    public required string MemberFunctionName;
    public required ProcessedMemberFunctionReturn MemberFunctionReturnType;
    public required ProcessedField[] MemberFunctionParameters;
}

public class ProcessedMemberFunctionReturn(Type type, string? overrideType) {
    public Type Type = type;
    public string? OverrideType = overrideType;
    public static implicit operator ProcessedMemberFunctionReturn((Type Type, string OverrideType) value) => new(value.Type, value.OverrideType);
    public static implicit operator (Type Type, string? OverrideType)(ProcessedMemberFunctionReturn value) => (value.Type, value.OverrideType);
    public static implicit operator ProcessedMemberFunctionReturn(Type type) => new(type, null);
    public static implicit operator Type(ProcessedMemberFunctionReturn value) => value.Type;
    public static implicit operator string(ProcessedMemberFunctionReturn value) => value.OverrideType ?? value.Type.FixTypeName();
}

public record ProcessingType(Type Type, string? OverrideTypeName) {
    public static implicit operator Type(ProcessingType t) => t.Type;
    public static implicit operator ProcessingType(Type t) => new(t, null);
}
