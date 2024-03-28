using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CExporter;

public static class TypeExtensions {
    public static bool IsFixedBuffer(this Type type) {
        return type.Name.EndsWith("e__FixedBuffer");
    }

    public static bool IsStruct(this Type type) {
        return type != typeof(decimal) && type is { IsValueType: true, IsPrimitive: false, IsEnum: false };
    }

    public static string FixTypeName(this Type? type, Func<Type, bool, string> unhandled, bool shouldLower = true) =>
        type switch {
            _ when type == typeof(void) || type == typeof(void*) || type == typeof(void**) ||
                   type == typeof(byte) || type == typeof(byte*) || type == typeof(byte**) => shouldLower ? type.Name.ToLower() : type.Name,
            _ when type == typeof(char) => "wchar_t",
            _ when type == typeof(bool) => "bool",
            _ when type == typeof(float) => "float",
            _ when type == typeof(double) => "double",
            _ when type == typeof(short) => "__int16",
            _ when type == typeof(int) => "__int32",
            _ when type == typeof(long) || type == typeof(nint) => "__int64",
            _ when type == typeof(ushort) => "unsigned __int16",
            _ when type == typeof(uint) => "unsigned __int32",
            _ when type == typeof(ulong) || type == typeof(nuint) => "unsigned __int64",
            _ when type == typeof(sbyte) => "signed __int8",
            _ when type == typeof(char*) => "wchar_t*",
            _ when type == typeof(short*) => "__int16*",
            _ when type == typeof(ushort*) => "unsigned __int16*",
            _ when type == typeof(int*) => "__int32*",
            _ when type == typeof(uint*) => "unsigned __int32*",
            _ when type == typeof(long*) || type == typeof(nint*) => "__int64*",
            _ when type == typeof(ulong*) || type == typeof(nuint*) => "unsigned __int64*",
            _ when type == typeof(float*) => "float*",
            _ when type == typeof(Half) => "__int16", // Half is a struct that is 2 bytes long and does not exist in C so we just use __int16
            _ => unhandled(type, shouldLower)
        };

    public static int SizeOf(this Type type) {
        // Marshal.SizeOf doesn't work correctly because the assembly is unmarshaled, and more specifically, it sets booleans as 4 bytes long...
        return type switch {
            _ when type == typeof(sbyte) || type == typeof(byte) || type == typeof(bool) => 1,
            _ when type == typeof(char) || type == typeof(short) || type == typeof(ushort) || type == typeof(Half) => 2,
            _ when type == typeof(int) || type == typeof(uint) || type == typeof(float) => 4,
            _ when type == typeof(long) || type == typeof(ulong) || type == typeof(double) || type.IsPointer || type.IsFunctionPointer || type.IsUnmanagedFunctionPointer || (type.Name == "Pointer`1" && type.Namespace == ExporterStatics.InteropNamespacePrefix[..^1]) => 8,
            _ when type.IsStruct() && !type.IsGenericType && (type.StructLayoutAttribute?.Value ?? LayoutKind.Sequential) != LayoutKind.Sequential => type.StructLayoutAttribute?.Size ?? (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0,
            _ when type.IsEnum => Enum.GetUnderlyingType(type).SizeOf(),
            _ when type.IsGenericType => Marshal.SizeOf(Activator.CreateInstance(type)!),
            _ => (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0
        };
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
        return type.IsPointer || type.IsFunctionPointer || type.IsUnmanagedFunctionPointer || (type.Name == "Pointer`1" && type.Namespace == ExporterStatics.InteropNamespacePrefix[..^1]);
    }

    public static string SanitizeName(this Type type) {
        var name = type.FullName ?? type.Namespace! + "." + type.Name;
        if (type.IsHavok() || type.IsStd() || type.IsXiv() | type.IsInterop()) {
            var offset = name.IndexOf('.', name.IndexOf('.') + 1) + 1;
            name = name[offset..];
        }
        if (!type.IsGenericType) return name;
        name = name[..name.IndexOf('`')];
        name += "<" + string.Join(", ", type.GenericTypeArguments.Select(t => t.SanitizeName())) + ">";
        return name;
    }
}

public static class FieldInfoExtensions {
    public static int GetFieldOffset(this FieldInfo info) {
        var attrs = info.GetCustomAttributes(typeof(FieldOffsetAttribute), false);
        return attrs.Length != 0 ? attrs.Cast<FieldOffsetAttribute>().Single().Value : GetFieldOffsetSequential(info);
    }

    public static int GetFieldOffsetSequential(this FieldInfo info) {
        if (info.DeclaringType is null)
            throw new Exception($"Unable to access declaring type of field {info.Name}");
        var fields = info.DeclaringType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        var offset = 0;
        foreach (var field in fields) {
            if (field == info)
                return offset;
            offset += field.FieldType.SizeOf();
        }
        throw new Exception("Field not found");
    }
}
public static class Extensions {
    public static void WriteFile(this FileInfo file, string content) {
        using var stream = file.CreateText();
        stream.Write(content);
    }
}
