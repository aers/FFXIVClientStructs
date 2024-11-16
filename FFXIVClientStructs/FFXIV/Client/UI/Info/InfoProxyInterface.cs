namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct InfoProxyInterface {
    [FieldOffset(0x8)] public UIModule* UIModule;
    //For Proxies with a fixed count this is apparently 0
    [FieldOffset(0x10)] public uint EntryCount;

    /// <summary>
    /// Loads received data into an info proxy specific array.
    /// </summary>
    /// <param name="packetPtr">A pointer to the packet to load in.</param>
    /// <param name="count">The number of entries to load.</param>
    /// <returns>Returns an nint, probably.</returns>
    [VirtualFunction(1)]
    public partial nint AddData(nint packetPtr, uint count = 10);

    /// <summary>
    /// Generates an info proxy specific network request for data.
    /// </summary>
    /// <returns>Returns true if the packet was sent (?), false otherwise.</returns>
    [VirtualFunction(3)]
    public partial bool RequestData();

    [VirtualFunction(4)]
    public partial uint GetEntryCount();

    [VirtualFunction(5)]
    public partial void ClearListData();

    /// <summary>
    /// Gets called after all data is received from the server.
    /// </summary>
    [VirtualFunction(10)]
    public partial void EndRequest();
}
