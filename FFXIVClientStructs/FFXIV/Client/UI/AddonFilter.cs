using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonFilter
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
//   Component::GUI::AtkManagedInterface
/// <summary>
/// A full-screen input filter. The Filter and FilterSystem addons are separate instances of this class.
/// </summary>
[Addon("Filter", "FilterSystem")]
[GenerateInterop]
[Inherits<AtkUnitBase>, Inherits<AtkManagedInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x340)]
public unsafe partial struct AddonFilter {
    /// <summary>
    /// Size of the full-screen filter quad.
    /// </summary>
    [FieldOffset(0x320)] public Vector2 ScreenSize;

    /// <summary>
    /// Depth written to all four vertices of the filter quad.
    /// </summary>
    [FieldOffset(0x328)] public float QuadDepth;

    /// <summary>
    /// IDs of addons currently using this filter. FilterSystem is managed without an addon ID.
    /// </summary>
    [FieldOffset(0x32C), FixedSizeArray] internal FixedSizeArray4<uint> _requestingAddonIds;
}
