using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// Base struct for all job gauge addons.
/// </summary>
[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public unsafe partial struct AddonJobHud {
    [FieldOffset(0x000)] public AtkUnitBase AtkUnitBase;

    [FieldOffset(0x220)] public byte Unk220;
    [FieldOffset(0x221)] public bool UseSimpleGauge;
    [FieldOffset(0x222)] public byte Unk222;

    // these 4 pointers get set in vf72, and point to varying offsets for each type of gauge
    [FieldOffset(0x228)] public AddonJobHudGauge* GaugeStandard;
    [FieldOffset(0x230)] public AddonJobHudGauge* GaugeSimple;
    [FieldOffset(0x238)] public AddonJobHudGaugeData* DataPrevious;
    [FieldOffset(0x240)] public AddonJobHudGaugeData* DataCurrent; // Current is always used to apply updates, and then copied onto Previous. The two are compared to detect changes.

    [FieldOffset(0x248)] public AtkResNode* RootNode;

    [FieldOffset(0x250)] public int TimelineLabelStandard; // always set to 19 by vf75
    [FieldOffset(0x254)] public int TimelineLabelSimple; // always set to 101 by vf75

    /// <summary>
    /// Base struct containing the data that each particular gauge relies on.<br/>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public unsafe partial struct AddonJobHudGaugeData {
        [FieldOffset(0x0)] public void* vtbl;
    }

    /// <summary>
    /// Base struct for the gauges themselves.<br/>
    /// The majority of the fields in any given gauge will be pointers to Nodes and Components within its addon, but data values are usually sprinkled in too.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe partial struct AddonJobHudGauge {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x8)] public AddonJobHud* JobHud;
    }
}
