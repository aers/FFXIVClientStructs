using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonWKSReward
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("WKSReward")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C0)]
public unsafe partial struct AddonWKSReward {
    [FieldOffset(0x238)] private AtkResNode* Unk238;
    [FieldOffset(0x248)] private AtkTextNode* Unk248;
}
