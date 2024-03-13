using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::ContentDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
// ctor "E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? B9 ?? ?? ?? ?? 48 89 03 33 ED"
[StructLayout(LayoutKind.Explicit, Size = 0xC48)]
public partial struct ContentDirector {
    [FieldOffset(0x00)] public Director Director;

    [FieldOffset(0xC08)] public float ContentTimeLeft;

    /// <summary>
    /// Gets the max time for the content in seconds
    /// </summary>
    /// <returns>Time in seconds</returns>
    [VirtualFunction(313)]
    public partial uint GetContentTimeMax();
}
