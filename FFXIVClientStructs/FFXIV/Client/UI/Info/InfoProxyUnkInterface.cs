using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct InfoProxyUnkInterface
{
    [FieldOffset(0x0)] public InfoProxyInterface InfoProxyPageInterface;
    [FieldOffset(0x20)] public Utf8String Unk20;
    //0x88
    //[FieldOffset(0x98)] Pointer to Array of Data 
}
