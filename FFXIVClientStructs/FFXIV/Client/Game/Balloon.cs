using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.Game;

public enum BalloonType : uint
{
    Timer = 0, // runs on a simple timer and disappears when the timer ends
    Unknown = 1 // the non-timer mode, not sure what its called or where its used
}

public enum BalloonState : uint
{
    Waiting = 0,
    Active = 1,
    Closing = 2,
    Inactive = 3
}

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public struct Balloon
{
    [FieldOffset(0x0)] public ushort DefaultBalloonId; // from Balloon exd
    [FieldOffset(0x2)] public ushort NowPlayingBalloonId; // 0 unless active
    [FieldOffset(0x4)] public float PlayTimer; // 0 unless active
    [FieldOffset(0x8)] public BalloonType Type;
    [FieldOffset(0xC)] public BalloonState State;
    [FieldOffset(0x10)] public Utf8String Text; // this is "emptied" (first character set to null) when inactive
    [FieldOffset(0x78)] public byte UnkBool;
}