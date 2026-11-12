using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Network;
using FFXIVClientStructs.FFXIV.Common;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingSignboard
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HousingSignboard)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AgentHousingSignboard {
    [FieldOffset(0x28)] public PlotSignboardType SignboardType;
    [FieldOffset(0x30)] private void* UnkPtr30;
    [FieldOffset(0x38)] public ushort TerritoryTypeId;
    [FieldOffset(0x3A)] public byte WardIndex;
    [FieldOffset(0x3B)] public byte PlotIndex;
    [FieldOffset(0x3C)] public ushort RoomIndex;
    [FieldOffset(0x3E)] public ushort PlaceNameId;
    [FieldOffset(0x40)] public PlotSize Size;
    [FieldOffset(0x48)] public HousingSignboardPurchaseDetailPacket SignboardPurchaseDetail;
    [FieldOffset(0x70)] public bool IsFirstComeFirstServed;
    [FieldOffset(0x71)] public bool OpenYesNoOkAddon;
    [FieldOffset(0x78)] public TimePoint StartTime;

    /// <remarks> Unix timestamp. </remarks>
    [FieldOffset(0x90)] public uint CurrentTimestamp;

    /// <remarks> Unix timestamp. </remarks>
    [FieldOffset(0x94)] public uint NextDevaluationTimestamp;

    [FieldOffset(0x98)] public int Price;
    [FieldOffset(0x9C)] public PlotSignboardBuyType SignboardBuyType;
    [FieldOffset(0xA0), FixedSizeArray] internal FixedSizeArray3<PlotSignboardBuyType> _unkA0;
    [FieldOffset(0xB0)] public ulong OwnerId; // Can be either a Player or an FC
    [FieldOffset(0xB8)] public uint AddonId0;
    [FieldOffset(0xBC)] public uint AddonId1;

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 30 48 8B F9 4C")]
    public partial void ReadPricePacket(HousingSignboardPricePacket* packet);

    [MemberFunction("E9 ?? ?? ?? ?? 48 83 7B ?? ?? 74 16")]
    public partial void ReadPacket(HousingSignboardPacket* packet);
}

public enum PlotSignboardType : byte {
    ForSale = 0,
    Estate = 1,
    PrivateChambers = 2, // FC Room
    Apartment = 3,
}

public enum PlotSignboardBuyType : uint {
    LotteryIndividual = 0,
    FCFSRegular_LotteryFreeCompany = 1,
    FCFSIndividualRelocate = 2,
    FCFSFreeCompanyRelocate = 3,
}
