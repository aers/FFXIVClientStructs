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
    [FieldOffset(0x29C), FixedSizeArray] internal FixedSizeArray3<FishInfo> _fish;

    [FieldOffset(0x8A8)] public AtkComponentGaugeBar* GaugeBar;

    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct FishInfo {
        [FieldOffset(0x00)] public bool Available;
        [FieldOffset(0x08)] public bool InverseDirection;
        [FieldOffset(0x09)] public bool GuaranteedLarge;
        [FieldOffset(0x0A)] public SpearfishSize Size;
        [FieldOffset(0x0C)] public SpearfishSpeed Speed;
    }
}

public enum SpearfishSize : sbyte {
    None = -1,
    Small = 1,
    Average = 2,
    Large = 3,
}

public enum SpearfishSpeed : short {
    None = -1,
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
}
