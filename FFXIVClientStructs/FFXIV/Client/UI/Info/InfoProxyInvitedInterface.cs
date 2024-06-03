namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyInvitedInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct InfoProxyInvitedInterface {
    [FieldOffset(0x18)] public Unk18 Unk18Obj;
    //There seems to be a pointer to data at 0x20

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Unk18 {
        [FieldOffset(0x8)] public void* Data;
    }
}
