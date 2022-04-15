namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

//ctor 40 53 48 83 EC 20 48 8B D9 48 8D 81 ?? ?? ?? ?? BA
[StructLayout(LayoutKind.Explicit, Size = 0x778)]
public unsafe partial struct PlayerState
{
    [FieldOffset(0x00)] public byte IsLoaded;
    [FieldOffset(0x01)] public fixed byte CharacterName[64];
    [FieldOffset(0x54)] public uint ObjectId;
    [FieldOffset(0x58)] public ulong ContentId;

    [FieldOffset(0x6A)] public byte CurrentClassJobId;
    [FieldOffset(0x78)] public short CurrentLevel;

    [FieldOffset(0x7A)] public fixed short ClassJobLevelArray[30];
    [FieldOffset(0xB8)] public fixed int ClassJobExpArray[30];

    [FieldOffset(0x130)] public short SyncedLevel;
    [FieldOffset(0x132)] public byte IsLevelSynced;

    [FieldOffset(0x154)] public int BaseStrength;
    [FieldOffset(0x158)] public int BaseDexterity;
    [FieldOffset(0x15C)] public int BaseVitality;
    [FieldOffset(0x160)] public int BaseIntelligence;
    [FieldOffset(0x164)] public int BaseMind;
    [FieldOffset(0x168)] public int BasePiety;

    [FieldOffset(0x16C)] public fixed int Attributes[74];

    [FieldOffset(0x294)] public byte GrandCompany;
    [FieldOffset(0x295)] public byte GCRankMaelstrom;
    [FieldOffset(0x296)] public byte GCRankTwinAdders;
    [FieldOffset(0x297)] public byte GCRankImmortalFlames;

    [FieldOffset(0x298)] public byte HomeAetheryteId;
    [FieldOffset(0x299)] public byte FavouriteAetheryteCount;
    [FieldOffset(0x29A)] public fixed byte FavouriteAetheryteArray[4];
    [FieldOffset(0x29E)] public byte FreeAetheryteId;

    [FieldOffset(0x2A0)] public uint BaseRestedExperience;

    [FieldOffset(0x458)] public short PlayerCommendations;

    [FieldOffset(0x70A)] public fixed ushort DesynthesisLevels[8];

    public float GetDesynthesisLevel(uint classJobId)
    {
        return classJobId is < 8 or > 15 ? 0 : DesynthesisLevels[classJobId - 8] / 100f;
    }

    [MemberFunction("E8 ?? ?? ?? ?? BE ?? ?? ?? ?? 84 C0 75 0C")]
    public partial byte GetBeastTribeRank(byte beastTribeIndex);

    [MemberFunction("45 33 C9 48 81 C1 ?? ?? ?? ?? 45 8D 51 02", IsStatic = true, IsPrivate = true)]
    private static partial ulong GetBeastTribeAllowance(void* ptr);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B E8 BB", IsStatic = true, IsPrivate = true)]
    private static partial void* GetBeastTribeAllowancePointer();

    public static ulong GetBeastTribeAllowance() {
        return GetBeastTribeAllowance(GetBeastTribeAllowancePointer());
    }

}