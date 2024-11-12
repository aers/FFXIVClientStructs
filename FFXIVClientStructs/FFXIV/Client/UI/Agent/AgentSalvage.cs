using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentSalvage
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Salvage)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x438)]
public unsafe partial struct AgentSalvage {

    [FieldOffset(0x30)] public SalvageItemCategory SelectedCategory;
    [FieldOffset(0x38)] public SalvageListItem* ItemList;
    [FieldOffset(0x40)] public Utf8String TextCarpenter;
    [FieldOffset(0xA8)] public Utf8String TextBlacksmith;
    [FieldOffset(0x110)] public Utf8String TextArmourer;
    [FieldOffset(0x178)] public Utf8String TextGoldsmith;
    [FieldOffset(0x1E0)] public Utf8String TextLeatherworker;
    [FieldOffset(0x248)] public Utf8String TextWeaver;
    [FieldOffset(0x2B0)] public Utf8String TextAlchemist;
    [FieldOffset(0x318)] public Utf8String TextCulinarian;

    [FieldOffset(0x380)] public uint ItemCount;
    // [FieldOffset(0x384)] public uint Unknown1; // 0x79 before desynth
    // [FieldOffset(0x38C)] public uint Unknown2; // 0x79 after desynth

    [FieldOffset(0x390)] public InventoryItem* DesynthItemSlot;
    [FieldOffset(0x398)] public SalvageResult DesynthItem;

    [FieldOffset(0x3A0)] public Utf8String TextQuantity;
    // [FieldOffset(0x408)] public byte Unknown3; // 0xC8
    [FieldOffset(0x409)] public bool IsSalvageResultAddonOpen;

    [FieldOffset(0x40C)] public uint DesynthItemId;
    [FieldOffset(0x410), FixedSizeArray] internal FixedSizeArray3<SalvageResult> _desynthResults;

    [MemberFunction("E8 ?? ?? ?? ?? EB 2A 48 8B 06")]
    public partial void ItemListRefresh(); // TODO: missing bool parameter

    [MemberFunction("E8 ?? ?? ?? ?? 41 81 BF ?? ?? ?? ?? ?? ?? ?? ?? 7D 1B")]
    public partial void ItemListAdd(bool meetsLevelRequirement, InventoryType containerId, int containerSlot, uint itemId, void* exdRow, uint quantity);

    public enum SalvageItemCategory {
        InventoryEquipment,
        InventoryHousing,
        ArmouryMainOff,
        ArmouryHeadBodyHands,
        ArmouryLegsFeet,
        ArmouryNeckEars,
        ArmouryWristsRings,
        Equipped,
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public struct SalvageListItem {
        [FieldOffset(0x00)] public Utf8String Name;
        [FieldOffset(0x68)] public InventoryType InventoryType;
        [FieldOffset(0x6C)] public uint InventorySlot;
        [FieldOffset(0x70)] public uint Quantity;
        [FieldOffset(0x74)] public uint ItemId;
        [FieldOffset(0x78)] public uint ClassJob;
        [FieldOffset(0x7C)] public byte Flags;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct SalvageResult {
    [FieldOffset(0x00)] public uint ItemId;
    [FieldOffset(0x04)] public int Quantity;
}
