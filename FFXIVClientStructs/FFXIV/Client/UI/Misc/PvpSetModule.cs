using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// The struct layout is purely speculative, as additional PvP actions were removed from the game.

// Client::UI::Misc::PvpSetModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4"
[GenerateInterop, Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct PvpSetModule {
    public static PvpSetModule* Instance() => Framework.Instance()->GetUiModule()->GetPvpSetModule();

    [FieldOffset(0x40)] internal FixedSizeArray20<AdditionalPvpActions> _additionalActions;
    [FieldOffset(0x90)] internal byte Unk90;

    [StructLayout(LayoutKind.Explicit, Size = 0x4)]
    public struct AdditionalPvpActions {
        [FieldOffset(0)] public ushort ActionId1;
        [FieldOffset(2)] public ushort ActionId2;
    }
}
