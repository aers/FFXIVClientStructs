namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingInteriorPattern
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HousingInteriorPattern)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xA38)]
public unsafe partial struct AgentHousingInteriorPattern {
    [FieldOffset(0x28)] internal byte Unk28; // flags
    [FieldOffset(0x29)] internal byte Unk29; // flags

    [FieldOffset(0x30)] public Utf8String CurrentString;
    [FieldOffset(0x98), FixedSizeArray] internal FixedSizeArray22<Utf8String> _availableRenovationNames;
    [FieldOffset(0x988)] internal Utf8String UnkString;
    /// <remarks> HousingRenovation row id </remarks>
    [FieldOffset(0x9F0)] public ushort CurrentRenovationRowId;
    /// <remarks> HousingRenovation row ids </remarks>
    [FieldOffset(0x9F2), FixedSizeArray] internal FixedSizeArray22<ushort> _availableRenovationRowIds;

    /// <remarks> Addon Id of HousingWareHouseStatus, MultipleHelpWindow or SelectYesno </remarks>
    [FieldOffset(0xA20)] public uint PopupAddonId;
    /// <remarks> Index of <see cref="AvailableRenovationRowIds"/> for which the SelectYesno addon is shown. </remarks>
    [FieldOffset(0xA24)] internal uint RenovationConfirmIndex;
}
