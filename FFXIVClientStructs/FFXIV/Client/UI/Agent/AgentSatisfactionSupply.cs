using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.SatisfactionSupply)]
[StructLayout(LayoutKind.Explicit, Size = 0x500)]
public unsafe partial struct AgentSatisfactionSupply
{
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FixedSizeArray<AgentDeliveryItemInfo>(3)] 
    [FieldOffset(0x1D4)] public fixed byte DeliveryInfo[0x108 * 3];
}

[StructLayout(LayoutKind.Explicit, Size = 0x108)]
public unsafe partial struct AgentDeliveryItemInfo
{
    [FieldOffset(0x28)] public Utf8String ItemName;
}