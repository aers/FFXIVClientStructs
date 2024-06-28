using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct ReferencedUtf8String {
    [FieldOffset(0)] public Utf8String Utf8String;
    [FieldOffset(0x68)] public uint RefCount;
}
