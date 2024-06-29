using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRetainerList
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
// ctor "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B F1 E8 ?? ?? ?? ?? 33 C9 48 8D 05 ?? ?? ?? ?? 48 89 06"
[Agent(AgentId.RetainerList)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x620)]
public unsafe partial struct AgentRetainerList {
    [FieldOffset(0x30)] public uint RetainerListOpenedTime;
    [FieldOffset(0x34)] public uint RetainerListSortAddonId;
    [FieldOffset(0x48)] public byte RetainerCount;
    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray10<Retainer> _retainers;

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct Retainer {
        [FieldOffset(0x00)] public Utf8String Name;

        [FieldOffset(0x6C)] public byte Index;
        [FieldOffset(0x6D)] public byte SortedIndex; // 0 Indexed
    }
}
