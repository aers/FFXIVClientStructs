namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

// Client::Game::Character::CharacterManager
//   Client::Game::Character::CharacterManagerInterface
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x390)]
[Inherits<CharacterManagerInterface>]
public unsafe partial struct CharacterManager {
    [StaticAddress("8B D0 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B D0", 5)]
    public static partial CharacterManager* Instance();

    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray100<Pointer<BattleChara>> _battleCharas;
    [FieldOffset(0x370)] public BattleChara* BattleCharaMemory;
    [FieldOffset(0x378)] public Companion* CompanionMemory;
    //used to calculate the minion address in CompanionMemory when adding a BattleChara
    [FieldOffset(0x380)] public int CompanionClassSize;
    [FieldOffset(0x384)] public int UpdateIndex;

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 84 3D ?? ?? ?? ??")]
    public partial BattleChara* LookupBattleCharaByEntityId(uint entityId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74 3A 0F B7 4C 24")]
    [GenerateStringOverloads]
    public partial BattleChara* LookupBattleCharaByName(CStringPointer name, bool onlyPlayers = false, short world = -1);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 4F 20 48 89 44 24")]
    public partial BattleChara* LookupBuddyByOwnerObject(BattleChara* owner);

    [MemberFunction("E8 ?? ?? ?? ?? EB 41 83 FF 1C")]
    public partial BattleChara* LookupPetByOwnerObject(BattleChara* owner);
}
