namespace FFXIVClientStructs.FFXIV.Client.SupportDesk;

// Client::SupportDesk::HttpConnection
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct HttpConnection {
    // Initializes the HTTP session.
    [VirtualFunction(1)]
    public partial void OpenSession();

    // Cleans up the HTTP session.
    [VirtualFunction(2)]
    public partial void CloseSession();
}
