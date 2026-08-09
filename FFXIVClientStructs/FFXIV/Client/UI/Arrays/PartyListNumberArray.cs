using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Arrays;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 746 * 4)]
public unsafe partial struct PartyListNumberArray {
    public static PartyListNumberArray* Instance() {
        var numberArray = AtkStage.Instance()->GetNumberArrayData(NumberArrayType.PartyList);
        return numberArray == null ? null : (PartyListNumberArray*)numberArray->IntArray;
    }

    [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray746<int> _data;

    [FieldOffset(0 * 4)] public bool IsVisible;
    [FieldOffset(1 * 4)] public bool IsCrossRealmParty;
    [FieldOffset(2 * 4)] public int PartyLeaderIndex;
    [FieldOffset(3 * 4)] public bool PartyHasMembers;
    [FieldOffset(4 * 4)] public bool HideWhenInSoloParty;
    /// <summary>
    /// Amount of players in the party.
    /// </summary>
    [FieldOffset(6 * 4)] public int PartyListCount;
    [FieldOffset(7 * 4)] public int EnmityLeaderIndex;
    [FieldOffset(8 * 4), FixedSizeArray] internal FixedSizeArray8<PartyListMemberNumberArray> _partyMembers;
    [FieldOffset(352 * 4)] public int TrustCount;
    [FieldOffset(353 * 4), FixedSizeArray] internal FixedSizeArray7<PartyListMemberNumberArray> _trustMembers;
    /// <summary>
    /// Pet/chocobo display data blocks.
    /// <br/>When <see cref="ChocoboCount"/> is non-zero, <c>Pets[0]</c> contains the Chocobo data and <c>Pets[1]</c> contains the Pet data.
    /// <br/>When <see cref="ChocoboCount"/> is zero, <c>Pets[0]</c> contains the Pet data.
    /// </summary>
    [FieldOffset(654 * 4), FixedSizeArray] internal FixedSizeArray2<PartyListMemberNumberArray> _pets;

    [FieldOffset(740 * 4)] public int ChocoboCount;
    [FieldOffset(741 * 4)] public int PetCount;
    [FieldOffset(742 * 4)] public bool UsePetSlot;
    [FieldOffset(743 * 4)] public bool HideEnmityLeader;
    [FieldOffset(744 * 4)] public uint TargetedEntityId;
    [FieldOffset(745 * 4)] public uint SoftTargetEntityId;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 43 * 4)]
    public partial struct PartyListMemberNumberArray {
        [FieldOffset(0), FixedSizeArray, CExporterIgnore] internal FixedSizeArray43<int> _data;

        [FieldOffset(2 * 4)] public int Level;
        [FieldOffset(3 * 4)] public int ClassIconId;
        [FieldOffset(6 * 4)] public int CurrentHealth;
        [FieldOffset(7 * 4)] public int MaxHealth;
        /// <summary>
        /// Goes from 0 to 200%
        /// </summary>
        [FieldOffset(8 * 4)] public int ShieldsPercentage;
        [FieldOffset(9 * 4)] public int CurrentMana;
        [FieldOffset(10 * 4)] public int MaxMana;
        /// <summary>
        /// Goes from 0 to 100%
        /// </summary>
        [FieldOffset(12 * 4)] public int EnmityPercent;
        /// <summary>
        /// Starts at 1
        /// <br/>[A]
        /// <br/>[2]
        /// <br/>[3]
        /// <br/>...
        /// <br/>[8]
        /// </summary>
        [FieldOffset(13 * 4)] public int EnmityLevel;
        /// <summary>
        /// Amount of Statuses applied to the player.
        /// <br/>Max is 10.
        /// </summary>
        [FieldOffset(16 * 4)] public int StatusCount;
        [FieldOffset(17 * 4), FixedSizeArray] internal FixedSizeArray10<int> _statusIconIds;
        [FieldOffset(27 * 4), FixedSizeArray] internal FixedSizeArray10<bool> _statusIsDispellable;
        /// <summary>
        /// -1 if not active
        /// </summary>
        [FieldOffset(37 * 4)] public int CastTime;
        [FieldOffset(38 * 4)] public int CastId;
        [Obsolete("Use EntityId Instead.")]
        [FieldOffset(40 * 4)] public int ContentId;
        [FieldOffset(40 * 4)] public uint EntityId;
        [FieldOffset(41 * 4)] public bool Targetable;
        [FieldOffset(42 * 4)] public int DisplayRow;
    }
}
