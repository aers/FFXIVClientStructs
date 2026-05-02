namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRaidFinder
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.RaidFinder)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x2368)]
public partial struct AgentRaidFinder {
    [FieldOffset(0x2C)] public uint SelectedEntry;

    [FieldOffset(0x1EA8), FixedSizeArray] internal FixedSizeArray4<TabData> _tabs; // filled here: 40 55 53 57 41 54 41 55 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 48 8B D9 (a1 is the agent)
    [FieldOffset(0x22E8)] public uint SelectedTab;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x110)]
    public partial struct TabData {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray5<TabEntryData> _entries;

        [FieldOffset(0xA0)] public int EntryCount;

        [FieldOffset(0xA8)] public Utf8String Label;

        [StructLayout(LayoutKind.Explicit, Size = 0x14)]
        public struct TabEntryData {
            [FieldOffset(0x00)] public uint InstanceContentId;
            [FieldOffset(0x04)] public uint ContentFinderConditionId;
            [FieldOffset(0x08)] public ushort SortKey;
            [FieldOffset(0x0C)] private int UnkC;
            [FieldOffset(0x10)] private byte UnkFlags1;
            [FieldOffset(0x11)] private byte UnkFlags2;
        }
    }
}
