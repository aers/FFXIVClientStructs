namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::RidePillon
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct RidePillon {
    [FieldOffset(0)] public uint Unk0;
    [FieldOffset(0x04)] public fixed uint Unk4[7]; // ObjectIDs
    [FieldOffset(0x20)] public fixed uint Unk20[7]; // ObjectIDs
}
