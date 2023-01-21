using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.DeepDungeonInspect)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentDeepDungeonInspect
{
    public static AgentDeepDungeonInspect* Instance() =>
        (AgentDeepDungeonInspect*)Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.DeepDungeonInspect);

    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public AgentDeepDungeonInspectData* Data;
    /*
    //Seems to be Show, but needs more investigation
    [MemberFunction("48 89 5C 24 08 57 48 83 EC 20 48 83 79 28 00 8B FA 48 8B D9 ?? ?? ?? ?? ?? ?? ?? 4C 8B C0 45 33 C9 33 D2 B9 60 01")]
    public partial void FUN_140a65850(uint ObjectID);
    */

    //Size taken from Alloc in disassembly
    [StructLayout(LayoutKind.Explicit, Size = 0x160)]
    public unsafe partial struct AgentDeepDungeonInspectData
    {
        [FieldOffset(0x00)] public uint RequestObjectID;
        [FieldOffset(0x04)] public uint CurrentObjectID;
        [FieldOffset(0x08)] public long Unk08; //Always 0 (solo in PotD)
        [FieldOffset(0x10)] public Utf8String SearchComment;
        [FieldOffset(0x78)] public Unk78* Unk78;
        [FieldOffset(0x80)] public byte Title;
        [FieldOffset(0x81)] public byte Unk81; //Always 0 (solo in PotD)
        [FieldOffset(0x82)] public byte WorldID;
        [FieldOffset(0x83)] public byte Unk83; //Always 0 (solo in PotD)
        [FieldOffset(0x84)] public byte Unk84; //Always 1 (solo in PotD)
        [FieldOffset(0x85)] public byte Job;
        [FieldOffset(0x86)] public byte Level;
        [FieldOffset(0x87)] public byte AetherPoolArmLvl;
        [FieldOffset(0x88)] public byte AetherPoolArmorLvl;
        [FieldOffset(0x90)] public Utf8String Name;
        [FieldOffset(0xF8)] public Utf8String UnkF8; //Never seen a value here. Type taken from Constructor
    }
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe partial struct Unk78
    {
        [FieldOffset(0x00)] public void** vtbl; //Seems to point ot a functiontable
        [FieldOffset(0x08)] public void* Unk08; //Points to local memory. Probably another class
    }
}

