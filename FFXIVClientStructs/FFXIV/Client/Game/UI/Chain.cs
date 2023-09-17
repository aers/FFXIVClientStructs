namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct Chain {
    [FieldOffset(0x00)] public float RemainingTime;
    [FieldOffset(0x04)] public float MaxTime;
}
