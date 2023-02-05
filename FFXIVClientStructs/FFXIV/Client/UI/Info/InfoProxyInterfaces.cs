using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct InfoProxyInterface

{
    [FieldOffset(0x0)] public void** vtbl;
    [FieldOffset(0x8)] public UIModule* UiModule;
    //For Proxies with a fixed count this is apparently 0
    [FieldOffset(0x10)] public uint EntryCount;

    [VirtualFunction(7)]
    public partial uint GetEntryCount();
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct InfoProxyUnk3Interface
{
    [FieldOffset(0x0)] public InfoProxyInterface InfoProxynterface;
    //There seems to be a pointer to data at 0x20
}

[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct InfoProxyUnkInterface
{
    [FieldOffset(0x0)] public InfoProxyInterface InfoProxyInterface;
    [FieldOffset(0x20)] public Utf8String Unk20;
    //0x88
    //[FieldOffset(0x98)] Pointer to Array of Data 
}

[StructLayout(LayoutKind.Explicit, Size = 0xC8)]
public unsafe partial struct InfoProxyUnk2Interface
{
    [FieldOffset(0x0)] public InfoProxyUnkInterface InfoProxyUnkInterface;
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct InfoProxyPageInterface
{
    [FieldOffset(0x0)] public InfoProxyInterface InfoProxyInterface;

}