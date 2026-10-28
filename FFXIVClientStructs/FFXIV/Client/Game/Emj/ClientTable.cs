namespace FFXIVClientStructs.FFXIV.Client.Game.Emj;

// Client::Game::Emj::ClientTable
//   Client::Game::Emj::Table
[GenerateInterop]
[Inherits<Table>]
[StructLayout(LayoutKind.Explicit, Size = 0x1420)]
public unsafe partial struct ClientTable {
    [FieldOffset(0x1418)] public uint LocalSeat;
}
