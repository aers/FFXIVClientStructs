using System.Text;

namespace FFXIVClientStructs.Interop;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct CString {
    [FieldOffset(0x00)] public byte* Value;

    public ReadOnlySpan<byte> AsSpan() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(Value);

    public override string ToString() => AsSpan().IsEmpty ? string.Empty : Encoding.UTF8.GetString(AsSpan());
    public int Length => AsSpan().Length;

    public static implicit operator byte*(CString cstr) => cstr.Value;
}
