using System.Text;

namespace FFXIVClientStructs.STD;

// std::string aka std::basic_string from msvc
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct StdString
{
    // if (Length < 16) uses Buffer else uses BufferPtr
    [FieldOffset(0x0)] public byte* BufferPtr;
    [FieldOffset(0x0)] public fixed byte Buffer[16];
    [FieldOffset(0x10)] public ulong Length;
    [FieldOffset(0x18)] public ulong Capacity;

    public byte[] GetBytes()
    {
        var data = new byte[Length];

        if (Length < 16)
            for (ulong i = 0; i < Length; i++)
                data[i] = Buffer[i];
        else
            for (ulong i = 0; i < Length; i++)
                data[i] = BufferPtr[i];
        return data;
    }

    public override string ToString()
    {
        return Encoding.UTF8.GetString(GetBytes());
    }
}