using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// GNB - Powder Gauge
/// </summary>
[Addon("JobHudGNB0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C8)]
public unsafe partial struct AddonJobHudGNB0 {
    [FieldOffset(0x278)] public PowderGaugeData DataPrevious;
    [FieldOffset(0x290)] public PowderGaugeData DataCurrent;
    [FieldOffset(0x2A8)] public PowderGauge GaugeStandard;
    [FieldOffset(0x348)] public PowderGaugeSimple GaugeSimple;

    [GenerateInterop]
    [Inherits<AddonJobHudGaugeData>]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct PowderGaugeData {
        [FieldOffset(0x08)] public bool Enabled;
        [FieldOffset(0x09)] public bool CartridgesEnabled;
        [FieldOffset(0x0A)] public bool TankStance;
        [FieldOffset(0x0B)] public bool Cartridge3Enabled;
        [FieldOffset(0x0C)] public bool Bloodfest;
        [FieldOffset(0x10)] public int Ammo;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct PowderGauge {
        [FieldOffset(0x10)] public AtkResNode* StanceIconFrame;
        [FieldOffset(0x18)] public AtkResNode* AmmoContainer;
        [FieldOffset(0x20)] public AtkResNode* RecoilContainer;
        [FieldOffset(0x28)] public AtkResNode* Container;
        [FieldOffset(0x30)] public AtkResNode* StanceIcon;
        [FieldOffset(0x38)] public bool Cartridge3Enabled;
        [FieldOffset(0x40)] public AtkResNode* RecoilNode;
        [FieldOffset(0x48)] public AtkResNode* AmmoPlate;
        [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray3<PowderCartridge> _powderCartridges;
        [FieldOffset(0x98)] public bool Bloodfest;
    }

    [GenerateInterop]
    [Inherits<AddonJobHudGauge>]
    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public partial struct PowderGaugeSimple {
        [FieldOffset(0x10), FixedSizeArray] internal FixedSizeArray3<PowderCartridge> _powderCartridges;
        [FieldOffset(0x58)] public AtkComponentBase* StanceIcon;
        [FieldOffset(0x68)] public AtkResNode* TwoGems;
        [FieldOffset(0x78)] public AtkResNode* Container;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct PowderCartridge {
        [FieldOffset(0x00)] public int State;
        [FieldOffset(0x08)] public AtkComponentNode* Component;
        [FieldOffset(0x10)] public AtkResNode* Node;
    }
}
