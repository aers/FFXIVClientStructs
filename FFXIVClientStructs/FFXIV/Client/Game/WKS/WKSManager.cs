using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.WKS;

// Client::Game::WKS::WKSManager
//   Client::Game::Character::CharacterManagerInterface
// Manager for Cosmic Exploration
[GenerateInterop]
[Inherits<CharacterManagerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xE20)]
public unsafe partial struct WKSManager {
    [StaticAddress("48 8B 7C 24 ?? 48 89 35 ?? ?? ?? ??", 8, isPointer: true)]
    public static partial WKSManager* Instance();

    [FieldOffset(0x18)] public ushort TerritoryId;

    [FieldOffset(0x4A)] public ushort DevGrade;

    [FieldOffset(0xDB0)] private void* UnkStructDB0; // size: 0x3A8
    [FieldOffset(0xDB8)] private void* UnkStructDB8; // size: 0x1D0
    [FieldOffset(0xDC0)] private void* UnkStructDC0; // size: 0xA110
    [FieldOffset(0xDC8)] private void* UnkStructDC8; // size: 0x10
    [FieldOffset(0xDD0)] private void* UnkStructDD0; // size: 0x90
    [FieldOffset(0xDD8)] private void* UnkStructDD8; // size: 0x2D8
    [FieldOffset(0xDE0)] private void* UnkStructDE0; // size: 0x198
    [FieldOffset(0xDE8)] private void* UnkStructDE8; // size: 0x328
    [FieldOffset(0xDF0)] private void* UnkStructDF0; // size: 0x18
    [FieldOffset(0xDF8)] public WKSResearch* Research;
    [FieldOffset(0xE00)] private void* UnkStructE00; // size: 0x40

    [FieldOffset(0xE08)] public StdVector<Pointer<WKSModuleBase>> Modules;
}
