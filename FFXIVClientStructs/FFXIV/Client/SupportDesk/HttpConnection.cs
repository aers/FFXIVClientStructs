namespace FFXIVClientStructs.FFXIV.Client.SupportDesk;

// Client::SupportDesk::HttpConnection
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct HttpConnection {
    [VirtualFunction(0)]
    public partial HttpRequest* Dtor(byte freeFlags);

    /// <summary> Initializes the HTTP session. </summary>
    [VirtualFunction(1)]
    public partial void OpenSession();

    /// <summary> Cleans up the HTTP session. </summary>
    [VirtualFunction(2)]
    public partial void CloseSession();

    /// <summary> Creates a new HTTPRequest. </summary>
    /// <param name="url">URL to make a request to.</param>
    /// <param name="verb">The HTTP verb, such as "GET" or "POST".</param>
    /// <param name="data">Any request data to send (only relevant for POST requests really).</param>
    /// <param name="dataLength">Length of the data buffer.</param>
    /// <returns>The new HTTPRequest handle if it could be successfully created.</returns>
    [VirtualFunction(4), GenerateStringOverloads]
    public partial HttpRequest* MakeRequest(CStringPointer url, CStringPointer verb, byte* data, ulong dataLength);
}
