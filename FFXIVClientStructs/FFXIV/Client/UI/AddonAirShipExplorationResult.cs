using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonAirShipExplorationResult
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("AirShipExplorationResult")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x5D68)]
public unsafe partial struct AddonAirShipExplorationResult {
    [FieldOffset(0x238)] private AtkResNode* RatingTimelineNode;
    [FieldOffset(0x240)] public AtkTextNode* RatingText;
    [FieldOffset(0x248)] private AtkResNode* ResultTimelineNode;
    [FieldOffset(0x250)] private AtkComponentBase* Unk250;
    [FieldOffset(0x258)] private AtkComponentBase* Unk258;
    [FieldOffset(0x260)] private AtkComponentTextNineGrid* Unk260;
    [FieldOffset(0x268)] private AtkComponentTextNineGrid* Unk268;
    [FieldOffset(0x270)] private AtkResNode* RewardsTimelineNode;

    [FieldOffset(0x278), FixedSizeArray] internal FixedSizeArray30<Pointer<AtkComponentBase>> _rewardSlots;
    [FieldOffset(0x368), FixedSizeArray] internal FixedSizeArray30<Pointer<AtkComponentIcon>> _rewardIcons;

    [FieldOffset(0x458)] public AtkComponentList* VoyageLogList;
    [FieldOffset(0x460)] public AtkTextNode* VoyageLogMeasureText;
    [FieldOffset(0x468)] public AtkComponentButton* RedeployButton;
    [FieldOffset(0x470)] public AtkComponentButton* FinalizeReportButton;

    [FieldOffset(0x478), FixedSizeArray] internal FixedSizeArray200<VoyageLogEntry> _voyageLogEntries;
    [FieldOffset(0x5BF8)] public uint VoyageLogEntryCount;
    [FieldOffset(0x5BFC), FixedSizeArray] internal FixedSizeArray30<RewardItemData> _rewardItems;
    [FieldOffset(0x5D64)] public uint RewardItemCount;

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct VoyageLogEntry {
        [FieldOffset(0x00)] public CStringPointer StringPtr;
        [FieldOffset(0x08)] public Utf8String String;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct RewardItemData {
        [FieldOffset(0x00)] public uint ItemId;
        [FieldOffset(0x04)] public uint Quantity;
        [FieldOffset(0x08)] private uint Unk08;
    }
}
