using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FFXIVClientStructs;
using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace CExporter;

public enum GapStrategy
{
    FullSize,   // Fill gaps in structs with sequential longs, ints, shorts, or bytes
    ByteArray,  // Fill gaps in structs with byte arrays
}

public static class ExporterStatics
{
    private static Type[] _definedTypes;

    public static Type[] DefinedTypes => _definedTypes ??= GetExportableTypes();

    public static string FFXIVNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.FFXIV), "");
    public static string StdNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.STD), "");
    public static string InteropNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.Interop), "");

    private static Type[] GetExportableTypes()
    {
        var assembly = AppDomain.CurrentDomain.Load(nameof(FFXIVClientStructs));

        Type[] definedTypes;
        try
        {
            definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
        }
        catch (ReflectionTypeLoadException ex)
        {
            definedTypes = ex.Types.Where(t => t != null).ToArray();
        }

        return definedTypes.Where(t => t.FullName!.StartsWith(FFXIVNamespacePrefix)).ToArray();
    }
}

public class ExporterIDA : ExporterBase
{
    public ExporterIDA() : base("::")
    {
    }

    protected override string GetEnumName(Type type)
    {
        return $"enum {type.Name}: {type.GetEnumUnderlyingType().FixTypeName(FixFullName)}";
    }
}

public class ExporterGhidra : ExporterBase
{
    public ExporterGhidra() : base("_")
    {
    }

    protected override string GetEnumName(Type type)
    {
        //Ghidra doesn't support setting enum sizes so this is exported as a comment instead
        return $"enum {type.FixTypeName(FixFullName)} /* Size=0x{type.GetEnumUnderlyingType().SizeOf():X} */";
    }
}

public abstract class ExporterBase
{
    private readonly string _separator;

    private GapStrategy _gapStrategy;

    private readonly HashSet<Type> _knownTypes = new();

    protected ExporterBase(string separator)
    {
        _separator = separator;
    }

    public string Export(GapStrategy gapStrategy)
    {
        _knownTypes.Clear();
        
        _gapStrategy = gapStrategy;

        var sb = new StringBuilder();

        var definedTypes = ExporterStatics.DefinedTypes.OrderBy(t => t.FullName).ToArray();

        sb.AppendLine("// Forward References");
        definedTypes.Where(t => t.IsStruct() && !t.IsFixedBuffer()).Select(t => $"struct {FixFullName(t)};").ToList().ForEach(t => sb.AppendLine(t));

        sb.AppendLine();
        sb.AppendLine("// Enum Definitions");
        var enums = definedTypes.Where(t => t.IsEnum).ToList();
        Console.Clear();
        for (var index = 0; index < enums.Count; index++)
        {
            var processPercent = index / (float) enums.Count;
            Console.SetCursorPosition(0,0);
            Console.WriteLine($"GapStrategy: {_gapStrategy}, Type: {GetType().Name}");
            Console.WriteLine($"Processing Structs: {processPercent:P}");
            ProcessEnum(enums[index], sb);
        }

        sb.AppendLine();
        sb.AppendLine("// Definitions");
        var definitions = definedTypes.Where(t => !t.IsEnum).ToList();
        Console.Clear();
        for (var index = 0; index < definitions.Count; index++)
        {
            var processPercent = index / (float) definitions.Count;
            Console.SetCursorPosition(0,0);
            Console.WriteLine($"GapStrategy: {_gapStrategy}, Type: {GetType().Name}");
            Console.WriteLine($"Processing Structs: {processPercent:P}");
            ProcessType(definitions[index], sb);
        }

        return sb.ToString();
    }

    private void ProcessType(Type type, StringBuilder header)
    {
        if (_knownTypes.Contains(type) || type.IsPrimitive)
            return;

        if (type.IsFixedBuffer())
        {
            return;
        }

        if (type.IsStruct())
        {
            ProcessStruct(type, header);
        }
        else
        {
            Debug.WriteLine($"Unhandled type: {type.FullName}");
        }
    }

    private List<UnionLayout> GetStructLayout(Type type)
    {
        var fields = type.GetFields()
            .Where(fieldInfo => !Attribute.IsDefined(fieldInfo, typeof(ObsoleteAttribute)))
            .Where(fieldInfo => !Attribute.IsDefined(fieldInfo, typeof(CExportIgnoreAttribute)))
            .Where(fieldInfo => !fieldInfo.IsLiteral) // not constants
            .Where(fieldInfo => !fieldInfo.IsStatic) // not static
            .OrderBy(fieldInfo => fieldInfo.GetFieldOffset())
            .Select(fieldInfo =>
                new StructObject
                {
                    Info = fieldInfo,
                    Offset = fieldInfo.GetFieldOffset(),
                    Size = fieldInfo.IsFixed() ? fieldInfo.GetFixedType().SizeOf() * fieldInfo.GetFixedSize() : fieldInfo.FieldType.SizeOf()
                }).GroupBy(obj => obj.Offset)
            .Select(grouping => new UnionLayout
            {
                Layouts = grouping.Select(f => new StructLayout
                {
                    Objects = new List<StructObject> { f }
                }).ToList()
            }).OrderBy(unionLayout => unionLayout.Offset()).ToList();

        var tries = 0;

        while (fields.Any(t => t.SizeDif() != 0))
        {
            for (var index = 0; index < fields.Count; index++)
            {
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

    private void ProcessStruct(Type type, StringBuilder header)
    {
        if (_knownTypes.Contains(type))
            return;

        if (type == typeof(void))
            return;

        var name = type.FullName;

        _knownTypes.Add(type);

        int structSize;
        if (type.IsGenericType)
        {
            if (type.ContainsGenericParameters)
            {
                header.AppendLine($"struct {FixFullName(type)}; /* Size=unknown due to generic type with parameters */");
                return;
            }

            structSize = Marshal.SizeOf(Activator.CreateInstance(type)!);
        }
        else
        {
            structSize = type.SizeOf();
        }

        var pad = structSize.ToString("X").Length;
        var padFill = new string(' ', pad + 2);

        var sb = new StringBuilder();

        sb.AppendLine($"struct {FixFullName(type)} /* Size=0x{structSize:X} */");
        sb.AppendLine("{");

        var offset = 0;
        var fields = GetStructLayout(type);

        foreach (var grouping in fields)
        {
            var fieldOffset = grouping.Offset();
            var layouts = grouping.Layouts;

            var isUnion = layouts.Count > 1;
            if (isUnion)
            {
                sb.AppendLine("    union {");
            }

            foreach (var structLayout in layouts)
            {
                var isStruct = structLayout.Objects.Count > 1;
                var layoutObjects = structLayout.Objects;
                if (isStruct)
                {
                    sb.AppendLine("    struct {");
                    if (layoutObjects.Any(layoutObject => SetProperty(type, header, layoutObject.Info, isUnion, layoutObject.Offset, padFill, sb, pad, ref offset)))
                    {
                        return;
                    }

                    sb.AppendLine($"    }} _union_struct_0x{structLayout.Offset():X};");
                }
                else if (SetProperty(type, header, layoutObjects[0].Info, isUnion, layoutObjects[0].Offset, padFill, sb, pad, ref offset)) return;
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

    private bool SetProperty(Type type, StringBuilder header, FieldInfo fieldInfo, bool isUnion, int fieldOffset, string padFill, StringBuilder sb, int pad, ref int offset)
    {
        var fieldType = fieldInfo.FieldType;
        int fieldSize;

        if (!isUnion)
            FillGaps(ref offset, fieldOffset, padFill, sb);

        if (offset > fieldOffset)
        {
            var k = sb.ToString();
            Debug.WriteLine($"Current offset exceeded the next field's offset (0x{offset:X} > 0x{fieldOffset:X}): {FixFullName(type)}.{fieldInfo.Name}");
            Console.WriteLine($"Current offset exceeded the next field's offset (0x{offset:X} > 0x{fieldOffset:X}): {FixFullName(type)}.{fieldInfo.Name}");
            return true;
        }

        if (fieldInfo.IsFixed())
        {
            var fixedType = fieldInfo.GetFixedType();
            var fixedSize = fieldInfo.GetFixedSize();
            ProcessType(fixedType, header);

            sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {fixedType.FixTypeName(FixFullName)} {fieldInfo.Name}[0x{fixedSize:X}];", fieldOffset));

            fieldSize = fixedType.SizeOf() * fixedSize;
        }
        else if (fieldType.IsPointer)
        {
            var elemType = fieldType.GetElementType()!;
            while (elemType.IsPointer)
                elemType = elemType.GetElementType()!;
            ProcessType(elemType, header);

            sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {fieldType.FixTypeName(FixFullName)} {fieldInfo.Name};", fieldOffset));

            fieldSize = 8;
        }
        else if (fieldType.IsEnum)
        {
            ProcessType(fieldType, header);

            sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {fieldType.FixTypeName(FixFullName)} {fieldInfo.Name};", fieldOffset));

            fieldSize = Enum.GetUnderlyingType(fieldType).SizeOf();
        }
        else
        {
            ProcessType(fieldType, header);

            sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {fieldType.FixTypeName(FixFullName)} {fieldInfo.Name};", fieldOffset));

            fieldSize = fieldType.IsGenericType ? Marshal.SizeOf(Activator.CreateInstance(fieldType)!) : fieldType.SizeOf();
        }

        if (!isUnion)
            offset += fieldSize;
        return false;
    }

    protected abstract string GetEnumName(Type type);

    private void ProcessEnum(Type type, StringBuilder header)
    {
        if (_knownTypes.Contains(type))
            return;

        _knownTypes.Add(type);

        var sb = new StringBuilder();

        sb.AppendLine(GetEnumName(type));

        sb.AppendLine("{");

        var values = Enum.GetValues(type);
        for (var i = 0; i < values.Length; i++)
        {
            var value = values.GetValue(i)!;
            var name = Enum.GetName(type, value);
            sb.Append($"    {name} = {value:D}");
            if (i < values.Length - 1)
                sb.AppendLine(",");
            else
                sb.AppendLine();
        }

        sb.AppendLine("};");

        header.AppendLine(sb.ToString());
    }

    private void ProcessPrimitive(Type type)
    {
        if (_knownTypes.Contains(type))
            return;

        _knownTypes.Add(type);
    }

    protected virtual string FixFullName(Type type)
    {
        string fullName;
        if (type.IsGenericType || (type.IsPointer && type.GetElementType()!.IsGenericType))
        {
            var isPointer = type.IsPointer;
            var dereferenced = isPointer ? type.GetElementType()! : type;
            var generic = dereferenced.GetGenericTypeDefinition();
            fullName = generic.FullName?.Split('`')[0];
            if (dereferenced.IsNested)
            {
                fullName += '+' + generic.FullName?.Split('+')[1].Split('[')[0];
            }

            fullName = dereferenced.GenericTypeArguments.Aggregate(fullName, (current, argType) => current + $"{_separator}{FixFullName(argType).Replace(_separator, "")}");
            if (isPointer)
                fullName += '*';
        }
        else
        {
            fullName = type.FullName!;
        }

        if (fullName.StartsWith(ExporterStatics.FFXIVNamespacePrefix))
            fullName = fullName.Remove(0, ExporterStatics.FFXIVNamespacePrefix.Length);
        if (fullName.StartsWith(ExporterStatics.StdNamespacePrefix))
            fullName = fullName.Remove(0, ExporterStatics.StdNamespacePrefix.Length);
        if (fullName.StartsWith(ExporterStatics.InteropNamespacePrefix))
            fullName = fullName.Remove(0, ExporterStatics.InteropNamespacePrefix.Length);

        // ReSharper disable once InvertIf
        if (fullName.Contains("FFXIVClientStructs, Version"))
        {
            if (fullName.EndsWith("*"))
            {
                fullName = "void*";
            }
            else
            {
                throw new Exception($"Failed to fix name: {fullName}");
            }
        }

        return fullName.Replace(".", _separator).Replace("+", _separator);
    }

    private void FillGaps(ref int offset, int maxOffset, string padFill, StringBuilder sb)
    {
        int gap;
        while ((gap = maxOffset - offset) > 0)
        {
            switch (_gapStrategy)
            {
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

record UnionLayout
{
    public List<StructLayout> Layouts = new();

    public int Size() => Layouts.Max(t => t.Size());
    public int Offset() => Layouts.Min(t => t.Offset());
    public int SizeDif() => Layouts.Max(t => t.Size()) - Layouts.Min(t => t.Size());
}

record StructLayout
{
    public List<StructObject> Objects = new();

    public void AddObjects(IEnumerable<StructObject> objs)
    {
        Objects.AddRange(objs);
        _size = Objects.Sum(t => t.Size);
        _offset = Objects.Min(t => t.Offset);
    }

    private int? _size;
    private int? _offset;

    public int Size() => _size ??= Objects.Sum(t => t.Size);

    public int Offset() => _offset ??= Objects.Min(t => t.Offset);
}

record StructObject
{
    public int Offset;
    public int Size;
    public FieldInfo Info;
}