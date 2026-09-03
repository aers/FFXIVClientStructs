namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::ShowHideRangeLayoutInstance
//   Client::LayoutEngine::Layer::TriggerBoxLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<TriggerBoxLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct ShowHideRangeLayoutInstance {
    [FieldOffset(0x80)] public uint LayerSetReferenceCount;
    /// <remarks> List of layer set IDs. </remarks>
    [FieldOffset(0x88)] public uint* LayerSetReferences;
    [FieldOffset(0x90)] public bool Active;
}
