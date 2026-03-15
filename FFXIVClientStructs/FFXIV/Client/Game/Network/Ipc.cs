namespace FFXIVClientStructs.FFXIV.Client.Game.Network;

// https://github.com/redstrate/Kawari/blob/f8c098b/core/src/packet/ipc.rs#L79
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public partial struct ServerIpcSegmentHeader {
    [FieldOffset(0x00)] public ushort Magic; // 0x14
    [FieldOffset(0x02)] public ushort OpCode;

    [FieldOffset(0x08)] public ushort ServerId;

    [FieldOffset(0x0C)] public int Timestamp;
}
