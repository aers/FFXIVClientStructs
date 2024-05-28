namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

[StructLayout(LayoutKind.Explicit, Size = 0x3888)]
[GenerateInterop]
public unsafe partial struct GameObjectManager {
    [FieldOffset(0x04)] public byte Active;
    [FieldOffset(0x18)][FixedSizeArray] internal FixedSizeArray599<Pointer<GameObject>> _objectList;
    [FieldOffset(0x12D0)][FixedSizeArray] internal FixedSizeArray599<Pointer<GameObject>> _objectListFiltered;
    [FieldOffset(0x2588)][FixedSizeArray] internal FixedSizeArray599<Pointer<GameObject>> _objectList3;
    [FieldOffset(0x3840)] public int ObjectListFilteredCount;
    [FieldOffset(0x3844)] public int ObjectList3Count;

    [StaticAddress("48 8D 35 ?? ?? ?? ?? 81 FA", 3)]
    public static partial GameObjectManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 75 12 48 FF C7")]
    public static partial GameObject* GetGameObjectByIndex(int index);
}
