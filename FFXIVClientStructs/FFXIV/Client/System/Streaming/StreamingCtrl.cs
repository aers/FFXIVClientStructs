namespace FFXIVClientStructs.FFXIV.Client.System.Streaming;

// Client::System::Streaming::StreamingCtrl
//   Client::System::Streaming::IStreamingCtrl
//   Client::System::Streaming::StreamingNotifier
//     Client::Graphics::Kernel::Notifier
//       Client::Graphics::Kernel::NotifierBase
/// <summary> Owned by <see cref="StreamingPlayer"/>. </summary>
[GenerateInterop]
[Inherits<IStreamingCtrl>, Inherits<StreamingNotifier>(parentOffset: 0x08)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public partial struct StreamingCtrl;
