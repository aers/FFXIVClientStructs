using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::PublicInstance
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public struct PublicInstance {
    [FieldOffset(0x10)] public Listener EventListener;
    [FieldOffset(0x20)] public int InstanceId;

    public bool IsInstancedArea() => InstanceId != 0;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Listener {
        [FieldOffset(0x00)] public AtkEventInterface AtkEventInterface;
    }
}
