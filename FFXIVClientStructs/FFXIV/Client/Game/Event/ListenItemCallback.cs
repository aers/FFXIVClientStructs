namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::ListenItemCallbackInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ListenItemCallbackInterface {
    [VirtualFunction(0)]
    public partial ListenItemCallbackInterface* Dtor(byte freeFlags);

    // [VirtualFunction(1)]
    // public partial void HandleCallback(???);
}

// Client::Game::Event::ListenItemCallback<T>
//   Client::Game::Event::ListenItemCallbackInterface
[GenerateInterop]
[Inherits<ListenItemCallbackInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct ListenItemCallback {
    [FieldOffset(0x08)] public void* Handler;
}
