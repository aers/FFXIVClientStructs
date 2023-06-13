using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace CExporter;

public enum EnvFormat
{
    IDA,     // IDA Format: Separator: "::", Enums: short names with underlying type info
    Ghidra,  // Ghidra Format: Separator: "_", Enums: long names w/o underlying type info
}

public class OldExporter
{
    private GapStrategy _gapStrategy;

    private EnvFormat _envFormat;

    private readonly HashSet<Type> _knownTypes = new();

    private readonly string _ffxivNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.FFXIV), "");
    private readonly string _stdNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.STD), "");
    private readonly string _interopNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.Interop), "");

    private Type[] GetExportableTypes(string assemblyName)
    {
        var assembly = AppDomain.CurrentDomain.Load(assemblyName);

        Type[] definedTypes;
        try
        {
            definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
        }
        catch (ReflectionTypeLoadException ex)
        {
            definedTypes = ex.Types.Where(t => t != null).ToArray();
        }

        return definedTypes.Where(t => t.FullName.StartsWith(_ffxivNamespacePrefix)).ToArray();
    }

    public string Export(GapStrategy strategy, EnvFormat envFormat)
    {
        _gapStrategy = strategy;
        _envFormat = envFormat;
        _knownTypes.Clear();

        var header = new StringBuilder();

        var definedTypes = GetExportableTypes(nameof(FFXIVClientStructs));

        // Make forward references for everything, cycles are bad, detecting them is harder.
        header.AppendLine("// Forward References");
        foreach (var type in definedTypes)
            if (type.IsStruct() && !type.IsFixedBuffer())
                header.AppendLine($"struct {FixFullName(type)};");

        header.AppendLine();
        header.AppendLine("// Definitions");
        foreach (var type in definedTypes)
        {
            ProcessType(type, header);
        }

        return header.ToString();
    }

    private void ProcessType(Type type, StringBuilder header)
    {
        if (_knownTypes.Contains(type))
            return;

        if (type.IsFixedBuffer())
        {
            return;
        }

        if (type.IsEnum)
        {
            ProcessEnum(type, header);
        }
        else if (type.IsStruct())
        {
            ProcessStruct(type, header);
        }
        else if (type.IsPrimitive)
        {
            ProcessPrimitive(type);
        }
        else
        {
            Debug.WriteLine($"Unhandled type: {type.FullName}");
        }
    }

    private void ProcessStruct(Type type, StringBuilder header)
    {
        if (_knownTypes.Contains(type))
            return;

        if (type == typeof(void))
            return;

        var name = type.FullName;
        // Debug.WriteLine($"Processing Struct:  {name}");

        _knownTypes.Add(type);

        int structSize;
        if (type.IsGenericType)
        {
            if (type.ContainsGenericParameters)
            {
                structSize = 0; // Generic types are ignored if they cannot be instantiated.
                header.AppendLine($"struct {FixFullName(type)}; /* Size=unknown due to generic type with parameters */");
                return;
            }

            structSize = Marshal.SizeOf(Activator.CreateInstance(type));
        }
        else
        {
            structSize = SizeOf(type);
        }

        var pad = structSize.ToString("X").Length;
        var padFill = new string(' ', pad + 2);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"struct {FixFullName(type)} /* Size=0x{structSize:X} */");
        sb.AppendLine("{");

        var offset = 0;
        var fieldGroupings = type.GetFields()
            .Where(finfo => !Attribute.IsDefined(finfo, typeof(ObsoleteAttribute)))
            .Where(finfo => !finfo.IsLiteral) // not constants
            .Where(finfi => !finfi.IsStatic)  // not static
            .OrderBy(finfo => finfo.GetFieldOffset())
            .GroupBy(finfo => finfo.GetFieldOffset());
        foreach (var grouping in fieldGroupings)
        {
            var fieldOffset = grouping.Key;
            var finfos = grouping.ToList();

            int unionMaxSize = 0;
            var isUnion = finfos.Count > 1;
            if (isUnion)
            {
                sb.AppendLine("    union {");
            }

            for (int i = 0; i < finfos.Count; i++)
            {
                var finfo = finfos[i];
                var fieldType = finfo.FieldType;
                int fieldSize = 0;

                if (!isUnion)
                    offset = FillGaps(offset, fieldOffset, padFill, sb);

                if (offset > fieldOffset)
                {
                    Debug.WriteLine($"Current offset exceeded the next field's offset (0x{offset:X} > 0x{fieldOffset:X}): {FixFullName(type)}.{finfo.Name}");
                    return;
                }

                if (finfo.IsFixed())
                {
                    var fixedType = finfo.GetFixedType();
                    var fixedSize = finfo.GetFixedSize();
                    ProcessType(fixedType, header);

                    sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fixedType)} {finfo.Name}[0x{fixedSize:X}];", offset));

                    fieldSize = SizeOf(fixedType) * fixedSize;
                }
                else if (fieldType.IsPointer)
                {
                    var elemType = fieldType.GetElementType();
                    while (elemType.IsPointer)
                        elemType = elemType.GetElementType();
                    ProcessType(elemType, header);

                    sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fieldType)} {finfo.Name};", offset));

                    fieldSize = 8;

                }
                else if (fieldType.IsEnum)
                {
                    ProcessType(fieldType, header);

                    sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fieldType)} {finfo.Name};", offset));

                    fieldSize = SizeOf(Enum.GetUnderlyingType(fieldType));
                }
                else
                {
                    ProcessType(fieldType, header);

                    sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fieldType)} {finfo.Name};", offset));

                    if (fieldType == typeof(bool))
                        fieldSize = 1;
                    else if (fieldType.IsGenericType)
                        fieldSize = Marshal.SizeOf(Activator.CreateInstance(fieldType));
                    else
                        fieldSize = SizeOf(fieldType);
                }

                if (!isUnion)
                    offset += fieldSize;
                else
                    unionMaxSize = Math.Max(unionMaxSize, 8);
            }

            if (isUnion)
            {
                offset += unionMaxSize;
                sb.AppendLine($"    }} _union_0x{fieldOffset:X};");
            }
        }

        FillGaps(offset, structSize, padFill, sb);

        sb.AppendLine("};");

        header.AppendLine(sb.ToString());
    }

    private int SizeOf(Type type)
    {
        // Marshal.SizeOf doesn't work correctly because the assembly is unmarshaled, and more specifically, it sets bools as 4 bytes long...
        return (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0;
    }

    private void ProcessEnum(Type type, StringBuilder header)
    {
        if (_knownTypes.Contains(type))
            return;

        _knownTypes.Add(type);

        // Debug.WriteLine($"Processing Enum:  {type.FullName}");

        var sb = new StringBuilder();

        if (_envFormat == EnvFormat.IDA)
        {
            var underlyingTypeName = FixTypeName(type.GetEnumUnderlyingType());
            sb.AppendLine($"enum {type.Name}: {underlyingTypeName}");
        }
        else
        {
            var underlyingType = type.GetEnumUnderlyingType();
            var fixedTypeName = FixTypeName(type);
            sb.AppendLine($"enum {fixedTypeName} /* Size=0x{SizeOf(underlyingType):X} */");
        }

        sb.AppendLine("{");

        var values = Enum.GetValues(type);
        for (int i = 0; i < values.Length; i++)
        {
            var value = values.GetValue(i);
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

        // Debug.WriteLine($"Processing Primitive: {type.FullName}");

        _knownTypes.Add(type);
    }

    private string FixFullName(Type type)
    {
        string separator;
        if (_envFormat == EnvFormat.IDA)
            separator = "::";
        else if (_envFormat == EnvFormat.Ghidra)
            separator = "_";
        else
            throw new Exception($"Unknown EnvFormat: {_envFormat}");

        string fullName;
        if (type.IsGenericType || (type.IsPointer && type.GetElementType().IsGenericType))
        {
            bool isPointer = type.IsPointer;
            var dereferenced = isPointer ? type.GetElementType() : type;
            var generic = dereferenced.GetGenericTypeDefinition();
            fullName = generic.FullName.Split('`')[0];
            if (dereferenced.IsNested)
            {
                fullName += '+' + generic.FullName.Split('+')[1].Split('[')[0];
            }
            foreach (var argType in dereferenced.GenericTypeArguments)
            {
                var argTypeFullName = FixFullName(argType).Replace("::", "");
                fullName += $"{separator}{argTypeFullName}";
            }
            if (isPointer)
                fullName += '*';
        }
        else
        {
            fullName = type.FullName;
        }

        if (fullName.StartsWith(_ffxivNamespacePrefix))
            fullName = fullName.Remove(0, _ffxivNamespacePrefix.Length);
        if (fullName.StartsWith(_stdNamespacePrefix))
            fullName = fullName.Remove(0, _stdNamespacePrefix.Length);
        if (fullName.StartsWith(_interopNamespacePrefix))
            fullName = fullName.Remove(0, _interopNamespacePrefix.Length);

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

        // This is a hack because Ghidra doesn't support specifying the enum size
        // By appending 0x<size> on the enum name, it makes it easier to manually go
        // in and fix the sizes up after the fact.
        if (_envFormat == EnvFormat.Ghidra && type.IsEnum)
        {
            var underlyingType = type.GetEnumUnderlyingType();
            fullName += $"0x{SizeOf(underlyingType):X}";
        }

        return fullName.Replace(".", separator).Replace("+", separator);
    }

    private string FixTypeName(Type type) =>
        type switch
        {
            _ when type == typeof(void) || type == typeof(void*) || type == typeof(void**) ||
                   type == typeof(char) || type == typeof(char*) || type == typeof(char**) ||
                   type == typeof(byte) || type == typeof(byte*) || type == typeof(byte**) => type.Name.ToLower(),
            _ when type == typeof(bool) => "bool",
            _ when type == typeof(float) => "float",
            _ when type == typeof(double) => "double",
            _ when type == typeof(short) => "__int16",
            _ when type == typeof(int) => "__int32",
            _ when type == typeof(long) || type == typeof(nint) => "__int64",
            _ when type == typeof(ushort) => "unsigned __int16",
            _ when type == typeof(uint) => "unsigned __int32",
            _ when type == typeof(ulong) => "unsigned __int64",
            _ when type == typeof(sbyte) => "signed __int8",
            _ when type == typeof(short*) => "__int16*",
            _ when type == typeof(ushort*) => "unsigned __int16*",
            _ when type == typeof(int*) => "__int32*",
            _ when type == typeof(uint*) => "unsigned __int32*",
            _ when type == typeof(float*) => "float*",
            _ => FixFullName(type)
        };

    private int FillGaps(int offset, int maxOffset, string padFill, StringBuilder sb)
    {
        int gap;
        while ((gap = maxOffset - offset) > 0)
        {
            if (_gapStrategy == GapStrategy.FullSize)
            {
                if (offset % 8 == 0 && gap >= 8)
                {
                    sb.AppendLine($"    /* {padFill} */ __int64 _gap_0x{offset:X};");
                    offset += 8;
                }
                else if (offset % 4 == 0 && gap >= 4)
                {
                    sb.AppendLine($"    /* {padFill} */ __int32 _gap_0x{offset:X};");
                    offset += 4;
                }
                else if (offset % 2 == 0 && gap >= 2)
                {
                    sb.AppendLine($"    /* {padFill} */ __int16 _gap_0x{offset:X};");
                    offset += 2;
                }
                else
                {
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X};");
                    offset += 1;
                }
            }
            else if (_gapStrategy == GapStrategy.ByteArray)
            {
                if (offset % 8 == 0 && gap >= 8)
                {
                    var gapDiv = gap - (gap % 8);
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X}[0x{gapDiv:X}];");
                    offset += gapDiv;
                }
                else if (offset % 4 == 0 && gap >= 4)
                {
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X}[0x4];");
                    offset += 4;
                }
                else if (offset % 2 == 0 && gap >= 2)
                {
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X}[0x2];");
                    offset += 2;
                }
                else
                {
                    sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X};");
                    offset += 1;
                }
            }
            else
            {
                throw new Exception($"Unknown GapStrategy {_gapStrategy}");
            }
        }
        return offset;
    }
}