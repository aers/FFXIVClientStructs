using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using FFXIVClientStructs.Attributes;

namespace CExporter;

public enum GapStrategy {
    FullSize,   // Fill gaps in structs with sequential longs, ints, shorts, or bytes
    ByteArray,  // Fill gaps in structs with byte arrays
}

public static class ExporterStatics {
    private static Type[]? _definedTypes;

    public static Type[] DefinedTypes => _definedTypes ??= GetExportableTypes();

#pragma warning disable CA2211
    // ReSharper disable once InconsistentNaming
    public static string FFXIVNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.FFXIV), "");
    public static string StdNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.STD), "");
    public static string InteropNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.Interop), "");

    public static string[] IgnoredTypeNames = { "MemberFunctionPointers", "StaticAddressPointers", "Addresses" };
    public static Dictionary<Type, string> ErrorListDictionary = new();
    public static Dictionary<Type, string> WarningListDictionary = new();
#pragma warning restore CA2211

    private static Type[] GetExportableTypes() {
        var assembly = AppDomain.CurrentDomain.Load(nameof(FFXIVClientStructs));

        Type[] definedTypes;
        try {
            definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
        } catch (ReflectionTypeLoadException ex) {
            definedTypes = ex.Types.Where(t => t != null).ToArray()!;
        }

        return definedTypes.Where(t => t.FullName!.StartsWith(FFXIVNamespacePrefix)).ToArray();
    }

}

// ReSharper disable once InconsistentNaming
public class ExporterIDA : ExporterBase {
    public ExporterIDA() : base("::") {
    }

    protected override string GetEnumName(Type type) {
        return $"enum {type.FixTypeName(FixFullName)}: {type.GetEnumUnderlyingType().FixTypeName(FixFullName)}";
    }
}

public class ExporterGhidra : ExporterBase {
    public ExporterGhidra() : base("_") {
    }

    protected override string GetEnumName(Type type) {
        //Ghidra doesn't support setting enum sizes so this is exported as a comment instead
        return $"enum {type.FixTypeName(FixFullName)} /* Size=0x{type.GetEnumUnderlyingType().SizeOf():X} */";
    }
}

public abstract class ExporterBase {
    private readonly string _separator;

    private readonly Dictionary<string, string> _nameOverride = new() { { "EventHandler", "EventHandlerStruct" } };

    private GapStrategy _gapStrategy;

    private readonly HashSet<Type> _knownTypes = new();

    public bool Errored { get; private set; }

    protected ExporterBase(string separator) {
        _separator = separator;
    }

    public string Export(GapStrategy gapStrategy) {
        _knownTypes.Clear();

        _gapStrategy = gapStrategy;

        var sb = new StringBuilder();

        var definedTypes = ExporterStatics.DefinedTypes.OrderBy(t => t.FullName).ToArray();

        sb.AppendLine("// Forward References");
        sb.AppendLine("__{0}__");
        //definedTypes.Where(t => t.IsStruct() && !t.IsFixedBuffer()).Select(t => $"struct {FixFullName(t)};").ToList().ForEach(t => sb.AppendLine(t));

        sb.AppendLine();
        sb.AppendLine("// Enum Definitions");
        var enums = definedTypes.Where(t => t.IsEnum).ToList();
#if DEBUG
        Console.Clear();
#endif
        for (var index = 0; index < enums.Count; index++) {
            var processPercent = index / (float)enums.Count;
#if DEBUG
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"GapStrategy: {_gapStrategy}, Type: {GetType().Name}");
            Console.WriteLine($"Processing Enums: {processPercent:P}");
#endif
            ProcessEnum(enums[index], sb);
        }

        sb.AppendLine();
        sb.AppendLine("// Definitions");
        var definitions = definedTypes.Where(t => !t.IsEnum).ToList();
#if DEBUG
        Console.Clear();
#endif
        for (var index = 0; index < definitions.Count; index++) {
            var processPercent = index / (float)definitions.Count;
#if DEBUG
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"GapStrategy: {_gapStrategy}, Type: {GetType().Name}");
            Console.WriteLine($"Processing Structs: {processPercent:P}");
#endif
            ProcessType(definitions[index], sb);
        }

        return sb.ToString().Replace("__{0}__", string.Join(Environment.NewLine, _knownTypes.Where(t => !t.IsEnum).Select(t => $"struct {FixFullName(t)};")));
    }

    private void ProcessType(Type type, StringBuilder header) {
        if (_knownTypes.Contains(type) || type.IsPrimitive || type.IsInterface || type.IsBlocked())
            return;

        if (type.IsFixedBuffer()) {
            return;
        }

        if (type.IsStruct()) {
            if (type.Namespace!.StartsWith(ExporterStatics.StdNamespacePrefix[..^1]))
                ProcessStdStruct(type, header);
            else
                ProcessStruct(type, header);
        } else {
            if (!ExporterStatics.IgnoredTypeNames.Any(type.FullName!.EndsWith))
                Debug.WriteLine($"Unhandled type: {type.FullName}");
        }
    }

    private static bool IsNotHavok(FieldInfo fieldInfo) {
        var type = fieldInfo.FieldType;
        if (type.IsFunctionPointer || type.IsUnmanagedFunctionPointer)
            return true;
        if (type.IsPointer)
            type = type.GetElementType()!;
        return !(type.GenericTypeArguments.Any(IsHavok) || IsHavok(type));
    }

    private static bool IsHavok(Type type) {
        //check if fieldInfo is either a Havok type or a recursive pointer to a Havok type or generic type
        if (type.IsPointer)
            type = type.GetElementType()!;
        return type.GenericTypeArguments.Any(IsHavok) || type.Namespace!.StartsWith("FFXIVClientStructs.Havok");
    }

    private List<UnionLayout> GetStructLayout(Type type) {
        var fields = type.GetFields()
            .Where(fieldInfo => !Attribute.IsDefined(fieldInfo, typeof(ObsoleteAttribute)))
            .Where(fieldInfo => !Attribute.IsDefined(fieldInfo, typeof(CExportIgnoreAttribute)))
            .Where(fieldInfo => !fieldInfo.IsLiteral) // not constants
            .Where(fieldInfo => !fieldInfo.IsStatic) // not static
            .Where(IsNotHavok) // Don't export Havok types
            .OrderBy(fieldInfo => fieldInfo.GetFieldOffset())
            .Select(fieldInfo =>
                new StructObject {
                    Info = fieldInfo,
                    Offset = fieldInfo.GetFieldOffset(),
                    Size = fieldInfo.IsFixed() ? fieldInfo.GetFixedType().SizeOf() * fieldInfo.GetFixedSize() : fieldInfo.FieldType.SizeOf()
                }).GroupBy(obj => obj.Offset)
            .Select(grouping => new UnionLayout {
                Layouts = grouping.Select(f => new StructLayout {
                    Objects = new List<StructObject> { f }
                }).ToList()
            }).OrderBy(unionLayout => unionLayout.Offset()).ToList();

        var tries = 0;

        while (fields.Any(t => t.SizeDif() != 0)) {
            for (var index = 0; index < fields.Count; index++) {
                var unionLayout = fields[index];
                if (unionLayout.SizeDif() == 0)
                    continue;

                var offsetMin = unionLayout.Layouts.Min(t => t.Offset());
                var offsetMax = unionLayout.Size() + offsetMin;
                var others = fields.Where(t => t.Offset() >= offsetMin && t.Offset() < offsetMax).ToList();
                if (others.Count == 0) tries++;
                fields.RemoveAll(others.Contains);
                var minKey = unionLayout.Layouts.FindIndex(t => t.Size() < unionLayout.Size());
                unionLayout.Layouts[minKey].AddObjects(others.SelectMany(t => t.Layouts).SelectMany(t => t.Objects).ToList());
                break;
            }

            if (tries > 5)
                break;
        }

        return fields;
    }

    private void ProcessStdStruct(Type type, StringBuilder header) {
        if (_knownTypes.Contains(type))
            return;

        _knownTypes.Add(type);

        var typeName = type.Name.IndexOf('`') > 0 ? type.Name[..type.Name.IndexOf('`')] : type.Name;

        if (typeName == "StdString") {
            _knownTypes.Remove(type);
            ProcessStruct(type, header);
            return;
        }

        var sb = new StringBuilder();
        if (type.ContainsGenericParameters) {
            header.AppendLine($"struct {FixFullName(type)}; /* Size=unknown due to generic type with parameters */");
            return;
        }

        var structSize = Marshal.SizeOf(Activator.CreateInstance(type)!);
        var offset = 0;
        var pad = structSize.ToString("X").Length;
        var padFill = new string(' ', pad + 2);

        var fields = type.GetFields().Where(fieldInfo => !Attribute.IsDefined(fieldInfo, typeof(ObsoleteAttribute)))
            .Where(fieldInfo => !Attribute.IsDefined(fieldInfo, typeof(CExportIgnoreAttribute)))
            .Where(fieldInfo => !fieldInfo.IsLiteral) // not constants
            .Where(fieldInfo => !fieldInfo.IsStatic) // not static
            .OrderBy(fieldInfo => fieldInfo.GetFieldOffset());

        sb.AppendLine($"struct {FixFullName(type)} /* Size=0x{structSize:X} */");
        sb.AppendLine("{");

        foreach (var fieldInfo in fields) {
            if (SetProperty(type, header, fieldInfo, false, fieldInfo.GetFieldOffset(), padFill, sb, pad, null, ref offset))
                return;
        }

        FillGaps(ref offset, structSize, padFill, sb);

        sb.AppendLine("};");

        header.AppendLine(sb.ToString());
    }

    private void ProcessStruct(Type type, StringBuilder header) {
        if (_knownTypes.Contains(type))
            return;

        if (type == typeof(void))
            return;

        _knownTypes.Add(type);

        int structSize;
        if (type.IsGenericType) {
            if (type.ContainsGenericParameters) {
                header.AppendLine($"struct {FixFullName(type)}; /* Size=unknown due to generic type with parameters */");
                return;
            }

            structSize = Marshal.SizeOf(Activator.CreateInstance(type)!);
        } else {
            structSize = type.SizeOf();
        }

        var pad = structSize.ToString("X").Length;
        var padFill = new string(' ', pad + 2);

        var sb = new StringBuilder();

        sb.AppendLine($"struct {FixFullName(type)} /* Size=0x{structSize:X} */");
        sb.AppendLine("{");

        var offset = 0;
        var fields = GetStructLayout(type);

        if (fields.Count == 0 && type.Name == "Pointer`1") {
            var allFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            fields = new List<UnionLayout>
            {
                new()
                {
                    Layouts = new List<StructLayout>
                    {
                        new()
                        {
                            Objects = new List<StructObject>
                            {
                                new()
                                {
                                    Offset = 0,
                                    Size = 8,
                                    Info = allFields[0]
                                }
                            }
                        }
                    }
                }
            };
        }

        foreach (var grouping in fields) {
            var fieldOffset = grouping.Offset();
            var layouts = grouping.Layouts;

            var isUnion = layouts.Count > 1;
            if (isUnion) {
                sb.AppendLine("    union {");
            }

            foreach (var structLayout in layouts) {
                var isStruct = structLayout.Objects.Count > 1;
                var layoutObjects = structLayout.Objects;
                if (isStruct) {
                    sb.AppendLine("    struct {");
                    if (layoutObjects.Any(layoutObject => SetProperty(type, header, layoutObject.Info, isUnion, layoutObject.Offset, padFill, sb, pad, fields.GetNextLayout(grouping), ref offset))) {
                        return;
                    }

                    sb.AppendLine($"    }} _union_struct_0x{structLayout.Offset():X};");
                } else if (SetProperty(type, header, layoutObjects[0].Info, isUnion, layoutObjects[0].Offset, padFill, sb, pad, fields.GetNextLayout(grouping), ref offset)) return;
            }

            if (!isUnion)
                continue;

            offset += grouping.Size();
            sb.AppendLine($"    }} _union_0x{fieldOffset:X};");
        }

        FillGaps(ref offset, structSize, padFill, sb);

        sb.AppendLine("};");

        header.AppendLine(sb.ToString());
    }

    private string BuildFunctionDefinition(FieldInfo fieldInfo) {
        var sb = new StringBuilder();
        var fieldType = fieldInfo.FieldType;
        sb.Append(fieldType.GetFunctionPointerReturnType().FixTypeName(FixFullName));
        sb.Append(" (__fastcall *");
        sb.Append(fieldInfo.Name);
        sb.Append(")(");
        sb.Append(string.Join(", ", fieldType.GetFunctionPointerParameterTypes().Select(t => t.FixTypeName(FixFullName)).Select((t, i) => t + $" a{i + 1}")));
        sb.Append(')');
        return sb.ToString();
    }

    private bool SetProperty(Type type, StringBuilder header, FieldInfo fieldInfo, bool isUnion, int fieldOffset, string padFill, StringBuilder sb, int pad, UnionLayout? nextLayout, ref int offset) {
        var fieldType = fieldInfo.FieldType;
        int fieldSize;

        if (!isUnion) {
            if (fieldType.IsUnmanagedFunctionPointer)
                FillVFuncGap(ref offset, fieldOffset, padFill, sb);
            else
                FillGaps(ref offset, fieldOffset, padFill, sb);
        }

        if (offset > fieldOffset) {
            var error = $"Current offset exceeded the next field's offset (0x{offset:X} > 0x{fieldOffset:X}): {FixFullName(type)}.{fieldInfo.Name}";
            Debug.WriteLine(error);
            Console.WriteLine(error);
            ExporterStatics.ErrorListDictionary.TryAdd(type, error);
            Errored = true;
            return true;
        }

        if (fieldInfo.IsFixed()) {
            var fixedType = fieldInfo.GetFixedType();
            var fixedSize = fieldInfo.GetFixedSize();
            ProcessType(fixedType, header);

            sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {fixedType.FixTypeName(FixFullName)} {fieldInfo.Name}[0x{fixedSize:X}];", fieldOffset));

            fieldSize = fixedType.SizeOf() * fixedSize;
        } else if (fieldType.IsPointer) {
            var elemType = fieldType.GetElementType()!;
            if (elemType.Namespace!.StartsWith(ExporterStatics.InteropNamespacePrefix[..^1]) || elemType.Namespace!.StartsWith(ExporterStatics.StdNamespacePrefix[..^1])) {
                while (elemType.IsPointer)
                    elemType = elemType.GetElementType()!;
                ProcessType(elemType, header);
            }

            sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {fieldType.FixTypeName(FixFullName)} {(fieldInfo.Name.EndsWith("k__BackingField") ? "Value" : fieldInfo.Name)};", fieldOffset));

            fieldSize = 8;
        } else if (fieldType.IsEnum) {
            ProcessType(fieldType, header);

            sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {fieldType.FixTypeName(FixFullName)} {fieldInfo.Name};", fieldOffset));

            var enumSize = Enum.GetUnderlyingType(fieldType).SizeOf();

            fieldSize = nextLayout?.Offset() - fieldOffset ?? enumSize;
            if (fieldSize >= enumSize) {
                fieldSize = enumSize;
            } else {
                var warn = $"Warning enum {FixFullName(type)} has bad size declaration";
                Debug.WriteLine(warn);
                Console.WriteLine(warn);
                ExporterStatics.WarningListDictionary.TryAdd(type, warn);
            }
        } else if (fieldType.IsFunctionPointer || fieldType.IsUnmanagedFunctionPointer) {
            sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {BuildFunctionDefinition(fieldInfo)};", fieldOffset));

            fieldSize = 8;
        } else {
            ProcessType(fieldType, header);

            sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {fieldType.FixTypeName(FixFullName)} {fieldInfo.Name};", fieldOffset));

            fieldSize = fieldType.IsGenericType ? Marshal.SizeOf(Activator.CreateInstance(fieldType)!) : fieldType.SizeOf();
        }

        if (!isUnion)
            offset += fieldSize;
        return false;
    }

    protected abstract string GetEnumName(Type type);

    private void ProcessEnum(Type type, StringBuilder header) {
        if (_knownTypes.Contains(type))
            return;

        _knownTypes.Add(type);

        var sb = new StringBuilder();

        sb.AppendLine(GetEnumName(type));

        sb.AppendLine("{");

        var values = Enum.GetNames(type).Select(t => Tuple.Create(t, Enum.Parse(type, t, true))).DistinctBy(t => t.Item2).ToArray();
        for (var i = 0; i < values.Length; i++) {
            var (name, value) = values[i];
            sb.Append($"    {name} = {value:D}");
            if (i < values.Length - 1)
                sb.AppendLine(",");
            else
                sb.AppendLine();
        }

        sb.AppendLine("};");

        header.AppendLine(sb.ToString());
    }

    protected virtual string FixFullName(Type type) {
        string fullName;
        if (type.IsGenericType || (type.IsPointer && type.GetElementType()!.IsGenericType)) {
            var isPointer = type.IsPointer;
            var dereferenced = isPointer ? type.GetElementType()! : type;
            var generic = dereferenced.GetGenericTypeDefinition();
            fullName = generic.FullName?.Split('`')[0]!;
            if (dereferenced.IsNested) {
                fullName += '+' + generic.FullName?.Split('+')[1].Split('[')[0];
            }

            fullName = dereferenced.GenericTypeArguments.Aggregate(fullName, (current, argType) => current + $"{_separator}{FixFullName(argType).Replace(_separator, "")}");
            if (isPointer)
                fullName += '*';
        } else {
            fullName = type.FullName!;
        }

        if (fullName.StartsWith(ExporterStatics.FFXIVNamespacePrefix))
            fullName = fullName.Remove(0, ExporterStatics.FFXIVNamespacePrefix.Length);
        if (fullName.StartsWith(ExporterStatics.StdNamespacePrefix))
            fullName = fullName.Remove(0, ExporterStatics.StdNamespacePrefix.Length);
        if (fullName.StartsWith(ExporterStatics.InteropNamespacePrefix))
            fullName = fullName.Remove(0, ExporterStatics.InteropNamespacePrefix.Length);

        // ReSharper disable once InvertIf
        if (fullName.Contains("FFXIVClientStructs, Version")) {
            if (fullName.EndsWith("*")) {
                fullName = "void*";
            } else {
                throw new Exception($"Failed to fix name: {fullName}");
            }
        }

        var (oldName, newName) = _nameOverride.FirstOrDefault(t => fullName.Contains(t.Key));
        if (string.IsNullOrWhiteSpace(oldName) || fullName.Replace("*", "").EndsWith("Struct"))
            return fullName.Replace(".", _separator).Replace("+", _separator);

        return fullName.Replace(".", _separator).Replace("+", _separator).Replace(oldName, newName);
    }

    private void FillVFuncGap(ref int offset, int maxOffset, string padFill, StringBuilder sb) {
        int gap;
        while ((gap = maxOffset - offset) > 0) {
            sb.AppendLine($"    /* {padFill} */ __int64 _vf{offset / 8};");
            offset += 8;
        }
    }

    private void FillGaps(ref int offset, int maxOffset, string padFill, StringBuilder sb) {
        int gap;
        while ((gap = maxOffset - offset) > 0) {
            switch (_gapStrategy) {
                case GapStrategy.FullSize when offset % 8 == 0 && gap >= 8:
                    sb.AppendLine($"    /* {padFill} */ __int64 _gap_0x{offset:X};");
                    offset += 8;
                    break;
                case GapStrategy.FullSize when offset % 4 == 0 && gap >= 4:
                    sb.AppendLine($"    /* {padFill} */ __int32 _gap_0x{offset:X};");
                    offset += 4;
                    break;
                case GapStrategy.FullSize when offset % 2 == 0 && gap >= 2:
                    sb.AppendLine($"    /* {padFill} */ __int16 _gap_0x{offset:X};");
                    offset += 2;
                    break;
                case GapStrategy.FullSize:
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X};");
                    offset += 1;
                    break;
                case GapStrategy.ByteArray when offset % 8 == 0 && gap >= 8:
                    var gapDiv = gap - gap % 8;
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X}[0x{gapDiv:X}];");
                    offset += gapDiv;
                    break;
                case GapStrategy.ByteArray when offset % 4 == 0 && gap >= 4:
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X}[0x4];");
                    offset += 4;
                    break;
                case GapStrategy.ByteArray when offset % 2 == 0 && gap >= 2:
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X}[0x2];");
                    offset += 2;
                    break;
                case GapStrategy.ByteArray:
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X};");
                    offset += 1;
                    break;
                default:
                    throw new Exception($"Unknown GapStrategy {_gapStrategy}");
            }
        }
    }
}

internal record UnionLayout {
    public List<StructLayout> Layouts = new();

    public int Size() => Layouts.Max(t => t.Size());
    public int Offset() => Layouts.Min(t => t.Offset());
    public int SizeDif() => Layouts.Max(t => t.Size()) - Layouts.Min(t => t.Size());
}

internal record StructLayout {
    public List<StructObject> Objects = new();

    public void AddObjects(IEnumerable<StructObject> objs) {
        Objects.AddRange(objs);
        _size = Objects.Sum(t => t.Size);
        _offset = Objects.Min(t => t.Offset);
    }

    private int? _size;
    private int? _offset;

    public int Size() => _size ??= Objects.Sum(t => t.Size);

    public int Offset() => _offset ??= Objects.Min(t => t.Offset);
}

internal record StructObject {
    public int Offset;
    public int Size;
    public required FieldInfo Info;
}
