namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::RelicNote
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct RelicNote {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 48 8B F8 E8 ?? ?? ?? ?? 45 33 F6", 3)]
    public static partial RelicNote* Instance();

    [FieldOffset(0x08)] public byte RelicId;
    [FieldOffset(0x09)] public byte RelicNoteId;
    [FieldOffset(0x0A), FixedSizeArray] internal FixedSizeArray10<byte> _monsterProgress;
    [FieldOffset(0x14)] public int ObjectiveProgress;

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 54 41 55 41 56 41 57 48 83 EC ?? 48 8B DA 4C 8B F1")]
    public partial bool IsMonsterNoteTarget(Character.Character* chara);

    public byte GetMonsterProgress(int index)
        => index is > 9 or < 0 ? (byte)0 : MonsterProgress[index];

    public bool IsDungeonComplete(int index) {
        if (index is > 3 or < 0)
            return false;
        return (ObjectiveProgress & (1 << index)) != 0;
    }

    public bool IsFateComplete(int index) {
        if (index is > 3 or < 0)
            return false;
        return (ObjectiveProgress & (1 << (index + 4))) != 0;
    }

    public bool IsLeveComplete(int index) {
        if (index is > 3 or < 0)
            return false;
        return (ObjectiveProgress & (1 << (index + 7))) != 0;
    }
}
