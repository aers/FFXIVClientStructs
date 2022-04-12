namespace FFXIVClientStructs.FFXIV.Client.Game.Character;

[StructLayout(LayoutKind.Explicit, Size = 0x338)]
public unsafe partial struct CharacterManager
{
    [StaticAddress("8B D0 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 3A")]
    public static partial CharacterManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 84 1D")]
    public partial BattleChara* LookupBattleCharaByObjectId(int objectId);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74 3A 0F B7 4C 24")]
    public partial BattleChara* LookupBattleCharaByName(string name, bool onlyPlayers = false, short world = -1);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 4D 20 48 89 44 24")]
    public partial BattleChara* LookupBuddyByOwnerObject(BattleChara* owner);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 EB ?? 83 FA")]
    public partial BattleChara* LookupPetByOwnerObject(BattleChara* owner);
}