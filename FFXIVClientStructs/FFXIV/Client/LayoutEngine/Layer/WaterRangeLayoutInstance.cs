namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::WaterRangeLayoutInstance
//   Client::LayoutEngine::Layer::TriggerBoxLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<TriggerBoxLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct WaterRangeLayoutInstance {
    [FieldOffset(0x80)] private uint Unk80; // First bit enables swimming, second bit messes with the environment like in The Tempest
}
