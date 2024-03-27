using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CExporter;

public static class ExporterStatics {
#pragma warning disable CA2211
    // ReSharper disable once InconsistentNaming
    public static string FFXIVNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.FFXIV), "");
    public static string StdNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.STD), "");
    public static string InteropNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.Interop), "");
    public static string HavokNamespacePrefix = string.Join(".", nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.Havok), "");

    public static string[] IgnoredTypeNames = { "MemberFunctionPointers", "StaticAddressPointers", "Addresses", "VTable" };
    public static Dictionary<Type, string> ErrorListDictionary = new();
    public static Dictionary<Type, string> WarningListDictionary = new();
    public static List<string> WarningList = [];
    public static List<string> ErrorList = [];
#pragma warning restore CA2211

    public static Type[] GetXIVTypes() {
        var assembly = AppDomain.CurrentDomain.Load(nameof(FFXIVClientStructs));

        Type[] definedTypes;
        try {
            definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
        } catch (ReflectionTypeLoadException ex) {
            definedTypes = ex.Types.Where(t => t != null).ToArray()!;
        }

        return definedTypes.Where(t => t.FullName!.StartsWith(FFXIVNamespacePrefix) && !t.FullName.EndsWith("VTable")).ToArray();
    }

    public static Type[] GetHavokTypes() {
        var assembly = AppDomain.CurrentDomain.Load(nameof(FFXIVClientStructs));

        Type[] definedTypes;
        try {
            definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
        } catch (ReflectionTypeLoadException ex) {
            definedTypes = ex.Types.Where(t => t != null).ToArray()!;
        }

        return definedTypes.Where(t => t.FullName!.StartsWith(HavokNamespacePrefix) && !t.FullName.EndsWith("VTable")).ToArray();
    }
}
