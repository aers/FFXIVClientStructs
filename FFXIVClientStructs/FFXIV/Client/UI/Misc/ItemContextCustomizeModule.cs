using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ItemContextCustomizeModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7 E8 ?? ?? ?? ?? 48 8D 8F"
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct ItemContextCustomizeModule {
    public static ItemContextCustomizeModule* Instance() => Framework.Instance()->GetUiModule()->GetItemContextCustomizeModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    [FieldOffset(0x40)] public fixed byte FirstTier[128];
    [FieldOffset(0xC0)] public fixed byte SecondTier[128];

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 7B 28 41 8D 76 02")]
    public partial void ResetAll();
}
