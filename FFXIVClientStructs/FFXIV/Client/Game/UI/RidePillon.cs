namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::RidePillon
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
[GenerateInterop]
public unsafe partial struct RidePillon {
    [FieldOffset(0)] public uint Unk0;
    [FieldOffset(0x04), FixedSizeArray] internal FixedSizeArray7<uint> _unk4; // ObjectIds
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray7<uint> _unk20; // ObjectIds
}
