namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

[StructLayout(LayoutKind.Explicit, Size = 0x2810)]
public unsafe partial struct GameObjectManager
{
    [FieldOffset(0x04)] public byte Active;
    [FieldOffset(0x18)] public fixed long ObjectList[426]; // size 426 * 8
    [FieldOffset(0xD68)] public fixed long ObjectListFiltered[426];
    [FieldOffset(0x1AB8)] public fixed long ObjectList3[426];
    [FieldOffset(0x2808)] public int ObjectListFilteredCount;
    [FieldOffset(0x280C)] public int ObjectList3Count;

    [StaticAddress("48 8D 35 ?? ?? ?? ?? 81 FA")]
    public static partial GameObjectManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 75 12 48 FF C7", IsStatic = true)]
    public static partial GameObject* GetGameObjectByIndex(int index);
}
