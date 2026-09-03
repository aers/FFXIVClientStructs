using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Revive
//   Component::GUI::AtkModuleInterface::AtkEventInterface
[GenerateInterop]
[Inherits<AtkModuleInterface.AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public partial struct Revive {
    [FieldOffset(0x10)] public ReviveState State;
    [FieldOffset(0x14)] public float Timer;
    [FieldOffset(0x18)] private float Unk18;
    [FieldOffset(0x1C)] private float Unk1C;
    [FieldOffset(0x20)] public int FeastMedalsPrevious; // Used as lnum1 in Addon#5409
    [FieldOffset(0x24)] public int FeastMedalsCurrent; // Used as lnum2 in Addon#5409
    [FieldOffset(0x24), Obsolete("Use State")] public byte ReviveState;
}

public enum ReviveState {
    Alive = 0, // or at least not dead
    Dying = 1,
    Revivable = 2,
    Reviving = 3,
}
