using FFXIVClientStructs.FFXIV.Client.UI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::PlayStaffRollTask
//   Client::Game::Event::EventSceneTaskInterface
[GenerateInterop]
[Inherits<EventSceneTaskInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public partial struct PlayStaffRollTask {
    [FieldOffset(0x10)] public uint StaffRollType; // not sure what id this is, but it also controls which BGM is used (hardcoded)
    [FieldOffset(0x14)] public CreditMode Mode;
    [FieldOffset(0x18)] public byte StaffRollFlags;
    [FieldOffset(0x1C)] public float StartWaitTime; // maybe for the music to kick in?
}
