using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// ctor: E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 59 ?? 48 89 01 E8 
[StructLayout(LayoutKind.Explicit, Size = 0x1A8)]
public unsafe partial struct DrawDataContainer {
    [FieldOffset(0x000)] public void** Vtable;
    [FieldOffset(0x008)] public Character* Parent;

    [FixedSizeArray<DrawObjectData>(3)]
    [FieldOffset(0x010)] public fixed byte WeaponData[3 * DrawObjectData.Size];

    public ref DrawObjectData Weapon(WeaponSlot which) {
        fixed (byte* ptr = WeaponData)
            return ref ((DrawObjectData*)ptr)[(int) which];
    }

    [Obsolete("Use Weapon(WeaponSlot.MainHand).ModelId", true)]
    [FieldOffset(0x010)] public WeaponModelId MainHandModel;
    [Obsolete("Use Weapon(WeaponSlot.MainHand).State", true)]
    [FieldOffset(0x06C)] public byte MainHandState;
    [Obsolete("Use Weapon(WeaponSlot.MainHand).Flags1", true)]
    [FieldOffset(0x072)] public ushort MainHandFlags1;
    [Obsolete("Use Weapon(WeaponSlot.MainHand).Flags2", true)]
    [FieldOffset(0x074)] public byte MainHandFlags2;

    [Obsolete("Use Weapon(WeaponSlot.OffHand).ModelId", true)]
    [FieldOffset(0x080)] public WeaponModelId OffHandModel;
    [Obsolete("Use Weapon(WeaponSlot.OffHand).State", true)]
    [FieldOffset(0x0DC)] public byte OffHandState;
    [Obsolete("Use Weapon(WeaponSlot.OffHand).Flags1", true)]
    [FieldOffset(0x0E2)] public ushort OffHandFlags1;
    [Obsolete("Use Weapon(WeaponSlot.OffHand).Flags2", true)]
    [FieldOffset(0x0E4)] public byte OffHandFlags2;

    [Obsolete("Use Weapon(WeaponSlot.Unk).ModelId", true)]
    [FieldOffset(0x0F0)] public WeaponModelId UnkE0Model;
    [Obsolete("Use Weapon(WeaponSlot.Unk).Flags1", true)]
    [FieldOffset(0x152)] public ushort Unk144Flags1;
    [Obsolete("Use Weapon(WeaponSlot.Unk).Flags2", true)]
    [FieldOffset(0x154)] public byte Unk144Flags2;

    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x00)] public EquipmentModelId Head;
    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x04)] public EquipmentModelId Top;
    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x08)] public EquipmentModelId Arms;
    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x0C)] public EquipmentModelId Legs;
    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x10)] public EquipmentModelId Feet;
    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x14)] public EquipmentModelId Ear;
    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x18)] public EquipmentModelId Neck;
    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x1C)] public EquipmentModelId Wrist;
    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x20)] public EquipmentModelId RFinger;
    [FieldOffset(0x010 + 3 * DrawObjectData.Size + 0x24)] public EquipmentModelId LFinger;

    [FieldOffset(0x188)] public CustomizeData CustomizeData;

    [FieldOffset(0x1A2)] public uint Unk18A;
    [FieldOffset(0x1A6)] public byte Flags1;
    [FieldOffset(0x1B7)] public byte Flags2;

    [MemberFunction("E8 ?? ?? ?? ?? 41 B5 ?? FF C6")]
    public partial void LoadEquipment(EquipmentSlot slot, EquipmentModelId* modelId, bool force);


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
        get => (Flags2 & 0x10) == 0x10;
        set => Flags2 = (byte)(value ? Flags2 | 0x10 : Flags2 & ~0x10);
    }

    [Obsolete("Use WeaponSpan[0].IsHidden", true)]
    public bool IsMainHandHidden {
        get => (Weapon(WeaponSlot.MainHand).State & 0x02) == 0x02;
        set => Weapon(WeaponSlot.MainHand).State = (byte)(value ? Weapon(WeaponSlot.MainHand).State | 0x02 : Weapon(WeaponSlot.MainHand).State & ~0x02);
    }

    [Obsolete("Use WeaponSpan[1].IsHidden", true)]
    public bool IsOffHandHidden {
        get => (Weapon(WeaponSlot.OffHand).State & 0x02) == 0x02;
        set => Weapon(WeaponSlot.OffHand).State = (byte)(value ? Weapon(WeaponSlot.OffHand).State | 0x02 : Weapon(WeaponSlot.OffHand).State & ~0x02);
    }
}



// ctor: E8 ?? ?? ?? ?? 48 8B E8 EB ?? 33 ED 48 89 AB
[StructLayout(LayoutKind.Explicit, Size = Size)]
public unsafe partial struct DrawObjectData {
    public const int Size = 0x70;

    [FieldOffset(0x00)] public WeaponModelId ModelId;
    [FieldOffset(0x10)] public void** VTable;
    [FieldOffset(0x18)] public DrawObject* DrawObject;
    [FieldOffset(0x5C)] public byte State;
    [FieldOffset(0x62)] public ushort Flags1;
    [FieldOffset(0x64)] public byte Flags2;

    public bool IsHidden {
        get => (State & 0x02) == 0x02;
        set => State = (byte)(value ? State | 0x02 : State & ~0x02);
    }
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
