using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace CExporter;

public static class TypeExtensions {
    public static Regex StdNodeRegex = new(@"^`[1-9]\+Node", RegexOptions.Compiled);

    public static bool IsFixedBuffer(this Type type) {
        return type.Name.EndsWith("e__FixedBuffer");
    }

    public static bool IsStruct(this Type type) {
        return type != typeof(decimal) && type is { IsValueType: true, IsPrimitive: false, IsEnum: false };
    }

    public static bool IsBaseType(this Type type) {
        while (true) {
            if (type.IsPointer) {
                type = type.GetElementType()!;
                continue;
            }
            if (type.IsGenericPointer()) {
                type = type.GenericTypeArguments[0];
                continue;
            }
            return type == typeof(void) || type == typeof(bool) || type == typeof(char) ||
                   type == typeof(sbyte) || type == typeof(byte) || type == typeof(short) ||
                   type == typeof(ushort) || type == typeof(int) || type == typeof(uint) ||
                   type == typeof(long) || type == typeof(ulong) || type == typeof(float) ||
                   type == typeof(double) || type == typeof(decimal) || type == typeof(nint) ||
                   type == typeof(nuint) || type == typeof(Half);
        }
    }

    public static bool IsInheritance(this Type type, FieldInfo field) {
        var inheritances = type.GetCustomAttributes().Where(t => t.GetType().Name.Contains("InheritsAttribute`1")).Select(t => t.GetType().GetGenericArguments()[0]).ToArray();
        if (inheritances.Length == 0) return false;
        foreach (var inheritance in inheritances) {
            if (inheritance.IsFieldInType(field)) return true;
            if (IsInheritance(inheritance, field)) return true;
        }
        return false;
    }

    public static bool IsFieldInType(this Type type, FieldInfo field) {
        var nameStrings = field.Name.Split('_');
        var index = Array.IndexOf(nameStrings, type.Name);
        if (index <= 0) return type.GetFields(ExporterStatics.BindingFlags).Any(f => f.Name == field.Name && f.FieldType == field.FieldType);
        var name = string.Join("_", nameStrings[(index + 1)..]);
        return type.GetFields(ExporterStatics.BindingFlags).Any(f => f.Name == name && f.FieldType == field.FieldType) || type.GetFields(ExporterStatics.BindingFlags).Any(f => f.Name == field.Name && f.FieldType == field.FieldType);
    }

    public static string FixTypeName(this Type type, Func<Type, bool, string> unhandled, bool shouldLower = true) =>
        type switch {
            _ when type == typeof(void) || type == typeof(byte) || type == typeof(byte*) || type == typeof(byte**) => shouldLower ? type.Name.ToLower() : type.Name,
            _ when type == typeof(char) => "wchar_t",
            _ when type == typeof(bool) => "byte",
            _ when type == typeof(float) => "float",
            _ when type == typeof(double) => "double",
            _ when type == typeof(short) => "__int16",
            _ when type == typeof(int) => "int",
            _ when type == typeof(long) || type == typeof(nint) => "__int64",
            _ when type == typeof(ushort) => "unsigned __int16",
            _ when type == typeof(uint) => "unsigned int",
            _ when type == typeof(ulong) || type == typeof(nuint) => "unsigned __int64",
            _ when type == typeof(sbyte) => "__int8",
            _ when type == typeof(char*) => "wchar_t*",
            _ when type == typeof(short*) => "__int16*",
            _ when type == typeof(ushort*) => "unsigned __int16*",
            _ when type == typeof(int*) => "int*",
            _ when type == typeof(uint*) => "unsigned int*",
            _ when type == typeof(long*) || type == typeof(nint*) => "__int64*",
            _ when type == typeof(ulong*) || type == typeof(nuint*) => "unsigned __int64*",
            _ when type == typeof(float*) => "float*",
            _ when type == typeof(Half) => "__int16", // Half is a struct that is 2 bytes long and does not exist in C so we just use __int16
            _ when type == typeof(void*) => "__int64",
            _ when type == typeof(void**) => "__int64*",
            _ => unhandled(type, shouldLower)
        };

    public static int SizeOf(this Type type) {
        return type switch {
            _ when type == typeof(sbyte) || type == typeof(byte) || type == typeof(bool) => 1,
            _ when type == typeof(char) || type == typeof(short) || type == typeof(ushort) || type == typeof(Half) => 2,
            _ when type == typeof(int) || type == typeof(uint) || type == typeof(float) => 4,
            _ when type == typeof(long) || type == typeof(ulong) || type == typeof(double) || type.IsPointer || type.IsFunctionPointer || type.IsUnmanagedFunctionPointer || (type.Name == "Pointer`1" && type.Namespace == ExporterStatics.InteropNamespacePrefix[..^1]) => 8,
            _ when type.Name.StartsWith("FixedSizeArray") => type.GetGenericArguments()[0].SizeOf() * int.Parse(type.Name[14..type.Name.IndexOf('`')]),
            _ when type.GetCustomAttribute<InlineArrayAttribute>() is { Length: var length } => type.GetGenericArguments()[0].SizeOf() * length,
            _ when type.IsStruct() && !type.IsGenericType && (type.StructLayoutAttribute?.Value ?? LayoutKind.Sequential) != LayoutKind.Sequential => type.StructLayoutAttribute?.Size ?? (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0,
            _ when type.IsEnum => Enum.GetUnderlyingType(type).SizeOf(),
            _ when type.IsGenericType => Marshal.SizeOf(Activator.CreateInstance(type)!),
            _ => GetSizeOf(type)
        };
    }

    private static int GetSizeOf(this Type type) {
        try {
            return Marshal.SizeOf(Activator.CreateInstance(type)!);
        } catch {
            return 0;
        }
    }

    public static string GetNamespace(this Type type) {
        var ns = type.Namespace!;
        var offset = ns.IndexOf('.', ns.IndexOf('.') + 1) + 1;
        return offset == 0 ? "" : ns[offset..];
    }

    public static string GetFullname(this Type type) {
        return type.Namespace + "." + type.Name;
    }

    public static bool IsHavok(this Type type) {
        return type.GetFullname().StartsWith(ExporterStatics.HavokNamespacePrefix);
    }

    public static bool IsStd(this Type type) {
        return type.GetFullname().StartsWith(ExporterStatics.StdNamespacePrefix);
    }

    public static bool IsXiv(this Type type) {
        return type.GetFullname().StartsWith(ExporterStatics.FFXIVNamespacePrefix);
    }

    public static bool IsInterop(this Type type) {
        return type.GetFullname().StartsWith(ExporterStatics.InteropNamespacePrefix);
    }

    public static bool IsPointer(this Type type) {
        return type.IsPointer || type.IsFunctionPointer || type.IsUnmanagedFunctionPointer || type.IsGenericPointer();
    }

    public static bool IsGenericPointer(this Type type) {
        return (type.Name == "Pointer`1" && type.Namespace == ExporterStatics.InteropNamespacePrefix[..^1]) || (type.Name == "hkRefPtr`1" && type.Namespace == ExporterStatics.HavokNamespacePrefix[..^1]);
    }

    public static string SanitizeName(this Type type) {
        if (type.IsPointer || type.IsFunctionPointer || type.IsUnmanagedFunctionPointer) return type.GetElementType()!.FixTypeName((t, _) => t.SanitizeName()) + "*";
        var name = type.FullName ?? type.Namespace! + "." + type.Name;
        if (type.IsHavok() || type.IsStd() || type.IsXiv() | type.IsInterop()) {
            var offset = name.IndexOf('.', name.IndexOf('.') + 1) + 1;
            name = name[offset..];
        }
        if (!type.IsGenericType) return name;
        switch (type.Name) {
            case "Pointer`1" when type.Namespace == ExporterStatics.InteropNamespacePrefix[..^1]:
                return type.GenericTypeArguments[0].FixTypeName((t, _) => t.SanitizeName()) + "*";
            case "hkRefPtr`1" when type.Namespace == ExporterStatics.HavokNamespacePrefix[..^1]:
                return type.GenericTypeArguments[0].FixTypeName((t, _) => t.SanitizeName()) + "*";
        }
        var tmp = name[name.IndexOf('`')..];
        if (StdNodeRegex.IsMatch(tmp)) {
            name = name[..name.IndexOf('`')] + "." + StdNodeRegex.Match(tmp).Value[3..];
        } else {
            name = name[..name.IndexOf('`')];
        }
        name += "<" + string.Join(", ", type.GenericTypeArguments.Select(t => t.FixTypeName((t, _) => t.SanitizeName()))) + ">";
        return name;
    }

    public static string FullSanitizeName(this Type type) {
        var name = type.FixTypeName((t, _) => t.SanitizeName()).Replace("+", ExporterStatics.Separator).Replace(".", ExporterStatics.Separator);
        return name;
    }
}

public static class FieldInfoExtensions {
    // see https://stackoverflow.com/questions/30817924/obtain-non-explicit-field-offset for explanation
    public static int GetFieldOffset(this FieldInfo info) => Marshal.ReadInt32(info.FieldHandle.Value + (4 + IntPtr.Size)) & 0xFFFFFF;
}
public static class Extensions {
    public static void WriteFile(this FileInfo file, string content) {
        using var stream = file.CreateText();
        stream.Write(content);
    }
}
