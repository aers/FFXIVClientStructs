namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// ctor: E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 59 ?? 48 89 01 E8 
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct DrawDataContainer
{
    [FieldOffset(0x000)] public void** Vtable;
    [FieldOffset(0x008)] public void*  Unk8;

    [FieldOffset(0x010)] public WeaponModelId  MainHandModel;
    [FieldOffset(0x020)] public DrawObjectData MainHand;
    [FieldOffset(0x072)] public ushort         MainHandFlags1;
    [FieldOffset(0x074)] public byte           MainHandFlags2;

    [FieldOffset(0x078)] public WeaponModelId  OffHandModel;
    [FieldOffset(0x088)] public DrawObjectData OffHand;
    [FieldOffset(0x0DA)] public ushort         OffHandFlags1;
    [FieldOffset(0x0DC)] public byte           OffHandFlags2;

    [FieldOffset(0x0E0)] public WeaponModelId  UnkE0Model;
    [FieldOffset(0x0F0)] public DrawObjectData UnkF0;
    [FieldOffset(0x142)] public ushort         Unk144Flags1;
    [FieldOffset(0x144)] public byte           Unk144Flags2;

    [FieldOffset(0x148)] public EquipmentModelId Head;
    [FieldOffset(0x14C)] public EquipmentModelId Top;
    [FieldOffset(0x150)] public EquipmentModelId Arms;
    [FieldOffset(0x154)] public EquipmentModelId Legs;
    [FieldOffset(0x148)] public EquipmentModelId Feet;
    [FieldOffset(0x15C)] public EquipmentModelId Ear;
    [FieldOffset(0x160)] public EquipmentModelId Neck;
    [FieldOffset(0x164)] public EquipmentModelId Wrist;
    [FieldOffset(0x168)] public EquipmentModelId RFinger;
    [FieldOffset(0x16C)] public EquipmentModelId LFinger;

    [FieldOffset(0x170)] public CustomizeData CustomizeData;

    [FieldOffset(0x18A)] public uint Unk18A;
    [FieldOffset(0x18E)] public byte Flags1;
    [FieldOffset(0x18F)] public byte Flags2;


    [MemberFunction("E8 ?? ?? ?? ?? 33 DB BE")]
    public partial void LoadWeapon(WeaponSlot slot, WeaponModelId weaponData, byte redrawOnEquality, byte unk2, byte skipGameObject, byte unk4);

    public enum WeaponSlot : uint
    {
        MainHand = 0,
        OffHand = 1,
        Unk = 2,
    }
}


// ctor: E8 ?? ?? ?? ?? 48 8B E8 EB ?? 33 ED 48 89 AB
[StructLayout(LayoutKind.Explicit, Size = 0x44)]
public unsafe partial struct DrawObjectData
{

}

[StructLayout(LayoutKind.Sequential, Size = Count)]
public unsafe partial struct CustomizeData
{
    private const int Count = 0x1A;

    public fixed byte Data[Count];

    public byte this[int idx]
        => Data[idx];

    [MemberFunction("E8 ?? ?? ?? ?? 33 DB 48 8D 75")]
    public partial bool NormalizeCustomizeData(CustomizeData* source);
}



[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct WeaponModelId
{
    [FieldOffset(0)] public ushort Type;
    [FieldOffset(2)] public ushort Id;
    [FieldOffset(4)] public ushort Variant;
    [FieldOffset(6)] public byte   Stain;

    [FieldOffset(0)] public ulong  Value;
}

[StructLayout(LayoutKind.Explicit, Size=4)]
public struct EquipmentModelId
{
    [FieldOffset(0)] public ushort Id;
    [FieldOffset(2)] public byte   Variant;
    [FieldOffset(3)] public byte   Stain;

    [FieldOffset(0)] public uint   Value;
}