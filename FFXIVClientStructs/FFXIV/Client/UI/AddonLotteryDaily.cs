using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonLotteryDaily
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[StructLayout(LayoutKind.Explicit, Size = 0x408)]
public unsafe struct AddonLotteryDaily
{
    [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public GameTileBoard GameBoard;
    [FieldOffset(0x268)] public LaneTileSelector LaneSelector;
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
    [FieldOffset(0x3D8)] public GameBoardNumbers GameNumbers;
    [FieldOffset(0x3FC)] public int UnkNumber3FC;
    [FieldOffset(0x400)] public int UnkNumber400;
    [FieldOffset(0x404)] public int UnkNumber404;

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct GameTileRow
    {
        [FieldOffset(0x0)] public AtkComponentCheckBox* Col1;
        [FieldOffset(0x8)] public AtkComponentCheckBox* Col2;
        [FieldOffset(0x10)] public AtkComponentCheckBox* Col3;

        public AtkComponentCheckBox* this[int index] => index switch
        {
            0 => Col1,
            1 => Col2,
            2 => Col3,
            _ => throw new ArgumentOutOfRangeException("Valid indexes are 0 through 2 inclusive.")
        };
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public struct GameTileBoard
    {
        [FieldOffset(0x0)] public GameTileRow Row1;
        [FieldOffset(0x18)] public GameTileRow Row2;
        [FieldOffset(0x30)] public GameTileRow Row3;

        public AtkComponentCheckBox* this[int index] => (index / 3) switch
        {
            0 => Row1[index % 3],
            1 => Row2[index % 3],
            2 => Row3[index % 3],
            _ => throw new ArgumentOutOfRangeException("Valid indexes are 0 through 8 inclusive.")
        };
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct LaneTileSelector
    {
        [FieldOffset(0x0)] public AtkComponentRadioButton* MajorDiagonal;
        [FieldOffset(0x8)] public AtkComponentRadioButton* Col1;
        [FieldOffset(0x10)] public AtkComponentRadioButton* Col2;
        [FieldOffset(0x18)] public AtkComponentRadioButton* Col3;
        [FieldOffset(0x20)] public AtkComponentRadioButton* MinorDiagonal;
        [FieldOffset(0x28)] public AtkComponentRadioButton* Row1;
        [FieldOffset(0x30)] public AtkComponentRadioButton* Row2;
        [FieldOffset(0x38)] public AtkComponentRadioButton* Row3;

        public AtkComponentRadioButton* this[int index] => index switch
        {
            0 => MajorDiagonal,
            1 => Col1,
            2 => Col2,
            3 => Col3,
            4 => MinorDiagonal,
            5 => Row1,
            6 => Row2,
            7 => Row3,
            _ => throw new ArgumentOutOfRangeException("Valid indexes are 0 through 8 inclusive.")
        };
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct GameNumberRow
    {
        [FieldOffset(0x0)] public int Col1;
        [FieldOffset(0x4)] public int Col2;
        [FieldOffset(0x8)] public int Col3;

        public int this[int index] => index switch
        {
            0 => Col1,
            1 => Col2,
            2 => Col3,
            _ => throw new ArgumentOutOfRangeException("Valid indexes are 0 through 8 inclusive.")
        };
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x24)]
    public struct GameBoardNumbers
    {
        [FieldOffset(0x0)] public GameNumberRow Row1;
        [FieldOffset(0xC)] public GameNumberRow Row2;
        [FieldOffset(0x18)] public GameNumberRow Row3;

        public int this[int index] => (index / 3) switch
        {
            0 => Row1[index % 3],
            1 => Row2[index % 3],
            2 => Row3[index % 3],
            _ => throw new ArgumentOutOfRangeException("Valid indexes are 0 through 8 inclusive.")
        };
    }
}