using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::HwdManager
// Manager for Firmament (Ishgardian Restoration)
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct HwdManager {
    [StaticAddress("48 8B 05 ?? ?? ?? ?? 48 8B 4C 24 ?? 0F B6 50 11", 3, isPointer: true)]
    public static partial HwdManager* Instance();

    [FieldOffset(0x11)] public byte DevelopmentLevel;
    [FieldOffset(0x12)] public ushort TerritoryTypeId;

    [FieldOffset(0x40)] public HwdDevEventHandler* HwdDevEventHandler;
}
