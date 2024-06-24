using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::RecommendEquipModule
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 33 ED 48 8D 59 08 4C 8B F1"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct RecommendEquipModule {
    public static RecommendEquipModule* Instance() => Framework.Instance()->GetUIModule()->GetRecommendEquipModule();

    [FieldOffset(0x00)] public bool IsUpdating;
    [FieldOffset(0x01)] public bool IsSetupForDifferentClassJob;
    [FieldOffset(0x04)] public uint CurrentSlotIndex; // used as index in the update loop

    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray14<Pointer<InventoryItem>> _recommendedItems;
    [FieldOffset(0x08), CExportIgnore] public InventoryItem* EquippedMainHand;
    [FieldOffset(0x10), CExportIgnore] public InventoryItem* EquippedOffHand;
    [FieldOffset(0x18), CExportIgnore] public InventoryItem* EquippedHead;
    [FieldOffset(0x20), CExportIgnore] public InventoryItem* EquippedBody;
    [FieldOffset(0x28), CExportIgnore] public InventoryItem* EquippedHands;
    [FieldOffset(0x30), CExportIgnore] public InventoryItem* EquippedWaist;
    [FieldOffset(0x38), CExportIgnore] public InventoryItem* EquippedLegs;
    [FieldOffset(0x40), CExportIgnore] public InventoryItem* EquippedFeet;
    [FieldOffset(0x48), CExportIgnore] public InventoryItem* EquippedEars;
    [FieldOffset(0x50), CExportIgnore] public InventoryItem* EquippedNeck;
    [FieldOffset(0x58), CExportIgnore] public InventoryItem* EquippedWrist;
    [FieldOffset(0x60), CExportIgnore] public InventoryItem* EquippedLeftRing;
    [FieldOffset(0x68), CExportIgnore] public InventoryItem* EquippedRightRing;
    [FieldOffset(0x70), CExportIgnore] public InventoryItem* EquippedSoulCrystal;
    [FieldOffset(0x78)] public ushort Level;
    [FieldOffset(0x7A)] public byte Race;
    [FieldOffset(0x7B)] public byte Sex;
    [FieldOffset(0x7C)] public byte ClassJob;
    [FieldOffset(0x7D)] public byte GrandCompany;
    [FieldOffset(0x7E)] public byte PvpRank;

    [MemberFunction("41 54 41 55 41 56 41 57 48 83 EC 28 80 39 00")]
    public partial bool Setup(byte race, byte sex, ushort level, byte classJob, byte grandCompany, byte pvpRank);

    [MemberFunction("41 54 41 55 41 56 41 57 48 83 EC 38 4C 8B F1")]
    public partial bool SetupFromPlayerState();

    /// <remarks> Calls SetupFromPlayerState internally. </remarks>
    [MemberFunction("40 56 41 54 41 55 41 57 48 83 EC 48 48 8B F1")]
    public partial bool SetupForClassJob(byte classJobId);

    [MemberFunction("E8 ?? ?? ?? ?? EB 07 C7 43 ?? ?? ?? ?? ?? 48 8B 03")]
    public partial void EquipRecommendedGear();

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 33 F6 66 C7 01")]
    public partial void Clear();
}
