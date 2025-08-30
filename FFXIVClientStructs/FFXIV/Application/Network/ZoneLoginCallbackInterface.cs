namespace FFXIVClientStructs.FFXIV.Application.Network;

// Application::Network::ZoneLoginCallbackInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public partial struct ZoneLoginCallbackInterface {
    [VirtualFunction(1)]
    public partial void OnZoneLogin();
}
