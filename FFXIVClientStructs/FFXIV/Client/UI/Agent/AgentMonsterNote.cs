using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent; 

[Agent(AgentId.MonsterNote)]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public struct AgentMonsterNote
{
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public StdVector<Utf8String> StringVector;
    [FieldOffset(0x40)] public uint BaseId;
    [FieldOffset(0x44)] public byte ClassId;
    [FieldOffset(0x45)] public byte ClassIndex;
    [FieldOffset(0x46)] public byte MonsterNote;
    [FieldOffset(0x47)] public byte Rank;
    [FieldOffset(0x48)] public byte Filter;

    [FieldOffset(0x5C)] public byte IsLocked;

    public uint GetMonsterNoteIdForIndex(int index)
    {
        return (uint)(ClassId * BaseId + Rank * 10 + index + 1);
    }
}