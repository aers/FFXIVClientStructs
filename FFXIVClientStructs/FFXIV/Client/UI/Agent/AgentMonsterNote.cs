using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMonsterNote
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MonsterNote)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct AgentMonsterNote {
    [FieldOffset(0x28)] public StdVector<Utf8String> StringVector;
    [FieldOffset(0x40)] public uint BaseId;
    [FieldOffset(0x44)] public byte ClassId;
    [FieldOffset(0x45)] public byte ClassIndex;
    [FieldOffset(0x46)] public byte MonsterNote;
    [FieldOffset(0x47)] public byte Rank;
    [FieldOffset(0x48)] public byte Filter;

    [FieldOffset(0x5C)] public byte IsLocked;

    public uint GetMonsterNoteIdForIndex(int index) {
        return (uint)(ClassId * BaseId + Rank * 10 + index + 1);
    }
}
