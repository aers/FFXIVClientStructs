
namespace FFXIVClientStructs.FFXIV.Client.UI; 

[StructLayout(LayoutKind.Explicit, Size = 0x710)]
[Addon("_ActionCross")]
public struct AddonActionCross {
    [FieldOffset(0x000)] public AddonActionBarBase ActionBarBase;
    [FieldOffset(0x6E8)] public int ExpandedHoldControlsLTRT;
    [FieldOffset(0x6EC)] public int ExpandedHoldControlsRTLT;

    public int ExpandedHoldControls => ExpandedHoldControlsLTRT > 0 ? ExpandedHoldControlsLTRT : ExpandedHoldControlsRTLT;
}
