namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::AreaInstance
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct AreaInstance {
    [FieldOffset(0x10)] public void* vtbl;
    [FieldOffset(0x20)] public int Instance; // TODO: rename, so we can add Instance()

    // "E8 ?? ?? ?? ?? 3C 01 75 0C 48 8D 0D"
    // but is a sig really worth it for this...
    public bool IsInstancedArea() => Instance != 0;
}
