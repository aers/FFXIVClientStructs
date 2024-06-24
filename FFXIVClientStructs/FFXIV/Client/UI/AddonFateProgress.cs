using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFateProgress
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FateProgress")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonFateProgress {
    [FieldOffset(0x230)] public byte TabCount;
    [FieldOffset(0x231)] public byte TabIndex;
    [FieldOffset(0x232)] public bool Loaded;

    [MemberFunction("83 FA 02 0F 87 ?? ?? ?? ?? 48 89 5C 24 ??")]
    public partial void SetTab(int tab, AtkEvent* atkEvent);
}
