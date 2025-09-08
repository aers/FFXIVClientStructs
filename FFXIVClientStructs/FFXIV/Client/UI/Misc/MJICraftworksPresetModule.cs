using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::MJICraftworksPresetModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x138)]
public unsafe partial struct MJICraftworksPresetModule {
    public static MJICraftworksPresetModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetMJICraftworksPresetModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray10<MJICraftworksPreset> _presets;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 6 * 4)]
    public partial struct MJICraftworksPreset {
        /// <remarks> MJICraftworksObject RowIds </remarks>
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray6<uint> _objects;
    }
}
