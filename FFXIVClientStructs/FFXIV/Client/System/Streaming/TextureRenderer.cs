namespace FFXIVClientStructs.FFXIV.Client.System.Streaming;

// Client::System::Streaming::TextureRenderer
//   CBaseVideoRenderer
//   Client::System::Streaming::StreamingNotifier
//     Client::Graphics::Kernel::Notifier
//       Client::Graphics::Kernel::NotifierBase
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x360)]
public partial struct TextureRenderer {
    [FieldOffset(0x1E0)] public StreamingNotifier Notifier;
}
