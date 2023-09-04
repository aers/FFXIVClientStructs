using System;
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

    public static string FixTypeName(this Type type, Func<Type, string> unhandled) =>
        type switch {
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
            _ when type == typeof(Half) => "__int16", // Half is a struct that is 2 bytes long and does not exist in C so we just use __int16
            _ => unhandled(type)
        };

    public static int SizeOf(this Type type) {
        // Marshal.SizeOf doesn't work correctly because the assembly is unmarshaled, and more specifically, it sets booleans as 4 bytes long...
        return type switch {
            _ when type == typeof(sbyte) || type == typeof(byte) || type == typeof(bool) => 1,
            _ when type == typeof(short) || type == typeof(ushort) || type == typeof(Half) => 2,
            _ when type == typeof(int) || type == typeof(uint) || type == typeof(float) => 4,
            _ when type == typeof(long) || type == typeof(ulong) || type == typeof(double) || type.IsPointer => 8,
            _ when type.IsStruct() => type.StructLayoutAttribute?.Size ?? (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0,
            _ => (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0
        };
    }

    public static bool IsBlocked(this Type type) =>
        type switch {
            _ when type == typeof(Half) => true,
            _ => false
        };
}

public static class FieldInfoExtensions {
    public static bool IsFixed(this FieldInfo info) {
        var attr = info.GetCustomAttributes(typeof(FixedBufferAttribute), false).Cast<FixedBufferAttribute>().FirstOrDefault();
        return attr != null;
    }

    public static Type GetFixedType(this FieldInfo info) {
        return info.GetCustomAttributes(typeof(FixedBufferAttribute), false).Cast<FixedBufferAttribute>().Single().ElementType;
    }

    public static int GetFixedSize(this FieldInfo info) {
        return info.GetCustomAttributes(typeof(FixedBufferAttribute), false).Cast<FixedBufferAttribute>().Single().Length;
    }

    public static int GetFieldOffset(this FieldInfo info) {
        var attrs = info.GetCustomAttributes(typeof(FieldOffsetAttribute), false);
        return attrs.Length != 0 ?
            attrs.Cast<FieldOffsetAttribute>().Single().Value :
            // Lets assume this is because it's a LayoutKind.Sequential struct
            Marshal.OffsetOf(info.DeclaringType!, info.Name).ToInt32();
    }
}
