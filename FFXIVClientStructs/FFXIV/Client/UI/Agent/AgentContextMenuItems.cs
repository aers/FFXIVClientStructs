using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent
{
    [StructLayout(LayoutKind.Explicit)]
    public struct AgentContextMenuItems
    {
        [FieldOffset(0x0)] public ushort AtkValueCount;
        [FieldOffset(0x8)] public AtkValue AtkValues;
        [FieldOffset(0x428)] public byte Actions;
        [FieldOffset(0x450)] public ulong UnkFunctionPointers;
        [FieldOffset(0x598)] public ulong RedButtonActions;
    }
}
