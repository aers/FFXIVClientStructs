using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("FlyText")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 89 07 48 89 AF", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x2E50)]
public unsafe partial struct AddonFlyText {
    [MemberFunction("E8 ?? ?? ?? ?? FF C7 41 D1 C7")]
    public partial nint AddFlyText(uint actorIndex, uint messageMax, NumberArrayData* numberArrayData,
        uint offsetNum, uint offsetNumMax, StringArrayData* stringArrayData, uint offsetStr,
        uint offsetStrMax, int unknown);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B 18")]
    public partial nint CreateFlyText(int kind, int val1, int val2, byte* text2,
        uint color, uint icon, uint damageTypeIcon, byte* text1,
        float yOffset);
}
