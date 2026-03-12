using System.Numerics;
using System.Runtime.CompilerServices;

namespace InteropGenerator.Runtime;

public static class BitOps {
    /// <summary>
    /// Creates a mask with <paramref name="length"/> number of set bits starting from the LSB.<br/>
    /// Example: <code>CreateLowBitMask&lt;byte&gt;(3)</code> results in <code>0b0000_0111</code>
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T CreateLowBitMask<T>(int length)
        where T : unmanaged, IBinaryInteger<T> {
        if (length <= 0) return T.Zero;
        if (length >= Unsafe.SizeOf<T>() * 8) return T.AllBitsSet;
        return (T.One << length) - T.One;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool GetBit<T>(T value, int index)
        where T : unmanaged, IBinaryInteger<T> {
        return ((value >> index) & T.One) != T.Zero;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T SetBit<T>(T value, int index, bool enable)
        where T : unmanaged, IBinaryInteger<T> {
        T mask = T.One << index;
        return enable ? value | mask : value & ~mask;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T GetBits<T>(T value, int shift, T mask)
        where T : unmanaged, IBinaryInteger<T> {
        return (value >> shift) & mask;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T SetBits<T>(T value, int shift, T mask, T newValue)
        where T : unmanaged, IBinaryInteger<T> {
        return (value & ~(mask << shift)) | ((newValue & mask) << shift);
    }
}
