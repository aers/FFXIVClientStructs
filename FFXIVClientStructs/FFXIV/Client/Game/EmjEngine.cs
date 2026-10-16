namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::EmjEngine
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct EmjEngine {
    [FieldOffset(0x08)] public EmjEngineCore* Core;
}
