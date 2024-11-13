using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCutSceneSelectString
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("CutSceneSelectString")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonCutSceneSelectString {
    [FieldOffset(0x248)] public AtkComponentList* OptionList;
    [FieldOffset(0x250)] public AtkComponentTextNineGrid* TextLabel;
}
