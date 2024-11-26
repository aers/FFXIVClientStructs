using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::ContentDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
[GenerateInterop(isInherited: true)]
[Inherits<Director>]
[StructLayout(LayoutKind.Explicit, Size = 0xD80)]
public partial struct ContentDirector {
    [FieldOffset(0x53A)] public byte ContentTypeRowId;

    [FieldOffset(0x578)] public DutyActionManager DutyActionManager;

    [FieldOffset(0xD40)] public float ContentTimeLeft;

    /// <summary>
    /// Gets the max time for the content in seconds
    /// </summary>
    /// <returns>Time in seconds</returns>
    [VirtualFunction(313)]
    public partial uint GetContentTimeMax();
}
