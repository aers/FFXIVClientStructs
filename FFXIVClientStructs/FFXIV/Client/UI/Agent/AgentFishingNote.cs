namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentFishingNote
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.FishingNote)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x170)]
public unsafe partial struct AgentFishingNote {
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray10<FishSlot> _fishSlots; // sets NumberArray when FishSlotsDirty

    [FieldOffset(0xA8), FixedSizeArray] internal FixedSizeArray19<SpotEntry> _spots;

    [FieldOffset(0x11C)] public uint RegionCount;
    [FieldOffset(0x120), FixedSizeArray] internal FixedSizeArray19<ushort> _regionPlaceNameIds;

    [FieldOffset(0x150)] private int Unk150;
    [FieldOffset(0x154)] public ushort ViewingPlaceNameRegionId;
    [FieldOffset(0x156)] public ushort ViewingPlaceNameId;
    [FieldOffset(0x158)] private ushort Unk158;

    [FieldOffset(0x15A)] public ushort CurrentTerritoryPlaceNameRegionId;
    [FieldOffset(0x15C)] public ushort CurrentTerritoryPlaceNameId;

    [FieldOffset(0x15E)] public ushort SelectedRegionPlaceNameId; // 0 is unset
    [FieldOffset(0x160)] public ushort SelectedRegionIndex;
    [FieldOffset(0x162)] public short SelectedSpotIndex; // -1 if none

    [FieldOffset(0x164)] public byte FishSlotCount;
    [FieldOffset(0x165)] public bool FishSlotsDirty; // rebuilds NumberArray/StringArray rows based on _fishSlots
    [FieldOffset(0x166)] public byte TabIndex; // 0 = Fishing, 1 = Spearfishing
    [FieldOffset(0x167)] public bool HasCurrentTerritoryInfo;

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct FishSlot {
        [FieldOffset(0x00)] public uint FishParameterId;
        [FieldOffset(0x04)] public bool IsUpdated;
        [FieldOffset(0x05)] public bool IsCaught;
        [FieldOffset(0x06)] public ushort GatheringSubCategoryId;
        [FieldOffset(0x08)] private byte Unk08;
        [FieldOffset(0x09)] private byte Unk09;
        [FieldOffset(0x0A)] private byte Unk0A;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x06)]
    public struct SpotEntry {
        [FieldOffset(0x00)] public ushort Order;
        [FieldOffset(0x02)] public ushort PlaceNameId;
        [FieldOffset(0x04)] private ushort RemappedId; // some sort of remapping after an AgentMap call
    }
}
