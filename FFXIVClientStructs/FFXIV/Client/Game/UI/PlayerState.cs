namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

//ctor 40 53 48 83 EC 20 48 8B D9 48 8D 81 ?? ?? ?? ?? BA
[StructLayout(LayoutKind.Explicit, Size = 0x798)]
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

    [FieldOffset(0x45C)] public short PlayerCommendations;

    [FieldOffset(0x712)] public fixed ushort DesynthesisLevels[8];
    
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E9 ?? ?? ?? ?? CC 48 8B C1")]
    public static partial PlayerState* Instance();

    public float GetDesynthesisLevel(uint classJobId)
    {
        return classJobId is < 8 or > 15 ? 0 : DesynthesisLevels[classJobId - 8] / 100f;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A 86")]
    public partial byte GetGrandCompanyRank();

    [MemberFunction("E8 ?? ?? ?? ?? BE ?? ?? ?? ?? 84 C0 75 0C")]
    public partial byte GetBeastTribeRank(byte beastTribeIndex);

    [MemberFunction("45 33 C9 48 81 C1 ?? ?? ?? ?? 45 8D 51 02", IsStatic = true, IsPrivate = true)]
    private static partial ulong GetBeastTribeAllowance(void* ptr);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B E8 BB", IsStatic = true, IsPrivate = true)]
    private static partial void* GetBeastTribeAllowancePointer();

    public static ulong GetBeastTribeAllowance() {
        return GetBeastTribeAllowance(GetBeastTribeAllowancePointer());
    }

    /// <summary>
    /// Check if a specific mount has been unlocked by the player.
    /// </summary>
    /// <param name="mountId">The ID of the mount to look up.</param>
    /// <returns>Returns true if the mount has been unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 5C 8B CB")]
    public partial bool IsMountUnlocked(uint mountId);

    /// <summary>
    /// Check if a specific ornament (fashion accessory) has been unlocked by the player.
    /// </summary>
    /// <param name="ornamentId">The ID of the ornament to look up.</param>
    /// <returns>Returns true if the ornament has been unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 41 0F B6 CE")]
    public partial bool IsOrnamentUnlocked(uint ornamentId);

    /// <summary>
    /// Check if a specific orchestrion roll has been unlocked by the player.
    /// </summary>
    /// <param name="rollId">The ID of the roll to look up.</param>
    /// <returns>Returns true if the roll has been unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 44 3B 08")]
    public partial bool IsOrchestrionRollUnlocked(uint rollId);

    /// <summary>
    /// Check if a Secret Recipe Book (DoH Master Tome) is unlocked and (indirectly) if the player can craft recipes
    /// from that specific book.
    /// </summary>
    /// <param name="tomeId">The ID of the book to check for. Can be retrieved from the SecretRecipeBook sheet.</param>
    /// <returns>Returns true if the book is unlocked.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 4D 9A")]
    public partial bool IsSecretRecipeBookUnlocked(uint tomeId);

    /// <summary>
    /// Check if a Folklore Book (DoL Master Tome) is unlocked and (indirectly) if the player can find legendary nodes
    /// revealed by that book.
    /// </summary>
    /// <param name="tomeId">The ID of the book to check for. Can be retrieved from GatheringSubCategory.Division</param>
    /// <returns>Returns true if the book is unlocked.</returns>
    [MemberFunction("E9 ?? ?? ?? ?? 0F B7 57 70")]
    public partial bool IsFolkloreBookUnlocked(uint tomeId);

    /// <summary>
    /// Check if a specific McGuffin (Collectible/Curiosity) has been unlocked by the player.
    /// </summary>
    /// <param name="mcGuffinId">The ID of the McGuffin to look up, generally from the McGuffin sheet.</param>
    /// <returns>Returns true if the McGuffin has been unlocked.</returns>
    [MemberFunction("8D 42 ?? 3C ?? 77 ?? 4C 8B 89")]
    public partial bool IsMcGuffinUnlocked(uint mcGuffinId);

    /// <summary>
    /// Check if a particular Framer's Kit is unlocked and can be used.
    /// </summary>
    /// <remarks>
    /// How IDs are located is a bit weird and not necessarily fully understood at time of writing. They appear on Framer
    /// Kit items in the AdditionalData field, and at +0 in BannerCondition EXDs when +0xE == 9.
    /// </remarks>
    /// <param name="kitId">The kit ID to check for.</param>
    /// <returns>Returns true if the framer's kit is unlocked.</returns>
    [MemberFunction("4C 8B C9 66 83 FA ?? 73")]
    public partial bool IsFramersKitUnlocked(uint kitId);
}