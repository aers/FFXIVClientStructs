using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMobHunt
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("MobHunt")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x258)]
public unsafe partial struct AddonMobHunt {
    [FieldOffset(0x230)] public AtkComponentButton* NextPageButton;
    [FieldOffset(0x238)] public AtkComponentButton* PreviousPageButton;
    [FieldOffset(0x240)] public AtkComponentButton* OpenMapButton;
    [FieldOffset(0x248)] public int CurrentPage;
}
