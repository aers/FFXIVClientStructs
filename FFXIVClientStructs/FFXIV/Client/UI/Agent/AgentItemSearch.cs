using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentItemSearch
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 33 ED C6 41 08 00 48 89 69 18"
[Agent(AgentId.ItemSearch)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3878)]
public unsafe partial struct AgentItemSearch {
    [FieldOffset(0x98)] public StringHolder* StringData;
    [FieldOffset(0x3384)] public uint ResultItemId;
    [FieldOffset(0x338C)] public uint ResultSelectedIndex;
    [FieldOffset(0x339C)] public ushort ResultHoveredIndex;
    [FieldOffset(0x33A0)] public uint ResultHoveredItemId;
    [FieldOffset(0x33A4)] public uint ResultHoveredCount;
    [FieldOffset(0x33AC)] public byte ResultHoveredHQ;
    // [FieldOffset(0x3858)] public uint* ItemBuffer;
    // [FieldOffset(0x3860)] public uint ItemCount;
    [FieldOffset(0x386A)] public bool IsPartialSearching;
    // [FieldOffset(0x386D)] public bool IsItemPushPending;

    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public struct StringHolder {
        // [FieldOffset(0x10)] public int Unk90Size;
        [FieldOffset(0x28)] public Utf8String SearchParam;
        // [FieldOffset(0x90)] public nint Unk90Ptr;
    }
}
