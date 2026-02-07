using System.Diagnostics.CodeAnalysis;
using FFXIVClientStructs.FFXIV.Client.Game.Network;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::DrawDataContainer
//   Client::Game::Character::ContainerInterface
[GenerateInterop]
[Inherits<ContainerInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x268)]
public unsafe partial struct DrawDataContainer {
    [FieldOffset(0x010), FixedSizeArray] internal FixedSizeArray3<DrawObjectData> _weaponData;
    [FieldOffset(0x1D0), FixedSizeArray] internal FixedSizeArray10<EquipmentModelId> _equipmentModelIds;
    [FieldOffset(0x220)] public CustomizeData CustomizeData;

    [BitField<bool>(nameof(IsHatHidden), 0)]
    [FieldOffset(0x23E)] public byte Flags1;
    [BitField<bool>(nameof(IsWeaponHidden), 0)]
    [BitField<bool>(nameof(IsVisorToggled), 4)]
    [BitField<bool>(nameof(VieraEarsHidden), 5)]
    [FieldOffset(0x23F)] public byte Flags2;
    [FieldOffset(0x240), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;

    [FieldOffset(0x258)] public CrestData FreeCompanyCrestData;
    [FieldOffset(0x260)] public byte FreeCompanyCrestBitfield; // & 0x01 for offhand weapon, & 0x02 for head, & 0x04 for top, ..., & 0x20 for feet

    [UnscopedRef] public ref DrawObjectData Weapon(WeaponSlot slot) => ref WeaponData[(int)slot];
    [UnscopedRef] public ref EquipmentModelId Equipment(EquipmentSlot slot) => ref EquipmentModelIds[(int)slot];

    [MemberFunction("E8 ?? ?? ?? ?? B1 ?? 41 FF C6")]
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

    [MemberFunction("44 0F B6 81 ?? ?? ?? ?? 41 0F B6 C0 41 80 E0 7F")]
    public partial void HideLegacyTattoo(bool hide);

    /// <summary>
    /// Called when Manually Adjust Visor is toggled or /visor is used.
    /// </summary>
    /// <param name="state">When true, visor will be toggled on, when false it will be toggled off.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B6 D6 48 8B CB")]
    public partial void SetVisor(bool state);

    /// <summary>
    /// Called when equipping facewear.
    /// </summary>
    /// <param name="index">The index of the glasses slot, usually 0.</param>
    /// <param name="id">Row ID from the Glasses sheet.</param>
    [MemberFunction("E8 ?? ?? ?? ?? EB 50 44 8B 03")]
    public partial void SetGlasses(int index, ushort id);

    /// <summary>
    /// Called when changing the visbility of Viera ears.
    /// </summary>
    /// <param name="hide">When false, the Viera ears are visible. When true they will be hidden.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 80 BF ?? ?? ?? ?? ?? 41 BD")]
    public partial void HideVieraEars(bool hide);

    [MemberFunction("48 89 5C 24 ?? 55 56 57 41 54 41 55 41 56 41 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 44 0F B6 B9")]
    public partial void LoadGearsetData(PacketPlayerGearsetData* gearsetData);

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
        Unk = 2, // TODO: CraftTool?
    }
}

// ctor E8 ?? ?? ?? ?? 48 8B E8 EB ?? 33 ED 48 89 AB
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct DrawObjectData {
    public const int Size = 0x70;

    [FieldOffset(0x00)] public WeaponModelId ModelId;
    [FieldOffset(0x18)] public DrawObject* DrawObject;
    [BitField<bool>(nameof(IsHidden), 1)]
    [FieldOffset(0x60)] public byte State;
    [FieldOffset(0x62)] public ushort Flags1;
    [FieldOffset(0x64)] public byte Flags2;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1A)]
public unsafe partial struct CustomizeData {
    [FieldOffset(0x00), CExporterIgnore, FixedSizeArray] internal FixedSizeArray26<byte> _data;

    [FieldOffset(0x00)] public byte Race;
    [FieldOffset(0x01)] public byte Sex;
    [FieldOffset(0x02)] public byte BodyType;
    [FieldOffset(0x03)] public byte Height;
    [FieldOffset(0x04)] public byte Tribe;
    [FieldOffset(0x05)] public byte Face;
    [FieldOffset(0x06)] public byte Hairstyle;
    [BitField<bool>(nameof(Highlights), 7)]
    [FieldOffset(0x07)] internal byte Data7;
    [FieldOffset(0x08)] public byte SkinColor;
    [FieldOffset(0x09)] public byte EyeColorRight;
    [FieldOffset(0x0A)] public byte HairColor;
    [FieldOffset(0x0B)] public byte HighlightsColor;
    [BitField<bool>(nameof(FacialFeature1), 0)]
    [BitField<bool>(nameof(FacialFeature2), 1)]
    [BitField<bool>(nameof(FacialFeature3), 2)]
    [BitField<bool>(nameof(FacialFeature4), 3)]
    [BitField<bool>(nameof(FacialFeature5), 4)]
    [BitField<bool>(nameof(FacialFeature6), 5)]
    [BitField<bool>(nameof(FacialFeature7), 6)]
    [BitField<bool>(nameof(LegacyTattoo), 7)]
    [FieldOffset(0x0C)] internal byte DataC;
    [FieldOffset(0x0D)] public byte TattooColor;
    [FieldOffset(0x0E)] public byte Eyebrows;
    [FieldOffset(0x0F)] public byte EyeColorLeft;
    [BitField<byte>(nameof(EyeShape), 0, 7)]
    [BitField<bool>(nameof(SmallIris), 7)]
    [FieldOffset(0x10)] internal byte Data10;
    [FieldOffset(0x11)] public byte Nose;
    [FieldOffset(0x12)] public byte Jaw;
    [BitField<byte>(nameof(Mouth), 0, 7)]
    [BitField<bool>(nameof(Lipstick), 7)]
    [FieldOffset(0x13)] internal byte Data13;
    [FieldOffset(0x14)] public byte LipColorFurPattern;
    [FieldOffset(0x15)] public byte MuscleMass;
    [FieldOffset(0x16)] public byte TailShape;
    [FieldOffset(0x17)] public byte BustSize;
    [BitField<byte>(nameof(FacePaint), 0, 7)]
    [BitField<bool>(nameof(FacePaintReversed), 7)]
    [FieldOffset(0x18)] internal byte Data18;
    [FieldOffset(0x19)] public byte FacePaintColor;

    public byte this[int idx] => Data[idx];

    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 48 8D 42")]
    public partial bool Normalize(CustomizeData* source);
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct WeaponModelId {
    [FieldOffset(0)] public ushort Id;
    [FieldOffset(2)] public ushort Type;
    [FieldOffset(4)] public ushort Variant;
    [FieldOffset(6)] public byte Stain0;
    [FieldOffset(7)] public byte Stain1;

    [FieldOffset(0), CExporterIgnore] public ulong Value;
}

[StructLayout(LayoutKind.Explicit, Size = 8)]
public struct EquipmentModelId {
    [FieldOffset(0)] public ushort Id;
    [FieldOffset(2)] public byte Variant;
    [FieldOffset(3)] public byte Stain0;
    [FieldOffset(4)] public byte Stain1;

    [FieldOffset(0), CExporterIgnore] public ulong Value;
}

[StructLayout(LayoutKind.Explicit, Size = 4)]
public struct LegacyEquipmentModelId {
    [FieldOffset(0)] public ushort Id;
    [FieldOffset(2)] public byte Variant;
    [FieldOffset(3)] public byte Stain;
    // Second Stain id is stored separately
}
