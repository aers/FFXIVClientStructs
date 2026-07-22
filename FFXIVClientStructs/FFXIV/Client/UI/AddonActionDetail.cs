using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonActionDetail
//   Client::UI::AddonActionDetailBase
[Addon("ActionDetail")]
[GenerateInterop]
[Inherits<AddonActionDetailBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x360)]
public unsafe partial struct AddonActionDetail {
    [FieldOffset(0x270)] private AtkTextNode* Unk270;
    [FieldOffset(0x278)] private AtkTextNode* Unk278;
    [FieldOffset(0x280)] private AtkTextNode* Unk280;
    [FieldOffset(0x288)] private AtkTextNode* Unk288;
    [FieldOffset(0x290)] private AtkTextNode* Unk290;
    [FieldOffset(0x298)] private AtkTextNode* Unk298;
    [FieldOffset(0x2F8)] private AtkResNode* Unk2F8;
    [FieldOffset(0x300)] private AtkResNode* Unk300;
    [FieldOffset(0x320)] private AtkTextNode* Unk320;
    [FieldOffset(0x328)] private AtkTextNode* Unk328;
    [FieldOffset(0x330)] private AtkResNode* Unk330;
    [FieldOffset(0x338)] private AtkResNode* Unk338;
    [FieldOffset(0x340)] private AtkResNode* Unk340;
    [FieldOffset(0x350)] private AtkTextNode* Unk350;

    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 83 EC 40 48 8B 42 28 4C 8B FA 48 8B F1 49 8B E8")]
    public partial void GenerateTooltip(NumberArrayData* numberArray, StringArrayData* stringArray);
}
