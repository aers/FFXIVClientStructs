using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::PerformanceModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct PerformanceModule {
    public static PerformanceModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetPerformanceModule();
    }

    [FieldOffset(0x48)] private ushort Unk48; // Version presumably. If 0, it migrates AssignAllNotesToKeyboard from FlagStatusModule or something like that.
    [FieldOffset(0x4A)] public ushort BPMSetting;
    [FieldOffset(0x4C)] public PerformanceSetting1Flag Settings1;
    [FieldOffset(0x4D)] public PerformanceSetting2Flag Settings2;

    public ushort BeatsPerMinute {
        get => (ushort)(BPMSetting & 0x1FF);
        set { BPMSetting = (ushort)((BPMSetting & ~0x1FF) | (value & 0x1FF)); }
    }

    public ushort BeatsPerMeasure {
        get => (ushort)((BPMSetting & 0x1E00) >> 9);
        set { BPMSetting = (ushort)((BPMSetting & ~0x1E00) | ((value << 9) & 0x1E00)); }
    }

    [Flags]
    public enum PerformanceSetting1Flag : byte {
        AssignAllNotesToKeyboard = 1 << 0,
        MuteOtherPerformers = 1 << 1,
        PlaybackTypeAllMembers = 1 << 2,
        DisplayControlGuide = 1 << 3,
        KeyboardMode = 1 << 4,
        ControllerMode = 1 << 5,
        AccentEachMeasure = 1 << 6,
        EnableCountIn = 1 << 7,
    }

    [Flags]
    public enum PerformanceSetting2Flag : byte {
        SoundEffectsOnlyDuringCountIn = 1 << 0,
        DisplayMetronome = 1 << 1,
        Unk4 = 1 << 2,
        Unk8 = 1 << 3,
        Unk16 = 1 << 4,
        Unk32 = 1 << 5,
        Unk64 = 1 << 6,
        Unk128 = 1 << 7,
    }
}
