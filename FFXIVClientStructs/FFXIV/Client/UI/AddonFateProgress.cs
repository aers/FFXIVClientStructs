using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("FateProgress")]
[StructLayout(LayoutKind.Explicit, Size = 0x2B8)]
public unsafe partial struct AddonFateProgress {
    [FieldOffset(0)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x230)] public byte TabCount;
    [FieldOffset(0x231)] public byte TabIndex;
    [FieldOffset(0x232)] public bool Loaded;

    [MemberFunction("83 FA 01 0F 87 ?? ?? ?? ?? 48 89 5C 24 ?? 48 89 6C 24")]
    public partial void SetTab(int tab, AtkEvent* atkEvent);
}
