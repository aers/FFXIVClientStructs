namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSContentInventoryProvider
//   Client::Game::ContentInventoryProvider
[GenerateInterop]
[Inherits<ContentInventoryProvider>]
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct WKSContentInventoryProvider {
    [FieldOffset(0x28)] public WKSContentInventoryContainer Cosmopouch1;
    [FieldOffset(0x68)] public WKSContentInventoryContainer Cosmopouch2;
}
