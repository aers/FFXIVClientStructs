using System.Runtime.InteropServices;
using System.Text;

namespace InteropGenerator.Runtime;

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe struct CStringPointer(byte* value) {
    [FieldOffset(0x00)] public byte* Value = value;

    public bool HasValue => Value != null;

    public ReadOnlySpan<byte> AsSpan() => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(Value);

    public override string ToString() => AsSpan().IsEmpty ? string.Empty : Encoding.UTF8.GetString(AsSpan());
    public int Length => AsSpan().Length;

    public static implicit operator byte*(CStringPointer cstr) => cstr.Value;
    public static implicit operator CStringPointer(byte* cstr) => new(cstr);

    public static implicit operator ReadOnlySpan<byte>(CStringPointer cstr) => cstr.AsSpan();
    public static implicit operator string(CStringPointer cstr) => cstr.ToString();
}
