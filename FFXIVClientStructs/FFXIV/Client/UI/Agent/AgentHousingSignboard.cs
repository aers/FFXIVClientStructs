using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingSignboard
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HousingSignboard)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xC0)]
public unsafe partial struct AgentHousingSignboard {
    [MemberFunction("E9 ?? ?? ?? ?? 48 83 7B ?? ?? 74 16")]
    public partial void ReadPacket(HousingSignboardPacket* packet);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x118)] // at least this big
public unsafe partial struct HousingSignboardPacket {
    [FieldOffset(0x0)] public HouseId HouseId;

    [FieldOffset(0x14)] public bool IsOpen;
    /// <remarks>
    /// Small = 0<br/>
    /// Medium = 1<br/>
    /// Large = 2<br/>
    /// Apartment = 5?
    /// </remarks>
    [FieldOffset(0x15)] public byte Size;
    /// <summary>
    /// See <see cref="Game.EstateType"/>.
    /// </summary>
    [FieldOffset(0x16)] public byte EstateType;
    [FieldOffset(0x17), FixedSizeArray(isString: true)] internal FixedSizeArray21<byte> _name;

    [FieldOffset(0x2E), FixedSizeArray(isString: true)] internal FixedSizeArray193<byte> _greeting;
    [FieldOffset(0xEF), FixedSizeArray(isString: true)] internal FixedSizeArray31<byte> _ownerName;

    [FieldOffset(0x10E), FixedSizeArray(isString: true)] internal FixedSizeArray4<byte> _FCTag;

    /// <remarks>HousingAppeal RowIds</remarks>
    [FieldOffset(0x115), FixedSizeArray] internal FixedSizeArray3<byte> _houseAppeals;
}
