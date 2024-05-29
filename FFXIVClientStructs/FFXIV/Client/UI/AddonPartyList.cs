using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("_PartyList")]
[GenerateInterop, Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x13E0)]
public unsafe partial struct AddonPartyList {
    [FieldOffset(0x220), FixedSizeArray] internal FixedSizeArray8<PartyListMemberStruct> _partyMembers;
    [FieldOffset(0x9E0), FixedSizeArray] internal FixedSizeArray7<PartyListMemberStruct> _trustMembers;
    [FieldOffset(0x10A8)] public PartyListMemberStruct Chocobo;
    [FieldOffset(0x11A0)] public PartyListMemberStruct Pet;

    [FieldOffset(0x1298), FixedSizeArray] internal FixedSizeArray8<uint> _partyClassJobIconId;
    [FieldOffset(0x12B8), FixedSizeArray] internal FixedSizeArray7<uint> _trustClassJobIconId;
    [FieldOffset(0x12D4)] public uint ChocoboIconId;
    [FieldOffset(0x12D8)] public uint PetIconId;

    [FieldOffset(0x1360), FixedSizeArray] internal FixedSizeArray17<short> _edited; // 0X11 if edited? Need comfirm

    [FieldOffset(0x1390)] public AtkNineGridNode* BackgroundNineGridNode;
    [FieldOffset(0x1398)] public AtkTextNode* PartyTypeTextNode; // Solo Light/Full Party
    [FieldOffset(0x13A0)] public AtkResNode* LeaderMarkResNode;
    [FieldOffset(0x13A8)] public AtkResNode* MpBarSpecialResNode;
    [FieldOffset(0x13B0)] public AtkTextNode* MpBarSpecialTextNode;

    [FieldOffset(0x13B8)] public int MemberCount;
    [FieldOffset(0x13BC)] public int TrustCount;
    [FieldOffset(0x13C0)] public int EnmityLeaderIndex; // Starts from 0 (-1 if no leader)
    [FieldOffset(0x13C4)] public int HideWhenSolo;

    [FieldOffset(0x13C8)] public int HoveredIndex;
    [FieldOffset(0x13CC)] public int TargetedIndex;

    [FieldOffset(0x13D0)] public int Unknown1410;
    [FieldOffset(0x13D4)] public int Unknown1414;
    [FieldOffset(0x13D8)] public byte Unknown1418;

    [FieldOffset(0x13DA)] public byte PetCount; // or PetSummoned?
    [FieldOffset(0x13DB)] public byte ChocoboCount; // or ChocoboSummoned?

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public partial struct PartyListMemberStruct {
        public const int Size = 0xF8;

        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<Pointer<AtkComponentIconText>> _statusIcons;
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
    }
}
