using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FFXIVClientStructs.Attributes;

namespace CExporter;

public static class ExporterStatics {
#pragma warning disable CA2211
    // ReSharper disable once InconsistentNaming
    public const string FFXIVNamespacePrefix = $"{nameof(FFXIVClientStructs)}.{nameof(FFXIVClientStructs.FFXIV)}";
    public const string StdNamespacePrefix = $"{nameof(FFXIVClientStructs)}.{nameof(FFXIVClientStructs.STD)}";
    public const string InteropNamespacePrefix = $"{nameof(FFXIVClientStructs)}.{nameof(FFXIVClientStructs.Interop)}";
    public const string HavokNamespacePrefix = $"{nameof(FFXIVClientStructs)}.{nameof(FFXIVClientStructs.Havok)}";
    public const string StdCppNamespace = "std::";
    public static readonly BindingFlags BindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
    public static readonly BindingFlags StaticBindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;

    public static readonly string[] IgnoredTypeNames = ["MemberFunctionPointers", "StaticAddressPointers", "Addresses", "VirtualTable"];
    public static readonly string[] BaseTypeNames = ["byte", "wchar_t", "char", "float", "double", "bool", "int8_t", "uint8_t", "int16_t", "uint16_t", "int32_t", "uint32_t", "int64_t", "uint64_t"];
    public static readonly List<string> WarningList = [];
    public static readonly List<string> ErrorList = [];

    public static readonly string Separator = "::";
#pragma warning restore CA2211

    public static Type[] GetXIVTypes() {
        var assembly = AppDomain.CurrentDomain.Load(nameof(FFXIVClientStructs));

        Type[] definedTypes;
        try {
            definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
        } catch (ReflectionTypeLoadException ex) {
            definedTypes = ex.Types.Where(t => t != null).ToArray()!;
        }

        return definedTypes.Where(t => t.FullName!.StartsWith(FFXIVNamespacePrefix) && !t.FullName.EndsWith("VirtualTable") && t.GetCustomAttribute<CExporterIgnoreAttribute>() == null).ToArray();
    }

    public static Type[] GetHavokTypes() {
        var assembly = AppDomain.CurrentDomain.Load(nameof(FFXIVClientStructs));

        Type[] definedTypes;
        try {
            definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
        } catch (ReflectionTypeLoadException ex) {
            definedTypes = ex.Types.Where(t => t != null).ToArray()!;
        }

        return definedTypes.Where(t => t.FullName!.StartsWith(HavokNamespacePrefix) && !t.FullName.EndsWith("VirtualTable") && t.GetCustomAttribute<CExporterIgnoreAttribute>() == null).ToArray();
    }

    public static Type GetBestMatchFromSize(int size) => size switch {
        < 9 => typeof(byte),
        < 17 => typeof(ushort),
        < 33 => typeof(uint),
        _ => typeof(ulong)
    };
}

internal class CExporterUnionCompare : IEqualityComparer<CExporterUnionAttribute> {
    public bool Equals(CExporterUnionAttribute? x, CExporterUnionAttribute? y) {
        return x is { IsStruct: var xb, Struct: var xs, Union: var xu } &&
               y is { IsStruct: var yb, Struct: var ys, Union: var yu } &&
               (xb == yb ? xs == ys && xu == yu : xu == yu);
    }
    public int GetHashCode(CExporterUnionAttribute obj) {
        return obj.IsStruct ? HashCode.Combine(obj.Union, obj.Struct) : HashCode.Combine(obj.Union);
    }
}
