using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingPortal
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HousingPortal)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct AgentHousingPortal {
    [MemberFunction("40 55 53 41 54 41 55 41 57 48 8D AC 24 ?? ?? ?? ?? B8")]
    public partial void ReadPacket(HousingPortalPacket* packet);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x96C)] // at least this big
public unsafe partial struct HousingPortalPacket {
    [FieldOffset(0x0)] public HouseId HouseId;
    [FieldOffset(0x8), FixedSizeArray] internal FixedSizeArray60<HouseInfoEntry> _houseInfoEntries;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe partial struct HouseInfoEntry {
        [FieldOffset(0)] public uint HousePrice;
        [FieldOffset(0x4)] public HouseInfoFlags InfoFlags;
        /// <remarks>HousingAppeal RowIds</remarks>
        [FieldOffset(0x5), FixedSizeArray] internal FixedSizeArray3<byte> _houseAppeals;
        [FieldOffset(0x8), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _ownerName;

        [Flags]
        public enum HouseInfoFlags : byte {
            PlotOwned = 1 << 0,
            VisitorsAllowed = 1 << 1,
            HasSearchComment = 1 << 2,
            HouseBuilt = 1 << 3,
            OwnedByFC = 1 << 4
        }
    }
}
