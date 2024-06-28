using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// PCT - Gauge 0
/// </summary>
[Addon("JobHudRPM0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C0)]
public unsafe partial struct AddonJobHudRPM0 {

}

/// <summary>
/// PCT - Gauge 1
/// </summary>
[Addon("JobHudRPM1")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x2F0)]
public unsafe partial struct AddonJobHudRPM1 {

}
