namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSModuleBase
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct WKSModuleBase {
    [VirtualFunction(0)]
    public partial WKSModuleBase* Dtor(byte freeFlags);
}
