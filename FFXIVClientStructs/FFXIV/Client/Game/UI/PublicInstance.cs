using FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::PublicInstance
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct PublicInstance {
    [FieldOffset(0x10)] public Listener EventListener;
    [FieldOffset(0x20)] public int InstanceId;

    public bool IsInstancedArea() => InstanceId != 0;

    [GenerateInterop]
[Inherits<AtkEventInterface>]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct Listener;
}
