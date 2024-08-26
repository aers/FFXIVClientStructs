namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::TitleController
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public partial struct TitleController {
    [MemberFunction("48 83 EC 38 B8 ?? ?? ?? ?? 66 3B D0")]
    public partial void SendTitleIdUpdate(ushort titleId);
}
