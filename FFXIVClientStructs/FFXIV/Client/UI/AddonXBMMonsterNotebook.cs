using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonXBMMonsterNotebook
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("XBMMonsterNotebook")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x880)]
public partial struct AddonXBMMonsterNotebook {
    [FieldOffset(0x6E8)] public TabController TabController;
}
