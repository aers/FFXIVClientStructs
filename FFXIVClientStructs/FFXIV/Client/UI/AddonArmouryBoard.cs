using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonArmouryBoard
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("ArmouryBoard")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x6C0)]
public partial struct AddonArmouryBoard {
    [FieldOffset(0x690)] public int TabIndex;

    [MemberFunction("40 53 48 83 EC 20 80 B9 ?? ?? ?? ?? ?? 48 8B D9 75 10")]
    public partial void NextTab(byte a2); // 7.0: inlined

    [MemberFunction("40 53 48 83 EC 20 80 B9 ?? ?? ?? ?? ?? 48 8B D9 0F 85 ?? ?? ?? ?? 8B 81")]
    public partial void PreviousTab(byte a2); // 7.0: inlined
}
