using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent; 

[Agent(AgentId.AozContentResult)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct AgentAozContentResult {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public AozContentResultData* AozContentResultData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public struct AozContentResultData {
    [FieldOffset(0x04)] public uint ClearTime;
    [FieldOffset(0x0C)] public uint Score;
    [FieldOffset(0x28)] public Utf8String StageName;
}