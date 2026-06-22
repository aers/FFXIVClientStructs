namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::ExitRangeLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
/// <summary>
/// BoxCollider that when touched triggers loading into a new zone.
/// </summary>
[GenerateInterop]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct ExitRangeLayoutInstance {
    /// <summary>
    /// TerritoryType that this exit leads to.
    /// </summary>
    [FieldOffset(0x86)] public ushort DestinationId;
}
