namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::ShowHideRangeLayoutInstance
//   Client::LayoutEngine::Layer::TriggerBoxLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<TriggerBoxLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct ShowHideRangeLayoutInstance {
    [FieldOffset(0x80)] private uint Unk80; // Count of something
}
