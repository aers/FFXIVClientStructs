using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::ContentDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<Director>]
[StructLayout(LayoutKind.Explicit, Size = 0xD88)]
public unsafe partial struct ContentDirector {
    [FieldOffset(0x542)] public byte ContentTypeRowId;

    [FieldOffset(0x580)] public DutyActionManager DutyActionManager;

    [FieldOffset(0xCE8)] public MapEffectList* MapEffects;

    [FieldOffset(0xCF0)] private DynamicEventContainer* DynamicEvents;

    [FieldOffset(0xD48)] public float ContentTimeLeft;

    /// <summary>
    /// Gets the max time for the content in seconds
    /// </summary>
    /// <returns>Time in seconds</returns>
    [VirtualFunction(313)]
    public partial uint GetContentTimeMax();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x608)]
    public partial struct MapEffectList {
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray128<MapEffectItem> _items;
        [FieldOffset(0x602)] public ushort ItemCount;
        [FieldOffset(0x604)] public byte Dirty;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xC)]
    public struct MapEffectItem {
        [FieldOffset(0x00)] public uint LayoutId;
        [FieldOffset(0x08)] public ushort State;
        [FieldOffset(0x0A)] public byte Flags;
    }
}
