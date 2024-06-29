using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::DrawDataContainer
//   Client::Game::Character::ContainerInterface
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 59 ?? 48 89 01 E8"
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
public unsafe partial struct DrawDataContainer {
    [FieldOffset(0x010), FixedSizeArray] internal FixedSizeArray3<DrawObjectData> _weaponData;

    [UnscopedRef]
    public ref DrawObjectData Weapon(WeaponSlot which) {
        return ref WeaponData[(int)which];
    }

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

    [FieldOffset(0x1A6)] public byte Flags1;
    [FieldOffset(0x1A7)] public byte Flags2;

    [FieldOffset(0x1D0), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;

    [MemberFunction("E8 ?? ?? ?? ?? B1 01 41 FF C6")]
    public partial void LoadEquipment(EquipmentSlot slot, EquipmentModelId* modelId, bool force);


    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 45 7F")]
    public partial void LoadWeapon(WeaponSlot slot, WeaponModelId weaponData, byte redrawOnEquality, byte unk2, byte skipGameObject, byte unk4);

    /// <summary>
    /// Called when Hide/Display Weapons when sheathed is toggled or /displayarms is used.
    /// </summary>
    /// <param name="hide">When false, weapons will be turned visible, when true, they will be hidden.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 46 54 0F BA E0 08")]
    public partial void HideWeapons(bool hide);

    /// <summary>
    /// Called when Hide/Display Headgear is toggled or /displayhead is used.
    /// </summary>
    /// <param name="unk">Almost always 0, but sometimes not?</param>
    /// <param name="hide">When false, the headgear will be turned visible, when true it will be hidden.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 55 C9")]
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
}

// ctor: "E8 ?? ?? ?? ?? 48 8B E8 EB ?? 33 ED 48 89 AB"
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct DrawObjectData {
    public const int Size = 0x70;

    [FieldOffset(0x00)] public WeaponModelId ModelId;
    [FieldOffset(0x18)] public DrawObject* DrawObject;
    [FieldOffset(0x60)] public byte State;
    [FieldOffset(0x62)] public ushort Flags1;
    [FieldOffset(0x64)] public byte Flags2;

    public bool IsHidden {
        get => (State & 0x02) == 0x02;
        set => State = (byte)(value ? State | 0x02 : State & ~0x02);
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1A)]
public unsafe partial struct CustomizeData {
    [FieldOffset(0x00), CExportIgnore, FixedSizeArray] internal FixedSizeArray26<byte> _data;

    [FieldOffset(0x00)] public byte Race;
    [FieldOffset(0x01)] public byte Sex;
    [FieldOffset(0x02)] public byte BodyType;
    [FieldOffset(0x03)] public byte Height;
    [FieldOffset(0x04)] public byte Tribe;
    [FieldOffset(0x05)] public byte Face;
    [FieldOffset(0x06)] public byte Hairstyle;
    // 0x07: Highlights
    [FieldOffset(0x08)] public byte SkinColor;
    [FieldOffset(0x09)] public byte EyeColorRight;
    [FieldOffset(0x0A)] public byte HairColor;
    [FieldOffset(0x0B)] public byte HighlightsColor;
    // 0x0C: FacialFeature1-7, LegacyTattoo
    [FieldOffset(0x0D)] public byte TattooColor;
    [FieldOffset(0x0E)] public byte Eyebrows;
    [FieldOffset(0x0F)] public byte EyeColorLeft;
    // 0x10: EyeShape, SmallIris
    [FieldOffset(0x11)] public byte Nose;
    [FieldOffset(0x12)] public byte Jaw;
    // 0x13: Mouth, Lipstick
    [FieldOffset(0x14)] public byte LipColorFurPattern;
    [FieldOffset(0x15)] public byte MuscleMass;
    [FieldOffset(0x16)] public byte TailShape;
    [FieldOffset(0x17)] public byte BustSize;
    // 0x18: FacePaint, FacePaintReversed
    [FieldOffset(0x19)] public byte FacePaintColor;

    public bool Highlights => (byte)(Data[0x07] & 0b_1000_0000) != 0;

    public bool FacialFeature1 => (byte)(Data[0x0C] & 0b_0000_0001) != 0;
    public bool FacialFeature2 => (byte)(Data[0x0C] & 0b_0000_0010) != 0;
    public bool FacialFeature3 => (byte)(Data[0x0C] & 0b_0000_0100) != 0;
    public bool FacialFeature4 => (byte)(Data[0x0C] & 0b_0000_1000) != 0;
    public bool FacialFeature5 => (byte)(Data[0x0C] & 0b_0001_0000) != 0;
    public bool FacialFeature6 => (byte)(Data[0x0C] & 0b_0010_0000) != 0;
    public bool FacialFeature7 => (byte)(Data[0x0C] & 0b_0100_0000) != 0;
    public bool LegacyTattoo => (byte)(Data[0x0C] & 0b_1000_0000) != 0;

    public byte EyeShape => (byte)(Data[0x10] & 0b_0111_1111);
    public bool SmallIris => (byte)(Data[0x10] & 0b_1000_0000) != 0;

    public byte Mouth => (byte)(Data[0x13] & 0b_0111_1111);
    public bool Lipstick => (byte)(Data[0x13] & 0b_1000_0000) != 0;

    public byte FacePaint => (byte)(Data[0x18] & 0b_0111_1111);
    public bool FacePaintReversed => (byte)(Data[0x18] & 0b_1000_0000) != 0;

    public byte this[int idx] => Data[idx];

    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 48 8D 42")]
    public partial bool NormalizeCustomizeData(CustomizeData* source);
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct WeaponModelId {
    [FieldOffset(0)] public ushort Id;
    [FieldOffset(2)] public ushort Type;
    [FieldOffset(4)] public ushort Variant;
    [FieldOffset(6)] public byte Stain;

    [FieldOffset(0), CExportIgnore] public ulong Value;
}

[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct EquipmentModelId {
    [FieldOffset(0)] public ushort Id;
    [FieldOffset(2)] public byte Variant;
    [FieldOffset(3)] public byte Stain;

    [FieldOffset(0), CExportIgnore] public uint Value;
}
