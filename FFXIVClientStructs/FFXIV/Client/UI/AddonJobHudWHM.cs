using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// WHM - Healing Gauge
/// </summary>
[Addon("JobHudWHM0")]
[GenerateInterop, Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
public unsafe partial struct AddonJobHudWHM0 {
    [FieldOffset(0x260)] public HealingGaugeData DataPrevious;
    [FieldOffset(0x280)] public HealingGaugeData DataCurrent;
    [FieldOffset(0x2A0)] public HealingGauge GaugeStandard;
    [FieldOffset(0x310), Obsolete("Wrongly defined supposed to be a pointer based on ctor reference")] public HealingGaugeSimple GaugeSimple;

    [GenerateInterop, Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct HealingGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<byte> _prerequisites;
        [FieldOffset(0x0C)] public int LilyCount;
        [FieldOffset(0x10)] public int LiliesSpent;
        [FieldOffset(0x14)] public int LilyTimer;
        [FieldOffset(0x18)] public int LilyTimerMax;
    }

    [GenerateInterop, Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct HealingGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkResNode* LilyContainer;
        [FieldOffset(0x20)] public AtkResNode* BloodLily;
        [FieldOffset(0x28)] public int LiliesSpent;

        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _lily;

        [FieldOffset(0x48)] public int LilyCount;
        [FieldOffset(0x50)] public AtkResNode* Branch;
        [FieldOffset(0x58)] public AtkComponentBase* Shine;
        [FieldOffset(0x60)] public AtkResNode* BranchContainer;
    }

    [GenerateInterop, Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct HealingGaugeSimple {
        [FieldOffset(0x10)] public AtkResNode* Container;
        [FieldOffset(0x18)] public AtkComponentBase* LilyGem1;
        [FieldOffset(0x20)] public AtkComponentBase* LilyGem2;
        [FieldOffset(0x28)] public AtkComponentBase* LilyGem3;
        [FieldOffset(0x30)] public AtkResNode* LilyGemGlow1;
        [FieldOffset(0x38)] public AtkResNode* LilyGemGlow2;
        [FieldOffset(0x40)] public AtkResNode* LilyGemGlow3;
        [FieldOffset(0x50)] public AtkResNode* BloodLilyContainer;
        [FieldOffset(0x58)] public AtkComponentBase* BloodGem1;
        [FieldOffset(0x60)] public AtkComponentBase* BloodGem2;
        [FieldOffset(0x68)] public AtkComponentBase* BloodGem3;
        [FieldOffset(0x70)] public AtkResNode* BloodGemGlow1;
        [FieldOffset(0x78)] public AtkResNode* BloodGemGlow2;
        [FieldOffset(0x80)] public AtkResNode* BloodGemGlow3;
        [FieldOffset(0x90), Obsolete("Wrongly defined most likely supposed to be a pointer")] public AtkComponentGaugeBar LilyTimerGaugeBar;
    }
}
