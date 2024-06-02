namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyPageInterface
//   Client::UI::Info::InfoProxyInterface
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
