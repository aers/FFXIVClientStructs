using FFXIVClientStructs.FFXIV.Client.Game;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc; 

// ctor 48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 33 ED 48 8D 59 08 4C 8B F1

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct RecommendEquipModule {
    [FieldOffset(0x00)] public uint Unk00;
    [FieldOffset(0x04)] public uint SlotCount; // maybe?

    [FieldOffset(0x08)] public InventoryItem* EquippedMainHand;
    [FieldOffset(0x10)] public InventoryItem* EquippedOffHand;
    [FieldOffset(0x18)] public InventoryItem* EquippedHead;
    [FieldOffset(0x20)] public InventoryItem* EquippedBody;
    [FieldOffset(0x28)] public InventoryItem* EquippedHands;
    [FieldOffset(0x30)] public InventoryItem* EquippedWaist; // wtf are you still doing here
    [FieldOffset(0x38)] public InventoryItem* EquippedLegs;
    [FieldOffset(0x40)] public InventoryItem* EquippedFeet;
    [FieldOffset(0x48)] public InventoryItem* EquippedEars;
    [FieldOffset(0x50)] public InventoryItem* EquippedNeck;
    [FieldOffset(0x58)] public InventoryItem* EquippedWrist;
    [FieldOffset(0x60)] public InventoryItem* EquippedLeftRing;
    [FieldOffset(0x68)] public InventoryItem* EquippedRightRing;
    [FieldOffset(0x70)] public InventoryItem* EquippedSoulCrystal;
    [FieldOffset(0x78)] public void* Unk00_15;
    [FieldOffset(0x78)] public ushort Level;
    [FieldOffset(0x7A)] public byte Unk7A;
    [FieldOffset(0x7B)] public byte Unk7B;
    [FieldOffset(0x7C)] public byte ClassJob;
    [FieldOffset(0x7D)] public byte Unk7D;
    [FieldOffset(0x7E)] public byte Unk7E;
    
    [MemberFunction("E8 ?? ?? ?? ?? BB ?? ?? ?? ?? 41 C6 46")]
    public partial bool SetupRecommendedGear();
    
    [MemberFunction("E8 ?? ?? ?? ?? EB 07 C7 43 ?? ?? ?? ?? ?? 48 8B 03")]
    public partial void EquipRecommendedGear();
}
