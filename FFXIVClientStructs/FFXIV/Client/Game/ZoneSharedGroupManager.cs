using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ZoneSharedGroupManager
//   Common::Component::Excel::ExcelSheetWaiter
[GenerateInterop]
[Inherits<ExcelSheetWaiter>]
[StructLayout(LayoutKind.Explicit, Size = 0x738)]
public partial struct ZoneSharedGroupManager {
    [MemberFunction("33 C0 4C 8B C9 38 41 32")]
    public partial void Refresh();
}
