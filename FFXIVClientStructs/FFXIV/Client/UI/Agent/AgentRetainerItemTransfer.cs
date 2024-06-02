using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRetainerItemTransfer
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.RetainerItemTransfer)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentRetainerItemTransfer {
    [FieldOffset(0x28)] public AgentRetainerItemTransferData* Data;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x41E8)]
public unsafe partial struct AgentRetainerItemTransferData {
    [FieldOffset(0x00)] public int ItemCount;

    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray140<DuplicateItemEntry> _duplicateItems;

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
