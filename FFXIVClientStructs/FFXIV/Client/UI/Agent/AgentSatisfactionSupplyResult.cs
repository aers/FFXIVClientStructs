using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.SatisfactionSupplyResult)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public partial struct AgentSatisfactionSupplyResult {
    [FieldOffset(0x28), CExporterExcel("SatisfactionNpc")] public uint CurrentSatisfactionNpcRowId;

    [FieldOffset(0x2D)] public bool IsRewardInitialized;
    [FieldOffset(0x2E)] public bool IsAddonOpen;
    [FieldOffset(0x2F)] public bool RewardClaimed;

    [FieldOffset(0x40)] public SatisfactionSupplyManager.NpcInfo CurrentNpcInfo;

    [FieldOffset(0x5C), FixedSizeArray] internal FixedSizeArray3<RewardDetail> _rewards;

    [FieldOffset(0x78), CExporterExcel("ENpcResident")] private nint CurrentNpcResidentNpcRow;

    [FieldOffset(0x80), CExporterExcel("Item"), FixedSizeArray] internal FixedSizeArray3<nint> _rewardItemRows;

    [FieldOffset(0x98)] public int AvailableRewardCount;
    [FieldOffset(0x9C)] public int ContextMenuSelectedRewardIndex;

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct RewardDetail {
        [FieldOffset(0)] public uint ItemId;
        [FieldOffset(4)] public ushort Amount;
        [FieldOffset(6)] public bool IsHQ;
    }
}
