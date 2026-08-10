namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::EventNpcLayoutInstance
//   Client::LayoutEngine::Layer::CharacterLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<CharacterLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public partial struct EventNpcLayoutInstance {
    [FieldOffset(0x80)] private bool Unk80;
    [FieldOffset(0x81)] private bool Unk81;
    [FieldOffset(0x82)] private bool Unk82;
}
