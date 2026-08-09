namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::FormatStringCallbackInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct FormatStringCallbackInterface {
    [VirtualFunction(0)]
    public partial FormatStringCallbackInterface* Dtor(byte freeFlags);

    [VirtualFunction(1)]
    public partial void HandleCallback(bool success, Utf8String* str, ulong callbackParam);
}

// Client::Game::Event::FormatStringCallback<T>
//   Client::Game::Event::FormatStringCallbackInterface
[GenerateInterop]
[Inherits<FormatStringCallbackInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct FormatStringCallback {
    [FieldOffset(0x08)] public void* Handler;
}
