// ReSharper disable once CheckNamespace
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::IndoorTerritory
//   Client::Game::HousingTerritory
[GenerateInterop]
[Inherits<HousingTerritory>]
[StructLayout(LayoutKind.Explicit, Size = 0x13150)]
public unsafe partial struct IndoorTerritory {
    [FieldOffset(0x10)] public HousingFurnitureManager FurnitureManager;

    [FieldOffset(0x125C0)] public ExcelSheetWaiter* ItemExcelSheetWaiter;
    [FieldOffset(0x125C8)] public ExcelSheet* ItemExcelSheet;
    [FieldOffset(0x125D0)] public HouseId HouseId; // Combines Ward, Plot, and Room
    [FieldOffset(0x125D8)] private uint Unk96A8;

    [FieldOffset(0x125E0)] public HousingTemporaryObject TemporaryObject;
    [FieldOffset(0x12620)] public HousingObject* TargetedHousingObject;
    [FieldOffset(0x12628)] public HousingObject* HoveredHousingObject;
    [FieldOffset(0x12630)] public HousingObject* MovingHousingObject;
    [FieldOffset(0x12638)] private uint Unk9708; // something layout related. same as OutdoorTerritory.Unk9B50
    [FieldOffset(0x1263C)] public uint CurrentFloor; // Might be int but was casted to uint
    [FieldOffset(0x12640)] public IndoorTerritoryUIEventListener UIEventListener1;
    [FieldOffset(0x12668)] public IndoorTerritoryUIEventListener UIEventListener2;
    [FieldOffset(0x12690)] public IndoorAreaLayoutData IndoorAreaLayoutData;

    [FieldOffset(0x12718)] private uint Unk97E8;

    [FieldOffset(0x12720)] private long Unk97F0;
    [FieldOffset(0x12728)] public Utf8String UnplacementText;
    [FieldOffset(0x12790)] public Utf8String ConfirmReleaseText; // Addon#6433
    [FieldOffset(0x127F8)] public byte HousingEmploymentNpcListRowId;
    [FieldOffset(0x127F9)] public byte HousingEmploymentNpcRace;

    // [FieldOffset(0x12818)] public StdSet/Map Vase(Flower)Data
    [FieldOffset(0x12828)] public IndoorTerritoryAquariumData AquariumData;
    [FieldOffset(0x12880)] public InventoryType StoreroomItemInventoryType;
    [FieldOffset(0x12884)] public short StoreroomItemInventorySlot;
    [FieldOffset(0x12886)] private bool StoreroomItemInventoryUnk;

    [FieldOffset(0x12890)] public Vector3 StoreroomItemPlacePosition;
    [FieldOffset(0x128A0)] public float StoreroomItemPlaceRotation;

    [FieldOffset(0x128A8)] private InventoryItem* UnkInventoryItem9978;

    [FieldOffset(0x128C0)] private InventoryItem* UnkInventoryItem9990; // retainer item?
    [FieldOffset(0x128C8)] private InventoryItem* UnkInventoryItem9998;

    [FieldOffset(0x128D0)] public byte InvertedBrightness;
    [FieldOffset(0x128D4)] public float BrightnessCurrent;
    [FieldOffset(0x128D8)] public float BrightnessTarget;
    [FieldOffset(0x128DC)] public float BrightnessTransitionSpeed;
    [FieldOffset(0x128E0)] public bool IsBrightnessTransitioning;

    [FieldOffset(0x128E4)] public bool SSAOEnable;
    [FieldOffset(0x128E5)] public byte SavedInvertedBrightness;
    [FieldOffset(0x128E6)] public bool SavedSSAOEnable;
    [FieldOffset(0x128E7)] private byte Unk99B7;
    [FieldOffset(0x128E8)] private byte Unk99B8;
    [FieldOffset(0x128E9)] private byte Unk99B9;
    [FieldOffset(0x128EA)] public bool ShowStoreroomTab; // in the "Indoor Furnishings" window

    [FieldOffset(0x128F0)] public HousingGuestBookData GuestBook;

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
