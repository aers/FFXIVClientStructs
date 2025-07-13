namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::GameObjectManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4CE8)]
public unsafe partial struct GameObjectManager {
    [StaticAddress("48 8D 35 ?? ?? ?? ?? 81 FA", 3)]
    public static partial GameObjectManager* Instance();

    [FieldOffset(0x00)] public uint NextUpdateIndex; // rate limiting for updates per frame
    [FieldOffset(0x04)] public byte Active;
    [FieldOffset(0x18)] public ObjectArrays Objects;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x4CD0)]
    public unsafe partial struct ObjectArrays {
        // sparse array containing all objects; some slots could be null
        // different ranges have different meaning:
        // 000-199: 200 objects from CharacterManager, 100 BattleCharas at index 2*i and their dependendent 100 objects (mounts, minions, etc) at index 2*i+1 (networked)
        // 200-448: 249 objects from ClientObjectManager (non-networked)
        // 449-488:  40 objects from EventObjectManager? (contains AreaObject, EventObject, GatheringPointObject, HousingObject, HousingCombinedObject, Treasure)
        // 489-628: 140 objects from StandObjectManager (Lively Actors (Named/Unnamed ENPCs))
        // 629-728: 100 objects from ReactionEventObjectManager (Gatherables/Farm in Island Sanctuary)
        // 729-818:  90 objects from MJIManager and WKSManager (more Lively Actors)

        /// <summary>
        /// Pointers to GameObjects, sorted by ObjectIndex. Contains null pointers for inactive indexes.
        /// </summary>
        [FieldOffset(0x0000), FixedSizeArray] internal FixedSizeArray819<Pointer<GameObject>> _indexSorted;

        /// <summary>
        /// Pointers to active GameObjects, sorted by GameObject.GetGameObjectId().
        /// </summary>
        [FieldOffset(0x1998), FixedSizeArray] internal FixedSizeArray819<Pointer<GameObject>> _gameObjectIdSorted;

        /// <summary>
        /// Pointers to active GameObjects with a valid GameObject.EntityId (!= E0000000), sorted by EntityId.
        /// </summary>
        [FieldOffset(0x3330), FixedSizeArray] internal FixedSizeArray819<Pointer<GameObject>> _entityIdSorted;

        [FieldOffset(0x4CC8)] public int GameObjectIdSortedCount;
        [FieldOffset(0x4CCC)] public int EntityIdSortedCount;

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
