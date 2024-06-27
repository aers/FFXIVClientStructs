namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::GameObjectManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3888)]
public unsafe partial struct GameObjectManager {
    [FieldOffset(0x00)] public uint NextUpdateIndex; // rate limiting for updates per frame
    [FieldOffset(0x04)] public byte Active;
    [FieldOffset(0x18)] public ObjectArrays Objects;

    [StaticAddress("48 8D 35 ?? ?? ?? ?? 81 FA", 3)]
    public static partial GameObjectManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 14 24 49 8B CC 8B D8 FF 52 ?? 45 33 C9")]
    public static partial GameObject* GetGameObjectByIndex(int index);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x3830)]
    public unsafe partial struct ObjectArrays {
        // sparse array containing all objects; some slots could be null
        // different ranges have different meaning:
        // 000-199: objects from CharacterManager at index 2*i and their dependendent objects (mounts, minions, etc) at index 2*i+1
        // 200-248: objects from ClientObjectManager
        // 249-288: objects from EventObjectManager?
        // 289-428: ?
        // 429-528: ?
        // 529-598: something MJI (island sanctuary) related

        /// <summary>
        /// Pointers to GameObjects, sorted by ObjectIndex. Contains null pointers for inactive indexes.
        /// </summary>
        [FieldOffset(0x0000), FixedSizeArray] internal FixedSizeArray599<Pointer<GameObject>> _indexSorted;

        /// <summary>
        /// Pointers to active GameObjects, sorted by GameObject.GetGameObjectId().
        /// </summary>
        [FieldOffset(0x12B8), FixedSizeArray] internal FixedSizeArray599<Pointer<GameObject>> _gameObjectIdSorted;

        /// <summary>
        /// Pointers to active GameObjects with a valid GameObject.EntityId (!= E0000000), sorted by EntityId.
        /// </summary>
        [FieldOffset(0x2570), FixedSizeArray] internal FixedSizeArray599<Pointer<GameObject>> _entityIdSorted;

        [FieldOffset(0x3828)] public int GameObjectIdSortedCount;
        [FieldOffset(0x382C)] public int EntityIdSortedCount;

        /// <summary>
        /// Binary search for an object by GameObjectId, using the GameObjectId sorted list.
        /// </summary>
        [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 48 8B D3 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8E")]
        public partial GameObject* GetObjectByGameObjectId(GameObjectId objectId);

        /// <summary>
        /// Binary search for an object by EntityId, using the EntityId sorted list.
        /// </summary>
        [MemberFunction("48 89 5C 24 ?? 44 8B 89")]
        public partial GameObject* GetObjectByEntityId(uint entityId);
    }
}
