using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonXBMMonsterNotebook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("XBMMonsterNotebook")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x8A0)]
public partial struct AddonXBMMonsterNotebook {
    [FieldOffset(0x708)] public TabController TabController;
}
