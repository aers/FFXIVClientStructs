// ReSharper disable once CheckNamespace
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::IndoorTerritory
//   Client::Game::HousingTerritory
[GenerateInterop]
[Inherits<HousingTerritory>]
[StructLayout(LayoutKind.Explicit, Size = 0xA220)]
public unsafe partial struct IndoorTerritory {
    [FieldOffset(0x10)] public HousingFurnitureManager FurnitureManager;
    [FieldOffset(0x10), Obsolete("Use FurnitureManager.FurnitureMemory or FurnitureVector"), FixedSizeArray] internal FixedSizeArray732<HousingFurniture> _furniture;
    [FieldOffset(0x8968), Obsolete("Use FurnitureManager.HousingObjectManager")] public HousingObjectManager HousingObjectManager;

    [FieldOffset(0x9690)] public ExcelSheetWaiter* ItemExcelSheetWaiter;
    [FieldOffset(0x9698)] public ExcelSheet* ItemExcelSheet;
    [FieldOffset(0x96A0)] public HouseId HouseId; // Combines Ward, Plot, and Room
    [FieldOffset(0x96A8)] public uint Unk96A8;

    [FieldOffset(0x96B0)] public HousingTemporaryObject TemporaryObject;
    [FieldOffset(0x96F0)] public HousingObject* TargetedHousingObject;
    [FieldOffset(0x96F8)] public HousingObject* HoveredHousingObject;
    [FieldOffset(0x9700)] public HousingObject* MovingHousingObject;
    [FieldOffset(0x9708)] public uint Unk9708; // something layout related. same as OutdoorTerritory.Unk9B50
    [FieldOffset(0x970C)] public uint CurrentFloor; // Might be int but was casted to uint
    [FieldOffset(0x9710)] public IndoorTerritoryUIEventListener UIEventListener1;
    [FieldOffset(0x9738)] public IndoorTerritoryUIEventListener UIEventListener2;
    [FieldOffset(0x9760)] public IndoorAreaLayoutData IndoorAreaLayoutData;

    [FieldOffset(0x97E8)] public uint Unk97E8;

    [FieldOffset(0x97F0)] public long Unk97F0;
    [FieldOffset(0x97F8)] public Utf8String UnplacementText;
    [FieldOffset(0x9860)] public Utf8String ConfirmReleaseText; // Addon#6433
    [FieldOffset(0x98C8)] public byte HousingEmploymentNpcListRowId;
    [FieldOffset(0x98C9)] public byte HousingEmploymentNpcRace;

    // [FieldOffset(0x98E8)] public StdSet/Map Vase(Flower)Data
    [FieldOffset(0x98F8)] public IndoorTerritoryAquariumData AquariumData;
    [FieldOffset(0x9950)] public InventoryType StoreroomItemInventoryType;
    [FieldOffset(0x9954)] public short StoreroomItemInventorySlot;
    [FieldOffset(0x9956)] public bool StoreroomItemInventoryUnk;

    [FieldOffset(0x9960)] public Vector3 StoreroomItemPlacePosition;
    [FieldOffset(0x9970)] public float StoreroomItemPlaceRotation;

    [FieldOffset(0x9978)] public InventoryItem* UnkInventoryItem9978;

    [FieldOffset(0x9990)] public InventoryItem* UnkInventoryItem9990; // retainer item?
    [FieldOffset(0x9998)] public InventoryItem* UnkInventoryItem9998;

    [FieldOffset(0x99A0)] public byte InvertedBrightness;
    [FieldOffset(0x99A4)] public float BrightnessCurrent;
    [FieldOffset(0x99A8)] public float BrightnessTarget;
    [FieldOffset(0x99AC)] public float BrightnessTransitionSpeed;
    [FieldOffset(0x99B0)] public bool IsBrightnessTransitioning;

    [FieldOffset(0x99B4)] public bool SSAOEnable;
    [FieldOffset(0x99B5)] public byte SavedInvertedBrightness;
    [FieldOffset(0x99B6)] public bool SavedSSAOEnable;
    [FieldOffset(0x99B7)] public byte Unk99B7;
    [FieldOffset(0x99B8)] public byte Unk99B8;
    [FieldOffset(0x99B9)] public byte Unk99B9;
    [FieldOffset(0x99BA)] public bool ShowStoreroomTab; // in the "Indoor Furnishings" window

    [FieldOffset(0x99C0)] public HousingGuestBookData GuestBook;

    [GenerateInterop]
    [Inherits<AtkModuleInterface.AtkEventInterface>] // technically Client::Game::HousingUIEventListener<Client::Game::IndoorTerritory>
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe partial struct IndoorTerritoryUIEventListener {
        [FieldOffset(0x10)] public IndoorTerritory* IndoorTerritory;
        [FieldOffset(0x18)] public InventoryItem* InventoryItem;
        [FieldOffset(0x20)] public uint AddonId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public struct IndoorTerritoryAquariumData {
        [FieldOffset(0x08)] public StdMap<uint, AquariumFishEntry> AquariumFishLookup; // key is ItemId
        [FieldOffset(0x18)] private HousingObjectManager.HousingObjectData HousingObjectData; // absolutely unsure if it's the same struct, but it looked like it

        [StructLayout(LayoutKind.Explicit, Size = 0x08)] // unsure with the size
        public struct AquariumFishEntry {
            [FieldOffset(0x00)] public uint AquariumFishRowId;
        }
    }
}
