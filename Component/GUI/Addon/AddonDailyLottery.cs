using System;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.Component.GUI.Addon
{
    // Component::GUI::AddonDailyLottery
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x408)]
    public unsafe struct AddonDailyLottery
    {
        // There are likely several fixed arrays in here
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x220)] public AtkComponentCheckBox* GameplayTileUpperLeft;
        [FieldOffset(0x228)] public AtkComponentCheckBox* GameplayTileUpperMiddle;
        [FieldOffset(0x230)] public AtkComponentCheckBox* GameplayTileUpperRight;
        [FieldOffset(0x238)] public AtkComponentCheckBox* GameplayTileMiddleLeft;
        [FieldOffset(0x240)] public AtkComponentCheckBox* GameplayTileCenter;
        [FieldOffset(0x248)] public AtkComponentCheckBox* GameplayTileMiddleRight;
        [FieldOffset(0x250)] public AtkComponentCheckBox* GameplayTileLowerLeft;
        [FieldOffset(0x258)] public AtkComponentCheckBox* GameplayTileLowerMiddle;
        [FieldOffset(0x260)] public AtkComponentCheckBox* GameplayTileLowerRight;
        [FieldOffset(0x268)] public AtkComponentRadioButton* LaneSelectorMajorDiagonal;
        [FieldOffset(0x270)] public AtkComponentRadioButton* LaneSelectorLeftColumn;
        [FieldOffset(0x278)] public AtkComponentRadioButton* LaneSelectorCenterColumn;
        [FieldOffset(0x280)] public AtkComponentRadioButton* LaneSelectorRightColumn;
        [FieldOffset(0x288)] public AtkComponentRadioButton* LaneSelectorMinorDiagonal;
        [FieldOffset(0x290)] public AtkComponentRadioButton* LaneSelectorTopRow;
        [FieldOffset(0x298)] public AtkComponentRadioButton* LaneSelectorCenterRow;
        [FieldOffset(0x2A0)] public AtkComponentRadioButton* LaneSelectorBottomRow;
        [FieldOffset(0x2A8)] public AtkComponentBase* UnkCompBase1;
        [FieldOffset(0x2B0)] public AtkComponentBase* UnkCompBase2;
        [FieldOffset(0x2B8)] public AtkComponentBase* UnkCompBase3;
        [FieldOffset(0x2C0)] public AtkComponentBase* UnkCompBase4;
        [FieldOffset(0x2C8)] public AtkComponentBase* UnkCompBase5;
        [FieldOffset(0x2D0)] public AtkComponentBase* UnkCompBase6;
        [FieldOffset(0x2D8)] public AtkComponentBase* UnkCompBase7;
        [FieldOffset(0x2E0)] public AtkComponentBase* UnkCompBase8;
        [FieldOffset(0x2E8)] public AtkComponentBase* UnkCompBase9;
        [FieldOffset(0x2F0)] public AtkResNode* UnkResNode1;
        [FieldOffset(0x2F8)] public AtkResNode* UnkResNode2;
        [FieldOffset(0x300)] public AtkResNode* UnkResNode3;
        [FieldOffset(0x308)] public AtkComponentBase* UnkCompBase10;
        [FieldOffset(0x310)] public AtkComponentBase* UnkCompBase11;
        [FieldOffset(0x318)] public AtkComponentBase* UnkCompBase12;
        [FieldOffset(0x320)] public AtkComponentButton* UnkCompButton1;
        [FieldOffset(0x328)] public AtkTextNode* UnkTextNode1;
        [FieldOffset(0x330)] public AtkComponentBase* UnkCompBase13;
        [FieldOffset(0x338)] public AtkComponentBase* UnkCompBase14;
        [FieldOffset(0x340)] public AtkComponentBase* UnkCompBase15;
        [FieldOffset(0x348)] public AtkComponentBase* UnkCompBase16;
        [FieldOffset(0x350)] public AtkComponentBase* UnkCompBase17;
        [FieldOffset(0x358)] public AtkComponentBase* UnkCompBase18;
        [FieldOffset(0x360)] public AtkComponentBase* UnkCompBase19;
        [FieldOffset(0x368)] public AtkComponentBase* UnkCompBase20;
        [FieldOffset(0x370)] public AtkComponentBase* UnkCompBase21;
        [FieldOffset(0x378)] public AtkComponentBase* UnkCompBase22;
        [FieldOffset(0x380)] public AtkComponentBase* UnkCompBase23;
        [FieldOffset(0x388)] public AtkComponentBase* UnkCompBase24;
        [FieldOffset(0x390)] public AtkComponentBase* UnkCompBase25;
        [FieldOffset(0x398)] public AtkComponentBase* UnkCompBase26;
        [FieldOffset(0x3A0)] public AtkComponentBase* UnkCompBase27;
        [FieldOffset(0x3A8)] public AtkComponentBase* UnkCompBase28;
        [FieldOffset(0x3B0)] public AtkComponentBase* UnkCompBase29;
        [FieldOffset(0x3B8)] public AtkComponentBase* UnkCompBase30;
        [FieldOffset(0x3C0)] public AtkComponentBase* UnkCompBase31;
        [FieldOffset(0x3C8)] public AtkImageNode* UnkImageNode1;
        [FieldOffset(0x3D0)] public int UnkNumber1;
        [FieldOffset(0x3D4)] public int UnkNumber2;
        [FieldOffset(0x3D8)] public int GameplayTileUpperLeftNumber;
        [FieldOffset(0x3DC)] public int GameplayTileUpperMiddleNumber;
        [FieldOffset(0x3E0)] public int GameplayTileUpperRightNumber;
        [FieldOffset(0x3E4)] public int GameplayTileMiddleLeftNumber;
        [FieldOffset(0x3E8)] public int GameplayTileCenterNumber;
        [FieldOffset(0x3EC)] public int GameplayTileMiddleRightNumber;
        [FieldOffset(0x3F0)] public int GameplayTileLowerLeftNumber;
        [FieldOffset(0x3F4)] public int GameplayTileLowerMiddleNumber;
        [FieldOffset(0x3F8)] public int GameplayTileLowerRightNumber;
        [FieldOffset(0x3FC)] public int UnkNumber3;
        [FieldOffset(0x400)] public int UnkNumber4;
        [FieldOffset(0x404)] public int UnkNumber5;
    }
}
