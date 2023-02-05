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
