namespace FFXIVClientStructs.FFXIV.Client.SupportDesk;

// Client::SupportDesk::HttpRequest
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct HttpRequest {
    [VirtualFunction(0)]
    public partial HttpRequest* Dtor(byte freeFlags);

    /// <summary> Updates various bits based on the current stage. </summary>
    [VirtualFunction(1)]
    public partial bool Update();

    /// <summary> Cleans up the open handle. </summary>
    [VirtualFunction(2)]
    public partial bool CloseHandle();
}
