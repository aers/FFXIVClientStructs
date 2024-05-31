namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

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

    [VirtualFunction(2)]
    public partial void RemoveData();

    /// <summary>
    /// Sets the value of <see cref="InfoProxyInterface.EntryCount"/> to 0 for this proxy. Does not actually delete any data from any arrays. 
    /// </summary>
    [VirtualFunction(3)]
    public partial void ClearData();

    /// <summary>
    /// Generates an info proxy specific network request for data.
    /// </summary>
    /// <returns>Returns true if the packet was sent (?), false otherwise.</returns>
    [VirtualFunction(5)]
    public partial bool RequestData();

    /// <summary>
    /// Gets called after all data is received from the server.
    /// </summary>
    [VirtualFunction(6)]
    public partial void EndRequest();

    [VirtualFunction(7)]
    public partial uint GetEntryCount();
}

[GenerateInterop(isInherited: true)]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct InfoProxyInvitedInterface {
    [FieldOffset(0x18)] public Unk18 Unk18Obj;
    //There seems to be a pointer to data at 0x20

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Unk18 {
        [FieldOffset(0x8)] public void* Data;
    }
}

[GenerateInterop(isInherited: true)]
[Inherits<InfoProxyInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct InfoProxyPageInterface {
    /// <summary>
    /// Handles the InfoProxyAddPage packet and calls <see cref="AddData"/> to load into the InfoProxy. Will also handle dispatching
    /// packets to the server for pagination/fetch purposes. Calls <see cref="EndRequest"/> when all data is loaded.
    /// </summary>
    /// <param name="packetPtr">A pointer to the packet data to load in.</param>
    [VirtualFunction(12)]
    public partial void AddPage(nint packetPtr);
}
