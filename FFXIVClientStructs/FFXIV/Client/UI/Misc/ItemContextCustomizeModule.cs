using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ItemContextCustomizeModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7 E8 ?? ?? ?? ?? 48 8D 8F"
[GenerateInterop, Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct ItemContextCustomizeModule {
    public static ItemContextCustomizeModule* Instance() => Framework.Instance()->GetUiModule()->GetItemContextCustomizeModule();

    [FieldOffset(0x40), FixedSizeArray] internal FixedSizeArray128<byte> _firstTier;
    [FieldOffset(0xC0), FixedSizeArray] internal FixedSizeArray128<byte> _secondTier;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 7B 28 41 8D 76 02")]
    public partial void ResetAll();
}
