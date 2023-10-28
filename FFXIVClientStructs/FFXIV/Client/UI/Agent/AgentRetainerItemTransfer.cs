using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.RetainerItemTransfer)]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentRetainerItemTransfer {
    [FieldOffset(0x0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public AgentRetainerItemTransferData* Data;
}

[StructLayout(LayoutKind.Explicit, Size = 0x41E8)]
public unsafe partial struct AgentRetainerItemTransferData {
    [FieldOffset(0x00)] public int ItemCount;

    [FieldOffset(0x10), FixedSizeArray<DuplicateItemEntry>(140)] public fixed byte DuplicateItem[0x78 * 140];

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public struct DuplicateItemEntry {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public bool Exists;
        [FieldOffset(0x6C)] public bool IsEnabled;

        /// <summary>
        /// Item ID for the duplicate item.
        /// Note: Not always set, unsure why...
        /// </summary>
        [FieldOffset(0x70)] public uint ItemId;

        /// <summary>.
        /// ItemUiCategory Icon ID
        /// Note: Not always set, unsure why...
        /// </summary>
        [FieldOffset(0x74)] public uint UiCategoryIconId;
    }
}
