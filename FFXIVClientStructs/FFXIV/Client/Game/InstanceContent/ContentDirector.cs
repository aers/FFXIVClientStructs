using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::ContentDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<Director>]
[StructLayout(LayoutKind.Explicit, Size = 0xD30)]
public unsafe partial struct ContentDirector {
    [FieldOffset(0x4E6)] public byte ContentTypeRowId;

    [FieldOffset(0x528)] public DutyActionManager DutyActionManager;

    [FieldOffset(0xC90)] public MapEffectList* MapEffects;
    [FieldOffset(0xC98)] private DynamicEventContainer* DynamicEvents;

    /// <remarks> This might also be a countdown until the content starts (e.g. Frontlines), then the actual time left of the content. </remarks>
    [FieldOffset(0xCF0)] public float ContentTimeLeft;

    [VirtualFunction(302)]
    public partial uint GetCurrentLevel();
    
    [VirtualFunction(303)]
    public partial uint GetMaxLevel();
    
    /// <summary>
    /// Gets the max time for the content in seconds
    /// </summary>
    /// <returns>Time in seconds</returns>
    [VirtualFunction(328)]
    public partial uint GetContentTimeMax();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x608)]
    public partial struct MapEffectList {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray128<MapEffectItem> _items;
        [FieldOffset(0x600)] public ushort ContentDirectorManagedSGRowId;
        [FieldOffset(0x602)] public ushort ItemCount;
        [FieldOffset(0x604)] public byte Dirty;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct MapEffectItem {
        [FieldOffset(0x00)] public uint LayoutId; // ContentDirectorManagedSG.Unknown0
        [FieldOffset(0x05)] public byte Unknown1; // ContentDirectorManagedSG.Unknown1
        [FieldOffset(0x08)] public ushort State;
        [FieldOffset(0x0A)] public byte Flags;
    }
}
