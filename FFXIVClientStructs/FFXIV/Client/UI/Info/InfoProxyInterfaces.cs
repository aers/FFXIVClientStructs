namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct InfoProxyInterface {
    [FieldOffset(0x0), CExportIgnore] public void** vtbl;
    [FieldOffset(0x8)] public UIModule* UiModule;
    //For Proxies with a fixed count this is apparently 0
    [FieldOffset(0x10)] public uint EntryCount;

    [VirtualFunction(6)]
    public partial void EndRequest();

    [VirtualFunction(7)]
    public partial uint GetEntryCount();
}

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct InfoProxyInvitedInterface {
    [FieldOffset(0x0)] public InfoProxyInterface InfoProxynterface;
    [FieldOffset(0x18)] public Unk18 Unk18Obj;
    //There seems to be a pointer to data at 0x20

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Unk18 {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public void* Data;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct InfoProxyPageInterface {
    [FieldOffset(0x0)] public InfoProxyInterface InfoProxyInterface;

    [VirtualFunction(12)]
    public partial bool AddPage(void* data);
}
