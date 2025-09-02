namespace FFXIVClientStructs.FFXIV.Application.Network;

// Application::Network::LogoutCallbackInterface
[GenerateInterop(isInherited: true)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 43 ?? 48 8D 05 ?? ?? ?? ?? 48 89 43 ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 E8", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct LogoutCallbackInterface {
    [VirtualFunction(1)]
    public partial void OnLogout(LogoutParams* logoutParams);

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct LogoutParams {
        [FieldOffset(0x0)] public int Type; // 2 opens the Dialogue box
        [FieldOffset(0x4)] public int Code; // 10000 for normal logout, 90002 for disconnect (lost connection)
    }
}
