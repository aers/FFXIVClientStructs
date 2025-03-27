using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[CExportIgnore]
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 745 * 4)]
public unsafe partial struct PartyListNumberArray {
    public static PartyListNumberArray* Instance() => (PartyListNumberArray*)AtkStage.Instance()->GetNumberArrayData(NumberArrayType.PartyList)->IntArray;

    [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray745<int> _data;

    [FieldOffset(1 * 4)] public bool IsCrossRealmParty;
    [FieldOffset(2 * 4)] public int PartyLeaderIndex;
    [FieldOffset(3 * 4)] public bool PartyHasMembers;
    [FieldOffset(4 * 4)] public bool HideWhenInSoloParty;
    /// <summary>
    /// Amount of players in the party.
    /// </summary>
    [FieldOffset(6 * 4)] public int PartyListCount;
    [FieldOffset(7 * 4), FixedSizeArray] internal FixedSizeArray8<PartyListMemberNumberArray> _partyMembers;
    [FieldOffset(352 * 4), FixedSizeArray] internal FixedSizeArray7<PartyListMemberNumberArray> _trustMembers;
    [FieldOffset(653 * 4), FixedSizeArray] internal FixedSizeArray2<PartyListMemberNumberArray> _pets;

    [CExportIgnore]
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 43 * 4)]
    public partial struct PartyListMemberNumberArray {
        [FieldOffset(0), FixedSizeArray, CExportIgnore] internal FixedSizeArray43<int> _data;

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
        [FieldOffset(13 * 4)] public int EnmityPercent;
        /// <summary>
        /// Starts at 1
        /// <br/>[A]
        /// <br/>[2]
        /// <br/>[3]
        /// <br/>...
        /// <br/>[8]
        /// </summary>
        [FieldOffset(14 * 4)] public int EnmityLevel;
        /// <summary>
        /// Amount of Statuses applied to the player.
        /// <br/>Max is 10.
        /// </summary>
        [FieldOffset(17 * 4)] public int StatusCount;
        [FieldOffset(18 * 4), FixedSizeArray] internal FixedSizeArray10<int> _statusIconIds;
        [FieldOffset(28 * 4), FixedSizeArray] internal FixedSizeArray10<bool> _statusIsDispellable;
        /// <summary>
        /// -1 if not active
        /// </summary>
        [FieldOffset(38 * 4)] public int CastTime;
        [FieldOffset(39 * 4)] public int CastId;
        [FieldOffset(41 * 4)] public int ContentId;
        [FieldOffset(42 * 4)] public bool Targetable;
    }
}
