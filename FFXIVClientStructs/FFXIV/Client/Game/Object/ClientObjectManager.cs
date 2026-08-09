using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::ClientObjectManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xFA0)]
public unsafe partial struct ClientObjectManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? C7 43 60 FF FF FF FF", 3)]
    public static partial ClientObjectManager* Instance();

    [FieldOffset(0x00)] public BattleChara* BattleCharaMemory;
    [FieldOffset(0x08)] public uint BattleCharaSize;
    [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray249<BattleCharaEntry> _battleCharas;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct BattleCharaEntry {
        [FieldOffset(0x00)] public BattleChara* BattleChara;
        [FieldOffset(0x08)] public ObjectKind ObjectKind;

        /// <remarks> Index in <see cref="BattleCharas"/>. </remarks>
        [FieldOffset(0x0C)] public byte Index;

        /// <remarks> Index in <see cref="BattleCharaMemory"/>. </remarks>
        [FieldOffset(0x0E)] public ushort MemoryIndex;
    }

    // TODO: change return type to int
    // TODO: change index type to int
    // TODO: change param type to bool with default false
    [MemberFunction("E8 ?? ?? ?? ?? 41 89 44 FC ??")]
    public partial uint CreateBattleCharacter(uint index = 0xFFFFFFFF, byte param = 0);

    // TODO: change return type to BattleChara*
    // TODO: change index type to int
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B C0 4D 85 C0")]
    public partial Character.Character* GetObjectByIndex(ushort index);

    // TODO: change return type to int
    [MemberFunction("E8 ?? ?? ?? ?? 8B E8 4C 8D 35")]
    public partial uint GetIndexByObject(GameObject* gameObject);

    // TODO: change index type to int
    // TODO: change param type to bool with default false
    [MemberFunction("E8 ?? ?? ?? ?? 41 C7 44 BE")]
    public partial void DeleteObjectByIndex(ushort index, byte param);

    // TODO: add param default value false
    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 48 8B CB 83 F8 FF")]
    public partial int CalculateNextAvailableIndex(bool param);

    [Obsolete("Use CalculateNextAvailableIndex overload with bool parameter")]
    public uint CalculateNextAvailableIndex() => (uint)CalculateNextAvailableIndex(false);
}
