using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonActionDetail
//   Client::UI::AddonActionDetailBase
[Addon("ActionDetail")]
[GenerateInterop]
[Inherits<AddonActionDetailBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x360)]
public unsafe partial struct AddonActionDetail {
    // Types recovered from AddonActionDetail.ctor's Get*NodeById calls and GenerateTooltip; their UI roles are still unknown.
    [FieldOffset(0x250)] private AtkResNode* Unk250;
    [FieldOffset(0x258)] private AtkResNode* Unk258;
    [FieldOffset(0x260)] private AtkComponentIcon* Unk260;
    [FieldOffset(0x268)] private AtkResNode* Unk268;
    [FieldOffset(0x270)] private AtkTextNode* Unk270;
    [FieldOffset(0x278)] private AtkTextNode* Unk278;
    [FieldOffset(0x280)] private AtkTextNode* Unk280;
    [FieldOffset(0x288)] private AtkTextNode* Unk288;
    [FieldOffset(0x290)] private AtkTextNode* Unk290;
    [FieldOffset(0x298)] private AtkTextNode* Unk298;
    [FieldOffset(0x2A0)] private AtkTextNode* Unk2A0;
    [FieldOffset(0x2A8)] private AtkTextNode* Unk2A8;
    [FieldOffset(0x2B0)] private AtkTextNode* Unk2B0;
    [FieldOffset(0x2B8)] private AtkTextNode* Unk2B8;
    [FieldOffset(0x2C0)] private AtkTextNode* Unk2C0;
    [FieldOffset(0x2C8)] private AtkTextNode* Unk2C8;
    [FieldOffset(0x2D0)] private AtkResNode* Unk2D0;
    [FieldOffset(0x2D8)] private AtkResNode* Unk2D8;
    [FieldOffset(0x2E0)] private AtkResNode* Unk2E0;
    [FieldOffset(0x2E8)] private AtkResNode* Unk2E8;
    [FieldOffset(0x2F0)] private AtkResNode* Unk2F0;
    [FieldOffset(0x2F8)] private AtkResNode* Unk2F8;
    [FieldOffset(0x300)] private AtkResNode* Unk300;
    [FieldOffset(0x308)] private AtkImageNode* Unk308;
    [FieldOffset(0x310)] private AtkImageNode* Unk310;
    [FieldOffset(0x318)] private AtkImageNode* Unk318;
    [FieldOffset(0x320)] private AtkTextNode* Unk320;
    [FieldOffset(0x328)] private AtkTextNode* Unk328;
    [FieldOffset(0x330)] private AtkResNode* Unk330;
    [FieldOffset(0x338)] private AtkTextNode* Unk338;
    [FieldOffset(0x340)] private AtkTextNode* Unk340;
    [FieldOffset(0x348)] private AtkResNode* Unk348;
    [FieldOffset(0x350)] private AtkTextNode* Unk350;
    [FieldOffset(0x358)] private AtkResNode* Unk358;

    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 83 EC 40 48 8B 42 28 4C 8B FA 48 8B F1 49 8B E8")]
    public partial void GenerateTooltip(NumberArrayData* numberArray, StringArrayData* stringArray);
}
