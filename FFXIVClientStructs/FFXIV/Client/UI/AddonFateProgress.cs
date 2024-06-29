using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFateProgress
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("FateProgress")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public unsafe partial struct AddonFateProgress {
    [FieldOffset(0x230), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentRadioButton>> _tabs;
    [FieldOffset(0x248)] public byte TabCount;
    [FieldOffset(0x249)] public byte TabIndex;
    [FieldOffset(0x24A)] public bool IsLoaded;

    [MemberFunction("83 FA 02 0F 87 ?? ?? ?? ?? 48 89 5C 24 ??")]
    public partial void SetTab(int tab, AtkEvent* atkEvent);
}
