namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::Treasure
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x210)]
public unsafe partial struct Treasure {
    [FieldOffset(0x1FC)] public TreasureFlags Flags;

    [Flags]
    public enum TreasureFlags : byte {
        None = 0,
        Opened = 1,
        FadedOut = 2
    }
}
