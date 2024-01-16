using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::VVDActionModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "40 53 48 83 EC 20 4C 8D 05 ?? ?? ?? ?? 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 03 48 8B C3"
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct VVDActionModule {
    public static VVDActionModule* Instance() => Framework.Instance()->GetUiModule()->GetVVDActionModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    [FieldOffset(0x40)] public byte Action1;
    [FieldOffset(0x41)] public byte Action2;

    [MemberFunction("48 83 EC 28 88 51 40")]
    public partial bool SaveActions(byte action1, byte action2);
}
