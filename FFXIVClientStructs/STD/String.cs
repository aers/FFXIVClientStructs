using System.Text;

namespace FFXIVClientStructs.STD;

// std::string aka std::basic_string from msvc
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct StdString {
    // if (Length < 16) uses Buffer else uses BufferPtr
    [FieldOffset(0x0), CExporterUnion("Union.Buffer")] public byte* BufferPtr;
    [FieldOffset(0x0), CExporterUnion("Union.Buffer")] public fixed byte Buffer[16];
    /// <summary>
    /// This string's length, as a <see cref="ulong"/>.
    /// </summary>
    [FieldOffset(0x10)] public ulong Length;
    [FieldOffset(0x18)] public ulong Capacity;

    /// <summary>
    /// This string's length, as an <see cref="int"/>.
    /// </summary>
    /// <exception cref="OverflowException">This string is ≥ 2 GiB, or an attempt is made to give it a negative length.</exception>
    /// <remarks>
    /// The primary motive of this property is to support the implicit <see cref="Index"/> and <see cref="Range"/> accessors.
    /// </remarks>
    public int Count {
        readonly get => checked((int)Length);
        set => Length = checked((ulong)value);
    }
    public readonly ref readonly byte this[int index] => ref AsSpan()[index];

    public readonly ReadOnlySpan<byte> AsSpan() {
        if (Length < 16) {
            fixed (StdString* pThis = &this) {
                return new(pThis->Buffer, (int)Length);
            }
        } else if (Length <= int.MaxValue) {
            return new(BufferPtr, (int)Length);
        } else {
            throw new OverflowException($"Cannot convert StdString of length {Length} (≥ 2 GiB) to ReadOnlySpan<byte>");
        }
    }

    public readonly ReadOnlySpan<byte> Slice(int start) => AsSpan().Slice(start);
    public readonly ReadOnlySpan<byte> Slice(int start, int length) => AsSpan().Slice(start, length);

    [Obsolete("Use AsSpan() instead")]
    public readonly byte[] GetBytes() {
        var data = new byte[Length];
        // If the string is too large to fit a span, it is also too large to fit an array:
        // https://sharplab.io/#v2:EYLgtghglgdgNAFxAJwK4wD4AEBMAGAWAChcBGY4gNwmQAIbkIBPAfVNoF5aYBTAd1rAmCHgG1YCAHQBZCAA8AahAA2qHrQC0tAKwA2ALoBuKjXrJGrHJ279BwsRJnylq9Vu3ajQA===
        // We are therefore not handling ≥ 2 GiB cases here - they should not happen in practice anyway.
        AsSpan().CopyTo(data);
        return data;
    }

    public readonly override string ToString()
        => Encoding.UTF8.GetString(AsSpan());

    public static implicit operator ReadOnlySpan<byte>(in StdString value)
        => value.AsSpan();
}
