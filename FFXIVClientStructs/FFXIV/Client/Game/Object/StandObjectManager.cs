namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::StandObjectManager
// Lively Actors (Named/Unnamed ENPCs)
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x840)]
public unsafe partial struct StandObjectManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74 11", 3)]
    public static partial StandObjectManager* Instance();

    [FieldOffset(0x00)] public Character.Character* CharacterMemory;
    [FieldOffset(0x08)] public EventObject* EventObjectMemory;
    [FieldOffset(0x10)] public uint CharacterSize;
    [FieldOffset(0x14)] public uint EventObjectSize;
    [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray120<CharacterEntry> _characters;
    [FieldOffset(0x798), FixedSizeArray] internal FixedSizeArray20<Pointer<EventObject>> _eventObjects;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct CharacterEntry {
        [FieldOffset(0x00)] public Character.Character* Character;
        [FieldOffset(0x08)] public ObjectKind ObjectKind; // ushort??

        /// <remarks> Index in <see cref="Characters"/>. </remarks>
        [FieldOffset(0x0C)] public ushort Index;
        /// <remarks> Index in <see cref="CharacterMemory"/>. </remarks>
        [FieldOffset(0x0E)] public ushort MemoryIndex;
    }
}
