using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonContentsFinderConfirm
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ContentsFinderConfirm")]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 89 03 41 b0 01 48 89 8b 20 02 00 00 33 c0 48 89 8b 28 02 00 00 ba 00 00 00 01", 3)]
public unsafe partial struct AddonContentsFinderConfirm {
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x228)] public AtkTextNode* AtkTextNode228;
    [FieldOffset(0x230)] public AtkTextNode* AtkTextNode230; // duty title
    [FieldOffset(0x238)] public AtkTextNode* AtkTextNode238;
    [FieldOffset(0x240)] public AtkTextNode* AtkTextNode240;
    [FieldOffset(0x248)] public AtkTextNode* AtkTextNode248;

    [FieldOffset(0x288)] public AtkComponentButton* CommenceButton;
    [FieldOffset(0x290)] public AtkComponentButton* WithdrawButton;
    [FieldOffset(0x298)] public AtkComponentButton* WaitButton;
}
