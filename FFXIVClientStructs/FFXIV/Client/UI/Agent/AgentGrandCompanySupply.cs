using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.GrandCompanySupply)]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct AgentGrandCompanySupply {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x60)] public SupplyProvisioningData* SupplyProvisioningData;
    [FieldOffset(0x68)] public GrandCompanyItem* ItemArray;

    [FieldOffset(0x78)] public int NumItems;
    [FieldOffset(0x90)] public int SelectedTab;
}

[StructLayout(LayoutKind.Explicit, Size = 0x790)]
public unsafe partial struct SupplyProvisioningData {
    [FixedSizeArray<SupplyProvisioningItem>(8)]
    [FieldOffset(0x40)] public fixed byte SupplyData[0xA8 * 8];

    [FixedSizeArray<SupplyProvisioningItem>(3)]
    [FieldOffset(0x580)] public fixed byte ProvisioningData[0xA8 * 3];
}

[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public struct SupplyProvisioningItem {
    [FieldOffset(0x00)] public int ItemId;
    [FieldOffset(0x04)] public int ExpReward;
    [FieldOffset(0x08)] public int SealReward;

    [FieldOffset(0x1A)] public byte NumRequested;
    [FieldOffset(0x28)] public Utf8String ItemName;

    [FieldOffset(0x90)] public int ItemCategoryIconId; // eg, Bracelet IconId, Body IconId
}

/// <summary>
/// Positions 0-7 are supply items (CRP, BSM, ...)
/// Positions 8-10 are provisioning items (MIN, BTN, FSH)
/// Positions 11+ are expert delivery items
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public struct GrandCompanyItem {
    [FieldOffset(0x00)] public Utf8String ItemName;

    /// <summary>
    /// For supply and provisioning items: Always Inventory1 (even if you have none in your inventory).
    /// </summary>
    [FieldOffset(0x68)] public InventoryType Inventory;

    [FieldOffset(0x70)] public int IconID;
    [FieldOffset(0x74)] public int ExpReward;
    [FieldOffset(0x78)] public int SealReward;
    [FieldOffset(0x80)] public int NumPossessed;
    [FieldOffset(0x84)] public uint ItemId;
    [FieldOffset(0x8C)] public int Position; // position within AgentGrandCompanySupply.ItemArray
    [FieldOffset(0x90)] public int NumRequested;

    /// <summary>
    /// For supply and provisioning items: Level
    /// For expert delivery items: ItemLevel
    /// </summary>
    [FieldOffset(0x94)] public short ItemLevel;

    /// <summary>
    /// for supply and provisioning items: always 0.
    /// </summary>
    [FieldOffset(0x96)] public byte ItemUiCategory;
    [FieldOffset(0x97)] public byte Slot;
    [FieldOffset(0x9A)] public byte TurnInAvailable;
    [FieldOffset(0x9B)] public byte Bonus;

    public bool IsTurnInAvailable => TurnInAvailable == 0;
    public bool IsBonusReward => Bonus != 0;
}
