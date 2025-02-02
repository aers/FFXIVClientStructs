namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::EventItemManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe partial struct EventItemManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 75 E4", 3)]
    public static partial EventItemManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B7 C0 45 33 C9 0F B7 D3")]
    public partial ushort GetTreasureSpotSubKey();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 D0 45 0F B6 CE")]
    public partial uint GetTreasureHuntRank();
}
