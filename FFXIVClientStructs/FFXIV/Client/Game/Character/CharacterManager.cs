namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::CharacterManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe partial struct CharacterManager {
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray100<Pointer<BattleChara>> _battleCharas;
    [FieldOffset(0x320)] public BattleChara* BattleCharaMemory;
    [FieldOffset(0x328)] public Companion* CompanionMemory;
    //used to calculate the minion address in CompanionMemory when adding a BattleChara
    [FieldOffset(0x330)] public int CompanionClassSize;
    [FieldOffset(0x334)] public int UpdateIndex;

    [StaticAddress("8B D0 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B D0", 5)]
    public static partial CharacterManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 84 3D ?? ?? ?? ??")]
    public partial BattleChara* LookupBattleCharaByEntityId(uint entityId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74 3A 0F B7 4C 24")]
    [GenerateStringOverloads]
    public partial BattleChara* LookupBattleCharaByName(byte* name, bool onlyPlayers = false, short world = -1);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 E9 ?? ?? ?? ?? 83 FA 40")]
    public partial BattleChara* LookupBuddyByOwnerObject(BattleChara* owner);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 EB ?? 83 FA")]
    public partial BattleChara* LookupPetByOwnerObject(BattleChara* owner);
}
