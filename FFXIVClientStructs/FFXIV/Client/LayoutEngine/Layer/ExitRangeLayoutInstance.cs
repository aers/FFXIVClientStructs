namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::ExitRangeLayoutInstance
//   Client::LayoutEngine::Layer::TriggerBoxLayoutInstance
//     Client::LayoutEngine::ILayoutInstance
//       Client::System::Common::NonCopyable
[GenerateInterop]
[Inherits<TriggerBoxLayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public partial struct ExitRangeLayoutInstance {
    [FieldOffset(0x80)] public ExitRangeType ExitType;
    [FieldOffset(0x84)] public ushort ZoneId;
    [FieldOffset(0x86)] public ushort TerritoryType;
    [FieldOffset(0x88)] public int Index;
    [FieldOffset(0x8C)] public uint DestInstanceId;
    [FieldOffset(0x90)] public uint ReturnInstanceId;
    [FieldOffset(0x94)] public float PlayerRunningDirection;
    [FieldOffset(0x98)] private uint UnkInstanceId;
    [FieldOffset(0x9C)] private ushort Unk9C;
}

public enum ExitRangeType {
    ZoneLine = 1,
    Invisible = 2, // used for doors etc.
}
