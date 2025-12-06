namespace FFXIVClientStructs.FFXIV.Client.SupportDesk;

// Client::SupportDesk::HttpConnectionImpl
//   Client::SupportDesk::HttpConnection
[GenerateInterop]
[Inherits<HttpConnection>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct HttpConnectionImpl {
    [FieldOffset(0x008)] void* SessionHandle; // HINTERNET
}
