using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;
// Client::UI::Agent::AgentRetainerList
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface

// size 0x550
// ctor 48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B F1 E8 ?? ?? ?? ?? 33 C9
[Agent(AgentId.RetainerList)]
[StructLayout(LayoutKind.Explicit, Size = 0x5B8)]
public unsafe struct AgentRetainerList
{
    public static AgentRetainerList* Instance()
    {
        return (AgentRetainerList*) Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(
            AgentId.RetainerList);
    }

    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0x30)] public uint RetainerListOpenedTime;
    [FieldOffset(0x34)] public uint RetainerListSortAddonId;
    [FieldOffset(0x48)] public byte RetainerCount;
    [FieldOffset(0x50)] public RetainerList Retainers;

    [StructLayout(LayoutKind.Explicit, Size = 0x460)]
    public struct RetainerList
    {
        [FieldOffset(0x00)] private fixed byte Retainers[0x460];
        [FieldOffset(0x70 * 0)] public Retainer Retainer0;
        [FieldOffset(0x70 * 1)] public Retainer Retainer1;
        [FieldOffset(0x70 * 2)] public Retainer Retainer2;
        [FieldOffset(0x70 * 3)] public Retainer Retainer3;
        [FieldOffset(0x70 * 4)] public Retainer Retainer4;
        [FieldOffset(0x70 * 5)] public Retainer Retainer5;
        [FieldOffset(0x70 * 6)] public Retainer Retainer6;
        [FieldOffset(0x70 * 7)] public Retainer Retainer7;
        [FieldOffset(0x70 * 8)] public Retainer Retainer8;
        [FieldOffset(0x70 * 9)] public Retainer Retainer9;

        public Retainer* this[int index]
        {
            get
            {
                if (index is < 0 or >= 10) return null;
                fixed (byte* p = Retainers)
                {
                    var r = (Retainer*) p;
                    return r + index;
                }
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct Retainer
    {
        [FieldOffset(0x00)] public Utf8String Name;

        [FieldOffset(0x6C)] public byte Index;
        [FieldOffset(0x6D)] public byte SortedIndex; // 0 Indexed
    }
}