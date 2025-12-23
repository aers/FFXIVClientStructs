using static FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureHotbarModule;
using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::QuickPanelModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x270)]
public unsafe partial struct QuickPanelModule {
    public static QuickPanelModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetQuickPanelModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray25<HotbarSlotType> _panel0CommandTypes;
    [FieldOffset(0x64), FixedSizeArray] internal FixedSizeArray25<uint> _panel0CommandIds;
    [FieldOffset(0xC8), FixedSizeArray] internal FixedSizeArray25<HotbarSlotType> _panel1CommandTypes;
    [FieldOffset(0xE4), FixedSizeArray] internal FixedSizeArray25<uint> _panel1CommandIds;
    [FieldOffset(0x148), FixedSizeArray] internal FixedSizeArray25<HotbarSlotType> _panel2CommandTypes;
    [FieldOffset(0x164), FixedSizeArray] internal FixedSizeArray25<uint> _panel2CommandIds;
    [FieldOffset(0x1C8), FixedSizeArray] internal FixedSizeArray25<HotbarSlotType> _panel3CommandTypes;
    [FieldOffset(0x1E4), FixedSizeArray] internal FixedSizeArray25<uint> _panel3CommandIds;

    [FieldOffset(0x268)] public QuickPanelSetting Settings;
    [FieldOffset(0x26C)] public QuickPanelFlag Flags;
    [FieldOffset(0x26E)] public byte Tint;
    /// <remarks> -1 = Last Panel used </remarks>
    [FieldOffset(0x26F)] public sbyte PanelOpenIndex;

    [Flags]
    public enum QuickPanelSetting : byte {
        None = 0,
        ClosePanelUponExecutingActions = 1 << 0,
        OpenPanelAtMouseCursorPosition = 1 << 1,
        DisableDraggingWithinCommandPanel = 1 << 2,
    }

    [Flags]
    public enum QuickPanelFlag : byte {
        None = 0,
        FirstTimeHelpSeen = 1 << 0,
    }
}
