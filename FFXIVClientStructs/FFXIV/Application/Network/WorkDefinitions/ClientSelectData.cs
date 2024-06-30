using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::ClientSelectData
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public partial struct ClientSelectData {
    [FieldOffset(0x8), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _displayName;
    [FieldOffset(0x28)] public byte CurrentClass;
    // 1 byte padding
    [FieldOffset(0x2A), FixedSizeArray] internal FixedSizeArray32<ushort> _classLv;
    [FieldOffset(0x6A)] public byte Race;
    [FieldOffset(0x6B)] public byte Tribe;
    [FieldOffset(0x6C)] public byte Sex;
    [FieldOffset(0x6D)] public byte BirthMonth;
    [FieldOffset(0x6E)] public byte Birthday;
    [FieldOffset(0x6F)] public byte GuardianDeity;
    [FieldOffset(0x70)] public byte FirstClass;
    // 1 byte padding
    [FieldOffset(0x72)] public ushort ZoneId;
    [FieldOffset(0x74)] public ushort TerritoryType;
    [FieldOffset(0x76)] public ushort ContentFinderCondition;
    [FieldOffset(0x78)] public CustomizeData CustomizeData;
    // 6 bytes unknown
    [FieldOffset(0x98)] public ulong ModelMainWeapon;
    [FieldOffset(0xA0)] public ulong ModelSubWeapon;
    [FieldOffset(0xA8), FixedSizeArray] internal FixedSizeArray10<uint> _modelEquip;
    [FieldOffset(0xD0), FixedSizeArray] internal FixedSizeArray10<byte> _equipStain1;
    [FieldOffset(0xDA), FixedSizeArray] internal FixedSizeArray2<ushort> _glasses;

    [FieldOffset(0xE0)] public uint AdditionalTimeEndRemake; // presumably
    [FieldOffset(0xE4)] public uint RemakeFlag; // presumably
    [FieldOffset(0xE8)] public ClientSelectDataConfigFlags ConfigFlags;
    [FieldOffset(0xEA)] public byte VoiceId;
    [FieldOffset(0xEB)] public bool IsNewGame; // presumably
    [FieldOffset(0xEC), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _worldName; // presumably
    [FieldOffset(0x110)] public ulong LoginStatus; // presumably
    [FieldOffset(0x118)] public bool IsOutTerritory; // presumably
}

[Flags]
public enum ClientSelectDataConfigFlags : ushort {
    None = 0,
    HideHead = 0x01,
    HideWeapon = 0x02,
    HideLegacyMark = 0x04,
    // ? = 0x08,
    StoreNewItemsInArmouryChest = 0x10,
    StoreCraftedItemsInInventory = 0x20,
    CloseVisor = 0x40
    // ? = 0x80
}
