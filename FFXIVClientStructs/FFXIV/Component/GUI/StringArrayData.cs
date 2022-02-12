using System.Text;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct StringArrayData
{
    [FieldOffset(0x0)] public AtkArrayData AtkArrayData;
    [FieldOffset(0x20)] public byte** StringArray; // char * *
    [FieldOffset(0x28)] public byte* UnkString; // char *

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F 10 41 0F B6 9F")]
    public partial void SetValue(int index, byte* value, bool notify);

    public void SetValue(int index, string value, bool notify)
    {
        SetValue(index, Encoding.UTF8.GetBytes(value), notify);
    }

    public void SetValue(int index, byte[] value, bool notify)
    {
        var alloc = Marshal.AllocHGlobal(value.Length + 1);
        Marshal.Copy(value, 0, alloc, value.Length);
        Marshal.WriteByte(alloc, value.Length, 0);
        SetValue(index, (byte*) alloc, notify);
        Marshal.FreeHGlobal(alloc);
    }
}