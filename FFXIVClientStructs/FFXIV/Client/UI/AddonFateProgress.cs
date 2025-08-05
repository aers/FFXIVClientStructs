using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFateProgress
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FateProgress")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E8)]
public unsafe partial struct AddonFateProgress {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _tabs;
    [FieldOffset(0x250)] public byte TabCount;
    [FieldOffset(0x251)] public byte TabIndex;
    [FieldOffset(0x252)] public bool IsLoaded;

    [MemberFunction("E9 ?? ?? ?? ?? 41 83 FA ?? 0F 85 ?? ?? ?? ?? E8")]
    public partial void SetTab(int tab, AtkEvent* atkEvent);
}
