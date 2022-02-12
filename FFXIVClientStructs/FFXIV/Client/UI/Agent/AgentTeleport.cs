using FFXIVClientStructs.FFXIV.Client.Game.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Teleport)]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe struct AgentTeleport
{
    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0x60)] public int AetheryteCount;
    [FieldOffset(0x68)] public StdVector<TeleportInfo>* AetheryteList;
}