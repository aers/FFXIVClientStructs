using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct ReferencedUtf8String {
    [FieldOffset(0)] public Utf8String Utf8String;
    [FieldOffset(0x68)] public uint RefCount;

    [MemberFunction("E8 ?? ?? ?? ?? C6 45 E8 01")]
    public static partial void Create(ReferencedUtf8String** targetPtr, Utf8String* source);
}
