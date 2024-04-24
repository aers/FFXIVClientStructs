using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FFXIVClientStructs.Attributes;

namespace CExporter;

public static class ExporterStatics {
#pragma warning disable CA2211
    // ReSharper disable once InconsistentNaming
    public static string FFXIVNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.FFXIV), "");
    public static string StdNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.STD), "");
    public static string InteropNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.Interop), "");
    public static string HavokNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.Havok), "");

    public static string[] IgnoredTypeNames = { "MemberFunctionPointers", "StaticAddressPointers", "Addresses", "VTable" };
    public static List<string> WarningList = [];
    public static List<string> ErrorList = [];

    public static string Separator = "::";
#pragma warning restore CA2211

    public static Type[] GetXIVTypes() {
        var assembly = AppDomain.CurrentDomain.Load(nameof(FFXIVClientStructs));

        Type[] definedTypes;
        try {
            definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
        } catch (ReflectionTypeLoadException ex) {
            definedTypes = ex.Types.Where(t => t != null).ToArray()!;
        }

        return definedTypes.Where(t => t.FullName!.StartsWith(FFXIVNamespacePrefix) && !t.FullName.EndsWith("VTable") && t.GetCustomAttribute<CExportIgnoreAttribute>() == null).ToArray();
    }

    public static Type[] GetHavokTypes() {
        var assembly = AppDomain.CurrentDomain.Load(nameof(FFXIVClientStructs));

        Type[] definedTypes;
        try {
            definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
        } catch (ReflectionTypeLoadException ex) {
            definedTypes = ex.Types.Where(t => t != null).ToArray()!;
        }

        return definedTypes.Where(t => t.FullName!.StartsWith(HavokNamespacePrefix) && !t.FullName.EndsWith("VTable") && t.GetCustomAttribute<CExportIgnoreAttribute>() == null).ToArray();
    }
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
