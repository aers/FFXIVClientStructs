using System.Text;

namespace FFXIVClientStructs.Interop;

[CExportIgnore]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct StringPointer {
    [FieldOffset(0x00)] public byte* Value;

    public ReadOnlySpan<byte> AsSpan() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(Value);

    public override string ToString() => AsSpan().IsEmpty ? string.Empty : Encoding.UTF8.GetString(AsSpan());
    public int Length => AsSpan().Length;

    public static implicit operator byte*(StringPointer cstr) => cstr.Value;
}
