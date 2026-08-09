namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::ActionTimelineCallbackInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ActionTimelineCallbackInterface {
    [VirtualFunction(0)]
    public partial ActionTimelineCallbackInterface* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void HandleCallback(Character.Character* character, ushort actionTimelineId, ulong callbackParam);
}

// Client::Game::Event::ActionTimelineCallback<T>
//   Client::Game::Event::ActionTimelineCallbackInterface
[GenerateInterop]
[Inherits<ActionTimelineCallbackInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ActionTimelineCallback {
    [FieldOffset(0x08)] public void* Handler;
}
