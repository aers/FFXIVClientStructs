namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::GameObjectLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
[GenerateInterop(isInherited: true)]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public partial struct GameObjectLayoutInstance {
    /// <remarks> Which sheet this RowId is part of most likely depends on <see cref="ILayoutInstance.Identifier.Type"/>. </remarks>
    [FieldOffset(0x30)] public uint BaseId;
}
