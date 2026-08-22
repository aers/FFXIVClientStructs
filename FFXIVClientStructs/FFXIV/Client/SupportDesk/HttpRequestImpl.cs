namespace FFXIVClientStructs.FFXIV.Client.SupportDesk;

// Client::SupportDesk::HttpRequestImpl
//   Client::SupportDesk::HttpRequest
[GenerateInterop]
[Inherits<HttpRequest>]
[StructLayout(LayoutKind.Explicit, Size = 0x8C8)]
public unsafe partial struct HttpRequestImpl {
    [FieldOffset(0x010)] public void* RequestHandle; // HINTERNET
    [FieldOffset(0x018)] public byte* ResponseData;
    [FieldOffset(0x020)] public long ResponseDataOffset;
    [FieldOffset(0x028)] public ulong ResponseDataSize;
    [FieldOffset(0x470)] public byte* OptionalData;
    [FieldOffset(0x480)] public HttpRequestStage Stage;
    [FieldOffset(0x48C)] public int StatusCode;
    /// <remarks> Increased by Framework.FrameDeltaTime every time Update is called. </remarks>
    [FieldOffset(0x8C0)] public float FrameDeltaTimeCounter;

    /// <summary> Initializes and begins this request. </summary>
    /// <param name="sessionHandle">The HINTERNET handle to use.</param>
    /// <param name="url">URL to make a request to.</param>
    /// <param name="verb">The HTTP verb, such as "GET" or "POST".</param>
    /// <param name="data">Any request data to send (only relevant for POST requests really).</param>
    /// <param name="dataLength">Length of the data buffer.</param>
    /// <returns>Whether the request was successfully sent.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 ?? 48 8B 03 BA ?? ?? ?? ?? 48 8B CB FF 10 33 DB")]
    public partial bool BeginRequest(void* sessionHandle, byte* url, byte* verb, byte* data, ulong dataLength);

    /// <summary> Used as the WinHttp status callback. </summary>
    /// <remarks> Documentation for this callback can be found <a href="https://learn.microsoft.com/en-us/windows/win32/api/winhttp/nc-winhttp-winhttp_status_callback">here</a>. </remarks>
    [MemberFunction("48 85 D2 0F 84 ?? ?? ?? ?? 48 89 5C 24 ?? 56 57")]
    public static partial void StatusCallback(void* requestHandle, HttpRequestImpl* context, uint internetStatus, void* statusInformation, uint statusInformationLength);
}

public enum HttpRequestStage {
    Unk0 = 0,
    /// <remarks> Set during BeginRequest. </remarks>
    Began = 1,
    /// <remarks> Used while and shortly after fetching the ContentLength and StatusCode headers from the response. </remarks>
    ReadingHeaders = 2,
    /// <remarks> Used while reading the response data. </remarks>
    ReadingData = 3,
    /// <remarks> Seen after FetchingData, and there's nothing more to read. </remarks>
    ReadAllData = 4,
    Unk5 = 5,
    Unk6 = 6,
    /// <remarks> Set for WINHTTP_CALLBACK_STATUS_HANDLE_CLOSING. </remarks>
    Closing = 7,
    /// <remarks> Set when the StatusCode is not 200 OK. Can also happen when WinHttpSendRequest is unsuccessful. </remarks>
    NotOk = 8,
    Unk9 = 9,
    Unk10 = 10,
    Unk11 = 11,
    Unk12 = 12,
    Unk13 = 13,
    /// <remarks> Set for WINHTTP_CALLBACK_STATUS_SECURE_FAILURE. </remarks>
    SecureFailure = 14,
}

