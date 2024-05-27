namespace FFXIVClientStructs.FFXIV.Common.Log;

//Component::Log::LogModule
//  Component::Log::LogModuleInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public partial struct LogModule {
    [FieldOffset(0x08)] public ulong LocalPlayerContentId;

    [FieldOffset(0x14)] public int LogMessageCount;

    [FieldOffset(0x48)] public StdVector<int> LogMessageIndex;
    [FieldOffset(0x60)] public StdVector<byte> LogMessageData;
}
