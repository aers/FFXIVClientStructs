using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentHousingInteriorPattern
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.HousingInteriorPattern)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x8F8)]
public unsafe partial struct AgentHousingInteriorPattern {
    [FieldOffset(0x28)] internal byte Unk28; // flags
    [FieldOffset(0x29)] internal byte Unk29; // flags

    [FieldOffset(0x30)] public Utf8String CurrentString;
    [FieldOffset(0x98), FixedSizeArray] internal FixedSizeArray19<Utf8String> _availableRenovationNames;
    [FieldOffset(0x850)] internal Utf8String UnkString;
    /// <remarks> HousingRenovation row id </remarks>
    [FieldOffset(0x8B8)] public ushort CurrentRenovationRowId;
    /// <remarks> HousingRenovation row ids </remarks>
    [FieldOffset(0x8BA), FixedSizeArray] internal FixedSizeArray19<ushort> _availableRenovationRowIds;
    [FieldOffset(0x8E0)] internal byte Unk8E0;

    /// <remarks> Addon Id of HousingWareHouseStatus, MultipleHelpWindow or SelectYesno </remarks>
    [FieldOffset(0x8E4)] public uint PopupAddonId;
    /// <remarks> Index of <see cref="AvailableRenovationRowIds"/> for which the SelectYesno addon is shown. </remarks>
    [FieldOffset(0x8E8)] internal uint RenovationConfirmIndex;
    [FieldOffset(0x8EC)] internal byte Unk8EC;
    [FieldOffset(0x8ED)] internal byte Unk8ED;

    [FieldOffset(0x8F0)] internal uint Unk8F0;
    [FieldOffset(0x8F5)] internal byte Unk8F5;
}
