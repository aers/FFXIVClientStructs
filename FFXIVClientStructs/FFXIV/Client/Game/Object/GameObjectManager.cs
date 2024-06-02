namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::GameObjectManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3888)]
public unsafe partial struct GameObjectManager {
    [FieldOffset(0x00)] public uint NextUpdateIndex; // rate limiting for updates per frame
    [FieldOffset(0x04)] public byte Active;
    [FieldOffset(0x18)] public Lists Objects;

    [StaticAddress("48 8D 35 ?? ?? ?? ?? 81 FA", 3)]
    public static partial GameObjectManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 75 12 48 FF C7")]
    public static partial GameObject* GetGameObjectByIndex(int index);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x3830)]
    public unsafe partial struct Lists {
        // sparse array containing all objects; some slots could be null
        // different ranges have different meaning:
        // 000-199: objects from CharacterManager at index 2*i and their dependendent objects (mounts, minions, etc) at index 2*i+1
        // 200-248: objects from ClientObjectManager
        // 249-288: objects from EventObjectManager?
        // 289-428: ?
        // 429-528: ?
        // 529-598: something MJI (island sanctuary) related
        [FieldOffset(0x0000), FixedSizeArray] internal FixedSizeArray599<Pointer<GameObject>> _all;

        // compact list of valid (non-null) objects, sorted by GetObjectID() result
        [FieldOffset(0x12B8), FixedSizeArray] internal FixedSizeArray599<Pointer<GameObject>> _filtered;

        // compact list of valid networked objects (non-null with EntityId != 0xE0000000), sorted by EntityId
        [FieldOffset(0x2570), FixedSizeArray] internal FixedSizeArray599<Pointer<GameObject>> _networked;

        [FieldOffset(0x3828)] public int FilteredCount;
        [FieldOffset(0x382C)] public int NetworkedCount;
    }
}
