namespace FFXIVClientStructs.FFXIV.Application.Network.LobbyClient;

// Application::Network::LobbyClient::LobbyRequestCallback
[GenerateInterop(isInherited: true)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 83 C4 20 5B C3 CC CC CC CC CC CC CC CC 33 C0 89 41 08", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct LobbyRequestCallback {
    [VirtualFunction(0)]
    public partial LobbyRequestCallback* Dtor(byte freeFlags);

    [VirtualFunction(4)]
    public partial void ReportError(LobbyStatusCode* status);
}

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public struct LobbyStatusCode {
    [FieldOffset(0x00)] public int Code;
    [FieldOffset(0x08)] public int CodeType;
    [FieldOffset(0x10)] public Utf8String String;
    [FieldOffset(0x78)] public ushort ErrorSheetRow;
}