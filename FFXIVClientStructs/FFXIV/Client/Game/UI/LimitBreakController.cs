namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::LimitBreakController
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct LimitBreakController {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 85 C0 74 1C", 3)]
    public static partial LimitBreakController* Instance();

    [FieldOffset(0x08)] public byte BarCount;
    [FieldOffset(0x0A)] public ushort CurrentValue;
    [FieldOffset(0x0C)] public uint BarValue;
}
