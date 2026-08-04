namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTelepotTown
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.TelepotTown)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct AgentTelepotTown {
    [FieldOffset(0x28)] public AgentTelepotTownData* Data;

    [MemberFunction("E9 ?? ?? ?? ?? 83 F9 01 0F 85 ?? ?? ?? ?? 48 8B 53 28")]
    public partial void TeleportToAetheryte(byte index);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xDFB0)]
public unsafe partial struct AgentTelepotTownData {
    [FieldOffset(0x08)] public byte CurrentAetheryte; // index of the aetheryte currently stood at
    [FieldOffset(0x09)] public byte AetheryteCount;   // number of aethernet entries

    [FieldOffset(0x0C), FixedSizeArray] internal FixedSizeArray64<AetheryteEntry> _entries;

    [FieldOffset(0x70E)] public byte SelectedAetheryte; // index selected in the aethernet list
    [FieldOffset(0x710)] public uint Flags;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct AetheryteEntry {
    [FieldOffset(0x00)] public uint AetheryteID;
    [FieldOffset(0x04)] private uint Unk04; // only written when marker below is not found
    [FieldOffset(0x08)] public ushort PlaceNameID; // Aetheryte.AethernetName
    [FieldOffset(0x0A)] private ushort PlaceNameID2; // written together with PlaceNameID
    [FieldOffset(0x0C)] public ushort MarkerIndex; // index of the matching map marker, 100 when not found
    [FieldOffset(0x0E)] public ushort MapID; // Aetheryte.Map
    [FieldOffset(0x10)] public ushort TerritoryTypeID; // Aetheryte.Territory
    [FieldOffset(0x12)] public byte GroupIndex; // index into the group table at AgentTelepotTownData+0x60C
    [FieldOffset(0x13)] public bool IsLocked;
    [FieldOffset(0x14)] public bool IsUnusable;
    [FieldOffset(0x15)] public bool IsAetheryte;
    [FieldOffset(0x16)] public bool IsCurrent;
}
