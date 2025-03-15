using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonNamePlate;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonPartyList
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_PartyList")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1590)]
public unsafe partial struct AddonPartyList {
    public static PartyListIntArrayData* Instance() => (PartyListIntArrayData*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.PartyList)->IntArray;

    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray8<PartyListMemberStruct> _partyMembers;
    [FieldOffset(0xA38), FixedSizeArray] internal FixedSizeArray7<PartyListMemberStruct> _trustMembers;
    [FieldOffset(0x1238)] public PartyListMemberStruct Chocobo;
    [FieldOffset(0x1338)] public PartyListMemberStruct Pet;

    [FieldOffset(0x1438), FixedSizeArray] internal FixedSizeArray8<uint> _partyClassJobIconId;
    [FieldOffset(0x1458), FixedSizeArray] internal FixedSizeArray7<uint> _trustClassJobIconId;
    [FieldOffset(0x1474)] public uint ChocoboIconId;
    [FieldOffset(0x1478)] public uint PetIconId;

    [FieldOffset(0x1510), FixedSizeArray] internal FixedSizeArray17<short> _edited; // 0X11 if edited? Need comfirm

    [FieldOffset(0x1538)] public AtkResNode* PartyListAtkResNode;
    [FieldOffset(0x1540)] public AtkNineGridNode* BackgroundNineGridNode;
    [FieldOffset(0x1548)] public AtkTextNode* PartyTypeTextNode; // Solo Light/Full Party
    [FieldOffset(0x1550)] public AtkResNode* LeaderMarkResNode;
    [FieldOffset(0x1558)] public AtkResNode* MpBarSpecialResNode;
    [FieldOffset(0x1560)] public AtkTextNode* MpBarSpecialTextNode;

    [FieldOffset(0x1568)] public int MemberCount;
    [FieldOffset(0x156C)] public int TrustCount;
    [FieldOffset(0x1570)] public int EnmityLeaderIndex; // Starts from 0 (-1 if no leader)
    [FieldOffset(0x1574)] public int HideWhenSolo;

    [FieldOffset(0x1578)] public int HoveredIndex;
    [FieldOffset(0x157C)] public int TargetedIndex;

    [FieldOffset(0x1580)] public int Unknown1580;
    [FieldOffset(0x1584)] public int Unknown1584;
    [FieldOffset(0x1588)] public byte Unknown1588;

    [FieldOffset(0x158A)] public byte PetCount; // or PetSummoned?
    [FieldOffset(0x158B)] public byte ChocoboCount; // or ChocoboSummoned?

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public partial struct PartyListMemberStruct {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray10<Pointer<AtkComponentIconText>> _statusIcons;
        [FieldOffset(0x50)] public AtkComponentBase* PartyMemberComponent;
        [FieldOffset(0x58)] public AtkTextNode* IconBottomLeftText;
        [FieldOffset(0x60)] public AtkResNode* NameAndBarsContainer;  // only contains hp/mp bars
        [FieldOffset(0x68)] public AtkResNode* Unknown68;  // seems to be related to MPGaugeBar
        [FieldOffset(0x70)] public AtkTextNode* GroupSlotIndicator;
        [FieldOffset(0x78)] public AtkTextNode* Name;
        [FieldOffset(0x80)] public AtkTextNode* CastingActionName;
        [FieldOffset(0x88)] public AtkImageNode* CastingProgressBar;
        [FieldOffset(0x90)] public AtkImageNode* CastingProgressBarBackground;
        [FieldOffset(0x98)] public AtkResNode* EmnityBarContainer;
        [FieldOffset(0xA0)] public AtkNineGridNode* EmnityBarFill;
        [FieldOffset(0xA8)] public AtkImageNode* ClassJobIcon;
        [FieldOffset(0xB0)] public void* UnknownB0;
        [FieldOffset(0xB8)] public AtkImageNode* UnknownImageB8;
        [FieldOffset(0xC0)] public AtkComponentBase* HPGaugeComponent;
        [FieldOffset(0xC8)] public AtkComponentGaugeBar* HPGaugeBar;
        [FieldOffset(0xD0)] public AtkComponentGaugeBar* MPGaugeBar;
        [FieldOffset(0xD8)] public AtkResNode* TargetGlowContainer;
        [FieldOffset(0xE0)] public AtkNineGridNode* ClickFlash;
        [FieldOffset(0xE8)] public AtkNineGridNode* TargetGlow;
        [FieldOffset(0xF8)] public byte EmnityByte; //01 or 02 or FF
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 745 * 4)]
    public partial struct PartyListIntArrayData {
        [FieldOffset(2 * 4)] public int PartyLeaderIndex;
        /// <summary>
        /// Amount of players in the party.
        /// </summary>
        [FieldOffset(6 * 4)] public int PartyListCount;
        [FieldOffset(7 * 4), FixedSizeArray] internal FixedSizeArray8<PartyListMemberIntArrayData> _partyMembers;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 43 * 4)]
    public partial struct PartyListMemberIntArrayData {
        [FieldOffset(3 * 4)] public int Level;
        [FieldOffset(4 * 4)] public int ClassIconId;
        [FieldOffset(7 * 4)] public int CurrentHealth;
        [FieldOffset(8 * 4)] public int MaxHealth;
        /// <summary>
        /// Goes from 0 to 200%
        /// </summary>
        [FieldOffset(9 * 4)] public int ShieldsPercentage;
        [FieldOffset(10 * 4)] public int CurrentMana; 
        [FieldOffset(11 * 4)] public int MaxMana;
        /// <summary>
        /// Goes from 0 to 100%
        /// </summary>
        [FieldOffset(13 * 4)] public int EmnityPercent;
        /// <summary>
        /// Starts at 1
        /// <br>[A]</br>
        /// <br>[2]</br>
        /// <br>[3]</br>
        /// <br>...</br>
        /// <br>[8]</br>
        /// </summary>
        [FieldOffset(14 * 4)] public int EmnityLevel;
        /// <summary>
        /// Amount of Statuses applied to the player.
        /// <br>Max is 10.</br>
        /// </summary>
        [FieldOffset(17 * 4)] public int StatusCount;
        [FieldOffset(18 * 4), FixedSizeArray] internal FixedSizeArray10<int> _statusIconIds;
        [FieldOffset(28 * 4), FixedSizeArray] internal FixedSizeArray10<int> _statusIsDispellable;
        /// <summary>
        /// -1 if not active
        /// </summary>
        [FieldOffset(38 * 4)] public int CastTime;
        [FieldOffset(39 * 4)] public int CastId;
        [FieldOffset(41 * 4)] public int ContentId;
        [FieldOffset(42 * 4)] public int Targetable;
    }
}
