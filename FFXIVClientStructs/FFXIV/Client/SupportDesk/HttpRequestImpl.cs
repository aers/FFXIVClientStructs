namespace FFXIVClientStructs.FFXIV.Client.SupportDesk;

// Client::SupportDesk::HttpRequestImpl
//   Client::SupportDesk::HttpRequest
[GenerateInterop]
[Inherits<HttpRequest>]
[StructLayout(LayoutKind.Explicit, Size = 0x8C8)]
public unsafe partial struct HttpRequestImpl {
    [FieldOffset(0x010)] void* RequestHandle; // HINTERNET
    [FieldOffset(0x018)] void* ResponseData;
    [FieldOffset(0x020)] void* ResponseDataOffset;
    [FieldOffset(0x028)] void* ResponseDataSize;
    [FieldOffset(0x470)] void* OptionalData;
    [FieldOffset(0x480)] int Stage;
}
