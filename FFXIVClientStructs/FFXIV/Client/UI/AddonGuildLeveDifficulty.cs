using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGuildLeveDifficulty
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GuildLeveDifficulty")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonGuildLeveDifficulty {
    [FieldOffset(0x238)] public AtkComponentSlider* DifficultySlider;
    [FieldOffset(0x240)] public AtkTextNode* DifficultyText;
}
