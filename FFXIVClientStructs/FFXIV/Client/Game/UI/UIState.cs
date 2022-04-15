using FFXIVClientStructs.FFXIV.Client.Game.Event;
using FFXIVClientStructs.FFXIV.Client.Game.Fate;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;
// this is a large object holding most of the other objects in the Client::Game::UI namespace
// all data in here is used for UI display

// ctor E8 ? ? ? ? 48 8D 0D ? ? ? ? 48 83 C4 28 E9 ? ? ? ? 48 83 EC 28 33 D2 
[StructLayout(LayoutKind.Explicit, Size = 0x168D8)] // its at least this big, may be a few bytes bigger
public unsafe partial struct UIState
{
    [FieldOffset(0x00)] public Hotbar Hotbar;
    [FieldOffset(0x08)] public Hate Hate;
    [FieldOffset(0x110)] public Hater Hater;
    [FieldOffset(0xA18)] public WeaponState WeaponState;
    [FieldOffset(0xA38)] public PlayerState PlayerState;
    [FieldOffset(0x11C8)] public Revive Revive;
    [FieldOffset(0x1498)] public Telepo Telepo;
    [FieldOffset(0x1A60)] public Buddy Buddy;
    [FieldOffset(0x2A70)] public RelicNote RelicNote;

    [FieldOffset(0xA6C0)] public Director* ActiveDirector;
    [FieldOffset(0xA808)] public FateDirector* FateDirector;
    [FieldOffset(0xA950)] public Map Map;

    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B 8B ?? ?? ?? ?? 48 8B 01")]
    public static partial UIState* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 88 45 80")]
    public partial bool IsUnlockLinkUnlocked(uint unlockLink);
}