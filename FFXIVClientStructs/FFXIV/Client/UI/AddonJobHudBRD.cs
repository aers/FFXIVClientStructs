using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// BRD - Song Gauge
/// </summary>
[Addon("JobHudBRD0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x4C0)]
public unsafe partial struct AddonJobHudBRD0 {
    [FieldOffset(0x260)] public SongGaugeData DataPrevious;
    [FieldOffset(0x2A0)] public SongGaugeData DataCurrent;
    [FieldOffset(0x2E0)] public SongGauge GaugeStandard;
    [FieldOffset(0x3E0)] public SongGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public partial struct SongGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray6<byte> _prerequisites;
        [FieldOffset(0x10)] public int SoulVoiceValue;
        [FieldOffset(0x14)] public int SoulVoiceMinimumNeeded;
        [FieldOffset(0x1C)] public int SoulVoiceMax;
        [FieldOffset(0x20)] public int Song;
        [FieldOffset(0x24)] public int SongTimeLeft;
        [FieldOffset(0x28)] public int SongTimerMax;
        [FieldOffset(0x2C)] public int Repertoire;
        [FieldOffset(0x34)] public byte HasPlayedMage;
        [FieldOffset(0x35)] public byte HasPlayedArmy;
        [FieldOffset(0x36)] public byte HasPlayedWanderer;
        [FieldOffset(0x38)] public byte* SongTitle;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x100)]
    public partial struct SongGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkTextNode* SongTitle;
        [FieldOffset(0x20)] public AtkTextNode* SongTimerText;
        [FieldOffset(0x28)] public AtkResNode* StaffHighlight;
        [FieldOffset(0x30)] public AtkResNode* RepertoireNotes;
        [FieldOffset(0x38)] public AtkResNode* SongBar;
        [FieldOffset(0x40)] public AtkResNode* StaffFlash;
        [FieldOffset(0x48)] public AtkResNode* HarpPlate;
        [FieldOffset(0x50)] public AtkResNode* SoulVoiceContainer;
        [FieldOffset(0x58)] public AtkComponentTextNineGrid* SoulVoiceValueDisplay;
        [FieldOffset(0x60)] public AtkComponentGaugeBar* SoulVoiceGaugeBar;
        [FieldOffset(0x68)] public AtkResNode* SoulVoiceTickmark;
        [FieldOffset(0x70)] public int ApexArrowStatus;

        [FieldOffset(0x78), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentBase>> _armyRepertoireNote;

        [FieldOffset(0x98), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _wandererRepertoireArrow;

        [FieldOffset(0xB0)] public AtkResNode* SongBarContainer;
        [FieldOffset(0xB8)] public AtkResNode* SongBarFill;
        [FieldOffset(0xC0)] public AtkResNode* SongsPlayedContainer;
        [FieldOffset(0xC8)] public AtkResNode* SongsPlayed;

        [FieldOffset(0xD0), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _songIcon;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public partial struct SongGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkComponentTextNineGrid* SongTitle;
        [FieldOffset(0x20)] public AtkComponentTextNineGrid* SongTimerDisplay;
        [FieldOffset(0x28)] public AtkResNode* SongBarContainer;
        [FieldOffset(0x30)] public AtkResNode* Repertoire;
        [FieldOffset(0x38)] public AtkResNode* RepertoireContainer;
        [FieldOffset(0x40)] public AtkComponentGaugeBar* SongGaugeBar;
        [FieldOffset(0x48)] public AtkResNode* SoulVoiceContainer;
        [FieldOffset(0x50)] public AtkComponentTextNineGrid* SoulVoiceValueDisplay;
        [FieldOffset(0x58)] public AtkComponentGaugeBar* SoulVoiceGaugeBar;
        [FieldOffset(0x60)] public AtkResNode* SoulVoiceTickmark;

        [FieldOffset(0x68), FixedSizeArray] internal FixedSizeArray4<Pointer<AtkComponentBase>> _armyRepertoireGem;

        [FieldOffset(0x88), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _wandererRepertoireGem;

        [FieldOffset(0xA0)] public AtkResNode* SongsPlayedContainer;
        [FieldOffset(0xA8)] public AtkResNode* SongsPlayed;

        [FieldOffset(0xB0), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _songIcon;

        [FieldOffset(0xC8)] public byte RadiantFinaleStatus;
    }
}
