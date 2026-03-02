using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonSpearFishing
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("SpearFishing")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x908)]
public unsafe partial struct AddonSpearFishing {
    /// <remarks> Order is bottom -> top </remarks>
    [FieldOffset(0x294), FixedSizeArray] internal FixedSizeArray3<FishInfo> _fish;

    [FieldOffset(0x8A8)] public AtkComponentGaugeBar* GaugeBar;
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public struct FishInfo {
    [FieldOffset(0x8)] public bool Available;
    [FieldOffset(0x10)] public bool InverseDirection;
    [FieldOffset(0x11)] public bool GuaranteedLarge;
    [FieldOffset(0x12)] public SpearfishSize Size;
    [FieldOffset(0x14)] public SpearfishSpeed Speed;
}

public enum SpearfishSize : byte {
    Unknown = 0,
    Small = 1,
    Average = 2,
    Large = 3,
    None = 255,
}

public enum SpearfishSpeed : ushort {
    Unknown = 0,
    SuperSlow = 100,
    ExtremelySlow = 150,
    VerySlow = 200,
    Slow = 250,
    Average = 300,
    Fast = 350,
    VeryFast = 400,
    ExtremelyFast = 450,
    SuperFast = 500,
    HyperFast = 550,
    LynFast = 600,

    None = ushort.MaxValue,
}
