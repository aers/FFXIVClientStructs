using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using FFXIVClientStructs.Interop.Attributes;

namespace CExporter;

public static class TypeExtensions {
    public static bool IsFixedBuffer(this Type type) {
        return type.Name.EndsWith("e__FixedBuffer");
    }

    public static bool IsStruct(this Type type) {
        return type != typeof(decimal) && type is { IsValueType: true, IsPrimitive: false, IsEnum: false };
    }

    public static string FixTypeName(this Type type, Func<Type, bool, string> unhandled, bool shouldLower = true) =>
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
            _ when type.IsStruct() => type.StructLayoutAttribute?.Size ?? (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0,
            _ => (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0
        };
    }

    public static bool IsBlocked(this Type type) =>
        type switch {
            _ when type == typeof(Half) => true,
            _ => false
        };

    public static Type? GetUnderlyingTypeFromOffset(this Type type) {
        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        return fields.FirstOrDefault(t => t.FieldType.IsStruct() && t.GetFieldOffset() == 0)?.FieldType;
    }
}

public static class FieldInfoExtensions {
    public static bool IsFixed(this FieldInfo info) {
        var attr = info.GetCustomAttributes(typeof(FixedBufferAttribute), false).Cast<FixedBufferAttribute>().FirstOrDefault();
        return attr != null;
    }

    public static Tuple<Type, int> GetFixed(this FieldInfo info) {
        var attributes = info.GetCustomAttributes();
        var array = attributes.Where(t => t.GetType().Name.Contains("FixedSizeArrayAttribute"));
        if (array.Any()) {
            var fsattr = (dynamic)array.First();
            var type = (Type)fsattr.GetType();
            return Tuple.Create(type.GenericTypeArguments[0], (int)fsattr.Count);
        }
        var attr = info.GetCustomAttributes(typeof(FixedBufferAttribute), false).Cast<FixedBufferAttribute>().Single();
        if (attr == null)
            throw new Exception("Field is not fixed");
        return new Tuple<Type, int>(attr.ElementType, attr.Length);
    }

    public static int GetFixedLength(this FieldInfo info) {
        var (type, length) = info.GetFixed();
        return length * type.SizeOf();
    }

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
    internal static UnionLayout? GetNextLayout(this List<UnionLayout> layouts, UnionLayout layout) {
        var index = layouts.IndexOf(layout);
        if (index == -1 || index == layouts.Count - 1)
            return null;
        return layouts[index + 1];
    }

    public static void WriteFile(this FileInfo file, string content) {
        using var stream = file.CreateText();
        stream.Write(content);
    }
}
