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
    
    [FieldOffset(0xCF0)] private DynamicEventContainer* DynamicEvents;

    [FieldOffset(0xD48)] public float ContentTimeLeft;

    /// <summary>
    /// Gets the max time for the content in seconds
    /// </summary>
    /// <returns>Time in seconds</returns>
    [VirtualFunction(313)]
    public partial uint GetContentTimeMax();
}
