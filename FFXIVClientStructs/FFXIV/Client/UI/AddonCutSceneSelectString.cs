using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCutSceneSelectString
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CutSceneSelectString")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonCutSceneSelectString {
    [FieldOffset(0x240)] public AtkComponentList* OptionList;
    [FieldOffset(0x248)] public AtkComponentTextNineGrid* TextLabel;
}
