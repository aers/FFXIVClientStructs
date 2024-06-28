using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.AddonJobHud;

namespace FFXIVClientStructs.FFXIV.Client.UI;

/// <summary>
/// VPR - Gauge 0
/// </summary>
[Addon("JobHudRDB0")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x2E0)]
public unsafe partial struct AddonJobHudRDB0 {

}

/// <summary>
/// VPR - Gauge 1
/// </summary>
[Addon("JobHudRDB1")]
[GenerateInterop]
[Inherits<AddonJobHud>]
[StructLayout(LayoutKind.Explicit, Size = 0x310)]
public unsafe partial struct AddonJobHudRDB1 {

}
