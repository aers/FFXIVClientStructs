using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::PublicInstance
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct PublicInstance {
    [FieldOffset(0x0)] public uint AddonId; // id of SelectString addon that shows "To reduce congestion, the area you are about to enter has been divided into multiple identical instances. Select a destination."
    [FieldOffset(0x4)] public float CloseCountdown; // starts at 60 seconds
    [FieldOffset(0x8)] public uint TerritoryTypeId; // used for the territory name in the selections

    [FieldOffset(0x10)] public Listener EventListener; // handles the players selection
    [FieldOffset(0x20)] public uint InstanceId;

    public bool IsInstancedArea() => InstanceId != 0;

    [GenerateInterop]
    [Inherits<AtkEventInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct Listener;
}
