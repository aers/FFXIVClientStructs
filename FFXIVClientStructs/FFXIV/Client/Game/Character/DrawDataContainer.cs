namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// ctor: E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 59 ?? 48 89 01 E8 
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct DrawDataContainer {
    [FieldOffset(0x000)] public void** Vtable;
    [FieldOffset(0x008)] public Character* Parent;

    [FieldOffset(0x010)] public WeaponModelId MainHandModel;
    [FieldOffset(0x020)] public DrawObjectData MainHand;
    [FieldOffset(0x06C)] public byte MainHandState;
    [FieldOffset(0x072)] public ushort MainHandFlags1;
    [FieldOffset(0x074)] public byte MainHandFlags2;

    [FieldOffset(0x078)] public WeaponModelId OffHandModel;
    [FieldOffset(0x088)] public DrawObjectData OffHand;
    [FieldOffset(0x0D4)] public byte OffHandState;
    [FieldOffset(0x0DA)] public ushort OffHandFlags1;
    [FieldOffset(0x0DC)] public byte OffHandFlags2;

    [FieldOffset(0x0E0)] public WeaponModelId UnkE0Model;
    [FieldOffset(0x0F0)] public DrawObjectData UnkF0;
    [FieldOffset(0x142)] public ushort Unk144Flags1;
    [FieldOffset(0x144)] public byte Unk144Flags2;

    [FieldOffset(0x148)] public EquipmentModelId Head;
    [FieldOffset(0x14C)] public EquipmentModelId Top;
    [FieldOffset(0x150)] public EquipmentModelId Arms;
    [FieldOffset(0x154)] public EquipmentModelId Legs;
    [FieldOffset(0x158)] public EquipmentModelId Feet;
    [FieldOffset(0x15C)] public EquipmentModelId Ear;
    [FieldOffset(0x160)] public EquipmentModelId Neck;
    [FieldOffset(0x164)] public EquipmentModelId Wrist;
    [FieldOffset(0x168)] public EquipmentModelId RFinger;
    [FieldOffset(0x16C)] public EquipmentModelId LFinger;

    [FieldOffset(0x170)] public CustomizeData CustomizeData;

    [FieldOffset(0x18A)] public uint Unk18A;
    [FieldOffset(0x18E)] public byte Flags1;
    [FieldOffset(0x18F)] public byte Flags2;

    [MemberFunction("E8 ?? ?? ?? ?? 41 B5 ?? FF C6")]
    public partial void LoadEquipment(EquipmentSlot slot, EquipmentModelId modelId, bool force);


    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 9E")]
    public partial void LoadWeapon(WeaponSlot slot, WeaponModelId weaponData, byte redrawOnEquality, byte unk2, byte skipGameObject, byte unk4);

    /// <summary>
    /// Called when Hide/Display Weapons when sheathed is toggled or /displayarms is used.
    /// </summary>
    /// <param name="hide">When false, weapons will be turned visible, when true, they will be hidden.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 86 ?? ?? ?? ?? A8 08")]
    public partial void HideWeapons(bool hide);

    /// <summary>
    /// Called when Hide/Display Headgear is toggled or /displayhead is used.
    /// </summary>
    /// <param name="unk">Almost always 0, but sometimes not?</param>
    /// <param name="hide">When false, the headgear will be turned visible, when true it will be hidden.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 45 85 F6 75 92")]
    public partial void HideHeadgear(uint unk, bool hide);

    /// <summary>
    /// Called when Manually Adjust Visor is toggled or /visor is used.
    /// </summary>
    /// <param name="state">When true, visor will be toggled on, when false it will be toggled off.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 97 ?? ?? ?? ?? 48 8B CF C0 EA")]
    public partial void SetVisor(bool state);

    public enum EquipmentSlot : uint {
        Head = 0,
        Body = 1,
        Hands = 2,
        Legs = 3,
        Feet = 4,
        Ears = 5,
        Neck = 6,
        Wrists = 7,
        RFinger = 8,
        LFinger = 9,
    }

    public enum WeaponSlot : uint {
        MainHand = 0,
        OffHand = 1,
        Unk = 2,
    }

    public bool IsHatHidden {
        get => (Flags1 & 0x01) == 0x01;
        set => Flags1 = (byte)(value ? Flags1 | 0x01 : Flags1 & ~0x01);
    }

    public bool IsWeaponHidden {
        get => (Flags2 & 0x01) == 0x01;
        set => Flags2 = (byte)(value ? Flags2 | 0x01 : Flags2 & ~0x01);
    }

    public bool IsVisorToggled {
        get => (Flags2 & 0x08) == 0x08;
        set => Flags2 = (byte)(value ? Flags2 | 0x08 : Flags2 & ~0x08);
    }

    private const byte WeaponHiddenFlag = 0x02;

    public bool IsMainHandHidden {
        get => (MainHandState & WeaponHiddenFlag) == WeaponHiddenFlag;
        set => MainHandState = (byte)(value ? MainHandState | WeaponHiddenFlag : MainHandState & ~WeaponHiddenFlag);
    }

    public bool IsOffHandHidden {
        get => (OffHandState & WeaponHiddenFlag) == WeaponHiddenFlag;
        set => OffHandState = (byte)(value ? OffHandState | WeaponHiddenFlag : OffHandState & ~WeaponHiddenFlag);
    }
}



// ctor: E8 ?? ?? ?? ?? 48 8B E8 EB ?? 33 ED 48 89 AB
[StructLayout(LayoutKind.Explicit, Size = 0x44)]
public unsafe partial struct DrawObjectData {

}

[StructLayout(LayoutKind.Explicit, Size = Count)]
public unsafe partial struct CustomizeData {
    private const int Count = 0x1A;

    [FieldOffset(0x00)] public fixed byte Data[Count];
    [FieldOffset(0x00)] public byte Race;
    [FieldOffset(0x01)] public byte Sex;
    [FieldOffset(0x02)] public byte BodyType;
    [FieldOffset(0x04)] public byte Clan;
    [FieldOffset(0x14)] public byte LipColorFurPattern;

    public byte this[int idx]
        => Data[idx];

    [MemberFunction("E8 ?? ?? ?? ?? 33 DB 48 8D 75")]
    public partial bool NormalizeCustomizeData(CustomizeData* source);
}



[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct WeaponModelId {
    [FieldOffset(0)] public ushort Id;
    [FieldOffset(2)] public ushort Type;
    [FieldOffset(4)] public ushort Variant;
    [FieldOffset(6)] public byte Stain;

    [FieldOffset(0)] public ulong Value;
}

[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct EquipmentModelId {
    [FieldOffset(0)] public ushort Id;
    [FieldOffset(2)] public byte Variant;
    [FieldOffset(3)] public byte Stain;

    [FieldOffset(0)] public uint Value;
}
