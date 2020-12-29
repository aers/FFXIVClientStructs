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
        [FieldOffset(0x2A8)] public AtkComponentBase* UnkCompBase2A8;
        [FieldOffset(0x2B0)] public AtkComponentBase* UnkCompBase2B0;
        [FieldOffset(0x2B8)] public AtkComponentBase* UnkCompBase2B8;
        [FieldOffset(0x2C0)] public AtkComponentBase* UnkCompBase2C0;
        [FieldOffset(0x2C8)] public AtkComponentBase* UnkCompBase2C8;
        [FieldOffset(0x2D0)] public AtkComponentBase* UnkCompBase2D0;
        [FieldOffset(0x2D8)] public AtkComponentBase* UnkCompBase2D8;
        [FieldOffset(0x2E0)] public AtkComponentBase* UnkCompBase2E0;
        [FieldOffset(0x2E8)] public AtkComponentBase* UnkCompBase2E8;
        [FieldOffset(0x2F0)] public AtkResNode* UnkResNode2F0;
        [FieldOffset(0x2F8)] public AtkResNode* UnkResNode2F8;
        [FieldOffset(0x300)] public AtkResNode* UnkResNode300;
        [FieldOffset(0x308)] public AtkComponentBase* UnkCompBase308;
        [FieldOffset(0x310)] public AtkComponentBase* UnkCompBase310;
        [FieldOffset(0x318)] public AtkComponentBase* UnkCompBase318;
        [FieldOffset(0x320)] public AtkComponentButton* UnkCompButton320;
        [FieldOffset(0x328)] public AtkTextNode* UnkTextNode328;
        [FieldOffset(0x330)] public AtkComponentBase* UnkCompBase330;
        [FieldOffset(0x338)] public AtkComponentBase* UnkCompBase338;
        [FieldOffset(0x340)] public AtkComponentBase* UnkCompBase340;
        [FieldOffset(0x348)] public AtkComponentBase* UnkCompBase348;
        [FieldOffset(0x350)] public AtkComponentBase* UnkCompBase350;
        [FieldOffset(0x358)] public AtkComponentBase* UnkCompBase358;
        [FieldOffset(0x360)] public AtkComponentBase* UnkCompBase360;
        [FieldOffset(0x368)] public AtkComponentBase* UnkCompBase368;
        [FieldOffset(0x370)] public AtkComponentBase* UnkCompBase370;
        [FieldOffset(0x378)] public AtkComponentBase* UnkCompBase378;
        [FieldOffset(0x380)] public AtkComponentBase* UnkCompBase380;
        [FieldOffset(0x388)] public AtkComponentBase* UnkCompBase388;
        [FieldOffset(0x390)] public AtkComponentBase* UnkCompBase390;
        [FieldOffset(0x398)] public AtkComponentBase* UnkCompBase398;
        [FieldOffset(0x3A0)] public AtkComponentBase* UnkCompBase3A0;
        [FieldOffset(0x3A8)] public AtkComponentBase* UnkCompBase3A8;
        [FieldOffset(0x3B0)] public AtkComponentBase* UnkCompBase3B0;
        [FieldOffset(0x3B8)] public AtkComponentBase* UnkCompBase3B8;
        [FieldOffset(0x3C0)] public AtkComponentBase* UnkCompBase3C0;
        [FieldOffset(0x3C8)] public AtkImageNode* UnkImageNode3C8;
        [FieldOffset(0x3D0)] public int UnkNumber3D0;
        [FieldOffset(0x3D4)] public int UnkNumber3D4;
        [FieldOffset(0x3D8)] public int GameplayTileUpperLeftNumber;
        [FieldOffset(0x3DC)] public int GameplayTileUpperMiddleNumber;
        [FieldOffset(0x3E0)] public int GameplayTileUpperRightNumber;
        [FieldOffset(0x3E4)] public int GameplayTileMiddleLeftNumber;
        [FieldOffset(0x3E8)] public int GameplayTileCenterNumber;
        [FieldOffset(0x3EC)] public int GameplayTileMiddleRightNumber;
        [FieldOffset(0x3F0)] public int GameplayTileLowerLeftNumber;
        [FieldOffset(0x3F4)] public int GameplayTileLowerMiddleNumber;
        [FieldOffset(0x3F8)] public int GameplayTileLowerRightNumber;
        [FieldOffset(0x3FC)] public int UnkNumber3FC;
        [FieldOffset(0x400)] public int UnkNumber400;
        [FieldOffset(0x404)] public int UnkNumber404;
    }
}
