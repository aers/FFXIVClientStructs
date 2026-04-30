using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonPartyList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_PartyList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x16A0)]
public unsafe partial struct AddonPartyList {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray8<PartyListMemberStruct> _partyMembers;
    [FieldOffset(0xA38), FixedSizeArray] internal FixedSizeArray8<PartyListMemberStruct> _trustMembers;
    [FieldOffset(0x1238)] public PartyListMemberStruct Chocobo;
    [FieldOffset(0x1338)] public PartyListMemberStruct Pet;
    //[FieldOffset(0x1438)] private PartyListMemberStruct ??; // new in 7.5

    [FieldOffset(0x1538), FixedSizeArray] internal FixedSizeArray8<uint> _partyClassJobIconId;
    [FieldOffset(0x1558), FixedSizeArray] internal FixedSizeArray7<uint> _trustClassJobIconId;
    
    [FieldOffset(0x1580)] public uint PetIconId;

    [FieldOffset(0x15C4)] public uint ChocoboIconId;

    [FieldOffset(0x161C), FixedSizeArray] internal FixedSizeArray19<short> _edited; // 0X11 if edited? Need comfirm

    [FieldOffset(0x1648)] public AtkResNode* PartyListAtkResNode;
    [FieldOffset(0x1650)] public AtkNineGridNode* BackgroundNineGridNode;
    [FieldOffset(0x1658)] public AtkTextNode* PartyTypeTextNode; // Solo Light/Full Party
    [FieldOffset(0x1660)] public AtkResNode* LeaderMarkResNode;
    [FieldOffset(0x1668)] public AtkResNode* MpBarSpecialResNode;
    [FieldOffset(0x1670)] public AtkTextNode* MpBarSpecialTextNode;

    [FieldOffset(0x1678)] public int MemberCount;
    [FieldOffset(0x167C)] public int TrustCount;
    [FieldOffset(0x1680)] public int EnmityLeaderIndex; // Starts from 0 (-1 if no leader)
    [FieldOffset(0x1684)] public int HideWhenSolo;

    [FieldOffset(0x1688)] public int HoveredIndex;
    [FieldOffset(0x168C)] public int TargetedIndex;

    [FieldOffset(0x1690)] private int Unknown1690;
    [FieldOffset(0x1694)] private int Unknown1694;
    [FieldOffset(0x1698)] private byte Unknown1698;

    [FieldOffset(0x169A)] public byte PetCount; // or PetSummoned?
    [FieldOffset(0x169B)] public byte ChocoboCount; // or ChocoboSummoned?

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public partial struct PartyListMemberStruct {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<Pointer<AtkComponentIconText>> _statusIcons;
        [FieldOffset(0x50)] public AtkComponentBase* PartyMemberComponent;
        [FieldOffset(0x58)] public AtkTextNode* IconBottomLeftText;
        [FieldOffset(0x60)] public AtkResNode* NameAndBarsContainer;  // only contains hp/mp bars
        [FieldOffset(0x68)] private AtkResNode* Unknown68;  // seems to be related to MPGaugeBar
        [FieldOffset(0x70)] public AtkTextNode* GroupSlotIndicator;
        [FieldOffset(0x78)] public AtkTextNode* Name;
        [FieldOffset(0x80)] public AtkTextNode* CastingActionName;
        [FieldOffset(0x88)] public AtkImageNode* CastingProgressBar;
        [FieldOffset(0x90)] public AtkImageNode* CastingProgressBarBackground;
        [FieldOffset(0x98)] public AtkResNode* EmnityBarContainer;
        [FieldOffset(0xA0)] public AtkNineGridNode* EmnityBarFill;
        [FieldOffset(0xA8)] public AtkImageNode* ClassJobIcon;
        [FieldOffset(0xB0)] private void* UnknownB0;
        [FieldOffset(0xB8)] private AtkImageNode* UnknownImageB8;
        [FieldOffset(0xC0)] public AtkComponentBase* HPGaugeComponent;
        [FieldOffset(0xC8)] public AtkComponentGaugeBar* HPGaugeBar;
        [FieldOffset(0xD0)] public AtkComponentGaugeBar* MPGaugeBar;
        [FieldOffset(0xD8)] public AtkResNode* TargetGlowContainer;
        [FieldOffset(0xE0)] public AtkNineGridNode* ClickFlash;
        [FieldOffset(0xE8)] public AtkNineGridNode* TargetGlow;
        [FieldOffset(0xF0)] public AtkCollisionNode* Collision;
        [FieldOffset(0xF8)] public byte EmnityByte; //01 or 02 or FF
    }
}
