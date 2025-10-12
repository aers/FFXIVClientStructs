// Portions of this file are derived from dotnet/runtime
// https://github.com/dotnet/runtime
// Licensed under the MIT license. See InteropGenerator/ThirdPartyLicenses.txt for details.

using System.Numerics;
using System.Runtime.CompilerServices;

namespace InteropGenerator.Runtime;

// Source: https://github.com/dotnet/runtime/blob/89ccd55/src/libraries/System.Private.CoreLib/src/System/Collections/BitArray.cs#L272-L334

/// <summary>
/// Represents a compact array of bits stored in unmanaged memory.
/// </summary>
public readonly unsafe struct BitArray(byte* ptr, int bitCount) {
    /// <summary>
    /// Gets the pointer to the unmanaged memory backing this bit array.
    /// </summary>
    public byte* Pointer => ptr;

    /// <summary>
    /// Gets the total number of bits in the array.
    /// </summary>
    public int BitCount => bitCount;

    /// <summary>
    /// Gets the length of the underlying storage in bytes.
    /// </summary>
    public int ByteLength => (BitCount + 7) / 8;

    /// <summary>
    /// Gets the number of bits set to <see langword="true"/> in the <see cref="BitArray"/>.
    /// </summary>
    public int PopCount {
        get {
            int popCount = 0;

            int fullBytes = BitCount / 8;
            for (int i = 0; i < fullBytes; i++)
                popCount += BitOperations.PopCount(ptr[i]);

            int remainingBits = BitCount & 7;
            if (remainingBits > 0)
                popCount += BitOperations.PopCount((byte)(ptr[fullBytes] & ((1 << remainingBits) - 1)));

            return popCount;
        }
    }

    /// <summary>
    /// Gets or sets the value of the bit at a specific position in the <see cref="BitArray"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the value to get or set.</param>
    /// <returns>The value of the bit at position <paramref name="index"/>.</returns>
    /// <returns>The value of the bit at position <paramref name="index"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is greater than or equal to <see cref="Count"/>.</exception>
    public bool this[int index] {
        get => Get(index);
        set => Set(index, value);
    }

    /// <summary>
    /// Gets the value of the bit at a specific position in the <see cref="BitArray"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the value to get.</param>
    /// <returns>The value of the bit at position <paramref name="index"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is greater than or equal to <see cref="Count"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Get(int index) {
        ArgumentOutOfRangeException.ThrowIfNegative(index, nameof(index));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(index, bitCount, nameof(index));

        (uint byteIndex, uint bitOffset) = Math.DivRem((uint)index, 8);
        return ((ptr[byteIndex]) & (1 << (int)bitOffset)) != 0;
    }

    /// <summary>
    /// Sets the value of the bit at a specific position in the <see cref="BitArray"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the value to get.</param>
    /// <param name="value">The Boolean value to assign to the bit.</param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is greater than or equal to <see cref="Count"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Set(int index, bool value) {
        ArgumentOutOfRangeException.ThrowIfNegative(index, nameof(index));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(index, bitCount, nameof(index));

        (uint byteIndex, uint bitOffset) = Math.DivRem((uint)index, 8);

        ref byte segment = ref ptr[byteIndex];
        byte bitMask = (byte)(1 << (int)bitOffset);
        if (value) {
            segment |= bitMask;
        } else {
            segment &= (byte)~bitMask;
        }
    }

    /// <summary>
    /// Attempts to get the value of the bit at a specific position in the <see cref="BitArray"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the value to get.</param>
    /// <param name="value">
    /// When this method returns, contains the value of the bit at position <paramref name="index"/>,
    /// if the index was within range; otherwise <see langword="false"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the bit was successfully retrieved; 
    /// otherwise, <see langword="false"/>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGet(int index, out bool value) {
        if ((uint)index >= (uint)bitCount) {
            value = false;
            return false;
        }

        (uint byteIndex, uint bitOffset) = Math.DivRem((uint)index, 8);
        value = ((ptr[byteIndex]) & (1 << (int)bitOffset)) != 0;
        return true;
    }

    /// <summary>
    /// Attempts to set the value of the bit at a specific position in the <see cref="BitArray"/>.
    /// </summary>
    /// <param name="index">The zero-based index of the value to set.</param>
    /// <param name="value">The Boolean value to assign to the bit.</param>
    /// <returns>
    /// <see langword="true"/> if the bit was successfully set; 
    /// otherwise, <see langword="false"/>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TrySet(int index, bool value) {
        if ((uint)index >= (uint)bitCount) {
            return false;
        }

        (uint byteIndex, uint bitOffset) = Math.DivRem((uint)index, 8);

        ref byte segment = ref ptr[byteIndex];
        byte bitMask = (byte)(1 << (int)bitOffset);
        if (value) {
            segment |= bitMask;
        } else {
            segment &= (byte)~bitMask;
        }

        return true;
    }

    /// <summary>
    /// Returns an enumerator that iterates through the <see cref="BitArray"/>.
    /// </summary>
    public BitArrayEnumerator GetEnumerator() => new(this);

    /// <summary>
    /// Enumerates the bits in a <see cref="BitArray"/>.
    /// </summary>
    public ref struct BitArrayEnumerator(BitArray bitArray) {
        private int _index = -1;

        /// <summary>
        /// Gets the current element in the collection.
        /// </summary>
        public readonly (int Index, bool Value) Current => (_index, bitArray[_index]);

        /// <summary>
        /// Advances the enumerator to the next bit in the collection.
        /// </summary>
        /// <returns><see langword="true"/> if the enumerator was successfully advanced; otherwise <see langword="false"/>.</returns>
        public bool MoveNext() => ++_index < bitArray.BitCount;

        /// <summary>
        /// Sets the enumerator to its initial position.
        /// </summary>
        public void Reset() {
            _index = -1;
        }
    }
}
