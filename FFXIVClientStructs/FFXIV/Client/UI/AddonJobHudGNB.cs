using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// GNB - Powder Gauge
/// </summary>
[Addon("JobHudGNB0")]
[StructLayout(LayoutKind.Explicit, Size = 0x358)]
public unsafe partial struct AddonJobHudGNB0 {
    [FieldOffset(0x000)] public AddonJobHud JobHud;

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct PowderGaugeData {
        [FieldOffset(0x00)] public AddonJobHudGaugeData GaugeData;
        [FieldOffset(0x08)] public fixed byte Prerequisites[4];
        [FieldOffset(0x0C)] public int Ammo;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public partial struct PowderGauge {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;
        [FieldOffset(0x10)] public AtkResNode* Container;

        [FixedSizeArray<Pointer<AtkComponentBase>>(3)]
        [FieldOffset(0x18)] public fixed byte Ammo[3 * 0x08];

        [FixedSizeArray<Pointer<AtkResNode>>(3)]
        [FieldOffset(0x30)] public fixed byte AmmoNode[3 * 0x08];

        [FieldOffset(0x58)] public AtkResNode* RecoilNode;
        [FieldOffset(0x60)] public AtkResNode* AmmoPlate;
        [FieldOffset(0x68)] public AtkResNode* StanceIcon;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public partial struct PowderGaugeSimple {
        [FieldOffset(0x00)] public AddonJobHudGauge Gauge;

        [FixedSizeArray<Pointer<AtkComponentBase>>(3)]
        [FieldOffset(0x10)] public fixed byte AmmoGem[3 * 0x08];

        [FixedSizeArray<Pointer<AtkResNode>>(3)]
        [FieldOffset(0x28)] public fixed byte AmmoGemGlow[3 * 0x08];

        [FieldOffset(0x48)] public AtkComponentBase* StanceIcon;
        [FieldOffset(0x58)] public AtkResNode* TwoGems;
    }

    [FieldOffset(0x260)] public PowderGaugeData DataPrevious;
    [FieldOffset(0x270)] public PowderGaugeData DataCurrent;
    [FieldOffset(0x280)] public PowderGauge GaugeStandard;
    [FieldOffset(0x2F0)] public PowderGaugeSimple GaugeSimple;
}
