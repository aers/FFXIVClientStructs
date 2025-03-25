namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::NameCache
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x73B4)]
public unsafe partial struct NameCache {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 75 0D 32 C0", 3)]
    public static partial NameCache* Instance();

    /// <remarks> Used for SeString macros PcName, IfPcGender and IfPcName. Data is cleared when switching zones. </remarks>
    [FieldOffset(0), FixedSizeArray] internal FixedSizeArray200<EntityCacheEntry> _entityCache;
    [FieldOffset(0x3B60)] public int NextEntityCacheIndex;

    /// <remarks> Used for crafter names in item tooltips. </remarks>
    [FieldOffset(0x3B68), FixedSizeArray] internal FixedSizeArray200<ContentIdCacheEntry> _contentIdCache;
    [FieldOffset(0x73A8)] public int NextContentIdCacheIndex;
    [FieldOffset(0x73AC)] public bool IsRequestingName;
    [FieldOffset(0x73B0)] public float RequestTimeoutTimer;

    /// <remarks> If not cached, will return null. </remarks>
    [MemberFunction("40 53 48 83 EC 30 49 8B D8 4C 8D 44 24")]
    public partial CStringPointer GetNameByEntityId(uint entityId, byte* outSex = null);

    /// <remarks> If not cached, will look it up locally (PlayerState, GroupManager, CharacterManager). </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 75 0D 48 8D 05")]
    public partial bool TryGetCharacterInfoByEntityId(uint entityId, CharacterInfo* outCharacterInfo);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 45 33 D2 48 8D 41 44")]
    public partial void SaveCharacterInfoForEntityId(uint entityId, CharacterInfo* characterInfo);

    /// <remarks> If not cached, the name will be requested from the server! </remarks>
    [MemberFunction("40 53 48 83 EC 30 4C 8B D2 48 8B D9")]
    public partial CStringPointer GetNameByContentId(ulong contentId);

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 33 C9 45 33 C9"), GenerateStringOverloads]
    public partial void SetNameForContentId(ulong contentId, CStringPointer name);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x4C)]
    public partial struct EntityCacheEntry {
        [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;
        [FieldOffset(0x40)] public byte Sex;
        [FieldOffset(0x44)] public uint EntityId;
        [FieldOffset(0x48)] public short HomeWorldId;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public partial struct ContentIdCacheEntry {
        [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;
        [FieldOffset(0x40)] public ulong ContentId;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0B)]
    public struct CharacterInfo {
        [FieldOffset(0x00)] public CStringPointer Name;
        [FieldOffset(0x08)] public short HomeWorldId;
        [FieldOffset(0x0A)] public byte Sex;
    }
}
