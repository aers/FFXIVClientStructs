namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::RelicNote
// size = 0x18
// ctor inlined in UIState
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct RelicNote
{
    [FieldOffset(0x08)] public byte RelicID;
    [FieldOffset(0x09)] public byte RelicNoteID;
    [FieldOffset(0x0A)] public fixed byte MonsterProgress[10];
    [FieldOffset(0x14)] public int ObjectiveProgress;

    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 84 C0 74 7E", 3)]
    public static partial RelicNote* Instance();

    public byte GetMonsterProgress(int index)
    {
        return index is > 9 or < 0 ? (byte) 0 : MonsterProgress[index];
    }

    public bool IsDungeonComplete(int index)
    {
        if (index is > 3 or < 0)
            return false;
        return (ObjectiveProgress & (1 << index)) != 0;
    }

    public bool IsFateComplete(int index)
    {
        if (index is > 3 or < 0)
            return false;
        return (ObjectiveProgress & (1 << (index + 4))) != 0;
    }

    public bool IsLeveComplete(int index)
    {
        if (index is > 3 or < 0)
            return false;
        return (ObjectiveProgress & (1 << (index + 7))) != 0;
    }
}