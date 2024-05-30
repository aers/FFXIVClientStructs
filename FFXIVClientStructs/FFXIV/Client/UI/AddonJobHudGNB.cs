using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// GNB - Powder Gauge
/// </summary>
[Addon("JobHudGNB0")]
[GenerateInterop, Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x358)]
public unsafe partial struct AddonJobHudGNB0 {
    [FieldOffset(0x260)] public PowderGaugeData DataPrevious;
    [FieldOffset(0x270)] public PowderGaugeData DataCurrent;
    [FieldOffset(0x280)] public PowderGauge GaugeStandard;
    [FieldOffset(0x2F0)] public PowderGaugeSimple GaugeSimple;

    [GenerateInterop, Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct PowderGaugeData {
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray4<byte> _prerequisites;
        [FieldOffset(0x0C)] public int Ammo;
    }

    [GenerateInterop, Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct PowderGauge {
        [FieldOffset(0x10)] public AtkResNode* Container;

        [FieldOffset(0x18), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _ammo;

        [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkResNode>> _ammoNode;

        [FieldOffset(0x58)] public AtkResNode* RecoilNode;
        [FieldOffset(0x60)] public AtkResNode* AmmoPlate;
        [FieldOffset(0x68)] public AtkResNode* StanceIcon;
    }

    [GenerateInterop, Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct PowderGaugeSimple {
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkComponentBase>> _ammoGem;

        [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray3<Pointer<AtkResNode>> _ammoGemGlow;

        [FieldOffset(0x48)] public AtkComponentBase* StanceIcon;
        [FieldOffset(0x58)] public AtkResNode* TwoGems;
    }
}
