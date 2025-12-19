using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentDeepDungeonInspect
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.DeepDungeonInspect)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentDeepDungeonInspect {
    [FieldOffset(0x28)] public AgentDeepDungeonInspectData* Data;

    //Size taken from Alloc in disassembly
    [StructLayout(LayoutKind.Explicit, Size = 0x160)]
    public unsafe partial struct AgentDeepDungeonInspectData {
        [FieldOffset(0x00)] public uint RequestEntityId;
        [FieldOffset(0x04)] public uint CurrentEntityId;
        [FieldOffset(0x08)] public uint StatusSearchComment;
        //[FieldOffset(0x0C)] public uint Unk0C;
        [FieldOffset(0x10)] public Utf8String SearchComment;
        [FieldOffset(0x78)] public InfoProxyDetail* InfoProxyDetail;
        [FieldOffset(0x80)] public byte Title;
        //[FieldOffset(0x81)] public byte Unk81; //Always 0 (solo in PotD)
        [FieldOffset(0x82)] public byte WorldId;
        //[FieldOffset(0x83)] public byte Unk83; //Always 0 (solo in PotD)
        //[FieldOffset(0x84)] public byte Unk84; //Always 1 (solo in PotD)
        [FieldOffset(0x85)] public byte Job;
        [FieldOffset(0x86)] public byte Level;
        [FieldOffset(0x87)] public byte AetherPoolArmLvl;
        [FieldOffset(0x88)] public byte AetherPoolArmorLvl;
        [FieldOffset(0x90)] public Utf8String Name;
        //[FieldOffset(0xF8)] public Utf8String UnkF8; //Never seen a value here. Type taken from Constructor
    }
}
