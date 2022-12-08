using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_PartyList")]
[StructLayout(LayoutKind.Explicit, Size = 0x13D8)]
public unsafe struct AddonPartyList
{
    [FieldOffset(0x000)] public AtkUnitBase AtkUnitBase;
    [FieldOffset(0x220)] public PartyMembers PartyMember; // 8 PartyListMember
    [FieldOffset(0x9E0)] public TrustMembers TrustMember; // 7 PartyListMember
    [FieldOffset(0x10A8)] public PartyListMemberStruct Chocobo;
    [FieldOffset(0x11A0)] public PartyListMemberStruct Pet;

    [FieldOffset(0x1298)] public fixed uint PartyClassJobIconId[8];
    [FieldOffset(0x12B8)] public fixed uint TrustClassJobIconId[7];
    [FieldOffset(0x12D4)] public uint ChocoboIconId;
    [FieldOffset(0x12D8)] public uint PetIconId;

    [FieldOffset(0x1360)] public fixed short Edited[17]; // 0X11 if edited? Need comfirm

    [FieldOffset(0x1388)] public AtkNineGridNode* BackgroundNineGridNode;
    [FieldOffset(0x1390)] public AtkTextNode* PartyTypeTextNode; // Solo Light/Full Party
    [FieldOffset(0x1398)] public AtkResNode* LeaderMarkResNode;
    [FieldOffset(0x13A0)] public AtkResNode* MpBarSpecialResNode;
    [FieldOffset(0x13A8)] public AtkTextNode* MpBarSpecialTextNode;

    [FieldOffset(0x13B0)] public int MemberCount;
    [FieldOffset(0x13B4)] public int TrustCount;
    [FieldOffset(0x13B8)] public int EnmityLeaderIndex; // Starts from 0 (-1 if no leader)
    [FieldOffset(0x13BC)] public int HideWhenSolo;

    [FieldOffset(0x13C0)] public int HoveredIndex;
    [FieldOffset(0x13C4)] public int TargetedIndex;

    [FieldOffset(0x13C8)] public int Unknown1410;
    [FieldOffset(0x13CC)] public int Unknown1414;
    [FieldOffset(0x13D0)] public byte Unknown1418;

    [FieldOffset(0x13D1)] public byte PetCount; // or PetSummoned?
    [FieldOffset(0x13D2)] public byte ChocoboCount; // or ChocoboSummoned?

    [StructLayout(LayoutKind.Explicit, Size = PartyListMemberStruct.Size * 8)]
    public struct PartyMembers
    {
        [FieldOffset(PartyListMemberStruct.Size * 00)]
        public PartyListMemberStruct PartyMember0;

        [FieldOffset(PartyListMemberStruct.Size * 01)]
        public PartyListMemberStruct PartyMember1;

        [FieldOffset(PartyListMemberStruct.Size * 02)]
        public PartyListMemberStruct PartyMember2;

        [FieldOffset(PartyListMemberStruct.Size * 03)]
        public PartyListMemberStruct PartyMember3;

        [FieldOffset(PartyListMemberStruct.Size * 04)]
        public PartyListMemberStruct PartyMember4;

        [FieldOffset(PartyListMemberStruct.Size * 05)]
        public PartyListMemberStruct PartyMember5;

        [FieldOffset(PartyListMemberStruct.Size * 06)]
        public PartyListMemberStruct PartyMember6;

        [FieldOffset(PartyListMemberStruct.Size * 07)]
        public PartyListMemberStruct PartyMember7;

        public PartyListMemberStruct this[int i]
        {
            get
            {
                return i switch
                {
                    0 => PartyMember0,
                    1 => PartyMember1,
                    2 => PartyMember2,
                    3 => PartyMember3,
                    4 => PartyMember4,
                    5 => PartyMember5,
                    6 => PartyMember6,
                    7 => PartyMember7,
                    _ => throw new IndexOutOfRangeException("Index should be in range of 0-7")
                };
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = PartyListMemberStruct.Size * 7)]
    public struct TrustMembers
    {
        [FieldOffset(PartyListMemberStruct.Size * 00)]
        public PartyListMemberStruct Trust0;

        [FieldOffset(PartyListMemberStruct.Size * 01)]
        public PartyListMemberStruct Trust1;

        [FieldOffset(PartyListMemberStruct.Size * 02)]
        public PartyListMemberStruct Trust2;

        [FieldOffset(PartyListMemberStruct.Size * 03)]
        public PartyListMemberStruct Trust3;

        [FieldOffset(PartyListMemberStruct.Size * 04)]
        public PartyListMemberStruct Trust4;

        [FieldOffset(PartyListMemberStruct.Size * 05)]
        public PartyListMemberStruct Trust5;

        [FieldOffset(PartyListMemberStruct.Size * 06)]
        public PartyListMemberStruct Trust6;

        public PartyListMemberStruct this[int i]
        {
            get
            {
                return i switch
                {
                    0 => Trust0,
                    1 => Trust1,
                    2 => Trust2,
                    3 => Trust3,
                    4 => Trust4,
                    5 => Trust5,
                    6 => Trust6,
                    _ => throw new IndexOutOfRangeException("Index should be in range of 0-6")
                };
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct PartyListMemberStruct
    {
        public const int Size = 0xF8;

        [FieldOffset(0x00)] public StatusIcons StatusIcon;
        [FieldOffset(0x50)] public AtkComponentBase* PartyMemberComponent;
        [FieldOffset(0x58)] public AtkTextNode* IconBottomLeftText;
        [FieldOffset(0x60)] public AtkResNode* NameAndBarsContainer;
        [FieldOffset(0x68)] public AtkTextNode* GroupSlotIndicator;
        [FieldOffset(0x70)] public AtkTextNode* Name;
        [FieldOffset(0x78)] public AtkTextNode* CastingActionName;
        [FieldOffset(0x80)] public AtkImageNode* CastingProgressBar;
        [FieldOffset(0x88)] public AtkImageNode* CastingProgressBarBackground;
        [FieldOffset(0x90)] public AtkResNode* EmnityBarContainer;
        [FieldOffset(0x98)] public AtkNineGridNode* EmnityBarFill;
        [FieldOffset(0xA0)] public AtkImageNode* ClassJobIcon;
        [FieldOffset(0xA8)] public void* UnknownA8;
        [FieldOffset(0xB0)] public AtkImageNode* UnknownImageB0;
        [FieldOffset(0xB8)] public AtkComponentBase* HPGaugeComponent;
        [FieldOffset(0xC0)] public AtkComponentGaugeBar* HPGaugeBar;
        [FieldOffset(0xC8)] public AtkComponentGaugeBar* MPGaugeBar;
        [FieldOffset(0xD0)] public AtkResNode* TargetGlowContainer;
        [FieldOffset(0xD8)] public AtkNineGridNode* ClickFlash;
        [FieldOffset(0xE0)] public AtkNineGridNode* TargetGlow;
        [FieldOffset(0xF0)] public byte EmnityByte; //01 or 02 or FF 

        [StructLayout(LayoutKind.Explicit, Size = 0x50)]
        public struct StatusIcons
        {
            [FieldOffset(0x00)] public AtkComponentIconText* StatusIcon0;
            [FieldOffset(0x08)] public AtkComponentIconText* StatusIcon1;
            [FieldOffset(0x10)] public AtkComponentIconText* StatusIcon2;
            [FieldOffset(0x18)] public AtkComponentIconText* StatusIcon3;
            [FieldOffset(0x20)] public AtkComponentIconText* StatusIcon4;
            [FieldOffset(0x28)] public AtkComponentIconText* StatusIcon5;
            [FieldOffset(0x30)] public AtkComponentIconText* StatusIcon6;
            [FieldOffset(0x38)] public AtkComponentIconText* StatusIcon7;
            [FieldOffset(0x40)] public AtkComponentIconText* StatusIcon8;
            [FieldOffset(0x48)] public AtkComponentIconText* StatusIcon9;

            public AtkComponentIconText* this[int i]
            {
                get
                {
                    return i switch
                    {
                        0 => StatusIcon0,
                        1 => StatusIcon1,
                        2 => StatusIcon2,
                        3 => StatusIcon3,
                        4 => StatusIcon4,
                        5 => StatusIcon5,
                        6 => StatusIcon6,
                        7 => StatusIcon7,
                        8 => StatusIcon8,
                        9 => StatusIcon9,
                        _ => throw new IndexOutOfRangeException("Index should be in range of 0-9")
                    };
                }
            }
        }
    }
}