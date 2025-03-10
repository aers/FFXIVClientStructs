using System.Text;

namespace FFXIVClientStructs.Interop;

[CExportIgnore]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct StringPointer(byte* value) {
    [FieldOffset(0x00)] public byte* Value = value;

    public ReadOnlySpan<byte> AsSpan() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(Value);

    public override string ToString() => AsSpan().IsEmpty ? string.Empty : Encoding.UTF8.GetString(AsSpan());
    public int Length => AsSpan().Length;

    public static implicit operator byte*(StringPointer cstr) => cstr.Value;
    public static implicit operator StringPointer(byte* cstr) => new(cstr);

    public static implicit operator ReadOnlySpan<byte>(StringPointer cstr) => cstr.AsSpan();
    public static implicit operator string(StringPointer cstr) => cstr.ToString();
}
