using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::PublicInstance
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct PublicInstance {
    [FieldOffset(0x0)] public uint AddonId; // id of SelectString addon that shows "To reduce congestion, the area you are about to enter has been divided into multiple identical instances. Select a destination."
    [FieldOffset(0x4)] public float CloseCountdown; // starts at 60 seconds
    [FieldOffset(0x8)] public uint TerritoryTypeId; // used for the territory name in the selections

    [FieldOffset(0x10)] public Listener EventListener; // handles the players selection
    [FieldOffset(0x20)] public uint InstanceId;

    public bool IsInstancedArea() => InstanceId != 0;

    [MemberFunction("4D 85 C9 0F 84 ?? ?? ?? ?? 89 54 24")]
    public partial byte ShowInstanceSelection(uint territoryType, uint instanceCount, uint* instancePlayerCounts, uint instancePlayerCountsLength);

    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 ?? 83 3B ?? 74 ?? 48 8B 10 48 8B C8 FF 52 ?? 8B 13 48 8B C8 4C 8B 00 41 FF 90")]
    public partial void CloseInstanceSelection();

    [GenerateInterop]
    [Inherits<AtkEventInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct Listener;
}
