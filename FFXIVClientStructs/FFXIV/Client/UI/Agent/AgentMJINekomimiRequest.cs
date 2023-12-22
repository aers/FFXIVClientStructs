using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MJINekomimiRequest)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentMJINekomimiRequest {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public FavorsData* Data;

    [StructLayout(LayoutKind.Explicit, Size = 0x318)]
    public unsafe partial struct FavorsData {
        [FieldOffset(0x000)] public int UpdateState; // 0 initial, 1 request sent, 2 response received, 3 addon updated

        [FixedSizeArray<ItemData>(6)]
        [FieldOffset(0x008)] public fixed byte Items[6 * 0x80];

        [FieldOffset(0x308)] public int WeekStartTime;
        [FieldOffset(0x30C)] public byte FullDeliveryBonus;

        [FieldOffset(0x310)] public byte AddonOpened;
        [FieldOffset(0x311)] public byte Flags; // 0x1 - fully inited, 0x2 - addon dirty?, 0x4 - ?
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public unsafe partial struct ItemData {
        [FieldOffset(0x00)] public ushort CraftObjectId; // MJICraftworksObject sheet
        [FieldOffset(0x04)] public uint IconRowId;
        [FieldOffset(0x08)] public uint ItemRowId;
        [FieldOffset(0x10)] public Utf8String Name;
        [FieldOffset(0x78)] public byte NumShipped;
        [FieldOffset(0x79)] public byte NumRequired;
        [FieldOffset(0x7A)] public byte NumScheduled;
        [FieldOffset(0x7B)] public byte Reward;
        [FieldOffset(0x7C)] public ItemFlags Flags;
    }

    [Flags]
    public enum ItemFlags : byte {
        Initialized = 0x01,
        Shipped = 0x02,
        Bonus = 0x04,
    }
}
