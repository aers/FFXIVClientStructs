namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSModuleBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct WKSModuleBase {
    [VirtualFunction(0)]
    public partial WKSModuleBase* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial bool SetIntData(int a2, int a3, int a4, int a5, int a6, int a7);

    [VirtualFunction(2)]
    public partial bool ProcessPacket(byte* packet);
}
