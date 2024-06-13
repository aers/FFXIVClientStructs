using FFXIVClientStructs.FFXIV.Client.Game.Event;

namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::ContentDirector
//   Client::Game::Event::Director
//     Client::Game::Event::LuaEventHandler
//       Client::Game::Event::EventHandler
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B F9 E8 ?? ?? ?? ?? 33 ED 48 8D 05 ?? ?? ?? ?? 48 89 07 48 8D 8F"
[GenerateInterop(isInherited: true)]
[Inherits<Director>]
[StructLayout(LayoutKind.Explicit, Size = 0xC48)]
public partial struct ContentDirector {
    [FieldOffset(0x536)] public byte ContentTypeRowId;

    [FieldOffset(0xC08)] public float ContentTimeLeft;

    /// <summary>
    /// Gets the max time for the content in seconds
    /// </summary>
    /// <returns>Time in seconds</returns>
    [VirtualFunction(313)]
    public partial uint GetContentTimeMax();
}
