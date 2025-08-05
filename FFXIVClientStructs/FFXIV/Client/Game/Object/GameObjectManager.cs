namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::GameObjectManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x4D1C)]
public unsafe partial struct GameObjectManager {
    [StaticAddress("48 8D 35 ?? ?? ?? ?? 81 FA", 3)]
    public static partial GameObjectManager* Instance();

    [FieldOffset(0x00)] public uint NextUpdateIndex; // rate limiting for updates per frame
    [FieldOffset(0x04)] public byte Active;
    [FieldOffset(0x20)] public ObjectArrays Objects;
    // new in 7.3, used for draw distance
    // [FieldOffset(0x4CF0)] internal float Unk4CF0; // default "819"
    // [FieldOffset(0x4CF4)] internal float Unk4CF4; // default "0.08"
    // [FieldOffset(0x4CF8)] internal float Unk4CF8; // default "0.25"
    // [FieldOffset(0x4D00)] internal uint Unk4D00; // default "60"
    // [FieldOffset(0x4D04)] internal uint Unk4D04; // default "0"
    // [FieldOffset(0x4D08)] internal float Unk4D08; // default "30"
    // [FieldOffset(0x4D0C)] internal float Unk4D0C; // default "1"
    // [FieldOffset(0x4D10)] internal float Unk4D10; // default "1.1"
    // [FieldOffset(0x4D14)] internal float Unk4D14; // default "0.9"
    // [FieldOffset(0x4D18)] internal float Unk4D18; // default "0.8"

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
