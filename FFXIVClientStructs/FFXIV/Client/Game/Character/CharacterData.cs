namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe struct CharacterData {
    [FieldOffset(0x0)] public void* vtbl;
    [FieldOffset(0x8)] public float ModelScale;
    [FieldOffset(0xC)] public int ModelCharaId;
    [FieldOffset(0x10)] public int ModelSkeletonId;
    [FieldOffset(0x14)] public int ModelCharaId_2; // == -1 -> return ModelCharaId
    [FieldOffset(0x18)] public int ModelSkeletonId_2; // == 0 -> return ModelSkeletonId

    [FieldOffset(0x1C)] public uint Health;
    [FieldOffset(0x20)] public uint MaxHealth;
    [FieldOffset(0x24)] public uint Mana;
    [FieldOffset(0x28)] public uint MaxMana;
    [FieldOffset(0x2C)] public ushort GatheringPoints;
    [FieldOffset(0x2E)] public ushort MaxGatheringPoints;
    [FieldOffset(0x30)] public ushort CraftingPoints;
    [FieldOffset(0x32)] public ushort MaxCraftingPoints;
    [FieldOffset(0x34)] public short TransformationId;
    [FieldOffset(0x36)] public short StatusEffectVFXId; // outdated since TitleID moved here
    [FieldOffset(0x36)] public ushort TitleID;

    [FieldOffset(0x3A)] public byte ClassJob;
    [FieldOffset(0x3B)] public byte Level;

    [FieldOffset(0x46)] public byte ShieldValue;

    [FieldOffset(0x48)] public byte OnlineStatus;
    [FieldOffset(0x49)] public byte Battalion; // used for determining friend/enemy state

    // 0x1, 0x2, 0x4, 0x8 = Unknown
    // 0x10 = IsHostile
    // 0x20 = InCombat 
    // 0x40 = OffHandDrawn
    [FieldOffset(0x4B)] public byte Flags1;

    // 0x1 = Unknown
    // 0x2 = Unknown (always on for some reason?)
    // 0x4 = Unknown
    // 0x8 = PartyMember
    // 0x10 = AllianceMember
    // 0x20 = Friend
    [FieldOffset(0x4C)] public byte Flags2;
}
