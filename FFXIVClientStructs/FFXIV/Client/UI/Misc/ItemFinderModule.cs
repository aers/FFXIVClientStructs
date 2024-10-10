using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ItemFinderModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "48 89 5C 24 ?? 57 48 83 EC 20 33 FF 48 89 51 10 48 8D 05 ?? ?? ?? ?? 48 89 79 08 48 8B D9 48 89 01 48 89 79 18 4C 8D 05 ?? ?? ?? ?? 89 79 20 8D 57 0C 48 89 79 28 89 79 3C 48 83 C1 30 E8 ?? ?? ?? ?? 89 BB"
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x11D0)]
public unsafe partial struct ItemFinderModule {
    public static ItemFinderModule* Instance() => Framework.Instance()->GetUIModule()->GetItemFinderModule();

    [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray24<uint> _requestItemIds;
    [FieldOffset(0xA0)] public bool IsRequestUnfulfilled;
    [FieldOffset(0xA1)] public bool IsCabinetCached;
    [FieldOffset(0xA2)] public bool IsRetainerManagerReady; // only temporary set to true until request is complete
    [FieldOffset(0xA3)] public bool IsSaddleBagCached;
    [FieldOffset(0xA4)] public bool IsGlamourDresserCached;
    [FieldOffset(0xA5)] public bool ShouldResetInvalid; // only clears data if player does not meet criteria (for example: has glamour dresser NOT unlocked)
    [FieldOffset(0xA6)] public byte UnkA6;
    [FieldOffset(0xA7)] public byte UnkA7;
    [FieldOffset(0xA8)] public StdList<ulong> UpdatedRetainerIds;
    [FieldOffset(0xA8), Obsolete("Use UpdatedRetainerIds instead")] public nint Retainer;
    [FieldOffset(0xB0), Obsolete("Use UpdatedRetainerIds.LongCount instead")] public long RetainerCount;
    [FieldOffset(0xB8)] public StdMap<ulong, Pointer<ItemFinderRetainerInventory>> RetainerInventories;
    [FieldOffset(0xB8), Obsolete("Use RetainerInventories instead")] public nint RetainerInventory;
    [FieldOffset(0xC0), Obsolete("Use RetainerInventories.LongCount instead")] public long RetainerInventoryCount;
    [FieldOffset(0xC8), FixedSizeArray] internal FixedSizeArray70<uint> _saddleBagItemIds;
    [FieldOffset(0x1E0), FixedSizeArray] internal FixedSizeArray70<uint> _premiumSaddleBagItemIds;
    [FieldOffset(0x2F8), FixedSizeArray] internal FixedSizeArray70<ushort> _saddleBagItemCount;
    [FieldOffset(0x384), FixedSizeArray] internal FixedSizeArray70<ushort> _premiumSaddleBagItemCount;
    [FieldOffset(0x410), FixedSizeArray] internal FixedSizeArray800<uint> _glamourDresserItemIds;

    [FieldOffset(0x10A0)] public ItemFinderModuleResult* Result;

    /// <summary>
    /// Searches inventories for the specified item id and opens the Item Search List window to display the results.
    /// </summary>
    /// <param name="itemId">The Id of the item to search for.</param>
    /// <param name="includeHQAndCollectibles">If <c>true</c>, it also searches for the item id as HQ and collectible versions.</param>
    [MemberFunction("E8 ?? ?? ?? ?? C6 43 08 01 EB 59")]
    public partial void SearchForItem(uint itemId, bool includeHQAndCollectibles = true);

    /// <summary>
    /// Checks if a retainer has been summoned within the current game session, indicating weather the data within the <c>RetainerInventory</c> is loaded from the server or from local cache.
    /// </summary>
    /// <param name="retainerId">The Id of the retainer to check.</param>
    /// <returns>If <c>true</c>, the retainer has been summoned in the current session. Otherwise, the retainer inventory is from a client side cache.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 45 8D 46 EC")]
    public partial bool IsRetainerCurrent(ulong retainerId);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x478)]
public unsafe partial struct ItemFinderRetainerInventory {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray14<uint> _equippedItemIds;
    [FieldOffset(0x38), FixedSizeArray] internal FixedSizeArray175<uint> _itemIds;
    [FieldOffset(0x2F4), FixedSizeArray] internal FixedSizeArray175<ushort> _itemCount;
    [FieldOffset(0x452), FixedSizeArray] internal FixedSizeArray18<ushort> _crystalQuantities;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1F8)]
public unsafe struct ItemFinderModuleResult {
    [FieldOffset(0x00)] public Utf8String ItemName;
    [FieldOffset(0x68)] public Utf8String ItemNameHQ;
    [FieldOffset(0xD0)] public Utf8String ItemNameCollectible;
    [FieldOffset(0x138)] public int EquipmentSlot;
    [FieldOffset(0x13C)] public int ArmouryChestCategory;
    [FieldOffset(0x140)] public int ArmouryChestCount;
    [FieldOffset(0x144)] public int CrystalsCount;
    [FieldOffset(0x148)] public int InventoryPage1Count;
    [FieldOffset(0x14C)] public int InventoryPage2Count;
    [FieldOffset(0x150)] public int InventoryPage3Count;
    [FieldOffset(0x154)] public int InventoryPage4Count;
    [FieldOffset(0x158)] public int ArmoireCount;
    [FieldOffset(0x15C)] public int SaddleBagPage1Count;
    [FieldOffset(0x160)] public int SaddleBagPage2Count;
    [FieldOffset(0x164)] public int PremiumSaddleBagPage1Count;
    [FieldOffset(0x168)] public int PremiumSaddleBagPage2Count;
    [FieldOffset(0x16C)] public int GlamourDresserCount;
    [FieldOffset(0x170)] public int EquipmentSlotHQ;
    [FieldOffset(0x174)] public int ArmouryChestCategoryHQ;
    [FieldOffset(0x178)] public int ArmouryChestCountHQ;
    [FieldOffset(0x17C)] public int CrystalsCountHQ;
    [FieldOffset(0x180)] public int InventoryPage1CountHQ;
    [FieldOffset(0x184)] public int InventoryPage2CountHQ;
    [FieldOffset(0x188)] public int InventoryPage3CountHQ;
    [FieldOffset(0x18C)] public int InventoryPage4CountHQ;
    [FieldOffset(0x190)] public int ArmoireCountHQ;
    [FieldOffset(0x194)] public int SaddleBagPage1CountHQ;
    [FieldOffset(0x198)] public int SaddleBagPage2CountHQ;
    [FieldOffset(0x19C)] public int PremiumSaddleBagPage1CountHQ;
    [FieldOffset(0x1A0)] public int PremiumSaddleBagPage2CountHQ;
    [FieldOffset(0x1A4)] public int GlamourDresserCountHQ;
    [FieldOffset(0x1A8)] public int EquipmentSlotCollectible;
    [FieldOffset(0x1AC)] public int ArmouryChestCategoryCollectible;
    [FieldOffset(0x1B0)] public int ArmouryChestCountCollectible;
    [FieldOffset(0x1B4)] public int CrystalsCountCollectible;
    [FieldOffset(0x1B8)] public int InventoryPage1CountCollectible;
    [FieldOffset(0x1BC)] public int InventoryPage2CountCollectible;
    [FieldOffset(0x1C0)] public int InventoryPage3CountCollectible;
    [FieldOffset(0x1C4)] public int InventoryPage4CountCollectible;
    [FieldOffset(0x1C8)] public int ArmoireCountCollectible;
    [FieldOffset(0x1CC)] public int SaddleBagPage1CountCollectible;
    [FieldOffset(0x1D0)] public int SaddleBagPage2CountCollectible;
    [FieldOffset(0x1D4)] public int PremiumSaddleBagPage1CountCollectible;
    [FieldOffset(0x1D8)] public int PremiumSaddleBagPage2CountCollectible;
    [FieldOffset(0x1DC)] public int GlamourDresserCountCollectible;
    [FieldOffset(0x1E0)] public ItemFinderModuleRetainerResult** Retainer;
    [FieldOffset(0x1E8)] public long RetainerCount;
    [FieldOffset(0x1F0)] public bool ShowHQCount;
    [FieldOffset(0x1F1)] public byte Unk1F1;
    [FieldOffset(0x1F2)] public bool ShowCollectibleCount;
    [FieldOffset(0x1F3)] public byte Unk1F3;
}

[StructLayout(LayoutKind.Explicit, Size = 0x7C)]
public unsafe struct ItemFinderModuleRetainerResult {
    [FieldOffset(0x00)] public ItemFinderModuleRetainerResult* Next;

    [FieldOffset(0x20)] public long RetainerId;
    [FieldOffset(0x28)] public int EquipmentSlot;
    [FieldOffset(0x2C)] public int CrystalsCount;
    [FieldOffset(0x30)] public int Page1Count;
    [FieldOffset(0x34)] public int Page2Count;
    [FieldOffset(0x38)] public int Page3Count;
    [FieldOffset(0x3C)] public int Page4Count;
    [FieldOffset(0x40)] public int Page5Count;
    [FieldOffset(0x44)] public int EquipmentSlotHQ;
    [FieldOffset(0x48)] public int CrystalsCountHQ;
    [FieldOffset(0x4C)] public int Page1CountHQ;
    [FieldOffset(0x50)] public int Page2CountHQ;
    [FieldOffset(0x54)] public int Page3CountHQ;
    [FieldOffset(0x58)] public int Page4CountHQ;
    [FieldOffset(0x5C)] public int Page5CountHQ;
    [FieldOffset(0x60)] public int EquipmentSlotCollectible;
    [FieldOffset(0x64)] public int CrystalsCountCollectible;
    [FieldOffset(0x68)] public int Page1CountCollectible;
    [FieldOffset(0x6C)] public int Page2CountCollectible;
    [FieldOffset(0x70)] public int Page3CountCollectible;
    [FieldOffset(0x74)] public int Page4CountCollectible;
    [FieldOffset(0x78)] public int Page5CountCollectible;
}
