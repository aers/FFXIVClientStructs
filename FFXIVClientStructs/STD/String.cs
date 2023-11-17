using System.Text;

namespace FFXIVClientStructs.STD;

// std::string aka std::basic_string from msvc
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct StdString {
    // if (Length < 16) uses Buffer else uses BufferPtr
    [FieldOffset(0x0)] public byte* BufferPtr;
    [FieldOffset(0x0)] public fixed byte Buffer[16];
    [FieldOffset(0x10)] public ulong Length;
    [FieldOffset(0x18)] public ulong Capacity;

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

    public readonly byte[] GetBytes() {
        var data = new byte[Length];

        if (Length <= int.MaxValue)
            AsSpan().CopyTo(data);
        else {
            fixed (byte* pData = data) {
                System.Buffer.MemoryCopy(BufferPtr, pData, Length, Length);
            }
        }
        return data;
    }

    public readonly override string ToString() {
        // Using GetBytes() if this string is too large to fit in a span brings no benefit:
        // Encoding.GetString(byte[]) uses .Length (not .LongLength), which throws an OverflowException if the string didn't fit in a span in the first place.
        return Encoding.UTF8.GetString(AsSpan());
    }

    public static implicit operator ReadOnlySpan<byte>(in StdString value)
        => value.AsSpan();
}
