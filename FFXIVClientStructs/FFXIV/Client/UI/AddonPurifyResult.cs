using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonPurifyResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("PurifyResult")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public unsafe partial struct AddonPurifyResult {
    [FieldOffset(0x238)] public AtkComponentButton* AutomaticButton;
    [FieldOffset(0x240)] public short ScaledWidth;
    [FieldOffset(0x242)] public short ScaledHeight;
}
