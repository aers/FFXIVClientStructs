namespace FFXIVClientStructs.FFXIV.Client.System.Streaming;

// Client::System::Streaming::StreamingPlayer
//   Client::System::Framework::Task
/// <summary> Created on first use and added to the framework's task manager. </summary>
[GenerateInterop]
[Inherits<Client.System.Framework.Task>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct StreamingPlayer {
    [StaticAddress("48 89 1D ?? ?? ?? ?? BA 02", 3, isPointer: true)]
    public static partial StreamingPlayer* Instance();

    [FieldOffset(0x38)] public StreamingCtrl* Ctrl;
}
