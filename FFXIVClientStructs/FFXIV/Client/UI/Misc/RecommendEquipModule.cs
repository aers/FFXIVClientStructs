using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::RecommendEquipModule
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct RecommendEquipModule {
    public static RecommendEquipModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetRecommendEquipModule();
    }

    [FieldOffset(0x00)] public bool IsUpdating;
    [FieldOffset(0x01)] public bool IsSetupForDifferentClassJob;
    [FieldOffset(0x04)] public uint CurrentSlotIndex; // used as index in the update loop

    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray14<Pointer<InventoryItem>> _recommendedItems;
    [FieldOffset(0x08), CExporterIgnore] public InventoryItem* EquippedMainHand;
    [FieldOffset(0x10), CExporterIgnore] public InventoryItem* EquippedOffHand;
    [FieldOffset(0x18), CExporterIgnore] public InventoryItem* EquippedHead;
    [FieldOffset(0x20), CExporterIgnore] public InventoryItem* EquippedBody;
    [FieldOffset(0x28), CExporterIgnore] public InventoryItem* EquippedHands;
    [FieldOffset(0x30), CExporterIgnore] public InventoryItem* EquippedWaist;
    [FieldOffset(0x38), CExporterIgnore] public InventoryItem* EquippedLegs;
    [FieldOffset(0x40), CExporterIgnore] public InventoryItem* EquippedFeet;
    [FieldOffset(0x48), CExporterIgnore] public InventoryItem* EquippedEars;
    [FieldOffset(0x50), CExporterIgnore] public InventoryItem* EquippedNeck;
    [FieldOffset(0x58), CExporterIgnore] public InventoryItem* EquippedWrist;
    [FieldOffset(0x60), CExporterIgnore] public InventoryItem* EquippedLeftRing;
    [FieldOffset(0x68), CExporterIgnore] public InventoryItem* EquippedRightRing;
    [FieldOffset(0x70), CExporterIgnore] public InventoryItem* EquippedSoulCrystal;
    [FieldOffset(0x78)] public ushort Level;
    [FieldOffset(0x7A)] public byte Race;
    [FieldOffset(0x7B)] public byte Sex;
    [FieldOffset(0x7C)] public byte ClassJob;
    [FieldOffset(0x7D)] public byte GrandCompany;
    [FieldOffset(0x7E)] public byte PvpRank;

    [MemberFunction("41 54 41 55 41 56 41 57 48 83 EC 28 80 39 00")]
    public partial bool Setup(byte race, byte sex, ushort level, byte classJob, byte grandCompany, byte pvpRank);

    // 7.0: inlined in SetupForClassJob
    // [MemberFunction("")]
    // public partial bool SetupFromPlayerState();

    /// <remarks> Calls SetupFromPlayerState internally. </remarks>
    [MemberFunction("40 56 41 54 41 55 41 57 48 83 EC 48 48 8B F1")]
    public partial bool SetupForClassJob(byte classJobId);

    [MemberFunction("E8 ?? ?? ?? ?? EB 07 C7 43 ?? ?? ?? ?? ?? 48 8B 03")]
    public partial void EquipRecommendedGear();

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 33 F6 66 C7 01")]
    public partial void Clear();
}
