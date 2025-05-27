using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

[Addon("AirShipExploration")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1208)]
public partial struct AddonAirShipExploration {
    [FieldOffset(0x9E0), FixedSizeArray] internal FixedSizeArray64<Destination> _destinations;
    [FieldOffset(0x11F8)] public ushort DestinationCount;

    /// <summary>
    /// The index of the destination that is currently being displayed on the right side of the addon.
    /// </summary>
    [FieldOffset(0x11FC)] public ushort DisplayedDestinationIndex;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct Destination {
        [FieldOffset(0x00)] public CStringPointer DestinationName;
        [FieldOffset(0x08)] public CStringPointer LocationName;
        [FieldOffset(0x10)] public ushort X;
        [FieldOffset(0x12)] public ushort Y;
        [FieldOffset(0x14)] public ushort RankReq;
        [FieldOffset(0x18)] public uint ExpReward;
        [FieldOffset(0x1E)] public byte Stars;
    }
}
