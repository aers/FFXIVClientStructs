using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct AgentContextInterface
    {
        [FieldOffset(0x0)] public AgentInterface AgentInterface;
        [FieldOffset(0x670)] public unsafe byte SelectedIndex;
        [FieldOffset(0x690)] public byte* Unk1;
        [FieldOffset(0xD08)] public byte* SubContextMenuTitle;
        [FieldOffset(0x1740)] public bool IsSubContextMenu;
    }
}
