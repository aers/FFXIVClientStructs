namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct InfoProxyInterface
{
    [FieldOffset(0x0)] public void** vtbl;
    [FieldOffset(0x8)] public UIModule* UiModule;
    [FieldOffset(0x10)] public uint Unk10;

    [VirtualFunction(7)]
    public partial uint GetUnk10();
}
